namespace FootballTracker.Application.UseCases.Users.RegisterUser;
public sealed class RegisterUserCommand
{
    public string Name { get; }
    public string Email { get; }

    public RegisterUserCommand(string name, string email)
    {
        Name = name;
        Email = email;
    }
}