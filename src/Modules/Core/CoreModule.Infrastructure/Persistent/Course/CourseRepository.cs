using Common.L3.Infrastructure.Repository;
using CoreModule.Domain.Course.Models;
using CoreModule.Domain.Course.Repository;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Infrastructure.Persistent.Course;

public class CourseRepository : BaseRepository<Domain.Course.Models.Course, CoreModuleEfContext>, ICourseRepository
{
    public CourseRepository(CoreModuleEfContext context) : base(context)
    {
    }

    public async Task AddSection(Section section)
    {
        var sql = $@"Insert Into [course].Sections (Id,CourseId,Title,DisplayOrder,CreationDate)
                    Values ('{section.Id}','{section.CourseId}',N'{section.Title}','{section.DisplayOrder}',getDate())"
        ;

      await  Context.Database.ExecuteSqlRawAsync(sql);
    }
}