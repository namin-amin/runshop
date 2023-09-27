package handlers

import "github.com/runshop/server/rest/pkg/app"

func RegisterHandlers(a app.IApp) {
	home := UserHandler{}
	home.NewHandler(a.Server(), a).RegisterHandler()
}
