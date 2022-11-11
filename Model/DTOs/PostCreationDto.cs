namespace Model.DTOs;

public class PostCreationDto
{
    public string Body { get; }
    public string Title { get; }
    
    public int UserId { get; }

    public PostCreationDto(string title, string body, int userId)
    {
        Body = body;
        Title = title;
        UserId = userId;
    }
}