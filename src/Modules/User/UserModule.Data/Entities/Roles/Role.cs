using Common.L1.Domain;
using System.ComponentModel.DataAnnotations;

namespace UserModule.Data.Entities.Roles;

public class Role : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }


    public List<RolePermission> Permissions { get; set; }
}