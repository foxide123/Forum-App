using Application.DaoInterfaces;
using EfcDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

public class PostEfcDao : IPostDao
{
    
    private readonly RedditContext context;

    public PostEfcDao(RedditContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post postToCreate, User user)
    {
        postToCreate.Creator = user;
        EntityEntry<Post> added = await context.Posts.AddAsync(postToCreate);
        await context.SaveChangesAsync();
        return added.Entity;    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        IEnumerable<Post> list = await context.Posts.Include(post => post.Creator).ToListAsync();
        return list;
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        Post? post = await context.Posts.FindAsync(id);
        return post;
    }

    public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int id)
    {
        IEnumerable<Post> list = await context.Posts.Include(post => post.Creator).Where(post => post.Creator.Id == id).ToListAsync();
        return list;    }
}