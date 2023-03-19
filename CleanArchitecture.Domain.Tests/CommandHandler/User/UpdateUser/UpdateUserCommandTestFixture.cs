using System;
using CleanArchitecture.Domain.Commands.Users.UpdateUser;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Interfaces.Repositories;
using Moq;

namespace CleanArchitecture.Domain.Tests.CommandHandler.User.UpdateUser;

public sealed class UpdateUserCommandTestFixture : CommandHandlerFixtureBase
{
    public UpdateUserCommandHandler CommandHandler { get; }
    private Mock<IUserRepository> UserRepository { get; }

    public UpdateUserCommandTestFixture()
    {
        UserRepository = new Mock<IUserRepository>();
        
        CommandHandler = new(
            Bus.Object,
            UnitOfWork.Object,
            NotificationHandler.Object,
            UserRepository.Object,
            User.Object);
    }
    
    public Entities.User SetupUser()
    {
        var user = new Entities.User(
            Guid.NewGuid(),
            "max@mustermann.com",
            "Max",
            "Mustermann",
            "Password",
            UserRole.User);

        UserRepository
            .Setup(x => x.GetByIdAsync(It.Is<Guid>(y => y == user.Id)))
            .ReturnsAsync(user);

        return user;
    }
}