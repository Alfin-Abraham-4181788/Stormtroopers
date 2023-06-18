using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Extends the PageModel class to create a page for reporting errors
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        /// <summary>
        /// Getter and Setter of RequesstId
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Checks if RequestId is not empty or null
        /// </summary>
        public bool ShowRequestId => (string.IsNullOrEmpty(RequestId) == false);

        /// <summary>
        /// Defines the logger for the error page
        /// </summary>
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// Initializes the error page model with the handed logger
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Place to put initializers and other activities to occur when the page is requested
        /// </summary>
        public void OnGet()
        {
            // The null-coalescing operator, ??, returns the left if the left is not null. Otherwise, it returns the right
            // 'Current?' allows Acitvity.Current to be null while checking the Id attribute, it will simply return null for Id
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}