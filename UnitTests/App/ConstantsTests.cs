using NUnit.Framework;

using Xamarin.Forms.Mocks;

using Game;

namespace UnitTests.Views
{
    [TestFixture]
    public class ConstantsTests
    {
        [Test]
        public void Constants_DatabasePath_Default_Should_Pass()
        {
            // Arrange

            // Initilize Xamarin Forms
            MockForms.Init();

            // Act
            var result = Constants.DatabasePath;

            // Reset

            // Assert
            Assert.AreEqual(true, result.Contains("game.db3"));
        }

        [Test]
        public void Constants_DatabaseFilename_Default_Should_Pass()
        {
            // Arrange

            // Initilize Xamarin Forms
            MockForms.Init();

            // Act
            var result = Constants.DatabaseFilename;

            // Reset

            // Assert
            Assert.AreEqual("game.db3", result);
        }
    }
}