package handlers

import (
	"github.com/labstack/echo/v4"
	"github.com/runshop/server/rest/pkg/app"
)

// IHandler
// Implement this Interface for all the Handlers
type IHandler interface {
	RegisterHandler()                                            // Register the defines route handlers
	NewHandler(engine *echo.Echo, appInstance app.IApp) IHandler //Insert new Handlers using the given gin engine
}
