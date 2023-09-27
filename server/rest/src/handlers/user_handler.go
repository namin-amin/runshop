package handlers

import (
	"github.com/gin-gonic/gin"
	"github.com/runshop/server/rest/pkg/app"
	"strconv"
)

type UserHandler struct {
	BaseHandler
}

func (uh *UserHandler) RegisterHandler() {
	uh.routGroup.GET("/", uh.getAllUsers)
	uh.routGroup.GET("/:id", uh.getOneUser)
}

func (uh *UserHandler) getAllUsers(ctx *gin.Context) {
	allUsers, err := uh.app.UserService().GetAll()
	if err != nil {
		uh.InternalServerError(ctx, "could not get data from the datasource", nil)
		return
	}
	uh.Ok(ctx, "", allUsers)

}

func (uh *UserHandler) getOneUser(ctx *gin.Context) {
	id := ctx.Param("id")
	parsedId, err := strconv.ParseInt(id, 10, 64)
	if err != nil {
		uh.BadRequest(ctx, "could not convert given value to required id", nil)
		return
	}
	user, err := uh.app.UserService().GetOne(parsedId)
	if err != nil {
		uh.InternalServerError(ctx, "could not retrieve specified user from the database", nil)
		return
	}
	uh.Ok(ctx, "", user)
}

func (uh *UserHandler) NewHandler(engine *gin.Engine, appInstance app.IApp) IHandler {
	uh.routGroup = engine.Group("home")
	uh.app = appInstance
	return uh
}
