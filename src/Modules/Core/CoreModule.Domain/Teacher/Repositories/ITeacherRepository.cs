using Common.L1.Domain.Repository;

namespace CoreModule.Domain.Teacher.Repositories;

public interface ITeacherRepository : IBaseRepository<Models.Teacher>
{
    void Delete(Models.Teacher teacher);
}