package services

import "github.com/runshop/server/rest/pkg/data"

type IBaseService[T interface{}] interface {
	Insert(item T) (T, error)
	Update(item T, id int) (T, error)
	GetAll() ([]T, error)
	GetOne(id int64) (T, error)
	Delete(id int) error
}

type BaseService[T interface{}] struct {
	repo data.IBaseRepo[T]
}

func (b BaseService[T]) Insert(item T) (T, error) {
	return b.repo.Insert(item)
}

func (b BaseService[T]) Update(item T, id int) (T, error) {
	return b.repo.Update(item, id)
}

func (b BaseService[T]) GetAll() ([]T, error) {
	return b.repo.GetAll()
}

func (b BaseService[T]) GetOne(id int64) (T, error) {
	return b.repo.GetOne(id)
}

func (b BaseService[T]) Delete(id int) error {
	return b.repo.Delete(id)
}
