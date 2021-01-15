using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Models;
using Game.ViewModels;

namespace UnitTests.ViewModels
{
    [TestFixture]
    public class GenericViewModelTests
    {
        [Test]
        public void GenericViewModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new GenericViewModel<ItemModel>();
            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GenericViewModel_Constructor_Valid_Data_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            data.Name = "test";

            // Act
            var result = new GenericViewModel<ItemModel>(data);
            // Reset

            // Assert
            Assert.AreEqual("test", result.Data.Name);
        }

        [Test]
        public void GenericViewModel_Constructor_Valid_Data__Null_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            data.Name = null;

            // Act
            var result = new GenericViewModel<ItemModel>(data);
            // Reset

            // Assert
            Assert.AreEqual(null, result.Data.Name);
        }
    }
}
