﻿using Common.L3.Infrastructure;
using CoreModule.Domain.Category.Models;
using CoreModule.Domain.Order.Models;
using CoreModule.Infrastructure.Persistent.Course;
using CoreModule.Infrastructure.Persistent.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Infrastructure.Persistent;

public class CoreModuleEfContext : BaseEfContext<CoreModuleEfContext>
{
    public CoreModuleEfContext(DbContextOptions<CoreModuleEfContext> options, IMediator mediator) : base(options, mediator)
    {
    }

    public DbSet<Domain.Course.Models.Course> Courses { get; set; }
    public DbSet<Domain.Teacher.Models.Teacher> Teachers { get; set; }
    public DbSet<CourseCategory> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfig).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}