using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class ActionEnumExtensionsTests
    {
        [Test]
        public void ActionEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ActionEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("None", result);
        }

        [Test]
        public void ActionEnumExtensionsTests_Move_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ActionEnum.Move.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual(" Moves ", result);
        }

        [Test]
        public void ActionEnumExtensionsTests_Ability_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ActionEnum.Ability.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual(" Uses Ability ", result);
        }

        [Test]
        public void ActionEnumExtensionsTests_Attack_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ActionEnum.Attack.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual(" Attacks ", result);
        }

        [Test]
        public void ActionEnumExtensionsTests_ToImage_Attack_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ActionEnum.Attack.ToImageURI();

            // Reset

            // Assert
            Assert.AreEqual("item.png", result);
        }

        [Test]
        public void ActionEnumExtensionsTests_ToImage_Ability_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ActionEnum.Ability.ToImageURI();

            // Reset

            // Assert
            Assert.AreEqual("item.png", result);
        }

        [Test]
        public void ActionEnumExtensionsTests_ToImage_Move_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ActionEnum.Move.ToImageURI();

            // Reset

            // Assert
            Assert.AreEqual("item.png", result);
        }

        [Test]
        public void ActionEnumExtensionsTests_ToImage_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ActionEnum.Unknown.ToImageURI();

            // Reset

            // Assert
            Assert.AreEqual("item.png", result);
        }
    }
}