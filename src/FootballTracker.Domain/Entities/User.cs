using FootballTracker.Domain.Common;
using FootballTracker.Domain.Enums;

namespace FootballTracker.Domain.Entities;


/*  🧠 Importante

Email normalizado no domínio

Autenticação não é problema do domínio

User aqui é conceitual, não técnico

 */

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; } //aqui não deveria ser um objeto "Email" com regex e validação? Sim, mas vamos simplificar por enquanto
    public string PasswordHash { get; private set; }
    public UserRole Role { get; private set; }
    public bool IsActive { get; private set; } = true;

    protected User() { }

    public User(string name, string email, string passwordHash)
    {
       Validate(name, email, passwordHash);

        Name = name.Trim();
        Email = email.Trim().ToLower();
        PasswordHash = passwordHash;
        Role = UserRole.User;
        IsActive = true;
    }

    private static void Validate(string name, string email, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("User name cannot be empty.");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty.");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password hash cannot be empty.");
    }

    public void PromoteToAdmin()
    {
        Role = UserRole.Admin;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}
