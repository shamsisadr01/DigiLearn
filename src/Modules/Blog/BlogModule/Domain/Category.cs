

using Common.L1.Domain;

namespace BlogModule.Domain;

public class Category : BaseEntity
{
    public string Title { get; set; }
    public string Slug { get; set; }
}