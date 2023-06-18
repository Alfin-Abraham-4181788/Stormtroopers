using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    ///  Read Page Model
    /// </summary>
    public class ReadModel : PageModel
    {
        /// <summary>
        /// Data Middle Tier
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Constructor for ReadModel by taking data Middle Tier as a parameter
        /// </summary>
        /// <param name="productService"></param>
        public ReadModel(JsonFileProductService productService)
        {
            // configuring productService from JsonFileProductService into local variable
            ProductService = productService;
        }
        public ProductModel Product;

        /// <summary>
        /// Customise OnGet method to retrieve all the data of specific id.
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }
    }
}
