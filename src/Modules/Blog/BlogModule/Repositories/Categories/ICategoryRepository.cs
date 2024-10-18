using BlogModule.Domain;
using Common.L1.Domain.Repository;

namespace BlogModule.Repositories.Categories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    void Delete(Category category);
    Task<List<Category>> GetAll();
}