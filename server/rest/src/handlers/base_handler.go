package handlers

import (
	"github.com/labstack/echo/v4"
	"github.com/runshop/server/rest/pkg/app"
	"time"
)

type BaseHandler struct {
	routGroup *echo.Group
	app       app.IApp
}

type Response struct {
	ResponseTime int64       `json:"responseTime"`
	Message      string      `json:"message"`
	Data         interface{} `json:"data"`
}

func NewResponse(message string, data interface{}) *Response {
	return &Response{
		ResponseTime: time.Now().Unix(),
		Message:      message,
		Data:         data,
	}
}
