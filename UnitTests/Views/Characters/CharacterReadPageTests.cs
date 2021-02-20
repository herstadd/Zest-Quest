using NUnit.Framework;
using System.Linq;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using System.Threading.Tasks;

namespace UnitTests.Views
{
    [TestFixture]
    public class CharacterReadPageTests : CharacterReadPage
    {
        App app;
        CharacterReadPage page;

        public CharacterReadPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new CharacterReadPage(new GenericViewModel<CharacterModel>(new CharacterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void CharacterReadPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterReadPage_Update_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Update_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_Delete_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Delete_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_GetItemToDisplay_Valid_Should_Pass()
        {
            // Arrange

            // Act
            page.GetItemToDisplay(ItemLocationEnum.Feet);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_ShowPopup_Valid_Should_Pass()
        {
            // Arrange

            // Act
            page.ShowPopup(new ItemModel());

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_ClosePopup_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_AddItemsToDisplay_With_Data_Should_Remove_And_Pass()
        {
            // Arrange

            // Put some data into the box so it can be removed
            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            itemBox.Children.Add(new Label());
            itemBox.Children.Add(new Label());

            // Act
            page.AddItemsToDisplay();

            // Reset

            // Assert
            Assert.AreEqual(7, itemBox.Children.Count()); // Got to here, so it happened...
        }

        [Test]
        public async Task CharacterReadPage_GetItemToDisplay_With_Item_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.PrimaryHand });

            var character = new CharacterModel();
            character.Head = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.PrimaryHand).First().Id;
            page.ViewModel.Data = character;

            // Act
            var result = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(2, result.Children.Count()); // Got to here, so it happened...
        }

        [Test]
        public async Task CharacterReadPage_GetItemToDisplay_With_NoItem_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            var item = new ItemModel { Location = ItemLocationEnum.PrimaryHand };
            await ItemIndexViewModel.Instance.CreateAsync(item);

            // Act
            var result = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(2, result.Children.Count()); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.PrimaryHand);
            page.ViewModel.Data.PrimaryHand = item.Id;
            var StackItem = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}