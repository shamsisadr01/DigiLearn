using CoreModule.Query._Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Query._Data;

class QueryContext : DbContext
{
    public QueryContext(DbContextOptions<QueryContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DbSet<UserQueryModel> Users { get; set; }
    public DbSet<TeacherQueryModel> Teachers { get; set; }
    public DbSet<CourseQueryModel> Courses { get; set; }
    public DbSet<CategoryQueryModel> CourseCategories { get; set; }
    public DbSet<EpisodeQueryModel> Episodes { get; set; }
    public DbSet<SectionQueryModel> Sections { get; set; }
    // public DbSet<OrderQueryModel> Orders { get; set; }
    //public DbSet<OrderItemQueryModel> OrderItems { get; set; }


    [Obsolete("This context is read-only", true)]
    public new int SaveChanges()
    {
        throw new InvalidOperationException("This context is read-only.");
    }

    [Obsolete("This context is read-only", true)]
    public new int SaveChanges(bool acceptAll)
    {
        throw new InvalidOperationException("This context is read-only.");
    }

    [Obsolete("This context is read-only", true)]
    public new Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        throw new InvalidOperationException("This context is read-only.");
    }

    [Obsolete("This context is read-only", true)]
    public new Task<int> SaveChangesAsync(bool acceptAll, CancellationToken token = default)
    {
        throw new InvalidOperationException("This context is read-only.");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");


        modelBuilder.Entity<TeacherQueryModel>(builder =>
        {
            builder.ToTable("Teachers");
            builder.Property(b => b.UserName)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(20);

        });

       /* modelBuilder.Entity<OrderItemQueryModel>(builder =>
        {
            builder.ToTable("OrderItems");

        });*/
        modelBuilder.Entity<CourseQueryModel>(builder =>
        {

            builder.OwnsOne(b => b.SeoData, config =>
            {
                config.Property(b => b.MetaDescription)
                    .HasMaxLength(500)
                    .HasColumnName("MetaDescription");

                config.Property(b => b.MetaTitle)
                    .HasMaxLength(500)
                    .HasColumnName("MetaTitle");

                config.Property(b => b.MetaKeyWords)
                    .HasMaxLength(500)
                    .HasColumnName("MetaKeyWords");

                config.Property(b => b.IndexPage)
                    .HasColumnName("IndexPage");

                config.Property(b => b.Canonical)
                    .HasMaxLength(500)
                    .HasColumnName("Canonical");

                config.Property(b => b.Schema)
                    .HasColumnName("Schema");
            });
        });
        base.OnModelCreating(modelBuilder);
    }
}