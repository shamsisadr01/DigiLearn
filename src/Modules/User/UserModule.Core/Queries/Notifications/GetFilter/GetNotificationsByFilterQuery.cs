using Common.L4.Query;
using UserModule.Core.Queries._DTOs;

namespace UserModule.Core.Queries.Notifications.GetFilter;

public class GetNotificationsByFilterQuery : QueryFilter<NotificationFilterResult, NotificationFilterParams>
{
    public GetNotificationsByFilterQuery(NotificationFilterParams filterParams) : base(filterParams)
    {
    }
}