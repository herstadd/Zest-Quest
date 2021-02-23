using NUnit.Framework;

using Game.Helpers;
using Game.GameRules;
using Game.Models;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class DefaultDataHelperTests
    {
        [Test]
        public void DefaultDataHelper_GetCharacter_Unkown_CharacterJobEnum_Should_Return_Null()
        {
            // Arrange

            // Act
            var Result = DefaultDataHelper.GetCharacter(CharacterJobEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(null, Result);
        }

        [Test]
        public void DefaultDataHelper_GetMonster_Unkown_MonsterTypeEnum_Should_Return_Null()
        {
            // Arrange

            // Acat
            var Result = DefaultDataHelper.GetMonster(MonsterTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(null, Result);
        }

    }
}