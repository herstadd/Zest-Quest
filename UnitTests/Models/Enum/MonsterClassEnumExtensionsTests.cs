﻿using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class MonsterClassEnumExtensionsTests
    {
        [Test]
        public void MonsterClassEnumExtensionsTests_ToMessage_Standard_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterClassEnumExtensions.ToMessage(MonsterClassEnum.Standard);

            // Reset

            // Assert
            Assert.AreEqual("Standard", result);
        }

        [Test]
        public void MonsterClassEnumExtensionsTests_ToMessage_Boss_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterClassEnumExtensions.ToMessage(MonsterClassEnum.Boss);

            // Reset

            // Assert
            Assert.AreEqual("Boss", result);
        }
    }
}
