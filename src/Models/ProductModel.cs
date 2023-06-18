using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using ContosoCrafts.WebSite.Validation;
using System.Net.NetworkInformation;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// ProductModel class
    /// </summary>
    public class ProductModel
    {
        //Getter and Setter of Id
        public string Id { get; set; }
        
        //Getter and Setter of Maker
        public string Maker { get; set; }

        [StringLength(maximumLength: 90, MinimumLength = 5, ErrorMessage = "The Image should have a length of more than {2} and less than {1}")]
        [Required(ErrorMessage = "Image is required")]
        [DataType(DataType.Url)]
        [ValidUrl()]
        // Regex for common image file extensions
        [RegularExpression(@"([^\\s]+(\\.(?i)(jpe?g|png|gif|bmp))$)", ErrorMessage = "That does not end in a common image file extension")]
        [JsonPropertyName("img")]
        //Getter and Setter of Image
        public string Image { get; set; }

        [StringLength(maximumLength: 90, MinimumLength = 3, ErrorMessage = "The Url should have a length of more than {2} and less than {1}")]
        [DataType(DataType.Url)]
        [ValidUrl()]
        
        //Getter and Setter of Url
        public string Url { get; set; }
        
        [StringLength (maximumLength: 80, MinimumLength = 3, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        
        //Getter and Setter of Title
        public string Title { get; set; }

        [StringLength(maximumLength: 470, MinimumLength = 10, ErrorMessage = "The Description should have a length of more than {2} and less than {1}")]

        //Getter and Setter of Description
        public string Description { get; set; }

        //Getter and Setter of Ratings
        public int[] Ratings { get; set; }

        //Getter and Setter of ProductType

        public ProductTypeEnum ProductType { get; set; }

        //Getter and Setter of Quantity
        public string Quantity { get; set; }

        [Range (-1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]

        //Getter and Setter of Price
        public int Price { get; set; }

        // Store the Comments entered by the users on this product
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();


        // Getter and Setter of Distance
        [Range (0, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public float Distance { get; set; }

        //Override function for string
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

        public ProductModel DeepCopy()
        {
            // New ProductModel to copy everything to
            ProductModel deepCopyModel = new ProductModel();
            deepCopyModel.Id = this.Id;
            deepCopyModel.Maker = this.Maker;
            deepCopyModel.Image = this.Image;
            deepCopyModel.Url = this.Url;
            deepCopyModel.Title = this.Title;
            deepCopyModel.Description = this.Description;
            deepCopyModel.ProductType = this.ProductType;
            deepCopyModel.Quantity = this.Quantity;
            deepCopyModel.Price = this.Price;
            deepCopyModel.CommentList = this.CommentList;
            deepCopyModel.Distance = this.Distance;

            if (this.Ratings == null)
            {
                return deepCopyModel;
            }

            deepCopyModel.Ratings = new int[this.Ratings.Length];
            this.Ratings.CopyTo(deepCopyModel.Ratings, 0);
            return deepCopyModel;
        }
    }
}