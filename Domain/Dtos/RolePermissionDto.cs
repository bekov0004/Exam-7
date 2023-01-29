using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class RolePermissionDto
{
    public int Id { get; set; }
    [Required]
    public int RoleId { get; set; } 
    [Required]
    public int PermissionId { get; set; }
}