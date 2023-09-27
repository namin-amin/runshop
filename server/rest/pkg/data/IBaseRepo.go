package data

import (
	"github.com/pocketbase/dbx"
)

type IBaseRepo[T interface{}] interface {
	Insert(item T) (T, error)
	Update(item T, id int) (T, error)
	GetAll() ([]T, error)
	GetOne(id int64) (T, error)
	Delete(id int) error
	DB() *dbx.DB
}

type BaseRepo[T interface{}] struct {
	db        *dbx.DB
	tableName string
}

func (b BaseRepo[T]) Insert(item T) (T, error) {
	err := b.db.Model(&item).Insert()
	return item, err
}

func (b BaseRepo[T]) Update(item T, id int) (T, error) {
	err := b.db.Model(&item).Update()
	return item, err
}

func (b BaseRepo[T]) GetAll() ([]T, error) {
	var result []T
	err := b.db.Select().All(&result)
	return result, err
}

func (b BaseRepo[T]) GetOne(id int64) (T, error) {
	var item T
	err := b.db.Select().Model(id, &item)
	return item, err
}

func (b BaseRepo[T]) Delete(id int) error {
	_, err := b.db.Delete(b.tableName, dbx.HashExp{"id": id}).Execute()
	return err
}

func (b BaseRepo[T]) DB() *dbx.DB {
	return b.db
}
