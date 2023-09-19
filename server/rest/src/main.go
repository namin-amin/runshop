package main

import (
	"github.com/gin-gonic/gin"
	app2 "github.com/runshop/server/rest/pkg/app"
	"github.com/runshop/server/rest/src/handlers"
)

func main() {
	app := app2.NewApp(gin.Default())
	handlers.RegisterHandlers(app)
	err := app.Server().Run(":3000")

	if err != nil {
		panic("Unable to start the server following error is thrown \n" + err.Error())
	}
}
