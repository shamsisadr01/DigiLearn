using Common.L2.Application;

namespace UserModule.Core.Commands.Notifications.Create;

public class CreateNotificationCommand : IBaseCommand
{
    public Guid UserId { get; set; }
    public string Text { get; set; }
    public string Title { get; set; }
}