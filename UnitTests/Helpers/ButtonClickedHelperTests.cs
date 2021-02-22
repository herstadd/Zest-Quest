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

        [Test]
        public void ButtonClicked_Minus_IsNotMaxHealth_Should_Return_1()
        {
            // Arrange

            // Act
            var result = ButtonClickedHelper.ValueChange("-", 1, false);

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ButtonClicked_Minus_IsMaxHealth_Should_Return_50()
        {
            // Arrange

            // Act
            var result = ButtonClickedHelper.ValueChange("-", 1, true, 50);

            // Assert
            Assert.AreEqual(50, result);
        }

        [Test]
        public void ButtonClicked_Minus_IsMaxHealth_Should_Return_True()
        {
            // Arrange

            // Act
            var result = ButtonClickedHelper.ValueChange("-", 2, true);

            // Assert
            Assert.GreaterOrEqual(result, 0);
        }
    }
}