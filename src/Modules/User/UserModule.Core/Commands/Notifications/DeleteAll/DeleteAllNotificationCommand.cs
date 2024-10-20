using Common.L2.Application;

namespace UserModule.Core.Commands.Notifications.DeleteAll;

public record DeleteAllNotificationCommand(Guid UserId) : IBaseCommand;