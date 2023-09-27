package services

import (
	"github.com/runshop/server/rest/pkg/data"
	"github.com/runshop/server/rest/pkg/models"
)

type IUserService interface {
	IBaseService[models.User]
}

type UserService struct {
	BaseService[models.User]
}

func NewUserService(repo data.IUserRepo) IUserService {
	return &UserService{
		BaseService[models.User]{
			repo: repo,
		},
	}
}
