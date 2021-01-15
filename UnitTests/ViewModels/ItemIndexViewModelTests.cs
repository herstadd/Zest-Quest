using NUnit.Framework;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using Game.Models;
using Game.ViewModels;

namespace UnitTests.ViewModels
{
    public class ItemIndexViewModelTests
    {
        ItemIndexViewModel ViewModel;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            ViewModel = ItemIndexViewModel.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            ViewModel.Dataset.Clear();
        }

        [Test]
        public async Task ItemIndexViewModel_Read_Invalid_ID_Bogus_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.ReadAsync("bogus");

            // Reset

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ItemIndexViewModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemIndexViewModel_SortDataSet_Default_Should_Pass()
        {
            // Arrange

            // Add items into the list Z ordered
            var dataList = new List<ItemModel>
            {
                new ItemModel { Name = "z" },
                new ItemModel { Name = "m" },
                new ItemModel { Name = "a" }
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
        public async Task ItemIndexViewModel_CheckIfItemExists_Default_Should_Pass()
        {
            // Arrange

            // Add items into the list Z ordered
            var dataTest = new ItemModel { Name = "test" };
            await ViewModel.CreateAsync(dataTest);

            await ViewModel.CreateAsync(new ItemModel { Name = "z" });
            await ViewModel.CreateAsync(new ItemModel { Name = "m" });
            await ViewModel.CreateAsync(new ItemModel { Name = "a" });

            // Act
            var result = ViewModel.CheckIfExists(dataTest);

            // Reset

            // Assert
            Assert.AreEqual(dataTest.Id, result.Id);
        }

        [Test]
        public void ItemIndexViewModel_CheckIfItemExists_Invalid_Null_Should_Fail ()
        {
            // Arrange

            // Act
            var result = ViewModel.CheckIfExists(null);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task ItemIndexViewModel_CheckIfItemExists_InValid_Missing_Should_Fail()
        {
            // Arrange

            // Add items into the list Z ordered
            var dataTest = new ItemModel { Name = "test" };
            // Don't add it to the list await ViewModel.CreateAsync(dataTest);

            await ViewModel.CreateAsync(new ItemModel { Name = "z" });
            await ViewModel.CreateAsync(new ItemModel { Name = "m" });
            await ViewModel.CreateAsync(new ItemModel { Name = "a" });

            // Act
            var result = ViewModel.CheckIfExists(dataTest);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task ItemIndexViewModel_Message_Delete_Valid_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new ItemModel());

            // Get the item to delete
            var first = ViewModel.Dataset.FirstOrDefault();

            // Make a Delete Page
            var myPage = new Game.Views.ItemDeletePage(true);

            // Act
            MessagingCenter.Send(myPage, "Delete", first);

            var data = await ViewModel.ReadAsync(first.Id);

            // Reset

            // Assert
            Assert.AreEqual(null, data); // Item is removed
        }

        [Test]
        public async Task ItemIndexViewModel_Delete_Valid_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new ItemModel());

            var first = ViewModel.Dataset.FirstOrDefault();

            // Act
            var result = await ViewModel.DeleteAsync(first);
            var exists = await ViewModel.ReadAsync(first.Id);

            // Reset

            // Assert
            Assert.AreEqual(true, result);  // Delete returned pass
            Assert.AreEqual(null, exists);  // Should not exist so is null
        }

        [Test]
        public async Task ItemIndexViewModel_Delete_Invalid_Should_Fail()
        {
            // Arrange
            var data = new ItemModel
            {
                Id = "bogus"
            };

            // Act
            var result = await ViewModel.DeleteAsync(data);

            // Reset

            // Assert
            Assert.AreEqual(false, result);  // Delete returned fail
        }

        [Test]
        public async Task ItemIndexViewModel_Delete_Invalid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.DeleteAsync(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void ItemIndexViewModel_Message_Create_Valid_Should_Pass()
        {
            // Arrange

            // Make a new Item
            var data = new ItemModel();

            // Make a Delete Page
            var myPage = new Game.Views.ItemCreatePage(true);

            var countBefore = ViewModel.Dataset.Count();

            // Act
            MessagingCenter.Send(myPage, "Create", data);
            var countAfter = ViewModel.Dataset.Count();

            // Reset

            // Assert
            Assert.AreEqual(countBefore + 1, countAfter); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task ItemIndexViewModel_Message_Update_Valid_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new ItemModel());

            // Get the item to delete
            var first = ViewModel.Dataset.FirstOrDefault();
            first.Name = "test";

            // Make a Delete Page
            var myPage = new Game.Views.ItemUpdatePage(true);

            // Act
            MessagingCenter.Send(myPage, "Update", first);
            var result = await ViewModel.ReadAsync(first.Id);

            // Reset

            // Assert
            Assert.AreEqual("test", result.Name); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task ItemIndexViewModel_Message_SetDataSource_Valid_Should_Pass()
        {
            // Arrange

            // Get the item to delete
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
        public async Task ItemIndexViewModel_Message_WipeDataList_Valid_Should_Pass()
        {
            // Arrange

            // Make the page Page
            var myPage = new Game.Views.AboutPage(true);

            var data = new ItemModel();
            await ViewModel.CreateAsync(data);

            // Act
            MessagingCenter.Send(myPage, "WipeDataList", true);
            var countAfter = ViewModel.Dataset.Count();

            // Reset

            // Assert
            Assert.AreEqual(26, countAfter); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task ItemIndexViewModel_Update_Valid_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new ItemModel());

            // Find the First ID
            var first = ViewModel.Dataset.FirstOrDefault();

            // Make a new item
            first.Name = "New Item";
            first.Value = 1000;

            // Act
            var result = await ViewModel.UpdateAsync(first);

            // Reset

            // Assert
            Assert.AreEqual(true, result);  // Update returned Pas
            Assert.AreEqual("New Item", first.Name);  // The Name was updated
            Assert.AreEqual(1000, first.Value);  // The Value was updated
        }

        [Test]
        public async Task ItemIndexViewModel_Update_Invalid_Bogus_Should_Fail()
        {
            // Arrange

            // Update only updates what is in the list, so update on something that does not exist will fail
            var newData = new ItemModel();

            // Act
            var result = await ViewModel.UpdateAsync(newData);

            // Reset

            // Assert
            Assert.AreEqual(false, result);  // Update returned fail
        }

        [Test]
        public async Task ItemIndexViewModel_Update_Invalid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.UpdateAsync(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task ItemIndexViewModel_Create_Valid_Should_Pass()
        {
            // Arrange
            var data = new ItemModel
            {
                Name = "New Item"
            };

            // Act
            var result = await ViewModel.CreateAsync(data);

            // Reset

            // Assert
            Assert.AreEqual(true, result);  // Update returned Pass
        }

        [Test]
        public async Task ItemIndexViewModel_Create_InValid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.CreateAsync(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void ItemIndexViewModel_ExecuteLoadDataCommand_Valid_Should_Pass()
        {
            // Arrange

            // Clear the Dataset, so no records
            ViewModel.Dataset.Clear();

            // Act
            ViewModel.LoadDatasetCommand.Execute(null);

            // Reset

            // Assert
            Assert.AreEqual(true, ViewModel.Dataset.Count() > 0); // Check that there are rows of data
        }

        [Test]
        public async Task ItemIndexViewModel_ExecuteLoadDataCommand_InValid_Exception_Should_Fail()
        {
            // Arrange
            await ViewModel.CreateAsync(new ItemModel());

            var oldDataset = ViewModel.Dataset;

            // Null dataset will throw

            ViewModel.Dataset = null;

            // Act
            ViewModel.LoadDatasetCommand.Execute(null);

            // Reset
            ViewModel.Dataset = oldDataset;

            // Assert
            Assert.AreEqual(true, ViewModel.Dataset.Count() > 0); // Check that there are rows of data
        }

        [Test]
        public void ItemIndexViewModel_ExecuteLoadDataCommand_Valid_IsBusy_Should_Pass()
        {
            // Arrange

            // Setting IsBusy will have the Load skip
            ViewModel.IsBusy = true;

            // Clear the Dataset, so no records
            ViewModel.Dataset.Clear();

            // Act
            ViewModel.LoadDatasetCommand.Execute(null);
            var count = ViewModel.Dataset.Count();  // Remember how many records exist

            // Reset
            ViewModel.IsBusy = false;
            ViewModel.ForceDataRefresh();

            // Assert
            Assert.AreEqual(0, count); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task ItemIndexViewModel_SetDataSource_SQL_Should_Pass()
        {
            // Arrange

            // Act
            var result = await ViewModel.SetDataSource(1);

            // Reset

            // Assert
            Assert.AreEqual(true, result); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task ItemIndexViewModel_SetDataSource_Mock_Should_Pass()
        {
            // Arrange

            // Act
            var result = await ViewModel.SetDataSource(0);

            // Reset

            // Assert
            Assert.AreEqual(true, result); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task ItemIndexViewModel_CreateUpdateAsync_Valid_Create_Should_Pass()
        {
            // Arrange
            var data = new ItemModel
            {
                Name = "New Item"
            };

            // Act
            var result = await ViewModel.CreateUpdateAsync(data);

            // Reset

            // Assert
            Assert.AreEqual(true, result);  // Update returned Pass
        }

        [Test]
        public async Task ItemIndexViewModel_CreateUpdateAsync_Valid_Update_Should_Pass()
        {
            // Arrange
            var data = new ItemModel
            {
                Name = "New Item"
            };

            await ViewModel.CreateUpdateAsync(data);

            data.Name = "Updated";

            // Act
            var result = await ViewModel.CreateUpdateAsync(data);

            // Reset

            // Assert
            Assert.AreEqual(true, result);  // Update returned Pass
        }

        [Test]
        public async Task ItemIndexViewModel_CreateUpdateAsync_InValid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.CreateUpdateAsync(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);  // Update returned Pass
        }

        [Test]
        public void ItemIndexViewModel_Create_Sync_Valid_Update_Should_Pass()
        {
            // Arrange
            var data = new ItemModel
            {
                Name = "New Item"
            };

            // Act
            var result = ViewModel.Create_Sync(data);

            // Reset

            // Assert
            Assert.AreEqual(true, result);  // Update returned Pass
        }

        [Test]
        public void ItemIndexViewModel_Create_Sync_InValid_Null_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel.Create_Sync(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);  // Update returned Pass
        }

        [Test]
        public void ItemIndexViewModel_GetDefaultItemId_Unknown_Should_Fail()
        {
            // Arrange

            // Act
            var result = ViewModel.GetDefaultItemId(ItemLocationEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(null, result);  // Update returned Pass
        }

        [Test]
        public async Task ItemIndexViewModel_GetDefaultItemId_Head_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new ItemModel { Location = ItemLocationEnum.PrimaryHand});

            // Act
            var result = ViewModel.GetDefaultItemId(ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.AreNotEqual(null, result);  // Update returned Pass
        }

        [Test]
        public async Task ItemIndexViewModel_GetDefaultItem_Unknown_Should_Fail()
        {
            // Arrange
            await ViewModel.CreateAsync(new ItemModel { Location = ItemLocationEnum.PrimaryHand });

            // Act
            var result = ViewModel.GetDefaultItem(ItemLocationEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(null, result);  // Update returned Pass
        }

        [Test]
        public async Task ItemIndexViewModel_GetDefaultItem_Head_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new ItemModel { Location = ItemLocationEnum.PrimaryHand });

            // Act
            var result = ViewModel.GetDefaultItem(ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.AreNotEqual(null, result);  // Update returned Pass
        }

        [Test]
        public void ItemIndexViewModel_GetLocationItems_Head_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel.GetLocationItems(ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.AreNotEqual(null, result);  // Update returned Pass
        }

        [Test]
        public void ItemIndexViewModel_GetLocationItems_RightFinger_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel.GetLocationItems(ItemLocationEnum.RightFinger);

            // Reset

            // Assert
            Assert.AreNotEqual(null, result);  // Update returned Pass
        }

        [Test]
        public void ItemIndexViewModel_GetLocationItems_LeftFinger_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel.GetLocationItems(ItemLocationEnum.LeftFinger);

            // Reset

            // Assert
            Assert.AreNotEqual(null, result);  // Update returned Pass
        }
    }
}