﻿using System.Security.Claims;

namespace DigiLearn.Infrastructure
{
    public static class ClaimUtils
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            return Guid.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }

        public static string GetUserPhoneNumber(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            return principal.FindFirst(ClaimTypes.MobilePhone)?.Value;
        }
    }
}
