namespace FootballTracker.API.DTOs.Users;

public sealed class RegisterUserRequest
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
}
