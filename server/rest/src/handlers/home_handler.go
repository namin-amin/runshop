package handlers

import (
	"github.com/gin-gonic/gin"
	"net/http"
)

type Home struct {
	BaseHandler
}

func (h *Home) RegisterHandler() {
	h.routGroup.GET("/", func(ctx *gin.Context) {
		ctx.JSON(http.StatusOK, gin.H{
			"name":    "hello",
			"message": "Iam a Hello",
		})
	})
}

func (h *Home) NewHandler(engine *gin.Engine) IHandler {
	h.routGroup = engine.Group("home")
	return h
}
