using Common.L2.Application;
using Microsoft.EntityFrameworkCore;
using UserModule.Data;

namespace UserModule.Core.Commands.Notifications.Delete;

public class DeleteNotificationCommandHandler : IBaseCommandHandler<DeleteNotificationCommand>
{
    private UserContext _userContext;

    public DeleteNotificationCommandHandler(UserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task<OperationResult> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        var notifiaction =await _userContext.Notifications.
            FirstOrDefaultAsync(n=>n.Id == request.NotificationId 
                                   && n.UserId == request.UserId, cancellationToken);
        if (notifiaction == null) 
            return OperationResult.NotFound();

        _userContext.Notifications.Remove(notifiaction);
        await _userContext.SaveChangesAsync();
        return OperationResult.Success();
    }
}