﻿using AutoMapper;
using Common.L2.Application;
using Common.L2.Application.SecurityUtil;
using Microsoft.EntityFrameworkCore;
using TicketModule.Core.DTOs;
using TicketModule.Data;
using TicketModule.Data.Entities;

namespace TicketModule.Core.Services;

public interface ITicketService
{
    Task<OperationResult<Guid>> CreateTicket(CreateTicketCommand command);
    Task<OperationResult> SendMessageInTicket(SendTicketMessageCommand command);
    Task<OperationResult> CloseTicket(Guid ticketId);

    Task<TicketDto?> GetTicket(Guid ticketId);
}

class TicketService : ITicketService
{
    private readonly TicketContext _context;
    private IMapper _mapper;
    public TicketService(TicketContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OperationResult<Guid>> CreateTicket(CreateTicketCommand command)
    {
        var ticket = _mapper.Map<Ticket>(command);

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return OperationResult<Guid>.Success(ticket.Id);
    }

    public async Task<OperationResult> SendMessageInTicket(SendTicketMessageCommand command)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(f => f.Id == command.TicketId);
        if (ticket == null)
        {
            return OperationResult.NotFound();
        }
        if (string.IsNullOrWhiteSpace(command.Text))
            return OperationResult.Error("متن پیام را وارد کنید");

        var message = new TicketMessage()
        {
            Text = command.Text.SanitizeText(),
            TicketId = command.TicketId,
            UserId = command.UserId,
            UserFullName = command.OwnerFullName
        };

        if (ticket.UserId == command.UserId)
        {
            ticket.TicketStatus = TicketStatus.Pending;
        }
        else
        {
            ticket.TicketStatus = TicketStatus.Answered;
        }


        _context.TicketMessages.Add(message);
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return OperationResult.Success();
    }

    public async Task<OperationResult> CloseTicket(Guid ticketId)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(f => f.Id == ticketId);
        if (ticket == null)
        {
            return OperationResult.NotFound();
        }
        ticket.TicketStatus = TicketStatus.Closed;
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return OperationResult.Success();
    }

    public async Task<TicketDto?> GetTicket(Guid ticketId)
    {
        var ticket = await _context.Tickets
            .Include(c => c.Message)
            .FirstOrDefaultAsync(f => f.Id == ticketId);

        return _mapper.Map<TicketDto>(ticket);
    }
}