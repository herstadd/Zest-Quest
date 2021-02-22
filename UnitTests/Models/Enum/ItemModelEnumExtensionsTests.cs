using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class ItemModelEnumExtensionsTests
    {
        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_None_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.None.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("None", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Apron_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Apron.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Apron", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Bandana_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Bandana.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Bandana", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_ChefHat_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.ChefHat.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("ChefHat", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_RoastedTurkeyHat_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.RoastedTurkeyHat.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("RoastedTurkeyHat", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_ButcherKnifeNecklace_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.ButcherKnifeNecklace.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("ButcherKnifeNecklace", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Timer_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Timer.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Timer", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Refrigerator_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Refrigerator.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Refrigerator", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Pan_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Pan.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Pan", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Knife_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Knife.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Knife", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_CuttingBoard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.CuttingBoard.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("CuttingBoard", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_RingPop_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.RingPop.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("RingPop", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_ScreamRing_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.ScreamRing.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("ScreamRing", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_OnionRing_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.OnionRing.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("OnionRing", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_FlipFlop_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.FlipFlop.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("FlipFlop", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Crocs_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Crocs.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Crocs", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_WookieBoots_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.WookieBoots.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("WookieBoots", result);
        }


    }
}