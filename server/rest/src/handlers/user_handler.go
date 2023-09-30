package handlers

import (
	echojwt "github.com/labstack/echo-jwt/v4"
	"github.com/labstack/echo/v4"
	"github.com/runshop/server/rest/pkg/app"
	"github.com/runshop/server/rest/pkg/models"
	"github.com/runshop/server/rest/src/handlers/middlewares"
	"github.com/runshop/server/rest/src/handlers/validations"
	"net/http"
	"strconv"
)

type UserHandler struct {
	BaseHandler
}

func (uh *UserHandler) RegisterHandler() {
	uh.routGroup.GET("/", uh.getAllUsers)
	uh.routGroup.GET("/:id", uh.getOneUser,
		echojwt.WithConfig(*middlewares.CustomJwtConfig()))
	uh.routGroup.POST("/", uh.newUser)
}

func (uh *UserHandler) getAllUsers(ctx echo.Context) error {
	allUsers, err := uh.app.UserService().GetAll()
	if err != nil {
		return echo.NewHTTPError(http.StatusInternalServerError, NewResponse("could not get users from datasource", nil))
	}
	return ctx.JSON(http.StatusOK, NewResponse("", allUsers))
}

func (uh *UserHandler) getOneUser(ctx echo.Context) error {
	id := ctx.Param("id")
	intId, err := strconv.ParseInt(id, 10, 64)
	if err != nil {
		return echo.NewHTTPError(http.StatusBadRequest, NewResponse("supplied parameter is not valid", nil))
	}
	return ctx.JSON(200, echo.Map{
		id: intId,
	})
}

func (uh *UserHandler) newUser(ctx echo.Context) error {
	user := new(models.User)

	err := ctx.Bind(&user)
	if err != nil {
		return echo.NewHTTPError(http.StatusBadRequest, NewResponse("could not bind the data or data was wrong", err.Error()))
	}

	err = validations.IsUserCreationDtoValid(*user)

	if err != nil {
		return echo.NewHTTPError(http.StatusBadRequest, NewResponse("validation error", err.Error()))
	}

	return ctx.JSON(http.StatusOK, user)
}

func (uh *UserHandler) NewHandler(engine *echo.Echo, appInstance app.IApp) IHandler {
	uh.routGroup = engine.Group("home")
	uh.app = appInstance
	return uh
}
