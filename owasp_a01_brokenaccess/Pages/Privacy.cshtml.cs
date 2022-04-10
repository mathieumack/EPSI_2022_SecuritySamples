using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using owasp_a01_brokenaccess.Data;
using System.Security.Claims;

namespace owasp_a01_brokenaccess.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly ApplicationDbContext context;

        public IdentityUser UserInformations { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public void OnGet(string email = null)
        {
            // Any user change the email from the query and show other user informations
            if (string.IsNullOrWhiteSpace(email))
                email = User.FindFirst(ClaimTypes.Email).Value;

            UserInformations = context.Users.AsQueryable().Where(e => e.Email == email).FirstOrDefault();
        }
    }
}