﻿namespace TicketModule.Core.DTOs;

public class SendTicketMessageCommand
{
    public Guid UserId { get; set; }
    public Guid TicketId { get; set; }
    public string OwnerFullName { get; set; }
    public string Text { get; set; }
}