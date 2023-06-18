using Bunit.Extensions;
using ContosoCrafts.WebSite;
using NUnit.Framework;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Unit testing for Explore Tests
    /// </summary>
    public class ExploreTests
    {
        // Database MiddleTier
        #region TestSetup
        public static ExploreModel pageModel;

        /// <summary>
        /// Initialize of Test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ExploreModel(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Checking whether page initializes products correctly with OnGet()
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(false, pageModel.Products.IsNullOrEmpty());
        }
        #endregion OnGet
    }
}