﻿using Common.L1.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreModule.Query._Data.Entities;

[Table("Users", Schema = "dbo")]
class UserQueryModel : BaseEntity
{
    [MaxLength(12)]
    public string PhoneNumber { get; set; }
    [MaxLength(50)]

    public string? Name { get; set; }

    [MaxLength(50)]
    public string? Family { get; set; }

    [MaxLength(110)]

    public string Avatar { get; set; }

    [MaxLength(110)]
    public string? Email { get; set; }


    public string? FullName
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Name) && string.IsNullOrWhiteSpace(Family))
                return null;
            return Name + " " + Family;
        }
    }
}