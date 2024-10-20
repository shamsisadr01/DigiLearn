﻿using Common.L2.Application;

namespace UserModule.Core.Commands.Notifications.Delete;

public record DeleteNotificationCommand(Guid NotificationId, Guid UserId) : IBaseCommand;