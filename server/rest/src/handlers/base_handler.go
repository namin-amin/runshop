package handlers

import (
	"github.com/gin-gonic/gin"
	"github.com/runshop/server/rest/pkg/app"
	"net/http"
	"time"
)

type BaseHandler struct {
	routGroup *gin.RouterGroup
	app       app.IApp
}

type Response struct {
	ResponseTime time.Time   `json:"responseTime"`
	Status       int         `json:"status"`
	Message      string      `json:"message"`
	Data         interface{} `json:"data"`
}

func (b *BaseHandler) NotFound(ctx *gin.Context, message string, data interface{}) {
	ctx.JSON(http.StatusNotFound, Response{
		ResponseTime: time.Now(),
		Status:       http.StatusNotFound,
		Message:      message,
		Data:         data,
	})
}

func (b *BaseHandler) Ok(ctx *gin.Context, message string, data interface{}) {
	ctx.JSON(http.StatusOK, Response{
		ResponseTime: time.Now(),
		Status:       http.StatusOK,
		Message:      message,
		Data:         data,
	})
}

func (b *BaseHandler) InternalServerError(ctx *gin.Context, message string, data interface{}) {
	ctx.JSON(http.StatusInternalServerError, Response{
		ResponseTime: time.Now(),
		Status:       http.StatusInternalServerError,
		Message:      message,
		Data:         data,
	})
}

func (b *BaseHandler) BadRequest(ctx *gin.Context, message string, data interface{}) {
	ctx.JSON(http.StatusBadRequest, Response{
		ResponseTime: time.Now(),
		Status:       http.StatusBadRequest,
		Message:      message,
		Data:         data,
	})
}
