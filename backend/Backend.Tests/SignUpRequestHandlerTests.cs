using System.Net;
using Backend.Application.Interfaces.Services;
using Backend.Application.UseCases.Auth.SignUp;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Backend.Tests;

public class SignUpRequestHandlerTests
{
    private readonly Mock<ILogger<SignUpRequestHandler>> _logger = new();
    private readonly Mock<IUserRepository> _userRepository = new();
    private readonly Mock<ITokenService> _tokenService = new();
    private readonly Mock<IUserTokenRepository> _userTokenRepository = new();
    private readonly Mock<IEmailSenderService> _emailSenderService = new();
    private readonly Mock<IUrlService> _urlService = new();

    private readonly SignUpRequestHandler _handler;

    public SignUpRequestHandlerTests()
    {
        _handler = new SignUpRequestHandler(
            _logger.Object,
            _userRepository.Object,
            _tokenService.Object,
            _userTokenRepository.Object,
            _emailSenderService.Object,
            _urlService.Object);
    }

    [Fact]
    public async Task Handle_Should_Return_Success_When_User_Is_Created()
    {
        // Arrange
        var request = new SignUpRequest
        {
            Username = "test",
            Password = "1234",
            PasswordConfirmation = "1234",
            Email = "test@mail.com"
        };
        
        var user = new User {Username = request.Username, Password = request.Password, Email = request.Email};

        _userRepository
            .Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        _tokenService.Setup(x => x.GenerateToken()).Returns("rawToken");
        _tokenService.Setup(x => x.HashToken("rawToken")).Returns("hashedToken");
        _urlService.Setup(x => x.GetAccountVerificationUrl("rawToken"))
            .Returns("url");

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.Contains("verify your account", result.Value.Message);
    }

    [Fact]
    public async Task Handle_Should_Call_Dependencies()
    {
        // Arrange
        var request = new SignUpRequest
        {
            Username = "test",
            Password = "1234",
            PasswordConfirmation = "1234",
            Email = "test@mail.com"
        };

        var user = new User {Username = request.Username, Password = request.Password, Email = request.Email};

        _userRepository
            .Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        _tokenService.Setup(x => x.GenerateToken()).Returns("rawToken");
        _tokenService.Setup(x => x.HashToken(It.IsAny<string>())).Returns("hashedToken");
        _urlService.Setup(x => x.GetAccountVerificationUrl(It.IsAny<string>()))
            .Returns("url");

        // Act
        await _handler.Handle(request, CancellationToken.None);

        // Assert
        _userRepository.Verify(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);
        _userTokenRepository.Verify(x => x.CreateAsync(It.IsAny<UserToken>(), It.IsAny<CancellationToken>()), Times.Once);
        _emailSenderService.Verify(x => x.SendAccountVerificationEmailAsync(
            It.IsAny<User>(), It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
