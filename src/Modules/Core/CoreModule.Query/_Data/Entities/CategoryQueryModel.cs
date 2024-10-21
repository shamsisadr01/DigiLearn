using Common.L1.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreModule.Query._Data.Entities;

[Table("Categories")]
class CategoryQueryModel : BaseEntity
{
    public string Title { get; set; }
    public string Slug { get; set; }

    [ForeignKey("ParentId")]
    public Guid? ParentId { get; set; }

    public List<CategoryQueryModel> Children { get; set; }
}