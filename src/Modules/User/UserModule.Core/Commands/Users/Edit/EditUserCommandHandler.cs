﻿using Common.EventBus.Abstractions;
using Common.EventBus.Events;
using Common.L2.Application;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using UserModule.Data;

namespace UserModule.Core.Commands.Users.Edit;

public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly UserContext _context;
    private readonly IEventBus _eventBus;

    public EditUserCommandHandler(UserContext context, IEventBus eventBus)
    {
        _context = context;
        _eventBus = eventBus;
    }

    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(f => f.Id == request.UserId, cancellationToken);
        if (user == null)
        {
            return OperationResult.NotFound();
        }
        user.Name = request.Name;
        user.Family = request.Family;
        if (string.IsNullOrWhiteSpace(request.Email) == false)
        {
            if (await EmailIsDuplicated(request.Email))
            {
                return OperationResult.Error("ایمیل وارد شده تکراری است");
            }
            user.Email = request.Email.ToLower();
        }

        await _context.SaveChangesAsync(cancellationToken);

        _eventBus.Publish(new UserEdited()
            {
                Email = user.Email,
                Family = user.Family,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                UserId = user.Id
            }, null, Exchanges.UserTopicExchange,
            ExchangeType.Topic, "user.edited");

        return OperationResult.Success();
    }

    private async Task<bool> EmailIsDuplicated(string email)
    {
        return await _context.Users.AnyAsync(f => f.Email == email.ToLower());
    }
}