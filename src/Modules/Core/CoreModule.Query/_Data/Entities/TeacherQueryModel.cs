﻿using Common.L1.Domain;
using CoreModule.Domain.Teacher.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreModule.Query._Data.Entities;

class TeacherQueryModel : BaseEntity
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string CvFileName { get; set; }
    public TeacherStatus Status { get; set; }


    [ForeignKey("UserId")]
    public UserQueryModel User { get; set; }
}