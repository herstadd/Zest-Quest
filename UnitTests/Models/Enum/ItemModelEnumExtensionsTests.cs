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
            Assert.AreEqual("Chef Hat", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_RoastedTurkeyHat_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.RoastedTurkeyHat.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Roasted Turkey Hat", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_ButcherKnifeNecklace_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.ButcherKnifeNecklace.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Butcher Knife Necklace", result);
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
            Assert.AreEqual("Cutting Board", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_RingPop_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.RingPop.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Ring Pop", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_ScreamRing_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.ScreamRing.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Scream Ring", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_OnionRing_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.OnionRing.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Onion Ring", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_FlipFlop_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.FlipFlop.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Flip Flop", result);
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
            Assert.AreEqual("Wookie Boots", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_SantaShoes_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.SantaShoes.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Santa Shoes", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_FriedChickenNecklace_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.FriedChickenNecklace.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Fried Chicken Necklace", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Gingerbread_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Gingerbread.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Gingerbread", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_MeatGuitar_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.MeatGuitar.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Meat Guitar", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Pot_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Pot.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Pot", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Puppet_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Puppet.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Puppet", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_VikingHat_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.VikingHat.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Viking Hat", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_WeddingRing_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.WeddingRing.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Wedding Ring", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_WitchNail_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.WitchNail.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Witch Nail", result);
        }

        [Test]
        public void ItemModelEnumExtensionsTests_ToMessage_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemModelEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Unknown", result);
        }
    }
}