using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class ButtonClickedHelperTests
    {
        [Test]
        public void ButtonClicked_Minus_IsNotMaxHealth_Should_Return_2()
        {
            // Arrange

            // Act
            var result = ButtonClickedHelper.ValueChange("-", 3, false);

            // Assert
            Assert.AreEqual(2, result);
        }
    }
}