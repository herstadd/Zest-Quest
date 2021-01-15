using System;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using System.Collections.Generic;

namespace UnitTests.Helpers
{
    [TestFixture]
    class BattleModeEnumHelperTests
    {
        [Test]
        public void BattleModeEnumHelper_GetListAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.GetListAll;

            // Assert
            Assert.AreEqual(6,result.Count());

            // Assert
        }

        [Test]
        public void BattleModeEnumHelper_GetListMessageAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.GetListMessageAll;

            // Assert
            Assert.AreEqual(6, result.Count());
        }

        [Test]
        public void BattleModeEnumHelper_ConvertStringToEnum_Should_Pass()
        {
            // Arrange

            var myList = Enum.GetNames(typeof(BattleModeEnum)).ToList();

            BattleModeEnum myActual;
            BattleModeEnum myExpected;

            // Act

            foreach (var item in myList)
            {
                myActual = BattleModeEnumHelper.ConvertStringToEnum(item);
                myExpected = (BattleModeEnum)Enum.Parse(typeof(BattleModeEnum), item);

                // Assert
                Assert.AreEqual(myExpected, myActual, "string: " + item + TestContext.CurrentContext.Test.Name);
            }
        }

        [Test]
        public void BattleModeEnumHelper_ConvertMessageStringToEnum_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertMessageStringToEnum("Map All Actions");

            // Assert
            Assert.AreEqual(BattleModeEnum.MapFull, result);
        }

        [Test]
        public void BattleModeEnumHelper_ConvertMessageStringToEnum_Bogus_Should_Fail()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertMessageStringToEnum("Bogus");

            // Assert
            Assert.AreEqual(BattleModeEnum.Unknown, result);
        }
    }
}

