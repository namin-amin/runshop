package middlewares

import (
	"github.com/golang-jwt/jwt/v5"
	echojwt "github.com/labstack/echo-jwt/v4"
	"github.com/labstack/echo/v4"
	"time"
)

type jwtCustomClaims struct {
	Name  string `json:"name"`
	Admin bool   `json:"admin"`
	jwt.RegisteredClaims
}

func GetToken(name string) (string, error) {
	claims := &jwtCustomClaims{
		name,
		true,
		jwt.RegisteredClaims{
			ExpiresAt: jwt.NewNumericDate(time.Now().Add(time.Hour * 72)),
		},
	}

	token := jwt.NewWithClaims(jwt.SigningMethodHS256, claims)
	t, err := token.SignedString([]byte("secret"))
	if err != nil {
		return "", err
	}
	return t, err
}

func CustomJwtConfig() *echojwt.Config {
	config := echojwt.Config{
		NewClaimsFunc: func(c echo.Context) jwt.Claims {
			return new(jwtCustomClaims)
		},
		SigningKey: []byte("secret"),
	}
	return &config
}

//func JWTAuth(next echo.HandlerFunc) echo.HandlerFunc {
//	return func(c echo.Context) error {
//		sentToken := c.Request().Header.Values("Authorization")
//
//		if len(sentToken) == 0 {
//			fmt.Println("no token")
//			return c.JSON(http.StatusUnauthorized, echo.Map{"message": "no auth token"})
//		}
//		token, err := jwt.ParseWithClaims(sentToken[0], &jwtCustomClaims{}, func(token *jwt.Token) (interface{}, error) {
//			return []byte("secret"), nil
//		})
//
//		if err != nil {
//			fmt.Println("jwt issue")
//			return c.JSON(http.StatusUnauthorized, echo.Map{"message": "malformed jwt"})
//		}
//
//		claims := token.Claims.(*jwtCustomClaims)
//
//		fmt.Println(claims.ID)
//		c.Request().Header.Set("userId", claims.ID)
//		return next(c)
//	}
//}
