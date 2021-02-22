using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class MonsterJobEnumExtensionsTests
    {
        [Test]
        public void MonsterJobEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterTypeEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Player", result);
        }

        [Test]
        public void MonsterJobEnumExtensionsTests_EvilRefrigerator_ToMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterTypeEnum.EvilRefrigerator.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Evil Refrigerator", result);
        }

        [Test]
        public void MonsterJobEnumExtensionsTests_EvilToaster_ToMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterTypeEnum.EvilToaster.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Evil Toaster", result);
        }

        [Test]
        public void MonsterJobEnumExtensionsTests_EvilBlender_ToMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterTypeEnum.EvilBlender.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Evil Blender", result);
        }

        [Test]
        public void MonsterJobEnumExtensionsTests_EvilDishwasher_ToMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterTypeEnum.EvilDishwasher.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Evil Dishwasher", result);
        }

        [Test]
        public void MonsterJobEnumExtensionsTests_EvilStove_ToMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterTypeEnum.EvilStove.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Evil Stove", result);
        }

        [Test]
        public void MonsterJobEnumExtensionsTests_EvilKitchenSink_ToMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterTypeEnum.EvilKitchenSink.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Evil KitchenSink", result);
        }
    }
}
