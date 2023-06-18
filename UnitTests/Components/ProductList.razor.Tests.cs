using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AngleSharp.Dom;

namespace UnitTests.Components
{
    /// <summary>
    /// Unit testing for Product List.razor
    /// </summary>
    public class ProductListTests : BunitTestContext
    {
        // Page Model variable
        public static PageModel pageModel;

        #region TestSetup
        /// <summary>
        /// Test Initialize function
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup
        /// <summary>
        /// Tests that the page renders properly and contains an expected sample build
        /// </summary>
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            // Act
            var page = RenderComponent<ProductList>();
            // Get the Cards retrned
            var result = page.Markup;
            // Assert
            Assert.AreEqual(false, result.Contains("The Quantified Cactus: An Easy Plant Soil Moisture Sensor"));
        }

        /// <summary>
        /// Tests the selectProduct button works as expected
        /// </summary>
        [Test]
        public void ProductList_ValidId_SelectProductId_Should_Return_Content()
        {
            // Arrange

            //Get an instance of ProductService
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            //Get the id variable for sun
            var id = "moreInfo_sun";

            //Get the base HTML page
            var page = RenderComponent<ProductList>();

            //Get the list of all buttons in the HTML document
            var buttonList = page.FindAll("Button");

            //Get the button that contains the id of the sun
            var button = buttonList.First(x => x.OuterHtml.Contains(id));

            //Act

            //Post action to get HTML from the click of the previously found button
            button.Click();

            //Get the rendered HTML from the button click
            var result = page.Markup;

            //Assert
            //Assert that the result contains section of what should be rendered
            Assert.AreEqual(true, result.Contains("The"));


        }

        #region SearchBar
        /// <summary>
        /// Search Input unit testing
        /// </summary>
        [Test]
        public void searchText_Should_Update_When_Text_Entered()
        {
            string inputText = "HelloSun";
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // Find searchbar
            IElement searchBar = page.FindAll("input").FirstOrDefault(x => x.Id.Equals("searchText"));

            // Act
            searchBar.Input(inputText);

            // Assert
            Assert.AreEqual(true, page.Markup.Contains(inputText));
        }

        /// <summary>
        /// unit testing to search any planets
        /// </summary>
        [Test]
        public void saveSearch_Should_Return_New_String()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            //Get the button element with the id of "search"
            IElement searchButton = page.FindAll("button").First(x => x.Id.Equals("search"));

            //Get the text input element with the ID of searchText
            IElement searchText = page.FindAll("input").FirstOrDefault(x => x.Id.Equals("searchText"));

            //Act

            //Post a change to the searchbox
            searchText.Change("sun");
        
            //Click the button with the changed data
            searchButton.Click();

            //Get the newly rendered HTML from the searchText change
            var result = page.Markup;

            //Assert

            //assert that the html contains the change
            Assert.AreEqual(true, result.Contains("sun"));
            //Assert that it is of type star
            Assert.AreEqual(true, result.Contains("Star"));

        }
        #endregion SearchBar

        /// <summary>
        /// Submitting unstared rating and increment the count
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Unstared_Should_Increment_Count_And_Check_Star()
        {
            // Arrange

            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            //locate mars info
            var id = "moreInfo_mars";
            var page = RenderComponent<ProductList>();

            //List of all buttons in html page
            var buttonList = page.FindAll("Button");

            //select mars button
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            //render html from the selected button click
            button.Click();

            //update page
            var buttonMarkup = page.Markup;

            //find all span html elements
            var starButtonList = page.FindAll("span");

            //second one is the vote button
            var preVoteCountSpan = starButtonList[2];

            //get current count of votes
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            //get the star button
            var starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));
            var preStarChange = starButton.OuterHtml;

            // Act

            starButton.Click();

            //render page after star click
            buttonMarkup = page.Markup;

            //find the star buttons again
            starButtonList = page.FindAll("span");

            //get the vote counts in the 3rd element
            var postVoteCountSpan = starButtonList[2];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            //Get last button
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            //save outerhtml to compare with the after click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // assert that there was no votes first, then compare after vote, then compare if they're equal
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }

        /// <summary>
        /// Submitting starred rating and increment the count
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Starred_Should_Increment_Count_And_Uncheck_Star()
        {
            // Arrange

            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            //locate earth info
            var id = "moreInfo_earth";
            var page = RenderComponent<ProductList>();

            //List of all buttons in html page
            var buttonList = page.FindAll("Button");

            //select mars button
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            //render html from the selected button click
            button.Click();

            //update page
            var buttonMarkup = page.Markup;

            //find all span html elements
            var starButtonList = page.FindAll("span");

            //second one is the vote button
            var preVoteCountSpan = starButtonList[2];

            //get current count of votes
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            //get the star button
            var starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));
            var preStarChange = starButton.OuterHtml;

            // Act

            starButton.Click();

            //render page after star click
            buttonMarkup = page.Markup;

            //find the star buttons again
            starButtonList = page.FindAll("span");

            //get the vote counts in the 3rd element
            var postVoteCountSpan = starButtonList[2];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            //Get last button
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            //save outerhtml to compare with the after click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // compare if they're equal
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }

        /// <summary>
        /// Unit testing for filter function
        /// </summary>
        [Test]
        public void objectFilter_SelectValid_Input_Should_Return_True()
        {
            // Arrange

            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            //save Id of the filter
            var id = "Planet";

            //Get html page
            var page = RenderComponent<ProductList>();

            //Get all instances of 'select'
            var selectList = page.FindAll("select");
            var select = selectList.First(m => m.OuterHtml.Contains(id));


            //Act

            //Post the value 'star' to the form
            select.Change("Star");

            //Get the new rendered HTML after the post
            var buttonMarkup = page.Markup;

            //Assert

            //Assertthat the values are saved in the markup
            Assert.AreEqual(true, buttonMarkup.Contains("sun"));
        }

        /// <summary>
        /// Unit testing for comment
        /// </summary>
        [Test]
        public void addComment_Valid_Text_Should_Return_True()
        {
            // Arrange

            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            //Save the id for mars
            var id = "mars";

            //Get the HTML page
            var page = RenderComponent<ProductList>();

            //Get list of all buttons
            var buttonList = page.FindAll("Button");

            //Get button with same id as mars
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            //Get the HTML page rendered from the click
            button.Click();

            //Update the page 
            var buttonMarkup = page.Markup;

            //instantiate card page
            var cardPage = RenderComponent<ProductList>();


            //get button with id as "AddComment"
            IElement searchButton = null;
            foreach (var element in page.FindAll("button"))
            {
                if (element.Id != null && element.Id.Equals("AddComment"))
                {
                    searchButton = element;
                }
            }

            //Get page after pressing "AddComment" button
            searchButton.Click();

            //Update the html
            var commentPage = page.Markup;

            //Get the element with the input tag with ID of "newComment"
            IElement newCommentBox = null;
            foreach (var element in page.FindAll("input"))
            {
                if (element.Id.Equals("newComment"))
                {
                    newCommentBox = element;
                }
            }

            //Get the element for keep comment button with ID keepComment
            IElement newCommentKeep = null;
            foreach (var element in page.FindAll("button"))
            {
                if (element.Id != null && element.Id.Equals("keepComment"))
                {
                    newCommentKeep = element;
                }
            }

            //Act

            //Post the comment to add
            newCommentBox.Change("blaaah");
            newCommentKeep.Click();

            //Get updated HTML markup page after the post
            var res = page.Markup;

            //Assert
            //Assert that the HTML rendered contains the newly added comment
            Assert.AreEqual(true, res.Contains("blaaah"));
        }

        #region Sort
        /// <summary>
        /// Test that sort is sorting the items alphabetically
        /// </summary>
        [Test]
        public void sortAlphabetically_Valid_Should_Return_Alphabetically_Sorted_Items()
        {
            // Arrange

            // Get first alphabetical item for later
            var firstItem = TestHelper.ProductService.GetAllData().OrderBy(x => x.Title).First();

            // Get the HTML page
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // Get button
            IElement sortAlphabetically = page.FindAll("input").FirstOrDefault(x=> x.Id.Equals("sortAlphabetically"));

            // Act
            sortAlphabetically.Click();

            // Assert
            Assert.AreEqual(true, page.FindAll("div").FirstOrDefault(x => x.ClassName.Equals("card-body")).ToMarkup().Contains(firstItem.Title));
        }

        /// <summary>
        /// Test that sort is sorting the items reverse alphabetically
        /// </summary>
        [Test]
        public void sortReverseAlphabetically_Valid_Should_Return_Reverse_Alphabetically_Sorted_Items()
        {
            // Arrange

            // Get first reverse alphabetical item for later
            var firstItem = TestHelper.ProductService.GetAllData().OrderByDescending(x => x.Title).First();

            // Get the HTML page
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // Get button to sort reverse alphabetically
            IElement sortReverseAlphabetically = page.FindAll("input").FirstOrDefault(x => x.Id.Equals("sortReverseAlphabetically"));

            // Act
            sortReverseAlphabetically.Click();

            // Assert
            Assert.AreEqual(true, page.FindAll("div").FirstOrDefault(x => x.ClassName.Equals("card-body")).ToMarkup().Contains(firstItem.Title));
        }

        /// <summary>
        /// Test that sort is sorting the items by distance
        /// </summary>
        [Test]
        public void sortDistance_Valid_Should_Return_Sorted_By_Distance_Items()
        {
            // Arrange

            // Get first reverse alphabetical item for later
            var firstItem = TestHelper.ProductService.GetAllData().OrderBy(x => x.Distance).First();

            // Get the HTML page
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var page = RenderComponent<ProductList>();

            // The page defaults to sorting the items by distance. To make sure the page is actually re-sorting the items, we first need to sort them by a different order first
            IElement sortAlphabetically = page.FindAll("input").FirstOrDefault(x => x.Id.Equals("sortAlphabetically"));
            sortAlphabetically.Click();

            // now sort by distance
            IElement sortByDistance = page.FindAll("input").FirstOrDefault(x => x.Id.Equals("sortByDistance"));

            // Act
            sortByDistance.Click();

            // Assert
            Assert.AreEqual(true, page.FindAll("div").FirstOrDefault(x => x.ClassName.Equals("card-body")).ToMarkup().Contains(firstItem.Title));
        }
        #endregion Sort
    }
}