using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class HitStatusEnumExtensionsTests
    {
        [Test]
        public void HitStatusEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Unknown", result);
        }

        [Test]
        public void HitStatusEnumExtensionsTests_Hit_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnum.Hit.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual(" hits ", result);
        }

        [Test]
        public void HitStatusEnumExtensionsTests_CriticalHit_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnum.CriticalHit.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual(" hits really hard ", result);
        }

        [Test]
        public void HitStatusEnumExtensionsTests_Miss_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnum.Miss.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual(" misses ", result);
        }

        [Test]
        public void HitStatusEnumExtensionsTests_CriticalMiss_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnum.CriticalMiss.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual(" misses really badly", result);
        }
    }
}
