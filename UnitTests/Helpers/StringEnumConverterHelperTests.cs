using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class StringEnumConverterHelperTests
    {
        [Test]
        public void StringEnumConvert_String_Should_Pass()
        {
            var myConverter = new StringEnumConverter();

            var myObject = "Feet";
            var Result = myConverter.Convert(myObject, typeof(ItemLocationEnum), null, null);
            var Expected = ItemLocationEnum.Feet;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void StringEnumConvert_Enum_Should_Pass()
        {
            var myConverter = new StringEnumConverter();

            var myObject = ItemLocationEnum.Feet;
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 40;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void StringEnumConvert_Other_Should_Skip()
        {
            var myConverter = new StringEnumConverter();

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
        public void StringEnumConvertBack_String_Should_Pass()
        {
            var myConverter = new StringEnumConverter();

            var myObject = "Feet";
            var Result = myConverter.ConvertBack(myObject, typeof(ItemLocationEnum), null, null);
            var Expected = ItemLocationEnum.Feet;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void StringEnumConvertBack_Enum_Should_Skip()
        {
            var myConverter = new StringEnumConverter();

            var myObject = ItemLocationEnum.Feet;
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void StringEnumConvertBack_Other_Should_Skip()
        {
            var myConverter = new StringEnumConverter();

            var myObject = new ItemModel();
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void StringEnumConvertBack_Int_Should_Pass()
        {
            var myConverter = new StringEnumConverter();

            int myObject = 40;
            var Result = myConverter.ConvertBack(myObject, typeof(ItemLocationEnum), null, null);
            var Expected = "Feet";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
    }
}