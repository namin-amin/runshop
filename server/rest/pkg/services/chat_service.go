package services

import (
	"github.com/runshop/server/rest/pkg/data"
	"github.com/runshop/server/rest/pkg/models"
)

type IChatService interface {
	IBaseService[models.Chat]
}

type ChatService struct {
	BaseService[models.Chat]
}

func NewChatService(repo data.IChatRepo) IChatService {
	return &ChatService{
		BaseService[models.Chat]{
			repo: repo,
		},
	}
}
