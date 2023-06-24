using Microsoft.AspNetCore.Mvc;

namespace TKS.Web.Helpers
{
    public class TKSWebHelpers
    {
    }
    public static class User
    {
        public static readonly string? Password = "User:password";
        public static readonly string? Salt = "User:salt";
        public static readonly string? UserName = "User:username";
        public static readonly string? HashKey = "User:hashkey";
    }
    public static class UrlHelperExtensions
    {
        public static string GetLocalUrl(this IUrlHelper urlHelper, string localUrl)
        {
            if (!urlHelper.IsLocalUrl(localUrl))
            {
                return urlHelper!.Page("/Index");
            }

            return localUrl;
        }
    }
}
