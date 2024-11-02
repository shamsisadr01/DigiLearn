using Common.L2.Application;

namespace CoreModule.Application.Order.RemoveItem;

public record RemoveOrderItemCommand(Guid UserId, Guid Id) : IBaseCommand;