using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite
{
    public class ExploreModel : PageModel
    {
        /// <summary>
        /// ExploreModel constructor
        /// </summary>
        /// <param name="productService"></param>
        public ExploreModel(JsonFileProductService productService)
        {
            //Product service of JsonFileProductService assigned to the local variable
            ProductService = productService;
        }

        /// <summary>
        /// Data Service getter
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Collection of the Data
        /// </summary>
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// Initializes page when page is requested by GET
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}
