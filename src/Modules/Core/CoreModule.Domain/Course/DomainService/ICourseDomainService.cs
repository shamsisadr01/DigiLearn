namespace CoreModule.Domain.Course.DomainService;

public interface ICourseDomainService
{
    bool SlugIsExist(string slug);
}