using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;

using Game.ViewModels;
using Game.Models;

namespace UnitTests.ViewModels
{
    public class MonsterIndexViewModelTests
    {
        MonsterIndexViewModel ViewModel;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            ViewModel = MonsterIndexViewModel.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            ViewModel.Dataset.Clear();
        }

        [Test]
        public async Task MonsterIndexViewModel_Read_Invalid_ID_Bogus_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.ReadAsync("bogus");

            // Reset

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void MonsterIndexViewModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterIndexViewModel_SortDataSet_Default_Should_Pass()
        {
            // Arrange

            // Add Monsters into the list Z ordered
            var dataList = new List<MonsterModel>
            {
                new MonsterModel { Name = "z" },
                new MonsterModel { Name = "m" },
                new MonsterModel { Name = "a" }
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
        public async Task MonsterIndexViewModel_CheckIfMonsterExists_Default_Should_Pass()
        {
            // Arrange

            // Add Monsters into the list Z ordered
            var dataTest = new MonsterModel { Name = "test" };
            await ViewModel.CreateAsync(dataTest);

            await ViewModel.CreateAsync(new MonsterModel { Name = "z" });
            await ViewModel.CreateAsync(new MonsterModel { Name = "m" });
            await ViewModel.CreateAsync(new MonsterModel { Name = "a" });

            // Act
            var result = ViewModel.CheckIfExists(dataTest);

            // Reset

            // Assert
            Assert.AreEqual(dataTest.Id, result.Id);
        }

        [Test]
        public async Task MonsterIndexViewModel_CheckIfMonsterExists_InValid_Missing_Should_Fail()
        {
            // Arrange

            // Add Monsters into the list Z ordered
            var dataTest = new MonsterModel { Name = "test" };
            // Don't add it to the list await ViewModel.CreateAsync(dataTest);

            await ViewModel.CreateAsync(new MonsterModel { Name = "z" });
            await ViewModel.CreateAsync(new MonsterModel { Name = "m" });
            await ViewModel.CreateAsync(new MonsterModel { Name = "a" });

            // Act
            var result = ViewModel.CheckIfExists(dataTest);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void MonsterIndexViewModel_CheckIfExists_InValid_Null_Should_Return_Null()
        {
            // Arrange

            // Act
            var result = ViewModel.CheckIfExists(null);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task MonsterIndexViewModel_Message_Delete_Valid_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new MonsterModel());

            // Get the Monster to delete
            var first = ViewModel.Dataset.FirstOrDefault();

            // Make a Delete Page
            var myPage = new Game.Views.MonsterDeletePage(true);

            // Act
            MessagingCenter.Send(myPage, "Delete", first);

            var data = await ViewModel.ReadAsync(first.Id);

            // Reset

            // Assert
            Assert.AreEqual(null, data); // Monster is removed
        }

        [Test]
        public void MonsterIndexViewModel_Message_Create_Valid_Should_Pass()
        {
            // Arrange

            // Make a new Monster
            var data = new MonsterModel();

            // Make a Delete Page
            var myPage = new Game.Views.MonsterCreatePage(true);

            var countBefore = ViewModel.Dataset.Count();

            // Act
            MessagingCenter.Send(myPage, "Create", data);
            var countAfter = ViewModel.Dataset.Count();

            // Reset

            // Assert
            Assert.AreEqual(countBefore + 1, countAfter); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task MonsterIndexViewModel_Message_Update_Valid_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new MonsterModel());

            // Get the Monster to delete
            var first = ViewModel.Dataset.FirstOrDefault();
            first.Name = "test";

            // Make a Delete Page
            var myPage = new Game.Views.MonsterUpdatePage(true);

            // Act
            MessagingCenter.Send(myPage, "Update", first);
            var result = await ViewModel.ReadAsync(first.Id);

            // Reset

            // Assert
            Assert.AreEqual("test", result.Name); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task MonsterIndexViewModel_Message_SetDataSource_Valid_Should_Pass()
        {
            // Arrange

            // Get the Monster to delete
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
        public async Task MonsterIndexViewModel_Message_WipeDataList_Valid_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new MonsterModel());

            // Make the page Page
            var myPage = new Game.Views.AboutPage(true);

            var data = new MonsterModel();
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