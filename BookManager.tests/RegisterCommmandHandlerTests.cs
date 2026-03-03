using BookManager.Application.Features.Auth.Commands;
using BookManager.Application.Interfaces;
using BookManager.Application.Services;
using BookManager.Domain.Entities;
using Moq;

namespace BookManager.tests
{
    public class RegisterCommmandHandlerTests
    {
        [Fact]
        public async Task Handle_WhenEmailAlreadyExists_ThrowExeption()
        {
            //Arrange
            var mockUSerRepo = new Mock<IUserRepository>();
            var mockJwtService = new Mock<IJwtService>();
            var mockEmail = new Mock<IEmailService>();

            mockUSerRepo.Setup(r => r.GetByEmailAsync("test@test.com"))
                .ReturnsAsync(new User { Email = "test@test.com" });

            var handler = new RegisterCommandHandler(
                mockUSerRepo.Object,
                mockJwtService.Object,
                mockEmail.Object
                );

            var command = new RegisterCommand
            {
                Email = "test@test.com",
                Password = "password123",
                Name = "test"
            };

            await Assert.ThrowsAsync<Exception>(() =>
            handler.Handle(command, CancellationToken.None));
        }
    [Fact]
        public async Task Handle_WhenValidData_ReturnsToken()
        {
            // Arrange
            var mockUserRepo = new Mock<IUserRepository>();
            var mockJwtService = new Mock<IJwtService>();
            var mockEmailService = new Mock<IEmailService>();

            // email doesn't exist
            mockUserRepo.Setup(r => r.GetByEmailAsync("new@test.com"))
                        .ReturnsAsync((User?)null);

            // fake token returned
            mockJwtService.Setup(j => j.GenerateToken(It.IsAny<User>()))
                          .Returns("fake-jwt-token");

            var handler = new RegisterCommandHandler(
                mockUserRepo.Object,
                mockJwtService.Object,
                mockEmailService.Object
            );

            var command = new RegisterCommand
            {
                Email = "new@test.com",
                Password = "password123",
                Name = "Test"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("fake-jwt-token", result);
        }
    }
}
