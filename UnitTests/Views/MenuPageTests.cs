using NUnit.Framework;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Game.Models;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using System.Linq;

namespace UnitTests.Views
{
    [TestFixture]
    public class MenuPageTests
    {
        App app;
        MenuPage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new MenuPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void MenuPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MenuPage_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page.RootPage;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MenuPage_ListViewMenu_InValid_Null_Should_Fail()
        {
            // Arrange

            var content = (StackLayout)page.Content;
            var listview = (ListView)content.Children.FirstOrDefault();

            // Act
            listview.SelectedItem = null;

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MenuPage_ListViewMenu_Valid_Game_Should_Pass()
        {
            // Arrange

            var data = new HomeMenuItemModel { Id = MenuItemEnum.Game, Title = "Game" };

            var content = (StackLayout)page.Content;
            var listview = (ListView)content.Children.FirstOrDefault();

            // Act
            listview.SelectedItem = data;

            // Reset

            // Assert
            Assert.IsTrue(true);
        }
    }
}