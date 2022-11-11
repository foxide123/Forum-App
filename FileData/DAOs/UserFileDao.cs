using Application.DaoInterfaces;
using Model;

namespace FileData.DAOs;

public class UserFileDao : IUserDao
{

    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }
    public Task<User> CreateAsync(User userToCreate)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        userToCreate.Id = userId;

        context.Users.Add(userToCreate);
        context.SaveChanges();

        return Task.FromResult(userToCreate);    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        User? user = context.Users.FirstOrDefault(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(user);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        User? user = context.Users.FirstOrDefault(user => user.Id == id);

        return Task.FromResult(user);
    }
}