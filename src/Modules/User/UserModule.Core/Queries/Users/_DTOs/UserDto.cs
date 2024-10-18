﻿namespace UserModule.Core.Queries.Users._DTOs;

public class UserDto 
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public string? Name { get; set; }

    public string? Family { get; set; }

    public string PhoneNumber { get; set; }
    public string? Email { get; set; }

    public string Password { get; set; }

    public string Avatar { get; set; }
    public List<RoleDto> Roles { get; set; } = new();


    public string FullName => $"{Name} {Family}";
}

public class RoleDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}