using NUnit.Framework;

using Game.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UnitTests.Models
{
    [TestFixture]
    public class CordinatesModelTests
    {
        [Test]
        public void CordinatesModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new CordinatesModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void CordinatesModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new CordinatesModel();

            // Reset

            // Assert 
            Assert.AreEqual(0,result.Row);
            Assert.AreEqual(0,result.Column);
        }

        [Test]
        public void CordinatesModel_Set_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new CordinatesModel();
            result.Row = 3;
            result.Column = 2;
            
            // Reset

            // Assert 
            Assert.AreEqual(3, result.Row);
            Assert.AreEqual(2, result.Column);
        }
    }
}