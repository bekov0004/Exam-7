using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class RoleDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}