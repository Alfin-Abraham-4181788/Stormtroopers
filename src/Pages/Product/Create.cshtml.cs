using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;


namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Create Page
    /// </summary>
    public class CreateModel : PageModel
    {
        /// <summary>
        /// Data middle tier
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// The data to show, bind to it for the post
        /// </summary>
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            ProductService.CreateData(Product);

            return RedirectToPage("./Index");
        }

        /// <summary>
        /// REST Get request, create ProductModel with default values to be edited before adding to datastore
        /// </summary>
        /// <param name="id"></param>
         public void OnGet()
        {
            Product = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "",
                Description = "",
                Url = "",
                Image = "",
            };

        }
    }
}