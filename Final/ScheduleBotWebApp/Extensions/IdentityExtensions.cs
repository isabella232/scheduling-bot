using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace ScheduleBotWebApp.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetFullName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("FullName");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetTimeZone(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("TimeZone");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetPhoneNumber(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("PhoneNumber");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserId");
            return (claim != null) ? claim.Value : string.Empty;
        }

    }
}