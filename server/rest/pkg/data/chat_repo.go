package data

import (
	"github.com/pocketbase/dbx"
	"github.com/runshop/server/rest/pkg/models"
)

type IChatRepo interface {
	IBaseRepo[models.Chat]
}

type ChatRepo struct {
	BaseRepo[models.Chat]
}

func NewUserService(dbContext *dbx.DB) IChatRepo {
	return &ChatRepo{
		BaseRepo[models.Chat]{
			db:        dbContext,
			tableName: "chat",
		},
	}
}
