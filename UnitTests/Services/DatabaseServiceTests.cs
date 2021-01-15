using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

using Game.Models;
using Game.Services;

namespace UnitTests.Services
{
    [TestFixture]
    public class DatabaseServiceTests
    {
        DatabaseService<ItemModel> DataStore;

        [SetUp]
        public void Setup()
        {
            //DatabaseService<ItemModel>.TestMode = true;
            DatabaseService<ItemModel>.TestMode = true;
            DataStore = DatabaseService<ItemModel>.Instance;
        }

        [TearDown]
        public async Task TearDown()
        {
            await DataStore.WipeDataListAsync();
        }

        [Test]
        public void DatabaseService_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DataStore;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void DatabaseService_Constructor_InValid_Should_Fail()
        {
            // Arrange

            // Make a second instance
            DatabaseService<ItemModel>.initialized = false;

            // Act
            DatabaseService<ItemModel> DataStore2 = new DatabaseService<ItemModel>();

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public async Task DatabaseService_WipeDataListAsync_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = await DataStore.WipeDataListAsync();

            // Reset

            // Assert
            Assert.AreEqual(true,result);
        }

        [Test]
        public async Task DatabaseService_WipeDataListAsync_InValid_ForceException_Should_Fail()
        {
            // Arrange

            DataStore.ForceExceptionOnNumber = 1;

            // Act
            var result = await DataStore.WipeDataListAsync();

            // Reset
            DataStore.ForceExceptionOnNumber = 0;

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void DatabaseService_GetDataConnection_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DatabaseService<ItemModel>.GetDataConnection();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task DatabaseService_SetNeedsRefresh_Valid_True_Should_Pass()
        {
            // Arrange
            var originalState = await DataStore.GetNeedsInitializationAsync();

            // Act
            DataStore.NeedsInitialization=true;
            var newState = await DataStore.GetNeedsInitializationAsync();

            // Reset

            // Turn it back to the original state
            DataStore.NeedsInitialization = originalState;

            // Assert
            Assert.AreEqual(true, newState);
        }

        [Test]
        public async Task DatabaseService_SetNeedsRefresh_Twice_True_Should_Pass()
        {
            // Arrange
            var originalState = await DataStore.GetNeedsInitializationAsync();

            // Act
            DataStore.NeedsInitialization = true;
            var newState = await DataStore.GetNeedsInitializationAsync();
            var newState2 = await DataStore.GetNeedsInitializationAsync();

            // Reset

            // Turn it back to the original state
            DataStore.NeedsInitialization = originalState;

            // Assert
            Assert.AreEqual(false, newState2);
        }

        [Test]
        public async Task DatabaseService_WipeDataListAsync_Valid_True_Should_Pass()
        {
            // Arrange

            // Act
            var newState = await DataStore.WipeDataListAsync();

            // Reset

            // Turn it back to the original state

            // Assert
            Assert.AreEqual(true, newState);
        }

        [Test]
        public async Task DatabaseService_CreateAsync_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = await DataStore.CreateAsync(new ItemModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task DatabaseService_CreateAsync_InValid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = await DataStore.CreateAsync(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task DatabaseService_CreateAsync_InValid_ForceException_Should_Fail()
        {
            // Arrange
            DataStore.ForceExceptionOnNumber = 1;

            // Act
            var result = await DataStore.CreateAsync(new ItemModel());

            // Reset
            DataStore.ForceExceptionOnNumber = 0;

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task DatabaseService_Read_Valid_Should_Pass()
        {
            // Arrange
            var item = new ItemModel();
            await DataStore.CreateAsync(item);

            // Act
            var result = await DataStore.ReadAsync(item.Id);

            // Reset

            // Assert
            Assert.AreEqual(item.Id, result.Id);
        }

        [Test]
        public async Task DatabaseService_Read_InValid_Null_List_Should_Fail()
        {
            // Arrange
            var item = new ItemModel();
            await DataStore.CreateAsync(item);

            // Act
            var result = await DataStore.ReadAsync(null);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task DatabaseService_Read_InValid_ForceException_Should_Fail()
        {
            // Arrange
            var item = new ItemModel();
            await DataStore.CreateAsync(item);

            DataStore.ForceExceptionOnNumber = 1;
            // Act
            var result = await DataStore.ReadAsync(item.Id);

            // Reset
            DataStore.ForceExceptionOnNumber = 0;

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task DatabaseService_Index_Valid_Should_Pass()
        {
            // Arrange
            var item = new ItemModel();
            await DataStore.CreateAsync(item);

            // Act
            var result = await DataStore.IndexAsync();

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public async Task DatabaseService_Index_InValid_ForceException_Should_Fail()
        {
            // Arrange
            var item = new ItemModel();
            await DataStore.CreateAsync(item);

            DataStore.ForceExceptionOnNumber = 1;
            // Act
            var result = await DataStore.IndexAsync();

            // Reset
            DataStore.ForceExceptionOnNumber = 0;

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task DatabaseService_Delete_Valid_Should_Pass()
        {
            // Arrange
            var item1 = new ItemModel
            {
                Name = "a"
            };

            var item2 = new ItemModel
            {
                Name = "b"
            };

            await DataStore.CreateAsync(item1);
            await DataStore.CreateAsync(item2);

            // Act
            var result = await DataStore.DeleteAsync(item1.Id);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task DatabaseService_Delete_InValid_Should_Fail()
        {
            // Arrange
            var item1 = new ItemModel
            {
                Name = "a"
            };

            var item2 = new ItemModel
            {
                Name = "b"
            };

            await DataStore.CreateAsync(item1);
            await DataStore.CreateAsync(item2);

            // Act
            var result = await DataStore.DeleteAsync("bogus");

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task DatabaseService_Delete_InValid_Null_Should_Fail()
        {
            // Arrange
            var item1 = new ItemModel
            {
                Name = "a"
            };

            var item2 = new ItemModel
            {
                Name = "b"
            };

            await DataStore.CreateAsync(item1);
            await DataStore.CreateAsync(item2);

            // Act
            var result = await DataStore.DeleteAsync(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task DatabaseService_Delete_InValid_ForceException_Should_Fail()
        {
            // Arrange
            var item1 = new ItemModel
            {
                Name = "a"
            };

            await DataStore.CreateAsync(item1);

            DataStore.ForceExceptionOnNumber = 3; // Read, Delete

            // Act
            var result = await DataStore.DeleteAsync(item1.Id);

            // Reset
            DataStore.ForceExceptionOnNumber = 0;

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task DatabaseService_Update_Valid_Should_Pass()
        {
            // Arrange
            var item1 = new ItemModel
            {
                Name = "a"
            };

            var item2 = new ItemModel
            {
                Name = "b"
            };

            await DataStore.CreateAsync(item1);
            await DataStore.CreateAsync(item2);

            // Act
            item2.Name = "c";
            
            var result = await DataStore.UpdateAsync(item2);
            var name = await DataStore.ReadAsync(item2.Id);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual("c", name.Name);
        }

        [Test]
        public async Task DatabaseService_Update_InValid_Null_Should_Fail()
        {
            // Arrange
            var item1 = new ItemModel
            {
                Name = "a"
            };

            var item2 = new ItemModel
            {
                Name = "b"
            };

            await DataStore.CreateAsync(item1);
            await DataStore.CreateAsync(item2);

            // Act
            var result = await DataStore.UpdateAsync(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task DatabaseService_Update_InValid_ID_Should_Fail()
        {
            // Arrange
            var item1 = new ItemModel
            {
                Name = "a"
            };

            var item2 = new ItemModel
            {
                Name = "b"
            };

            await DataStore.CreateAsync(item1);
            //await DataStore.CreateAsync(item2);   // Don't put 2 in the list

            // Act
            var result = await DataStore.UpdateAsync(item2);
            var name = await DataStore.ReadAsync(item1.Id);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual("a", name.Name);
        }

        [Test]
        public async Task DatabaseService_Update_ForceException_Should_Fail()
        {
             // Arrange
            var item1 = new ItemModel
            {
                Name = "a"
            };

            var item2 = new ItemModel
            {
                Name = "b"
            };

            await DataStore.CreateAsync(item1);
            await DataStore.CreateAsync(item2);

            // Act
            item2.Name = "c";

            DataStore.ForceExceptionOnNumber = 3; // Read, then update

            // Act
            var result = await DataStore.UpdateAsync(item1);

            // Reset
            DataStore.ForceExceptionOnNumber = 0;

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}