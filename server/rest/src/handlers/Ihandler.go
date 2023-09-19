package handlers

import "github.com/gin-gonic/gin"

// IHandler
// Implement this Interface for all the Handlers
type IHandler interface {
	RegisterHandler()                       // Register the defines route handlers
	NewHandler(engine *gin.Engine) IHandler //Create new Handlers using the given gin engine
}
