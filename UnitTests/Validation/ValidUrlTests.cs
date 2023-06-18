using NUnit.Framework;
using ContosoCrafts.WebSite.Validation;
using System.ComponentModel.DataAnnotations;

namespace UnitTests.Validations
{
    /// <summary>
    /// Product Model Unit test
    /// </summary>
    public class ValidUrlTests
    {
        #region TestSetup
        /// <summary>
        /// Test Setup
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region isValid
        /// <summary>
        /// Test if null value returns null
        /// </summary>
        [Test]
        public void isValid_Invalid_Null_Should_Return_False()
        {
            // Arrange
            var validation = new ValidUrl();
            var context = new ValidationContext(TestHelper.PageContext);

            // Act
            var result = validation.IsValidPublicAccess(null, context);

            // Assert
            Assert.AreEqual(false, result == ValidationResult.Success);
        }

        [Test]
        public void isValid_Invalid_Url_Should_Return_False()
        {
            // Arrange
            var validation = new ValidUrl();
            var context = new ValidationContext(TestHelper.PageContext);

            // Act
            var result = validation.IsValidPublicAccess("www.example.com", context);

            // Assert
            Assert.AreEqual(false, result == ValidationResult.Success);
        }

        [Test]
        public void isValid_Valid_Url_Should_Return_True()
        {
            // Arrange
            var validation = new ValidUrl();
            var context = new ValidationContext(TestHelper.PageContext);

            // Act
            var result = validation.IsValidPublicAccess("https://www.example.com", context);

            // Assert
            Assert.AreEqual(true, result == ValidationResult.Success);
        }
        #endregion
    }
}
