using runShop.Models.models;
using runShop.rest.Dtos.user;

namespace Namespace;
public static class AuthControllerTestFixture
{

    public static CreateUserDto CreateUserDtoFixture = new()
    {
        Email = "test@123.com",
        FirstName = "tester",
        LastName = "testlastname",
        Password = "!@33444DEr##"
    };

    public static User UserFixture = new()
    {
        CreatedAt = DateTime.Now,
        UpdateAt = DateTime.Now,
        Email = "test@123.com",
        FirstName = "tester",
        LastName = "testlastname",
        Password = "!@33444DEr##",
        Id = 1
    };

}
