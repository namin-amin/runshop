package main

import (
	"github.com/labstack/echo/v4"
	app2 "github.com/runshop/server/rest/pkg/app"
	"github.com/runshop/server/rest/src/handlers"
)

func main() {
	app := app2.NewApp(echo.New())
	handlers.RegisterHandlers(app)
	app.Server().Logger.Fatal(app.Server().Start(":3000"))
}
