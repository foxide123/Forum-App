using Model;
using Model.DTOs;
using Model;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User userToCreate);
    Task<User?> GetByUsernameAsync(string username);
    
    Task<User?> GetByIdAsync(int id);

}