package services

import (
	"github.com/runshop/server/rest/pkg/data"
	"github.com/runshop/server/rest/pkg/models"
)

type IChannelService interface {
	IBaseService[models.Channel]
}

type ChannelService struct {
	BaseService[models.Channel]
}

func NewChannelService(repo data.IChannelRepo) IChannelService {
	return &ChannelService{
		BaseService[models.Channel]{
			repo: repo,
		},
	}
}
