using Common.L1.Domain.Repository;
using CoreModule.Domain.Course.Models;

namespace CoreModule.Domain.Course.Repository;

public interface ICourseRepository : IBaseRepository<Models.Course>
{
    Task AddSection(Section section);
}