using Common.L1.Domain.Repository;
using CoreModule.Domain.Category.Models;

namespace CoreModule.Domain.Category.Repository;

public interface ICourseCategoryRepository : IBaseRepository<CourseCategory>
{
    Task Delete(CourseCategory category);
}