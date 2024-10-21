using Common.L3.Infrastructure.Repository;
using CoreModule.Domain.Category.Models;
using CoreModule.Domain.Category.Repository;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Infrastructure.Persistent.Category;

public class CourseCategoryRepository : BaseRepository<CourseCategory,CoreModuleEfContext>,ICourseCategoryRepository
{
    public CourseCategoryRepository(CoreModuleEfContext context) : base(context)
    {
    }

    public async Task Delete(CourseCategory category)
    {
        var categoryHasCourse = await Context.Courses
            .AnyAsync(f => f.CategoryId == category.Id || f.SubCategoryId == category.Id);

        if (categoryHasCourse)
        {
            throw new Exception("این دسته بندی دارای چندین دوره است");
        }

        var children = await Context.Categories.Where(r => r.ParentId == category.Id).ToListAsync();
        if (children.Any())
        {
            foreach (var child in children)
            {
                var isAnyCourse = await Context.Courses
                    .AnyAsync(f => f.CategoryId == child.Id || f.SubCategoryId == child.Id);
                if (isAnyCourse)
                {
                    throw new Exception("این دسته بندی دارای چندین دوره است");
                }
                else
                {
                    Context.Remove(child);
                }
            }
        }
        Context.Remove(category);
        await Context.SaveChangesAsync();
    }
}