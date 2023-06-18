using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
///<summary>
/// AboutUs Page
///<summary>
{
    public class AboutUsModel : PageModel
    {
        /// <summary>
        /// logger for index model to render
        /// </summary>
        private readonly ILogger<AboutUsModel> _logger;

        /// <summary>
        /// Constructor taking input Logger
        /// </summary>
        /// <param name="logger"></param>
        public AboutUsModel(ILogger<AboutUsModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Customize onGet() method for AboutUs page.
        /// </summary>
        public void OnGet()
        {
        }
    }
}
