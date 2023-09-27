package models

import "encoding/json"

type User struct {
	BaseModel
	FirstName string `json:"firstName" db:"firstName"`
	LastName  string `json:"lastName" db:"lastName"`
	Email     string `json:"email" db:"email"`
	Password  string `json:"password,omitempty" db:"password"`
}

func (u User) MarshalJSON() ([]byte, error) {
	type user User // prevent recursion
	x := user(u)
	x.Password = ""
	return json.Marshal(x)
}
