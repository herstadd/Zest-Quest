using NUnit.Framework;
using Game.ViewModels;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.Services;
using System.Threading.Tasks;
using Game.Models;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ViewModels
{
    public class ScoreIndexViewModelTests
    {
        ScoreIndexViewModel ViewModel;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            ViewModel = ScoreIndexViewModel.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            ViewModel.Dataset.Clear();
        }

        [Test]
        public async Task ScoreIndexViewModel_Read_Invalid_ID_Bogus_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.ReadAsync("bogus");

            // Reset

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ScoreIndexViewModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ScoreIndexViewModel_SortDataSet_Default_Should_Pass()
        {
            // Arrange

            // Add Scores into the list Z ordered
            var dataList = new List<ScoreModel>
            {
                new ScoreModel { Name = "z" },
                new ScoreModel { Name = "m" },
                new ScoreModel { Name = "a" }
            };

            // Act
            var result = ViewModel.SortDataset(dataList);

            // Reset

            // Assert
            Assert.AreEqual("a", result[0].Name);
            Assert.AreEqual("m", result[1].Name);
            Assert.AreEqual("z", result[2].Name);
        }

        [Test]
        public async Task ScoreIndexViewModel_CheckIfScoreExists_Default_Should_Pass()
        {
            // Arrange

            // Add Scores into the list Z ordered
            var dataTest = new ScoreModel { Name = "test" };
            await ViewModel.CreateAsync(dataTest);

            await ViewModel.CreateAsync(new ScoreModel { Name = "z" });
            await ViewModel.CreateAsync(new ScoreModel { Name = "m" });
            await ViewModel.CreateAsync(new ScoreModel { Name = "a" });

            // Act
            var result = ViewModel.CheckIfScoreExists(dataTest);

            // Reset

            // Assert
            Assert.AreEqual(dataTest.Id, result.Id);
        }

        [Test]
        public async Task ScoreIndexViewModel_CheckIfScoreExists_InValid_Missing_Should_Fail()
        {
            // Arrange

            // Add Scores into the list Z ordered
            var dataTest = new ScoreModel { Name = "test" };
            // Don't add it to the list await ViewModel.CreateAsync(dataTest);

            await ViewModel.CreateAsync(new ScoreModel { Name = "z" });
            await ViewModel.CreateAsync(new ScoreModel { Name = "m" });
            await ViewModel.CreateAsync(new ScoreModel { Name = "a" });

            // Act
            var result = ViewModel.CheckIfScoreExists(dataTest);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task ScoreIndexViewModel_Message_Delete_Valid_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new ScoreModel());

            // Get the Score to delete
            var first = ViewModel.Dataset.FirstOrDefault();

            // Make a Delete Page
            var myPage = new Game.Views.ScoreDeletePage(true);

            // Act
            MessagingCenter.Send(myPage, "Delete", first);

            var data = await ViewModel.ReadAsync(first.Id);

            // Reset

            // Assert
            Assert.AreEqual(null, data); // Score is removed
        }

        [Test]
        public void ScoreIndexViewModel_Message_Create_Valid_Should_Pass()
        {
            // Arrange

            // Make a new Score
            var data = new ScoreModel();

            // Make a Delete Page
            var myPage = new Game.Views.ScoreCreatePage(true);

            var countBefore = ViewModel.Dataset.Count();

            // Act
            MessagingCenter.Send(myPage, "Create", data);
            var countAfter = ViewModel.Dataset.Count();

            // Reset

            // Assert
            Assert.AreEqual(countBefore + 1, countAfter); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task ScoreIndexViewModel_Message_Update_Valid_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new ScoreModel());

            // Get the Score to delete
            var first = ViewModel.Dataset.FirstOrDefault();
            first.Name = "test";

            // Make a Delete Page
            var myPage = new Game.Views.ScoreUpdatePage(true);

            // Act
            MessagingCenter.Send(myPage, "Update", first);
            var result = await ViewModel.ReadAsync(first.Id);

            // Reset

            // Assert
            Assert.AreEqual("test", result.Name); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task ScoreIndexViewModel_Message_SetDataSource_Valid_Should_Pass()
        {
            // Arrange

            // Get the Score to delete
            var data = 3000; // Non existing value

            // Make the page Page
            var myPage = new Game.Views.AboutPage(true);

            // Act
            MessagingCenter.Send(myPage, "SetDataSource", data);
            var result = ViewModel.GetCurrentDataSource();

            // Reset
            await ViewModel.SetDataSource(0);

            // Assert
            Assert.AreEqual(0, result); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task ScoreIndexViewModel_Message_WipeDataList_Valid_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new ScoreModel());

            // Make the page Page
            var myPage = new Game.Views.AboutPage(true);

            var data = new ScoreModel();
            await ViewModel.CreateAsync(data);

            // Act
            MessagingCenter.Send(myPage, "WipeDataList", true);
            var countAfter = ViewModel.Dataset.Count();

            // Reset

            // Assert
            Assert.AreEqual(2, countAfter); // Count of 0 for the load was skipped
        }
    }
}