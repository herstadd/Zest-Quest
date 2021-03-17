using NUnit.Framework;

using Game;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;

namespace UnitTests.Views
{
    [TestFixture]
    public class VillagePageTests
    {
        App app;
        VillagePage page;

        // Base Constructor
        //public VillagePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new VillagePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void VillagePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void VillagePage_ItemsButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.ItemsButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void VillagePage_CharactersButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.CharactersButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void VillagePage_MonstersButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.MonstersButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void VillagePage_ScoresButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.ScoresButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}