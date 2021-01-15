using NUnit.Framework;

using Game;
using Game.Views;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Game.ViewModels;
using System.Threading.Tasks;

namespace UnitTests.Views
{
    [TestFixture]
    public class ItemIndexPageTests : ItemIndexPage
    {
        App app;
        ItemIndexPage page;

        public ItemIndexPageTests() : base(true) { }
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new ItemIndexPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void ItemIndexPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemIndexPage_AddItem_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.AddItem_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemIndexPage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemIndexPage_OnItemSelected_Clicked_Default_Should_Pass()
        {
            // Arrange

            var selectedItem = new ItemModel();

            var selectedItemChangedEventArgs = new SelectedItemChangedEventArgs(selectedItem, 0);

            // Act
            page.OnItemSelected(null, selectedItemChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemIndexPage_OnItemSelected_Clicked_Invalid_Null_Should_Fail()
        {
            // Arrange

            var selectedItemChangedEventArgs = new SelectedItemChangedEventArgs(null, 0);

            // Act
            page.OnItemSelected(null, selectedItemChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemIndexPage_OnAppearing_Valid_Should_Pass()
        {
            // Arrange

            // Warm it up
            ItemIndexViewModel ViewModel = ItemIndexViewModel.Instance;

            // Act
            OnAppearing();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemIndexPage_OnAppearing_Valid_Empty_Should_Pass()
        {
            // Arrange

            // Add each model here to warm up and load it.
            ItemIndexViewModel ViewModel = ItemIndexViewModel.Instance;
            ViewModel.Dataset.Clear();

            // Act
            OnAppearing();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}