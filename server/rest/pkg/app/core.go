package app

import (
	"github.com/gin-gonic/gin"
)

type App struct {
	engine *gin.Engine
}

func (a *App) Server() *gin.Engine {
	return a.engine
}

func NewApp(engine *gin.Engine) IApp {
	return &App{
		engine: engine,
	}
}
