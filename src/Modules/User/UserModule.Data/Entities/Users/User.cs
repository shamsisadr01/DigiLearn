using Common.L1.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using UserModule.Data.Entities.Roles;

namespace UserModule.Data.Entities.Users;

[Index("Email", IsUnique = true)]
[Index("PhoneNumber", IsUnique = true)]
public class User : BaseEntity
{
    [MaxLength(50)]
    public string? Name { get; set; }

    [MaxLength(50)]
    public string? Family { get; set; }

    [MaxLength(11)]
    [Required]
    public string PhoneNumber { get; set; }


    [MaxLength(50)]
    public string? Email { get; set; }


    [MaxLength(70)]
    [Required]
    public string Password { get; set; }

    [MaxLength(100)]
    [Required]
    public string Avatar { get; set; }

    public List<UserRole> UserRoles { get; set; }
}

public class UserRole : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }


    public User User { get; set; }
    public Role Role { get; set; }
}