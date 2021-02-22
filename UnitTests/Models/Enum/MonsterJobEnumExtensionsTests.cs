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
    }
}
