package models

type Chat struct {
	BaseModel
	Sender   int64  `json:"sender"`
	Reciever int64  `json:"reciever"`
	Message  string `json:"message"`
}
