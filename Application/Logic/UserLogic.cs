using System.Text.RegularExpressions;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Model;
using Model.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    public async Task<User> CreateAsync(UserCreationDto userToCreate)
    {
        User? existingUser = await userDao.GetByUsernameAsync(userToCreate.Username);
        
        if (existingUser != null)
        {
            throw new Exception("User with that username already exists");
        }

        ValidateUserPassword(userToCreate.Password);
        ValidateUserEmail(userToCreate.Email);

        User toCreate = new User()
        {
            UserName = userToCreate.Username,
            Password = userToCreate.Password,
            Email = userToCreate.Email
        };

        User user = await userDao.CreateAsync(toCreate);
        
        return user;
    }

    private static void ValidateUserPassword(string password)
    {
        if (password.Length < 8)
        {
            throw new Exception("Password is too short");
        }

        if (!password.Any(c => char.IsDigit(c)))
        {
            throw new Exception("Password must contain at least one number");
        }
    }
    
    private static void ValidateUserEmail(string email)
    {
        if (!email.Contains('@'))
        {
            throw new Exception("This is not a valid email");
        }
    }
    
    public async Task<User> GetUserAsync(string username, string password)
    {
        User? existingUser = await userDao.GetByUsernameAsync(username);
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return await Task.FromResult(existingUser);
    }
}