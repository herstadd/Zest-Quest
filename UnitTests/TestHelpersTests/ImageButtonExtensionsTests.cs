using NUnit.Framework;

using Game;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Game.ViewModels;
using Game.Models;
using Game.Views;
using System.Linq;

namespace UnitTests.TestHelpers
{
    [TestFixture]
    public class ImageButtonExtensionsTests
    {
        App app;
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void PerformClick_Valid_No_Command_Should_Pass()
        {
            // Arrange
            var imageButtonView = new ImageButton();

            // Act
            imageButtonView.PerformClick();

            // Reset

            // Assert
            Assert.IsTrue(true);    // Got here
        }

        [Test]
        public void PerformClick_InValid_Null_Command_Should_Fail()
        {
            // Arrange
            var imageButtonView = new ImageButton();

            imageButtonView = null;

            // Act
            imageButtonView.PerformClick();

            // Reset

            // Assert
            Assert.IsTrue(true);    // Got here
        }    

    }
}