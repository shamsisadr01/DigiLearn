﻿using Common.L4.Query;
using Common.L4.Query.Filter;

namespace BlogModule.Service.DTOs.Query;

public class BlogPostFilterResult : BaseFilter<BlogPostFilterItemDto, BlogPostFilterParams>
{

}

public class BlogPostFilterParams : BaseFilterParam
{
    public string? Search { get; set; }
    public string? CategorySlug { get; set; }
}
public class BlogPostFilterItemDto : BaseDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public long Visit { get; set; }
    public string ImageName { get; set; }
    public BlogCategoryDto Category { get; set; }
}