using CommentModule.Domain;
using Common.L4.Query.Filter;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Common.L4.Query;

namespace CommentModule.Services.DTOs;

public class CreateCommentCommand
{
    [Required]
    public string Text { get; set; }
    public Guid? ParentId { get; set; } = null;
    public Guid UserId { get; set; } = Guid.Empty;
    public Guid EntityId { get; set; }
    public CommentType CommentType { get; set; }
}
public class CommentDto : BaseDto
{
    public Guid UserId { get; set; }
    public Guid EntityId { get; set; }
    public string Text { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public CommentType CommentType { get; set; }

    public List<CommentReplyDto> Replies { get; set; }
}

public class CommentReplyDto : BaseDto
{
    public Guid UserId { get; set; }
    public Guid EntityId { get; set; }
    public string Text { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public Guid? ParentId { get; set; }
    public CommentType CommentType { get; set; }
}

public class CommentFilterResult : BaseFilter<CommentDto, CommentFilterParams>
{

}
public class AllCommentFilterResult : BaseFilter<CommentReplyDto, CommentFilterParams>
{

}

public class CommentFilterParams : BaseFilterParam
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public CommentType? CommentType { get; set; } = null;
    public Guid? EntityId { get; set; } = null;

    [Display(Name = "نام")]
    public string? Name { get; set; }
    public string? Family { get; set; }
}