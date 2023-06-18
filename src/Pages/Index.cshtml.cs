using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    ///<summary>
    /// Index Page
    ///<summary>
    public class IndexModel : PageModel
    {   
        ///logger for index model to render
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Constructor taking two input Logger and json file product service as constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            // Stores the passed logger
            _logger = logger;
            // Stores the passed JsonProductService for the page to get data from
            ProductService = productService;
        }

        /// <summary>
        /// Data Middle Tier
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Getter and Setter method for Products
        /// </summary>
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// Customize onGet() method for products Get All Data
        /// </summary>
        public void OnGet()
        {
            // Load a list of all the products to use in the page
            Products = ProductService.GetAllData();
        }
    }
}