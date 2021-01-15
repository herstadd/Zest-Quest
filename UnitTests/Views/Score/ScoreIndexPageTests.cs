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
    public class ScoreIndexPageTests : ScoreIndexPage
    {
        App app;
        ScoreIndexPage page;

        public ScoreIndexPageTests() : base(true) { }
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new ScoreIndexPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void ScoreIndexPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ScoreIndexPage_AddScore_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.AddScore_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ScoreIndexPage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ScoreIndexPage_OnItemSelected_Clicked_Default_Should_Pass()
        {
            // Arrange

            var selectedScore = new ScoreModel();

            var SelectedItemChangedEventArgs = new SelectedItemChangedEventArgs(selectedScore, 0);

            // Act
            page.OnItemSelected(null, SelectedItemChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ScoreIndexPage_OnItemSelected_Clicked_Invalid_Null_Should_Fail()
        {
            // Arrange

            var SelectedItemChangedEventArgs = new SelectedItemChangedEventArgs(null, 0);

            // Act
            page.OnItemSelected(null, SelectedItemChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ScoreIndexPage_OnAppearing_Valid_Should_Pass()
        {
            // Arrange

            ScoreIndexViewModel ViewModel = ScoreIndexViewModel.Instance;

            // Act
            OnAppearing();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
            Assert.IsNotNull(ViewModel);
        }

        [Test]
        public void ScoreIndexPage_OnAppearing_Valid_Empty_Should_Pass()
        {
            // Arrange

            ScoreIndexViewModel ViewModel = ScoreIndexViewModel.Instance;
            ViewModel.Dataset.Clear();

            // Act
            OnAppearing();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}