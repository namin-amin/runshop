using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Namespace;
using runShop.Models.models;
using runShop.rest.AuthUtils;
using runShop.rest.Controllers;
using runShop.rest.Dtos.user;
using runShop.services.user;

namespace runShop.rest.Test;

public class AuthControllerTest
{
    private readonly Mock<IJwtUtils> jwtUtil;
    private readonly Mock<FluentValidation.IValidator<CreateUserDto>> validator;
    private readonly Mock<IUserService> userService;
    private readonly Mock<IMapper> mapper;

    public AuthControllerTest()
    {

        jwtUtil = new Mock<IJwtUtils>();
        validator = new Mock<FluentValidation.IValidator<CreateUserDto>>();
        userService = new Mock<IUserService>();
        mapper = new Mock<IMapper>();

    }

    [Fact]
    public async void Resgiter_and_get_new_user()
    {

        //Arrange
        var validationResult = new FluentValidation.Results.ValidationResult();

        validator.Setup(vld => vld.Validate(AuthControllerTestFixture.CreateUserDtoFixture)).Returns(validationResult);

        mapper.Setup(mp => mp.Map<User>(AuthControllerTestFixture.CreateUserDtoFixture)).Returns(AuthControllerTestFixture.UserFixture);

        userService.Setup(uservice => uservice.CreateNewUser(AuthControllerTestFixture.UserFixture).Result).Returns(AuthControllerTestFixture.UserFixture);

        jwtUtil.Setup(util => util.CreteJwtToken(AuthControllerTestFixture.UserFixture)).Returns("test@123schemassdsuhghhhhhhhhhhfuuusbfbusbvubuvbbuvbb");

        var authController = new AuthController(
                                                jwtUtil.Object,
                                                validator.Object,
                                                userService.Object,
                                                mapper.Object);

        //Act

        var result = await authController.RegisterUser(AuthControllerTestFixture.CreateUserDtoFixture);

        Debug.WriteLine(result);

        //Assert
        Assert.Equal(StatusCodes.Status200OK, ((ObjectResult)result).StatusCode);
    }

    [Fact]
    public async void Login_and_get_userDetails()
    {

        //Arrange
        var validationResult = new FluentValidation.Results.ValidationResult();

        validator.Setup(vld => vld.Validate(AuthControllerTestFixture.CreateUserDtoFixture)).Returns(validationResult);

        mapper.Setup(mp => mp.Map<User>(AuthControllerTestFixture.CreateUserDtoFixture)).Returns(AuthControllerTestFixture.UserFixture);

        userService.Setup(us => us.IsValidUser(AuthControllerTestFixture.UserFixture).Result).Returns(true);

        jwtUtil.Setup(util => util.CreteJwtToken(AuthControllerTestFixture.UserFixture)).Returns("test@123schemassdsuhghhhhhhhhhhfuuusbfbusbvubuvbbuvbb");

        var authController = new AuthController(
                                              jwtUtil.Object,
                                              validator.Object,
                                              userService.Object,
                                              mapper.Object);

        //Act

        var result = await authController.LogIn(AuthControllerTestFixture.CreateUserDtoFixture);

        //Assert
        Assert.Equal(StatusCodes.Status200OK, ((ObjectResult)result).StatusCode);

    }
}
