using Microsoft.EntityFrameworkCore;

namespace Domain.Entities; 
public class UserLogin
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime LoginDate { get; set; }

    public UserLogin()
    {
        LoginDate = DateTime.Now;
    }
}