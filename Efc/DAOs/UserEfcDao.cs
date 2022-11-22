using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    
    private readonly RedditContext context;

    public UserEfcDao(RedditContext context)
    {
        this.context = context;
    }
    public async Task<User> CreateAsync(User userToCreate)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(userToCreate);
        await context.SaveChangesAsync();
        return newUser.Entity;    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.UserName.ToLower().Equals(username.ToLower())
        );
        return existing;    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.Id == id);
       
        return existing;       }
}