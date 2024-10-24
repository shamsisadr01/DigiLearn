using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreModule.Infrastructure.Persistent.Course;

public class CourseConfig : IEntityTypeConfiguration<Domain.Course.Models.Course>
{
    public void Configure(EntityTypeBuilder<Domain.Course.Models.Course> builder)
    {
        builder.ToTable("Courses", "course");

        builder.HasIndex(b => b.Slug).IsUnique();


        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);


        builder.Property(b => b.ImageName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.VideoName)
            .IsRequired(false);

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


        builder.OwnsMany(b => b.Sections, config =>
        {
            config.ToTable("Sections", "course");
            config.HasKey("Id");
            config.WithOwner().HasForeignKey("CourseId");

            config.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            config.OwnsMany(r => r.Episodes, e =>
            {
                e.ToTable("Episodes", "course");

                e.HasKey("Id");
                e.WithOwner().HasForeignKey("SectionId");

                e.Property(b => b.Title)
                    .HasMaxLength(100);

                e.Property(b => b.EnglishTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                e.Property(b => b.VideoName)
                    .IsRequired()
                    .HasMaxLength(200);

                e.Property(b => b.AttachmentName)
                    .IsRequired(false)
                    .HasMaxLength(200);
            });
        });


    }
}