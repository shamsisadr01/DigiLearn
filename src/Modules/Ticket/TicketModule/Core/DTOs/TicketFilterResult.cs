using Common.L4.Query;
using Common.L4.Query.Filter;
using TicketModule.Data.Entities;

namespace TicketModule.Core.DTOs;

public class TicketFilterData : BaseDto
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string OwnerFullName { get; set; }
    public TicketStatus Status { get; set; }
}
public class TicketFilterResult : BaseFilter<TicketFilterData, TicketFilterParams>
{

}

public class TicketFilterParams : BaseFilterParam
{
    public Guid? UserId { get; set; }
    public string? Title { get; set; }
    public TicketStatus? Status { get; set; }

}