using Model.DTOs;
using Model;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);
    Task<User> GetUserAsync(string username, string password);
}