using NUnit.Framework;

using Xamarin.Forms.Mocks;

using Game;

namespace UnitTests.Views
{
    [TestFixture]
    public class AppTests : App
    {
        [Test]
        public void App_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Initilize Xamarin Forms
            MockForms.Init();

            // Act
            var result = new App();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void App_OnResume_Default_Should_Pass()
        {
            // Arrange

            // Initilize Xamarin Forms
            MockForms.Init();

            // Act
            OnResume();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void App_OnSleep_Default_Should_Pass()
        {
            // Arrange

            // Initilize Xamarin Forms
            MockForms.Init();

            // Act
            OnSleep();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void App_OnStart_Default_Should_Pass()
        {
            // Arrange

            // Initilize Xamarin Forms
            MockForms.Init();

            // Act
            OnStart();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void App_InitializeComponent_Default_Should_Pass()
        {
            // Arrange

            // Initilize Xamarin Forms
            
            MockForms.Init();
            var page = new App();

            // Act
            var result = page.Resources["PageBackgroundColor"];

            //Reset

            // Assert
            Assert.IsNotNull(result); // Got to here, so it happened...
        }
    }
}