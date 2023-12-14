using UserManagerApp.Server.Domain;

namespace UserManagerApp.Server.Models;

public record UserModel
{
    public string Id { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public User ToDomainEntity()
    {
        return new User
        {
            Login = Login,
            FirstName = FirstName,
            LastName = LastName,
        };
    }

    public static UserModel FromDomainEntity(User user)
    {
        return new UserModel
        {
            Id = user.Id.ToString() ?? string.Empty,
            Login = user.Login,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
    }
}