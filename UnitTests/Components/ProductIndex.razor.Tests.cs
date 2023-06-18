using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Components
{
    /// <summary>
    /// Unit testing for Product Index Tests
    /// </summary>
    public class ProductIndexTests : BunitTestContext
    { 
    #region TestSetup

        /// <summary>
        /// Test set up Intialize
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        /// <summary>
        /// Product Index testing by default it should Return title
        /// </summary>
        [Test]
        public void ProductIndex_Default_Should_Return_Content()
        {
            //Getting product service file in to services
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            //Render Product Index Page
            var page = RenderComponent<ProductIndex>();

            // Get the Markup to use for the Assert
            var result = page.Markup;

            //checking the value of Title for a particular Id.
            // Assert
            Assert.AreEqual(true, result.Contains("Earth"));
        }
    }
}