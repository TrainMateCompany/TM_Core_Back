namespace Trainmate.Common.Dto.Request;

public class UserRequestDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }  
    public bool? trainer { get; set; }
    public string? genre  { get; set; }
    public bool? Active { get; set; }
    
}