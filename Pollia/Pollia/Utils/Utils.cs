using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Pollia.Utils
{
    public static class Utils
    {
        public static DateTime StringToTime(this string stringTime)
        {
            try
            {
                return DateTime.ParseExact(stringTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new Exception("Not right date format");
            }
        }

        //Get User's Fullname
        public static string GetFullName(this System.Security.Principal.IPrincipal usr)
        {
            var fullNameClaim = ((ClaimsIdentity)usr.Identity).Claims.ToArray()[5];
            if (fullNameClaim != null)
                return fullNameClaim.Value.ToString();

            return "";
        }

        //Get User's Avatar
        public static string GetAvatar(this System.Security.Principal.IPrincipal usr)
        {
            var avtClaim = ((ClaimsIdentity)usr.Identity).Claims.ToArray()[6];
            if (avtClaim != null)
                return avtClaim.Value.ToString();

            return "";
        }

        //Get User's Role
        public static string GetRole(this System.Security.Principal.IPrincipal usr)
        {
            var roleClaim = ((ClaimsIdentity)usr.Identity).Claims.ToArray()[1];
            if (roleClaim != null)
                return roleClaim.Value.ToString();

            return "";
        }
    }
}