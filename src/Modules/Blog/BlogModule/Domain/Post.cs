using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.L1.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogModule.Domain;

[Index("Slug",IsUnique = true)]
[Table("Posts",Schema = "dbo")]
public class Post : BaseEntity
{
    [MaxLength(80)]
    public string Title { get; set; }
    [MaxLength(80)]
    public string Slug { get; set; }
    public string Description { get; set; }
    [MaxLength(80)]
    public string Author { get; set; }
    public long Visit { get; set; }
    [MaxLength(110)]
    public string ImageName { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
}