package handlers

import "github.com/runshop/server/rest/pkg/app"

func RegisterHandlers(a app.IApp) {
	test := Test{}
	test.NewHandler(a.Server()).RegisterHandler()
	home := Home{}
	home.NewHandler(a.Server()).RegisterHandler()
}
