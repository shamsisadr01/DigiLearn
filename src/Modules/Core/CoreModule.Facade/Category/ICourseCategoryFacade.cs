using Common.L2.Application;
using CoreModule.Application.Category.AddChild;
using CoreModule.Application.Category.Create;
using CoreModule.Application.Category.Edit;

namespace CoreModule.Facade.Category;

public interface ICourseCategoryFacade
{
    Task<OperationResult> Create(CreateCategoryCommand command);
    Task<OperationResult> Edit(EditCategoryCommand command);
    Task<OperationResult> Delete(Guid id);
    Task<OperationResult> AddChild(AddChildCategoryCommand command);



   /* Task<List<CourseCategoryDto>> GetMainCategories();
    Task<CourseCategoryDto?> GetById(Guid categoryId);
    Task<List<CourseCategoryDto>> GetChildren(Guid parentId);*/
}