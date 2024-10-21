using Common.L2.Application;

namespace CoreModule.Application.Category.Delete;

public record DeleteCategoryCommand(Guid CategoryId) : IBaseCommand;