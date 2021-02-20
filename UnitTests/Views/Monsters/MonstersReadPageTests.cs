using NUnit.Framework;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Views
{
    [TestFixture]
    public class MonsterReadPageTests : MonsterReadPage
    {
        App app;
        MonsterReadPage page;

        public MonsterReadPageTests() : base(true) { }
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new MonsterReadPage(new GenericViewModel<MonsterModel>(new MonsterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void MonsterReadPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterReadPage_Update_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Update_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_Delete_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Delete_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_GetItemToDisplay_Valid_Should_Pass()
        {
            // Arrange

            // Act
            page.GetItemToDisplay();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_GetItemToDisplay_Valid_Popup_Should_Have_Clickable_Button()
        {
            // Arrange
            page.ViewModel.Data.UniqueItem = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Head);

            // Act
            page.GetItemToDisplay();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_GetItemToDisplay_Valid_Click_Button_Should_Open_Popup()
        {
            // Arrange
            page.ViewModel.Data.UniqueItem = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Head);

            var stackView = page.GetItemToDisplay();

            ImageButton imageButtonView = new ImageButton();

            foreach (View i in ((StackLayout)stackView).Children.Where(x => x.GetType() == typeof(ImageButton))) 
            {
                imageButtonView = (ImageButton)i;
            }

            // Act
            imageButtonView.PerformClick();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_ShowPopup_Valid_Should_Pass()
        {
            // Arrange

            // Act
            page.ShowPopup(new ItemModel());

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_ClosePopup_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_AddItemsToDisplay_With_Data_Should_Remove_And_Pass()
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
            Assert.AreEqual(1, itemBox.Children.Count()); // Got to here, so it happened...
        }

        [Test]
        public async Task MonsterReadPage_GetItemToDisplay_With_Item_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Head });

            var Monster = new MonsterModel();
            Monster.Head = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Head).First().Id;
            page.ViewModel.Data = Monster;

            // Act
            var result = page.GetItemToDisplay();

            // Reset
            ItemIndexViewModel.Instance.ForceDataRefresh();

            // Assert
            Assert.AreEqual(2, result.Children.Count()); // Got to here, so it happened...
        }

        [Test]
        public async Task MonsterReadPage_GetItemToDisplay_With_NoItem_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Head });

            // Act
            var result = page.GetItemToDisplay();

            // Reset
            ItemIndexViewModel.Instance.ForceDataRefresh();

            // Assert
            Assert.AreEqual(2, result.Children.Count()); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var StackItem = page.GetItemToDisplay();
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

    }
}