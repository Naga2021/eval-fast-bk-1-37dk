using FortCode.Controllers;
using FortCode.Data;
using FortCode.Data.Entities;
using FortCode.Data.Models;
using FortCode.Data.Repository;
using FortCode.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FortCode.UnitTests
{
    public class UserTest
    {
        private readonly UserController _userController;
        private readonly Mock<ITokenService> _tokenService;
        private readonly Mock<IUserRepository> _userRepository;
        private const string _name = "test";
        private const string _password = "test@123";

        public UserTest()
        { 
            _tokenService = new Mock<ITokenService>();
            _userRepository = new Mock<IUserRepository>();
            _userController = new UserController(_userRepository.Object, _tokenService.Object);
        }
        [Fact]
        public async Task Register_RegisterUser_ReturnTrue()
        {
            var registerModel = Mock.Of<User>(user => user.Name == _name && user.Password == _password);

            _userRepository.Setup(m => m.Save(It.IsAny<User>())).ReturnsAsync(true);

            bool result= await _userController.Register(registerModel);
            Assert.True(result);
        }

        [Fact]
        public async Task Login_GivenValidCredentials_GenerateToken()
        {
            var loginModel = Mock.Of<LoginModel>(login => login.Name == _name && login.Password == _password);
            var data = Mock.Of<User>(user=>user.Name == _name && user.Password ==_password);

            _userRepository.Setup(m => m.GetUser(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(data);
            _tokenService.Setup(token => token.CreateToken(It.IsAny<string>())).Returns("data");

            var result = await _userController.Login(loginModel) as OkObjectResult;
            Assert.Equal("data",result.Value.ToString());

        }

        [Fact]
        public async Task Login_GivenInvalidCredentials_ReturnBadRequestError()
        {
            var loginModel = Mock.Of<LoginModel>(login => login.Name == "test" && login.Password == "test");

            var result = await _userController.Login(loginModel) as BadRequestResult;
            Assert.IsType<BadRequestResult>(result);


        }
    }
}
