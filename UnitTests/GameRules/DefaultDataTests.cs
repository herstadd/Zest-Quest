using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.GameRules;

namespace UnitTests.GameRules
{
    [TestFixture]
    public class DefaultDataTests
    {
        [Test]
        public void DefaultData_Valid_LoadData_Item_Should_Pass()
        {
            // Arrange

            // Act
            var result = DefaultData.LoadData(new ItemModel());

            // Reset

            // Assert
            Assert.AreEqual(26, result.Count());
        }

        [Test]
        public void DefaultData_Valid_LoadData_Character_Should_Pass()
        {
            // Arrange

            // Act
            var result = DefaultData.LoadData(new CharacterModel());

            // Reset

            // Assert
            Assert.AreEqual(7, result.Count());
        }

        [Test]
        public void DefaultData_Valid_LoadData_Monster_Should_Pass()
        {
            // Arrange

            // Act
            var result = DefaultData.LoadData(new MonsterModel());

            // Reset

            // Assert
            Assert.AreEqual(7, result.Count());
        }


        [Test]
        public void DefaultData_Valid_LoadData_Score_Should_Pass()
        {
            // Arrange

            // Act
            var result = DefaultData.LoadData(new ScoreModel());

            // Reset

            // Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}