using System;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class DifficultyEnumHelperTests
    {
        [Test]
        public void DifficultyEnumHelper_GetListMonster_Should_Pass()
        {
            // Arrange

            // Instantiate a new Difficulty Base, should have default of 1 for all values
            var myDataList = DifficultyEnumHelper.GetListMonster;

            // Get Expected set
            var myList = Enum.GetNames(typeof(DifficultyEnum)).ToList();
            var myExpectedList = myList.Where(a =>
                                            a.ToString() != DifficultyEnum.Unknown.ToString()
                                        ).ToList();

            // Act

            // Make sure each item is in the list
            foreach (var item in myDataList)
            {
                //if (item == DifficultyEnum.Unknown.ToString())
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
        public void DifficultyEnumHelper_GetListAll_Should_Pass()
        {
            // Arrange

            // Instantiate a new Difficulty Base, should have default of 1 for all values
            var myDataList = DifficultyEnumHelper.GetListAll;

            // Get Expected set
            var myList = Enum.GetNames(typeof(DifficultyEnum)).ToList();
            var myExpectedList = myList.Where(a =>
                                                a.ToString() != DifficultyEnum.Unknown.ToString()
                                            ).ToList();

            // Act

            // Make sure each item is in the list
            foreach (var item in myDataList)
            {
                if (item == DifficultyEnum.Unknown.ToString())
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
        public void DifficultyEnumHelper_ConvertStringToEnum_Should_Pass()
        {
            // Arrange

            var myList = Enum.GetNames(typeof(DifficultyEnum)).ToList();

            DifficultyEnum myActual;
            DifficultyEnum myExpected;

            // Act

            foreach (var item in myList)
            {
                myActual = DifficultyEnumHelper.ConvertStringToEnum(item);
                myExpected = (DifficultyEnum)Enum.Parse(typeof(DifficultyEnum), item);

                // Assert
                Assert.AreEqual(myExpected, myActual, "string: " + item + TestContext.CurrentContext.Test.Name);
            }
        }
    }
}

