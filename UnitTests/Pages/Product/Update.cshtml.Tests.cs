
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Provides unit testing for the Update page
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup
        // Declare the model of the Update page to be used in unit tests
        public static UpdateModel pageModel;

        [SetUp]
        /// <summary>
        /// Initializes mock Update page model for testing.
        /// </summary>
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        /// <summary>
        /// Test that's loading the update page returns a non-empty list of products
        /// </summary>
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("venus");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Venus", pageModel.Product.Title);
        }
        #endregion OnGet

        #region OnPost
        [Test]
        /// <summary>
        /// Test that checks update functionality
        /// </summary>
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "venus_planet",
                Title = "Planet Venus",
                Description = "2nd planet",
                Url = "https://solarsystem.nasa.gov/planets/venus/overview/",
                Image = "https://solarsystem.nasa.gov/system/news_items/list_view_images/1519_688_Venus_list.jpg"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        [Test]
        /// <summary>
        /// Test that checks update functionality's error state
        /// </summary>
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            // Store the ActionResult of the post? TODO: better understand this line of code or ask professor
            var result = pageModel.OnPost() as ActionResult;
            // Store whether the ModelState is valid for later assert
            var stateIsValid = pageModel.ModelState.IsValid;

            // Reset
            // This should remove the error we added
            pageModel.ModelState["bogus"].Errors.Clear();

            // Assert
            Assert.AreEqual(false, stateIsValid);
        }
        #endregion OnPost
    }
}