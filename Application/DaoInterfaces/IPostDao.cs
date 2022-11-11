using Model;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post postToCreate, User user);

    Task<IEnumerable<Post>> GetAllAsync();

    Task<Post?> GetByIdAsync(int id);
    Task<IEnumerable<Post>> GetPostsByUserIdAsync(int id);
}