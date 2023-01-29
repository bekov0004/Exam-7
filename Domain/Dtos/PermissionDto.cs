using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class PermissionDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}