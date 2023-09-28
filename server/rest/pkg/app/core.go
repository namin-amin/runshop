package app

import (
	"github.com/labstack/echo/v4"
	"github.com/runshop/server/rest/pkg/data"
	"github.com/runshop/server/rest/pkg/services"
)

type App struct {
	engine      *echo.Echo
	userService services.IUserService
}

func (a *App) UserService() services.IUserService {
	return a.userService
}

func (a *App) Server() *echo.Echo {
	return a.engine
}

func NewApp(engine *echo.Echo) IApp {
	dbConnection := data.NewDbConnection()
	return &App{
		engine:      engine,
		userService: services.NewUserService(data.NewUserRepo(dbConnection)),
	}
}
