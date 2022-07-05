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
        var sut = new UsersController(_userService);

        //Act
        var result = (OkObjectResult)await sut.Get();

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokeUserService()
    {
        //var user = _fixture.Build<User>().With(p => p.Id, () => id).CreateMany(10);
        //var users = _fixture.Build<User>().With(f => f.Name, _fixture.Create("Name")).CreateMany(20);
        //default 3
        var users = _fixture.Create<List<UserModel>>();
        var testEntities = _fixture.Build<UserModel>().CreateMany(5).ToList();

        //var sut = new UsersController(_userService.GetAllUsers());

        //Act
        //var result = (OkObjectResult)await sut.Get();

        //Assert
        testEntities.Should().NotBeEmpty();
    }
}