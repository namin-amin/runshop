package handlers

import "github.com/runshop/server/rest/pkg/app"

func RegisterHandlers(a app.IApp) {
	home := Home{}
	home.NewHandler(a.Server()).RegisterHandler()
}
