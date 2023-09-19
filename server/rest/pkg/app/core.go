package app

import "github.com/gin-gonic/gin"

type App struct {
}

func (a App) Server() *gin.Engine {
	server := gin.Default()
	return server
}
