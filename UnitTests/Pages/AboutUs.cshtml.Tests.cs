using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.AboutUs
{

    /// <summary>
    /// Unit testing for AboutUs Page
    /// </summary>
    public class AboutUsTests
    {
        #region TestSetup
        //Create local AboutUs Model to test functions.
        public static AboutUsModel pageModel;

        /// <summary>
        /// Set up test intialize
        /// </summary>        
        [SetUp]
        public void TestInitialize()
        {
            //Create mock object of AboutUSmodel logger
            var MockLoggerDirect = Mock.Of<ILogger<AboutUsModel>>();

            //Initialize the AboutUs model.
            pageModel = new AboutUsModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Checking AboutUs page working
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion OnGet
    }
}