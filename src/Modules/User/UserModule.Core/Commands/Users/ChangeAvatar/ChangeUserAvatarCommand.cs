using Common.L2.Application.FileUtil.Services;
using Common.L2.Application;
using Microsoft.AspNetCore.Http;

namespace UserModule.Core.Commands.Users.ChangeAvatar;

public class ChangeUserAvatarCommand : IBaseCommand
{
    public Guid UserId { get; set; }
    public IFormFile AvatarFile { get; set; }
}