using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TDDNet6.API.Controllers;
using TDDNet6.Models.User;
using TDDNet6.Services.User;
using Xunit;

namespace TDDNet6.Tests.Systems.Controllers;

public class TestUsersController
{
    private readonly IUserService _userService = Substitute.For<IUserService>();
    private readonly IFixture _fixture = new Fixture();

    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        //Arrange
        var randomUsers = _fixture.Create<List<UserModel>>(); //create 3 users by default
        //var randomUsers = _fixture.Build<UserModel>().CreateMany(5).ToList();
        _userService.GetAllUsers().Returns(randomUsers);

        var sut = new UsersController(_userService);

        //Act
        var result = (OkObjectResult) await sut.Get();

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokeUserServiceExacltyOnce()
    {
        // Arrange
        var randomUsers = _fixture.Create<List<UserModel>>(); //create 3 users by default
        //var randomUsers = _fixture.Build<UserModel>().CreateMany(5).ToList();
        _userService.GetAllUsers().Returns(randomUsers);

        var sut = new UsersController(_userService);

        //Act
        var result = (OkObjectResult)await sut.Get();

        //Assert
        _userService.Received(1);
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers()
    {
        //Arrange
        //var randomUsers = _fixture.Create<List<UserModel>>(); //create 3 users by default
        var randomUsers = _fixture.Build<UserModel>().CreateMany(5).ToList();
        _userService.GetAllUsers().Returns(randomUsers);

        var sut = new UsersController(_userService);

        // Act
        var result = await sut.Get();

        //Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<UserModel>>();
    }

    [Fact]
    public async Task Get_OnUsersNotFound_Returns404()
    {
        //Arrange
        _userService.GetAllUsers().Returns(new List<UserModel>());

        var sut = new UsersController(_userService);

        // Act
        var result = await sut.Get();

        //Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task Get_OnUsersNotFound_ReturnStatusCode404()
    {
        //Arrange
        _userService.GetAllUsers().Returns(new List<UserModel>());

        var sut = new UsersController(_userService);

        //Act
        var result = (NotFoundResult)await sut.Get();

        //Assert
        result.StatusCode.Should().Be(404);
    }
}