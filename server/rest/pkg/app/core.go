package app

import (
	"github.com/gin-gonic/gin"
	"github.com/runshop/server/rest/pkg/data"
	"github.com/runshop/server/rest/pkg/services"
)

type App struct {
	engine      *gin.Engine
	userService services.IUserService
}

func (a *App) UserService() services.IUserService {
	return a.userService
}

func (a *App) Server() *gin.Engine {
	return a.engine
}

func NewApp(engine *gin.Engine) IApp {
	dbConnection := data.NewDbConnection()
	return &App{
		engine:      engine,
		userService: services.NewUserService(data.NewUserRepo(dbConnection)),
	}
}
