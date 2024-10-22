using Common.L1.Domain.Utilities;
using CoreModule.Domain.Course.DomainService;
using CoreModule.Domain.Course.Repository;

namespace CoreModule.Application.Course;

public class CourseDomainService : ICourseDomainService
{
    private readonly ICourseRepository _repository;

    public CourseDomainService(ICourseRepository repository)
    {
        _repository = repository;
    }

    public bool SlugIsExist(string slug)
    {
        return _repository.Exists(f => f.Slug == slug.ToSlug());
    }
}