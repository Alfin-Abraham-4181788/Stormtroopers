using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Index Page will return all the data to show
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// IndexModel constructor
        /// </summary>
        /// <param name="productService"></param>
        public IndexModel(JsonFileProductService productService)
        {
            //Product service of JsonFileProductService assigned to the local variable
            ProductService = productService;
        }

        /// <summary>
        /// Data Service
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Collection of the Data
        /// </summary>
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// REST OnGet, return all data
        /// </summary>
        public void OnGet()
        {
            //ProductService function  GetAllData will return result of All the products from database
            Products = ProductService.GetAllData();
        }
    }
}