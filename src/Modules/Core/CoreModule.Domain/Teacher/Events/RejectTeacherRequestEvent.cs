using Common.L1.Domain;

namespace CoreModule.Domain.Teacher.Events;

public class RejectTeacherRequestEvent : BaseDomainEvent
{
    public string Description { get; set; }
    public Guid UserId { get; set; }
}
public class AcceptTeacherRequestEvent : BaseDomainEvent
{
    public Guid UserId { get; set; }
}