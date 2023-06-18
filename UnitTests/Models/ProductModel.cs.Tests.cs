using NUnit.Framework;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// Product Model Unit test
    /// </summary>
    public class ProductModelTest
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

        #region toString
        /// <summary>
        /// Tostring validation
        /// </summary>
        [Test]
        public void toString_Valid_Test_Should_return_String()
        {
            // Arrange
            var newData = new ProductModel()
            {
                Id = "mercury",
                Title = "Test",
                Description = "This is a test.",
                Url = "https://spaceplace.nasa.gov/all-about-mercury/en/",
                Image = "https://spaceplace.nasa.gov/review/all-about-mercury/mercury1.en.jpg",
                Distance = (float) 0.39,
            };

            // Act
            var result = "{\"Id\":\"mercury\",\"Maker\":null,\"img\":\"https://spaceplace.nasa.gov/review/all-about-mercury/mercury1.en.jpg\",\"Url\":\"https://spaceplace.nasa.gov/all-about-mercury/en/\",\"Title\":\"Test\",\"Description\":\"This is a test.\",\"Ratings\":null,\"ProductType\":0,\"Quantity\":null,\"Price\":0,\"CommentList\":[],\"Distance\":0.39}";

            // Assert
            Assert.AreEqual(result, newData.ToString());
        }
        #endregion

        #region DeepCopy

        /// <summary>
        /// Tests whether Deep copy makes a new object
        /// </summary>
        [Test]
        public void DeepCopy_Valid_Should_Return_Copy_Of_Original()
        {
            // Arrange

            // Make a product model to copy from
            var originalData = new ProductModel()
            {
                Title = "original",
                Description = "original desc",
                Ratings = new int[] {1},
            };

            // Act

            // Make a copy of the data
            var result = originalData.DeepCopy();

            // Assert
            Assert.AreEqual(true, originalData.Title.Equals(result.Title));
            Assert.AreEqual(false, result.Ratings == null);
        }

        /// <summary>
        /// Tests whether Deep copy makes a new object
        /// </summary>
        [Test]
        public void DeepCopy_Valid_Null_Ratings_Should_Return_Copy_Of_Original()
        {
            // Arrange

            // Make a product model to copy from
            var originalData = new ProductModel()
            {
                Title = "original",
                Description = "original desc",
                Ratings = null,
            };

            // Act

            // Make a copy of the data
            var result = originalData.DeepCopy();

            // Assert
            Assert.AreEqual(true, originalData.Title.Equals(result.Title));
            Assert.AreEqual(true, result.Ratings == null);
        }

        /// <summary>
        /// Tests whether Deep copy makes a new object
        /// </summary>
        [Test]
        public void DeepCopy_Valid_Should_Return_New_Object()
        {
            // Arrange

            // Make a product model to copy from
            var originalData = new ProductModel()
            {
                Title = "original",
                Description = "original desc",
            };

            // Act

            // Make a copy of the data and change it
            var result = originalData.DeepCopy();
            result.Title = "new copy";

            // Assert
            Assert.AreEqual(false, originalData.Title.Equals(result.Title));
        }
        #endregion DeepCopy
    }
}