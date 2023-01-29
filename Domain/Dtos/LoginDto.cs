using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class LoginDto
{
    [Required]
    public string Username { get; set; }
    [Required,DataType(DataType.Password)]
    public string PassWord { get; set; }
}