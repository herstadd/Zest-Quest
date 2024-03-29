﻿using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class ItemLocationEnumConverterHelperTests
    {
        [Test]
        public void ItemLocationEnumConverterHelperTests_Convert_Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new ItemLocationEnumConverter();

            var myObject = "PrimaryHand";
            var Expected = "Primary Hand";

            // Act
            var Result = myConverter.Convert(myObject, null, null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
        [Test]
        public void ItemLocationEnumConverterHelperTests_Convert_Boolean_Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new ItemLocationEnumConverter();

            var myObject = true;
            var Expected = 0;

            // Act
            var Result = myConverter.Convert(myObject, null, null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumConverterHelperTests_ConvertBack_Num__Valid_Should_Pass()
        {
            // Arrange
            var myConverter = new ItemLocationEnumConverter();
            var myObject = 12;
            var Expected = "Necklass";

            // Act
            var Result = myConverter.ConvertBack(myObject, typeof(ItemLocationEnum), null, null);

            // Reset

            // Assert
            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
    }
}