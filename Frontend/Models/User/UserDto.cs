namespace PCMasterFrontend.Models.User;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new();
}
