namespace TicketModule.Core.DTOs;

public class TicketMessageDto
{
    public Guid UserId { get; set; }
    public string OwnerFullName { get; set; }
    public string Text { get; set; }
    public DateTime CreationDate { get; set; }
}