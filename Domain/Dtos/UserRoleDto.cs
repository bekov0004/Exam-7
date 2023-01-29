﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class UserRoleDto
{
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int RoleId { get; set; } 
}