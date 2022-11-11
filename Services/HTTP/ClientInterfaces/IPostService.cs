

using Model;
using Model.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<ICollection<Post>> GetAllAsync();
    Task<IEnumerable<Post>> GetUserPostsAsync(int id);
    
    Task<Post> GetByIdAsync(int id);
    
}