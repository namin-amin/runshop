package handlers

import (
	"github.com/gin-gonic/gin"
	"github.com/runshop/server/rest/pkg/app"
)

// IHandler
// Implement this Interface for all the Handlers
type IHandler interface {
	RegisterHandler()                                             // Register the defines route handlers
	NewHandler(engine *gin.Engine, appInstance app.IApp) IHandler //Insert new Handlers using the given gin engine
}
