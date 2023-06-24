using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TKS.Web.Pages.Admin
{
    public class LogoutModel : PageModel
    {
        private readonly ILogger<LogoutModel>? Logger;

        public LogoutModel(ILogger<LogoutModel>? logger)
        {
            Logger = logger;
        }

        public async Task OnGetAsync()
        {
            if(User.Identity.IsAuthenticated)
            {
                Logger.LogInformation("User {Name} logged out at {Time}.",
                    User.Identity.Name, DateTime.UtcNow);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            Response.Redirect("/Index");
        }
    }
}
