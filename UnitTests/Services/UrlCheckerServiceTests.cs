using NUnit.Framework;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Pages.Product.Services
{
    /// <summary>
    /// Test the functionality of the methods in JsonFileProductServiceTest
    /// </summary>
    public class UrlCheckerServiceTests
    {

        #region TestSetup
        /// <summary>
        /// Default Constructor
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region ValidateUrl
        /// <summary>
        /// REST Get Products data
        /// POST a valid rating
        /// Test that the last data that was added was added correctly
        /// </summary>
        [Test]
        public void ValidateUrl_Valid_Absolute_URL_Should_Return_True()
        {
            // Arrange

            // Act
            var result = UrlCheckerService.ValidateUrl("https://www.example.com/");

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Invalid Informal url unit testing
        /// </summary>
        [Test]
        public void ValidateUrl_Invalid_Informal_URL_Should_Return_False()
        {
            // Arrange

            // Act
            var result = UrlCheckerService.ValidateUrl("www.example.com/");

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Dead url unit testing
        /// </summary>
        [Test]
        public void ValidateUrl_Invalid_Dead_URL_Should_Return_False()
        {
            // Arrange

            // Act
            var result = UrlCheckerService.ValidateUrl("http://www.asdfghjkl.com/");

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion ValidateUrl
    }
}