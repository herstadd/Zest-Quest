using System;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using System.Collections.Generic;

namespace UnitTests.Helpers
{
    [TestFixture]
    class HitStatusEnumHelperTests
    {
        [Test]
        public void HitStatusEnumHelper_GetListAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.GetListAll;

            // Assert
            Assert.AreEqual(6,result.Count());

            // Assert
        }

        [Test]
        public void HitStatusEnumHelper_GetListMessageAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.GetListMessageAll;

            // Assert
            Assert.AreEqual(6, result.Count());
        }

        [Test]
        public void HitStatusEnumHelper_ConvertStringToEnum_Should_Pass()
        {
            // Arrange

            var myList = Enum.GetNames(typeof(HitStatusEnum)).ToList();

            HitStatusEnum myActual;
            HitStatusEnum myExpected;

            // Act

            foreach (var item in myList)
            {
                myActual = HitStatusEnumHelper.ConvertStringToEnum(item);
                myExpected = (HitStatusEnum)Enum.Parse(typeof(HitStatusEnum), item);

                // Assert
                Assert.AreEqual(myExpected, myActual, "string: " + item + TestContext.CurrentContext.Test.Name);
            }
        }

        [Test]
        public void HitStatusEnumHelper_ConvertMessageStringToEnum_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertMessageStringToEnum(" misses ");

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        [Test]
        public void HitStatusEnumHelper_ConvertMessageStringToEnum_Bogus_Should_Fail()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertMessageStringToEnum("Bogus");

            // Assert
            Assert.AreEqual(HitStatusEnum.Unknown, result);
        }
    }
}

