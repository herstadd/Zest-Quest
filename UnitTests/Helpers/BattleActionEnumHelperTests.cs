using System;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using System.Collections.Generic;

namespace UnitTests.Helpers
{
    [TestFixture]
    class BattleActionEnumHelperTests
    {
        [Test]
        public void BattleActionEnumHelper_GetListAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleActionEnumHelper.GetListAll;

            // Assert
            Assert.AreEqual(3,result.Count());

            // Assert
        }

        [Test]
        public void BattleActionEnumHelper_ConvertStringToEnum_Should_Pass()
        {
            // Arrange

            var myList = Enum.GetNames(typeof(BattleActionEnum)).ToList();

            BattleActionEnum myActual;
            BattleActionEnum myExpected;

            // Act

            foreach (var item in myList)
            {
                myActual = BattleActionEnumHelper.ConvertStringToEnum(item);
                myExpected = (BattleActionEnum)Enum.Parse(typeof(BattleActionEnum), item);

                // Assert
                Assert.AreEqual(myExpected, myActual, "string: " + item + TestContext.CurrentContext.Test.Name);
            }
        }
    }
}