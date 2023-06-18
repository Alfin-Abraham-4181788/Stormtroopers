using ContosoCrafts.WebSite.Pages.Product;
using NUnit.Framework;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Unit testing for Read Tests
    /// </summary>
    public class ReadTests
    {
        // Database MiddleTier
        #region TestSetup
        public static ReadModel pageModel;
        /// <summary>
        /// Initialize of Test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
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
            pageModel.OnGet("venus");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Venus", pageModel.Product.Title);
        }
        #endregion OnGet
    }
}