using FootballTracker.Domain.Common;

namespace FootballTracker.Domain.Entities;


/*  🧠 Importante

Email normalizado no domínio

Autenticação não é problema do domínio

User aqui é conceitual, não técnico

 */

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    protected User() { }

    public User(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("User name cannot be empty.");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty.");

        Name = name.Trim();
        Email = email.Trim().ToLower();
    }
}
