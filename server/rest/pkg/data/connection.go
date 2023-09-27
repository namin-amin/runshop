package data

import (
	"fmt"
	_ "github.com/go-sql-driver/mysql"
	"github.com/pocketbase/dbx"
)

func NewDbConnection() *dbx.DB {
	db, err := dbx.Open("mysql", "root:secret123@/TestDb")
	if err != nil {
		panic("could not start connection")
		return nil
	}
	fmt.Println("connected")
	return db
}
