using Common.L1.Domain;
using System.ComponentModel.DataAnnotations;

namespace TicketModule.Data.Entities;

class Ticket : BaseEntity
{
    public Guid UserId { get; set; }
    [MaxLength(100)]
    public string OwnerFullName { get; set; }

    [MaxLength(11)]
    public string PhoneNumber { get; set; }

    [MaxLength(100)]
    public string Title { get; set; }
    public string Text { get; set; }
    public TicketStatus TicketStatus { get; set; }

    public List<TicketMessage> Message { get; set; }
}

public enum TicketStatus
{
    Pending,
    Answered,
    Closed
}