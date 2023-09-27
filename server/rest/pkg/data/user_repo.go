package data

import (
	"github.com/pocketbase/dbx"
	"github.com/runshop/server/rest/pkg/models"
)

type IUserRepo interface {
	IBaseRepo[models.User]
}

type UserRepo struct {
	BaseRepo[models.User]
}

func NewUserRepo(dbContext *dbx.DB) IUserRepo {
	return &UserRepo{
		BaseRepo[models.User]{
			db:        dbContext,
			tableName: "users",
		},
	}
}
