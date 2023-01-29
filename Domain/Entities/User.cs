namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string PassWord { get; set; }
    public List<UserRole> UserRoles { get; set; }
    public List<UserLogin> UserLogins { get; set; }
}