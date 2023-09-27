package data

import (
	"github.com/pocketbase/dbx"
	"github.com/runshop/server/rest/pkg/models"
)

type IChannelRepo interface {
	IBaseRepo[models.Channel]
}

type ChannelRepo struct {
	BaseRepo[models.Channel]
}

func NewChannelRepo(dbContext *dbx.DB) IChannelRepo {
	return ChannelRepo{
		BaseRepo[models.Channel]{
			db:        dbContext,
			tableName: "channel",
		},
	}
}
