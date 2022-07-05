using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Moq;
using TDDNet6.API.Controllers;
using TDDNet6.Models.User;
using TDDNet6.Services.User;
using Xunit;

namespace TDDNet6.Tests.Systems.Controllers;

public class TestUsersController
{
    private readonly IUserService _userService = Substitute.For<IUserService>();
    //private readonly IUserService _userServiceMock = new Mock<IUserService>();
    private readonly IFixture _fixture = new Fixture();

    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        //Arrange
        var sut = new UsersController(_userService);

        //Act
        var result = (OkObjectResult)await sut.Get();

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokeUserService()
    {
        // TODO: check how to return a new list with NSubstitute
        //var res = _userService.GetAllUsers().Returns(Task.FromResult(1)));
        //default 3
        var users = _fixture.Create<List<UserModel>>();
        var testEntities = _fixture.Build<UserModel>().CreateMany(5).ToList();

        var userServiceMock = new Mock<IUserService>();

        userServiceMock.Setup(s => s.GetAllUsers()).ReturnsAsync(new List<UserModel>());

        var sut = new UsersController(userServiceMock.Object);

        //Act
        var result = (OkObjectResult)await sut.Get();

        //Assert
        userServiceMock.Verify(s => s.GetAllUsers(), Times.Once());
    }
}