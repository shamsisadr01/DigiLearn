using Common.EventBus.Abstractions;
using Common.EventBus.Events;
using Common.L2.Application;
using Common.L2.Application.FileUtil.Interfaces;
using Common.L2.Application.SecurityUtil;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using UserModule.Data;

namespace UserModule.Core.Commands.Users.ChangeAvatar;

public class ChangeUserAvatarCommandHandler : IBaseCommandHandler<ChangeUserAvatarCommand>
{
    private readonly UserContext _context;
    private readonly IFileService _fileService;
    private readonly IEventBus _eventBus;

    public ChangeUserAvatarCommandHandler(UserContext context , IEventBus eventBus, IFileService fileService)
    {
        _context = context;
        _eventBus = eventBus;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(ChangeUserAvatarCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(f => f.Id == request.UserId, cancellationToken);
        if (user == null)
        {
            return OperationResult.NotFound();
        }

        if (request.AvatarFile.IsImage() == false)
        {
            return OperationResult.Error("عکس نامعتبر است");
        }

        var avatar =
            await _fileService.SaveFileAndGenerateName(request.AvatarFile, UserModuleDirectories.UserAvatar);
        user.Avatar = avatar;
        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);

        _eventBus.Publish(new UserChangeAvatar()
        {
            UserId = user.Id,
            Avatar = avatar
        }, null, Exchanges.UserTopicExchange, ExchangeType.Topic, "user.changeAvatar");

        return OperationResult.Success();
    }
}