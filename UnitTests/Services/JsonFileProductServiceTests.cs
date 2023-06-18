using System.Linq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.AddRating
{
    /// <summary>
    /// Test the functionality of the methods in JsonFileProductServiceTest
    /// </summary>
    public class JsonFileProductServiceTests
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

        #region AddRating
        /// <summary>
        /// REST Get Products data
        /// POST a valid rating
        /// Test that the last data that was added was added correctly
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Id_Rating_null_Should_Return_new_Array()
        {
            // Arrange
            // Get the Last data item
            var data = TestHelper.ProductService.GetAllData().Last();

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, 0);

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// REST POST data that doesn't fit the constraints defined in function
        /// Test if it Adds
        /// Returns False because it wont add
        /// </summary>
        [Test]
        public void AddRating_Invalid_Product_ID_Not_Present_Should_Return_False()
        {
            // Arrange

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating("1000", 5);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// REST get result of false ID entered data
        /// Checks if the result equals the added data
        /// Should return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_ID_Null_Should_Return_False()
        {
            // Arrange

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// REST Gets First Node of original data
        /// Caches the length of how many votes were made
        /// POST a new rating of 5 stars
        /// Gets first node of new data
        /// Checks origional data length against the new data length +1
        /// Checks if last data point was the one that was added
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Rating_5_Should_Return_True()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            // Store the original Rating list length
            var countOriginal = data.Ratings.Length;

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            // Get the updated First data item
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        /// <summary>
        /// REST get original data list
        /// Post rating to the data where number of stars are invalid
        /// Resturns false for invalid data point
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Rating_more_5_Should_Return_False()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// REST get original ratings
        /// POST a rating against the constraint <=0
        /// Compares rating to see if added corrctly
        /// Should return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Rating_less_than_0_Should_Return_False()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, -2);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// REST get original data
        /// Cache length of data
        /// POST new valid data point
        /// GET new data
        /// Test if equal count is original + 1, and new data should be equal
        /// Test if the correct valid data point was added
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Rating_greater_than_0_Should_Return_True()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            // Store the original Rating list length for comparison later
            var countOriginal = data.Ratings.Length;

            // Act
            // Store the result of the AddRating method (which is being tested)
            var result = TestHelper.ProductService.AddRating(data.Id, 1);
            // Get the updated First data item for comparison
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(1, dataNewList.Ratings.Last());
        }
        #endregion AddRating

        #region UpdateData
        /// <summary>
        /// Create new default data object assigning parameters with invalid ID
        /// Test if correctly added
        /// Should return null
        /// </summary>
        [Test]
        public void Update_Data_Invalid_Product_Id_Should_Return_True()
        {
            // Arrange
            // A new product with an invalid Id (aka, not already existing in the datastore)
            var newData = new ProductModel()
            {
                Id = "testing",
                Title = "Test",
                Description = "This is a test.",
                Url = "https://spaceplace.nasa.gov/all-about-mercury/en/",
                Image = "https://spaceplace.nasa.gov/review/all-about-mercury/mercury1.en.jpg",
            };

            //Act
            // Store the result of the UpdateData method (which is being tested)
            var result = TestHelper.ProductService.UpdateData(newData);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Create new default data object assigning parameters with valid ID
        /// GET the data list
        /// Test if correctly added
        /// Should return true
        /// </summary>
        [Test]
        public void Update_Data_Valid_Product_Id_Should_Return_True()
        {
            // Arrange
            // A new product with an valid Id (aka, already existing in the datastore)
            var newData = new ProductModel()
            {
                Id = "mercury",
                Title = "Test",
                Description = "This is a test.",
                Url = "https://spaceplace.nasa.gov/all-about-mercury/en/",
                Image = "https://spaceplace.nasa.gov/review/all-about-mercury/mercury1.en.jpg",
            };

            //Act
            // Store the result of the UpdateData method (which is being tested)
            TestHelper.ProductService.UpdateData(newData);
            // Store the updated product for comparison
            var updatedData = TestHelper.ProductService.GetAllData()
                .FirstOrDefault(x => x.Id.Equals(newData.Id));

            // Assert
            Assert.AreEqual(updatedData.Title, newData.Title);
            Assert.AreEqual(updatedData.Description, newData.Description);
        }
        #endregion UpdateData

        #region DeleteData
        /// <summary>
        /// GET the data list
        /// POST delete data
        /// Check if deleted data is in result
        /// Should return true
        /// </summary>
        [Test]
        public void DeleteData_Valid_Product_Id_Should_Return_True()
        {
            // Arrange
            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            // Store the result of the DeleteData method (which is being tested)
            var result = TestHelper.ProductService.DeleteData(data.Id);

            // Assert
            Assert.AreEqual(true, result.Id.Contains(data.Id));
        }
        #endregion

        #region CreateData
        /// <summary>
        /// GET original data list
        /// GET new data and POST a new ProductService object with default constructor parameters
        /// Cache lengths of original data list and new data list
        /// compared length should return false
        /// </summary>
        [Test]
        public void CreateData_Adding_Should_Return_Larger_ProductList()
        {
            // Arrange
            // Get the count of the current product list
            var oldProductCount = TestHelper.ProductService.GetAllData().Count();
            // Create dummy data to insert
            var dummyData = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Dummy Test Data",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // Act
            // Store the result of the CreateData method (which is being tested)
            var result = TestHelper.ProductService.CreateData(dummyData);
            // Store the count of the old product list for comparison later
            int newProductCount = TestHelper.ProductService.GetAllData().Count();

            // Reset

            // Assert
            Assert.AreEqual(true, newProductCount > oldProductCount);
        }
        #endregion
    }
}