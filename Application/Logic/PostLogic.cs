using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Model;
using Model.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }
    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.UserId);
        
        if (user == null)
        {
            throw new Exception($"User with id {dto.UserId} was not found.");
        }
        
        ValidateTodo(dto);
        Post created = await postDao.CreateAsync(new Post(){Body = dto.Body, Title = dto.Title},user);
        return created;
    }

    private void ValidateTodo(PostCreationDto dto)
    {
        string title = dto.Title;
        if (string.IsNullOrEmpty(title)) throw new Exception("Title cannot be empty.");

        string body = dto.Body;
        if (string.IsNullOrEmpty(body)) throw new Exception("Body cannot be empty. ");
    }
    
    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        return await postDao.GetAllAsync();
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        return await postDao.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int id)
    {
        return await postDao.GetPostsByUserIdAsync(id);
    }
}