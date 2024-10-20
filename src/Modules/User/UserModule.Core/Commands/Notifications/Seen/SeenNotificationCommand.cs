using Common.L2.Application;

namespace UserModule.Core.Commands.Notifications.Seen;

public record SeenNotificationCommand(Guid NotificationId) : IBaseCommand;