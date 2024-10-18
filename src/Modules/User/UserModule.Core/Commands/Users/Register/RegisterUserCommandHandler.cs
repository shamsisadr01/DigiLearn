using Common.L2.Application;
using Common.L2.Application.SecurityUtil;
using Microsoft.EntityFrameworkCore;
using UserModule.Data;
using UserModule.Data.Entities.Users;

namespace UserModule.Core.Commands.Users.Register;

public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand,Guid>
{
    private readonly UserContext _context;

    public RegisterUserCommandHandler(UserContext context)
    {
        _context = context;
    }

    public async Task<OperationResult<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await _context.Users.AnyAsync(f => f.PhoneNumber == request.PhoneNumber))
        {
            return OperationResult<Guid>.Error("شماره تلفن تکراری است");
        }

        var user = new User()
        {
            PhoneNumber = request.PhoneNumber,
            Password = Sha256Hasher.Hash(request.Password),
            Avatar = "default.png",
            Id = Guid.NewGuid()
        };

        _context.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return OperationResult<Guid>.Success(user.Id);
    }
}