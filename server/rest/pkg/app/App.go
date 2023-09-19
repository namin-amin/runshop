package app

import (
	"github.com/gin-gonic/gin"
)

type IApp interface {
	Server() *gin.Engine
}
