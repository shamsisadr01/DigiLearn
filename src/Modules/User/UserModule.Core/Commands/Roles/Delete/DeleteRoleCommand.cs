using Common.L2.Application;

namespace UserModule.Core.Commands.Roles.Delete;

public record DeleteRoleCommand(Guid RoleId) : IBaseCommand;