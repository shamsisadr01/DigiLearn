using Common.L4.Query;
using Common.L4.Query.Filter;
using CoreModule.Domain.Course.Enums;

namespace CoreModule.Query.Course._DTOs;

public class CourseFilterParams : BaseFilterParam
{
    public Guid? TeacherId { get; set; }
    public CourseActionStatus? ActionStatus { get; set; } = null;
    public CourseStatus? CourseStatus { get; set; } = null;
    public CourseLevel? CourseLevel { get; set; } = null;
   // public CourseFilterSort FilterSort { get; set; } = CourseFilterSort.Latest;
   // public SearchByPrice SearchByPrice { get; set; } = SearchByPrice.All;
    public string CategorySlug { get; set; }
    public string Search { get; set; }
}

public class CourseFilterResult : BaseFilter<CourseFilterData, CourseFilterParams>
{

}

public class CourseFilterData : BaseDto
{
    public string ImageName { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public int Price { get; set; }
    public CourseActionStatus CourseStatus { get; set; }
    public int EpisodeCount => Sections.Sum(s => s.Episodes.Count);
    public string Teacher { get; set; }
    public List<CourseSectionDto> Sections { get; set; }
}

public class CourseSectionDto : BaseDto
{
    public Guid CourseId { get; set; }
    public string Title { get; set; }
    public int DisplayOrder { get; set; }

    public List<EpisodeDto> Episodes { get; set; }
}

public class EpisodeDto : BaseDto
{
    public Guid SectionId { get; set; }
    public string Title { get; set; }
    public string EnglishTitle { get; set; }
    public Guid Token { get; set; }
    public TimeSpan TimeSpan { get; set; }
    public string VideoName { get; set; }
    public string? AttachmentName { get; set; }
    public bool IsActive { get; set; }
    public bool IsFree { get; set; }
}