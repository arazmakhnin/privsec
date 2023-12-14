using UserManagerApp.Server.DAL;
using UserManagerApp.Server.Domain;

namespace UserManagerApp.Server.Services;

public interface IUserService
{
    Task<IReadOnlyCollection<User>> GetAll();
    Task<User> Add(User user);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IReadOnlyCollection<User>> GetAll()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> Add(User user)
    {
        await _userRepository.Add(user);
        return user;
    }
}