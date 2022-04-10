using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace owasp_a10_ssrf.Pages
{
    public class MyAccountModel : PageModel
    {
        private readonly ILogger<MyAccountModel> _logger;

        [BindProperty]
        public string Name { get; set; }

        public MyAccountModel(ILogger<MyAccountModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            Name = "My name";

            // We check domain to refuse all request that come with localhost as domain. But you can change it by 127.0.0.1
            if (HttpContext.Request.Host.Host.Equals("localhost", StringComparison.InvariantCultureIgnoreCase))
                return BadRequest();

            return Page();
        }
    }
}