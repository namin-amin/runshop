package validations

import (
	validation "github.com/go-ozzo/ozzo-validation"
	"github.com/go-ozzo/ozzo-validation/is"
	"github.com/runshop/server/rest/pkg/models"
	"regexp"
)

func IsUserCreationDtoValid(user models.User) error {
	return validation.ValidateStruct(&user,
		validation.Field(&user.FirstName, validation.Required, validation.RuneLength(2, 100)),
		validation.Field(&user.Email, validation.Required, is.Email),
		validation.Field(&user.Password,
			validation.Required,
			validation.RuneLength(8, 1000),
			validation.Match(regexp.MustCompile("^.*(.*[a-z]).*$")).Error("password must contain at-least 1 lower letter"),
			validation.Match(regexp.MustCompile("^.*(.*[0-9]).*$")).Error("password must contain at-least 1 number"),
			validation.Match(regexp.MustCompile("^.*(.*[!#$%&? \"]).*$")).Error("password must contain at-least one special characters"),
			validation.Match(regexp.MustCompile("^.*(.*[A-Z]).*$")).Error("password must contain at-least 1 upper case letter"),
		),
	)
}
