﻿using Common.L2.Application;
using MediatR;
using UserModule.Core.Commands.Users.Edit;
using UserModule.Core.Commands.Users.Register;
using UserModule.Core.Queries.Users._DTOs;
using UserModule.Core.Queries.Users.GetByPhoneNumber;

namespace UserModule.Core.Services;

public interface IUserFacade
{
    Task<OperationResult<Guid>> RegisterUser(RegisterUserCommand command);
    Task<OperationResult> EditUserProfile(EditUserCommand command);
   /* Task<OperationResult> EditUser(FullEditUserCommand command);
    Task<OperationResult> ChangeAvatar(ChangeUserAvatarCommand command);
    Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command);*/
    Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
    Task<UserDto?> GetById(Guid id);
}

public class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;

    public UserFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult<Guid>> RegisterUser(RegisterUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditUserProfile(EditUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }

    public async Task<UserDto?> GetById(Guid id)
    {
        throw new Exception();
        // return await _mediator.Send(new GetUserByIdQuery(id));
    }
}