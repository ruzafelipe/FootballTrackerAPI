using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Users.RegisterUser;

public sealed class RegisterUserHandler
{
    private readonly IUserRepository _userRepository;

    public RegisterUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> HandleAsync(RegisterUserCommand command)
    {
        var user = new User(
            name: command.Name,
            email: command.Email
        );

        await _userRepository.AddAsync(user);

        return user.Id;
    }
}