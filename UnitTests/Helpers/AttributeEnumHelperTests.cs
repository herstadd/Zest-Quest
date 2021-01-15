using System;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class AttributeEnumHelperTests
    {
        [Test]
        public void AttributeEnumHelper_GetListCharacter_Should_Pass()
        {
            // Arrange

            // Instantiate a new Attribute Base, should have default of 1 for all values
            var myDataList = AttributeEnumHelper.GetListCharacter;

            // Get Expected set
            var myList = Enum.GetNames(typeof(AttributeEnum)).ToList();
            var myExpectedList = myList.Where(a =>
                                            a.ToString() != AttributeEnum.Unknown.ToString()
                                        ).ToList();

            // Act

            // Make sure each item is in the list
            foreach (var item in myDataList)
            {
                //if (item == AttributeEnum.Unknown.ToString())
                //{
                //    continue;
                //}

                var found = false;
                foreach (var expected in myExpectedList)
                {
                    if (item == expected)
                    {
                        found = true;
                        break;
                    }
                }

                // Assert
                Assert.AreEqual(true, found, "item : " + item + TestContext.CurrentContext.Test.Name);
            }

            // reverse it, to make sure the list has each item
            // Make sure each item is in the list
            foreach (var expected in myExpectedList)
            {
                var found = false;
                {
                    foreach (var item in myDataList)
                        if (item == expected)
                        {
                            found = true;
                            break;
                        }
                }

                // Assert
                Assert.AreEqual(true, found, "expected : " + expected + TestContext.CurrentContext.Test.Name);
            }

        }

        [Test]
        public void AttributeEnumHelper_GetListItem_Should_Pass()
        {
            // Arrange

            // Instantiate a new Attribute Base, should have default of 1 for all values
            var myDataList = AttributeEnumHelper.GetListItem;

            // Get Expected set
            var myList = Enum.GetNames(typeof(AttributeEnum)).ToList();
            var myExpectedList = myList.Where(a =>
                                                a.ToString() != AttributeEnum.Unknown.ToString() &&
                                                a.ToString() != AttributeEnum.MaxHealth.ToString()
                                            ).ToList();

            // Act

            // Make sure each item is in the list
            foreach (var item in myDataList)
            {
                if (item == AttributeEnum.Unknown.ToString())
                {
                    continue;
                }

                if (item == AttributeEnum.MaxHealth.ToString())
                {
                    continue;
                }

                var found = false;
                foreach (var expected in myExpectedList)
                {
                    if (item == expected)
                    {
                        found = true;
                        break;
                    }
                }

                // Assert
                Assert.AreEqual(true, found, "item : " + item + TestContext.CurrentContext.Test.Name);
            }

            // reverse it, to make sure the list has each item
            // Make sure each item is in the list
            foreach (var expected in myExpectedList)
            {
                var found = false;
                {
                    foreach (var item in myDataList)
                        if (item == expected)
                        {
                            found = true;
                            break;
                        }
                }

                // Assert
                Assert.AreEqual(true, found, "expected : " + expected + TestContext.CurrentContext.Test.Name);
            }

        }

        [Test]
        public void AttributeEnumHelper_ConvertStringToEnum_Should_Pass()
        {
            // Arrange

            var myList = Enum.GetNames(typeof(AttributeEnum)).ToList();

            AttributeEnum myActual;
            AttributeEnum myExpected;

            // Act

            foreach (var item in myList)
            {
                myActual = AttributeEnumHelper.ConvertStringToEnum(item);
                myExpected = (AttributeEnum)Enum.Parse(typeof(AttributeEnum), item);

                // Assert
                Assert.AreEqual(myExpected, myActual, "string: " + item + TestContext.CurrentContext.Test.Name);
            }
        }
    }
}

