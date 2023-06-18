using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
    ///<summary>
    /// Privacy Page
    ///<summary>
{
    public class PrivacyModel : PageModel
    {
        //logger for index model to render
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Constructor taking input Logger
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Customize onGet() method for privacy page.
        /// </summary>
        public void OnGet()
        {
        }
    }
}
