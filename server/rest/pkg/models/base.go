package models

type BaseModel struct {
	Id      int64  `json:"id" db:"id"`
	Created string `json:"created" db:"created"`
	Updated string `json:"updated" db:"updated"`
}
