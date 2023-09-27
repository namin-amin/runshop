package models

type Channel struct {
	BaseModel
	Name        string `json:"name"`
	Description string `json:"description"`
}

type ChannelMembers struct {
	BaseModel
	UserId    int64 `json:"userId"`
	ChannelId int64 `json:"channelId"`
}
