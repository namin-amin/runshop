package app

import (
	"github.com/gin-gonic/gin"
	"github.com/runshop/server/rest/pkg/services"
)

type IApp interface {
	Server() *gin.Engine
	UserService() services.IUserService
}
