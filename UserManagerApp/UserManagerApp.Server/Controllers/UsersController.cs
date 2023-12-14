using Microsoft.AspNetCore.Mvc;
using UserManagerApp.Server.Models;
using UserManagerApp.Server.Services;

namespace UserManagerApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ICollection<UserModel>> GetAllUsers()
    {
        return (await _userService.GetAll()).Select(UserModel.FromDomainEntity).ToArray();
    }

    [HttpPost]
    public async Task<UserModel> Add(UserModel user)
    {
        var addedUser = await _userService.Add(user.ToDomainEntity());
        return UserModel.FromDomainEntity(addedUser);
    }
}