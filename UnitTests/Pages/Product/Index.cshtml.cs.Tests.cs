using Bunit.Extensions;
using ContosoCrafts.WebSite.Pages.Product;
using NUnit.Framework;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Unit testing for Index Tests
    /// </summary>
    public class IndexTests
    {
        // Database MiddleTier
        #region TestSetup
        public static IndexModel pageModel;

        /// <summary>
        /// Initialize of Test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        /// <summary>
        /// Checking whether product user want is there in result or not.
        /// </summary>
        #region OnGet
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