namespace Model.DTOs;

public class UserCreationDto
{
    public string Username { get;}
    public string Password { get; }
    
    public string Email { get; }

    public UserCreationDto(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
    }

   
}