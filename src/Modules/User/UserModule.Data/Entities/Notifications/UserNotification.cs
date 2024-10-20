using Common.L1.Domain;
using System.ComponentModel.DataAnnotations;

namespace UserModule.Data.Entities.Notifications;

public class UserNotification : BaseEntity
{
    public Guid UserId { get; set; }

    [MaxLength(2000)]
    public string Text { get; set; }
    [MaxLength(300)]
    public string Title { get; set; }
    public bool IsSeen { get; set; }
}