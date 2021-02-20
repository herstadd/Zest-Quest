using System;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class ItemLocationEnumHelperTests
    {

        [Test]
        public void ItemLocationEnumHelper_ItemLocationEnum_Valid_1Time_6sided_Should_Between_1_and_6()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetListItem;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemLocationEnumHelper_GetListCharacter_Should_Pass()
        {
            // Arrange

            // Instantiate a new ItemLocation Base, should have default of 1 for all values
            var myDataList = ItemLocationEnumHelper.GetListCharacter;

            // Get Expected set
            var myList = Enum.GetNames(typeof(ItemLocationEnum)).ToList();
            var myExpectedList = myList.Where(a =>
                                          a.ToString() != ItemLocationEnum.Unknown.ToString() &&
                                           a.ToString() != ItemLocationEnum.Finger.ToString()
                                            )
                                            .OrderBy(a => a)
                                            .ToList();

            // Act

            // Make sure each item is in the list
            foreach (var item in myDataList)
            {
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
        public void ItemLocationEnumHelper_GetListItem_Should_Pass()
        {
            // Arrange

            // Instantiate a new ItemLocation Base, should have default of 1 for all values
            var myDataList = ItemLocationEnumHelper.GetListItem;

            // Get Expected set
            var myList = Enum.GetNames(typeof(ItemLocationEnum)).ToList();
            var myExpectedList = myList.Where(a =>
                                            a.ToString() != ItemLocationEnum.Unknown.ToString() &&
                                            a.ToString() != ItemLocationEnum.LeftFinger.ToString() &&
                                            a.ToString() != ItemLocationEnum.RightFinger.ToString()
                                            )
                                            .OrderBy(a => a)
                                            .ToList();

            // Act

            // Make sure each item is in the list
            foreach (var item in myDataList)
            {
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
        public void ItemLocationEnumHelper_ConvertStringToEnum_Should_Pass()
        {
            // Arrange

            var myList = Enum.GetNames(typeof(ItemLocationEnum)).ToList();

            ItemLocationEnum myActual;
            ItemLocationEnum myExpected;

            // Act

            foreach (var item in myList)
            {
                myActual = ItemLocationEnumHelper.ConvertStringToEnum(item);
                myExpected = (ItemLocationEnum)Enum.Parse(typeof(ItemLocationEnum), item);

                // Assert
                Assert.AreEqual(myExpected, myActual, "string: " + item + TestContext.CurrentContext.Test.Name);
            }
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_1_Should_Pass()
        {
            // Arrange

            var value = 1;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = ItemLocationEnum.Head;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_2_Should_Pass()
        {
            // Arrange

            var value = 2;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = ItemLocationEnum.Necklass;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_3_Should_Pass()
        {
            // Arrange

            var value = 3;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = ItemLocationEnum.PrimaryHand;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_4_Should_Pass()
        {
            // Arrange

            var value = 4;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = ItemLocationEnum.OffHand;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_5_Should_Pass()
        {
            // Arrange

            var value = 5;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = ItemLocationEnum.RightFinger;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_6_Should_Pass()
        {
            // Arrange

            var value = 6;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = ItemLocationEnum.LeftFinger;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_7_Should_Pass()
        {
            // Arrange

            var value = 7;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = ItemLocationEnum.Feet;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        #region ItemLocationEnumConverter

        [Test]
        public void ItemLocationEnumConvert_String_Should_Pass()
        {
            var myConverter = new ItemLocationEnumConverter();

            var myObject = "Feet";
            var Result = myConverter.Convert(myObject, typeof(ItemLocationEnum), null, null);
            var Expected = ItemLocationEnum.Feet.ToMessage();

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumConvert_Enum_Should_Pass()
        {
            var myConverter = new ItemLocationEnumConverter();

            var myObject = ItemLocationEnum.Feet;
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = "Feet";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumConvert_Other_Should_Skip()
        {
            var myConverter = new ItemLocationEnumConverter();

            var myObject = new ItemModel();
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void IntEnumConvertBack_Should_Skip()
        {
            var myConverter = new IntEnumConverter();

            var myObject = "Bogus";
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void IntEnumConvertBack_Int_Should_Pass()
        {
            var myConverter = new IntEnumConverter();

            int myObject = 40;
            var Result = myConverter.ConvertBack(myObject, typeof(ItemLocationEnum), null, null);
            var Expected = "Feet";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumConvertBack_String_Should_Pass()
        {
            var myConverter = new ItemLocationEnumConverter();

            var myObject = "Feet";
            var Result = myConverter.ConvertBack(myObject, typeof(ItemLocationEnum), null, null);
            var Expected = ItemLocationEnum.Feet;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumConvertBack_Enum_Should_Skip()
        {
            var myConverter = new ItemLocationEnumConverter();

            var myObject = ItemLocationEnum.Feet;
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumConvertBack_Other_Should_Skip()
        {
            var myConverter = new ItemLocationEnumConverter();

            var myObject = new ItemModel();
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumConvertBack_Int_Should_Pass()
        {
            var myConverter = new ItemLocationEnumConverter();

            int myObject = 40;
            var Result = myConverter.ConvertBack(myObject, typeof(ItemLocationEnum), null, null);
            var Expected = "Feet";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
        #endregion ItemLocationEnumConverter

        #region ConvertMessageToEnum
        [Test]
        public void ConvertMessageToEnum_Valid_Feet_Should_Return_Enum()
        {

            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertMessageToEnum("Feet");

            // Assert
            Assert.AreEqual(ItemLocationEnum.Feet, result);
        }

        [Test]
        public void ConvertMessageToEnum_InValid_Bogus_Should_Return_Unknown()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertMessageToEnum("bogus");

            // Assert
            Assert.AreEqual(ItemLocationEnum.Unknown, result);
        }

        #endregion ConvertMessageToEnum

        #region GetListMessageCharacter
        [Test]
        public void GetListMessageCharacter_Valid_Default_Should_Return_List()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetListMessageCharacter;

            // Assert
            Assert.AreEqual(7, result.Count());
        }
        #endregion GetListMessageCharacter
    }
}