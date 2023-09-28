package app

import (
	"github.com/labstack/echo/v4"
	"github.com/runshop/server/rest/pkg/services"
)

type IApp interface {
	Server() *echo.Echo
	UserService() services.IUserService
}
