package handlers

import (
	"github.com/labstack/echo/v4"
	"github.com/runshop/server/rest/pkg/app"
	"net/http"
)

type UserHandler struct {
	BaseHandler
}

func (uh *UserHandler) RegisterHandler() {
	uh.routGroup.GET("/", uh.getAllUsers)
	uh.routGroup.GET("/:id", uh.getOneUser)
}

func (uh *UserHandler) getAllUsers(ctx echo.Context) error {
	allUsers, err := uh.app.UserService().GetAll()
	if err != nil {
		return echo.NewHTTPError(http.StatusInternalServerError, NewResponse("could not get users from datasource", nil))
	}
	return ctx.JSON(http.StatusOK, NewResponse("", allUsers))
}

func (uh *UserHandler) getOneUser(ctx echo.Context) error {
	return ctx.String(200, "")
}

func (uh *UserHandler) NewHandler(engine *echo.Echo, appInstance app.IApp) IHandler {
	uh.routGroup = engine.Group("home")
	uh.app = appInstance
	return uh
}
