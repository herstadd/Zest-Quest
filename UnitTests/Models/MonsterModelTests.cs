using NUnit.Framework;

using Game.Models;
using Game.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    [TestFixture]
    public class MonsterModelTests
    {
        [TearDown]
        public void TearDown()
        {
            ItemIndexViewModel.Instance.Dataset.Clear();
        }

        [Test]
        public void MonsterModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new MonsterModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterModel_Constructor_New_Item_Should_Copy()
        {
            // Arrange
            var dataNew = new MonsterModel();
            dataNew.Attack = 2;
            dataNew.Id = "oldID";

            // Act
            var result = new MonsterModel(dataNew);

            // Reset

            // Assert 
            Assert.AreNotEqual("oldID", result.Id);
        }

        [Test]
        public void MonsterModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new MonsterModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result.Attack);
            Assert.IsNotNull(result.Defense);
            Assert.IsNotNull(result.Speed);
        }

        [Test]
        public void MonsterModel_Set_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new MonsterModel();
            result.Attack = 6;
            result.Defense = 7;
            result.Speed = 8;

            // Reset

            // Assert 
            Assert.AreEqual(6, result.Attack);
            Assert.AreEqual(7, result.Defense);
            Assert.AreEqual(8, result.Speed);

            Assert.IsNotNull(result.Id);
            Assert.AreEqual(result.Id, result.Guid);

            Assert.AreEqual("item.png", result.ImageURI);
            Assert.AreEqual(PlayerTypeEnum.Monster, result.PlayerType);

            Assert.AreEqual(true, result.Alive);
            Assert.AreEqual(0, result.Order);
            Assert.AreEqual(0, result.ListOrder);
            Assert.AreEqual(1, result.Level);
            Assert.AreEqual(299, result.ExperienceRemaining);
            Assert.AreEqual(0, result.CurrentHealth);
            Assert.AreEqual(0, result.MaxHealth);
            Assert.AreEqual(0, result.ExperienceTotal);

            Assert.AreEqual(null, result.Head);
            Assert.AreEqual(null, result.Feet);
            Assert.AreEqual(null, result.Necklass);
            Assert.AreEqual(null, result.PrimaryHand);
            Assert.AreEqual(null, result.OffHand);
            Assert.AreEqual(null, result.RightFinger);
            Assert.AreEqual(null, result.LeftFinger);

            Assert.AreEqual(DifficultyEnum.Average, result.Difficulty);
        }

        [Test]
        public void MonsterModel_Update_Default_Should_Pass()
        {
            // Arrange
            var dataOriginal = new MonsterModel();
            dataOriginal.Attack = 1;

            var dataNew = new MonsterModel();
            dataNew.Attack = 2;

            // Act
            var result = dataOriginal.Update(dataNew);

            // Reset

            // Assert 
            Assert.AreEqual(2, dataOriginal.Attack);
        }

        [Test]
        public void MonsterModel_Update_InValid_Null_Should_Fail()
        {
            // Arrange
            var dataOriginal = new MonsterModel();
            dataOriginal.Attack = 2;

            // Act
            var result = dataOriginal.Update(null);

            // Reset

            // Assert 
            Assert.AreEqual(2, dataOriginal.Attack);
        }

        [Test]
        public void MonsterModel_FormatOuput_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.FormatOutput();

            // Reset

            // Assert 
            Assert.AreEqual(true, result.Contains("Troll"));
        }

        [Test]
        public void MonsterModel_Set_Get_Default_Should_Pass()
        {
            // Arrange
            var result = new MonsterModel();

            // Act
            result.Id = "bogus";
            result.ImageURI = "uri";
            result.PlayerType = PlayerTypeEnum.Monster;
            result.Alive = false;
            result.Order = 100;
            result.Guid = "guid";
            result.ListOrder = 200;
            result.Speed = 300;
            result.Level = 400;
            result.ExperienceRemaining = 500;
            result.CurrentHealth = 600;
            result.MaxHealth = 700;
            result.ExperienceTotal = 800;
            result.Defense = 900;
            result.Attack = 123;
            result.Head = "head";
            result.Feet = "feet";
            result.Necklass = "necklass";
            result.PrimaryHand = "primaryhand";
            result.OffHand = "offhand";
            result.RightFinger ="rightfinger";
            result.LeftFinger = "leftfinger";

            // Reset

            // Assert
            Assert.AreEqual("bogus", result.Id);
            Assert.AreEqual("uri", result.ImageURI);
            Assert.AreEqual(PlayerTypeEnum.Monster, result.PlayerType);
            Assert.AreEqual(false, result.Alive);
            Assert.AreEqual(100, result.Order);
            Assert.AreEqual("guid", result.Guid);
            Assert.AreEqual(200, result.ListOrder);
            Assert.AreEqual(300, result.Speed);
            Assert.AreEqual(400, result.Level);
            Assert.AreEqual(500, result.ExperienceRemaining);
            Assert.AreEqual(600, result.CurrentHealth);
            Assert.AreEqual(700, result.MaxHealth);
            Assert.AreEqual(800, result.ExperienceTotal);
            Assert.AreEqual(900, result.Defense);
            Assert.AreEqual(123, result.Attack);
            Assert.AreEqual("head", result.Head);
            Assert.AreEqual("feet", result.Feet);
            Assert.AreEqual("necklass", result.Necklass);
            Assert.AreEqual("primaryhand", result.PrimaryHand);
            Assert.AreEqual("offhand", result.OffHand);
            Assert.AreEqual("rightfinger", result.RightFinger);
            Assert.AreEqual("leftfinger", result.LeftFinger);
        }

        [Test]
        public void MonsterModel_GetAttack_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetAttack();

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void MonsterModel_GetDefense_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetDefense();

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void MonsterModel_GetSpeed_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetSpeed();

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void MonsterModel_GetHealthCurrent_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetCurrentHealthTotal;

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void MonsterModel_GetHealthMax_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetMaxHealthTotal;

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void MonsterModel_CauseDeath_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.CauseDeath();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MonsterModel_FormatOutput_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.FormatOutput();

            // Reset

            // Assert
            Assert.AreEqual(true, result.Contains("Troll"));
        }

        [Test]
        public void MonsterModel_AddExperience_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.AddExperience(0);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MonsterModel_CalculateExperienceEarned_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.CalculateExperienceEarned(0);

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void MonsterModel_GetItem_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetItem("test");

            // Reset

            // Assert
            Assert.AreEqual(null,result);
        }

        [Test]
        public void MonsterModel_GetItemByLocation_Head_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void MonsterModel_GetItemByLocation_Feet_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.Feet);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void MonsterModel_GetItemByLocation_Necklass_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.Necklass);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void MonsterModel_GetItemByLocation_PrimaryHand_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.AreEqual(null,result);
        }

        [Test]
        public void MonsterModel_GetItemByLocation_OffHand_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.OffHand);

            // Reset

            // Assert
            Assert.AreEqual(null,result);
        }

        [Test]
        public void MonsterModel_GetItemByLocation_RightFinger_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.RightFinger);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void MonsterModel_GetItemByLocation_LeftFinger_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.LeftFinger);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task MonsterModel_GetItemByLocation_Unknown_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id = "head" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Id = "necklass" });

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task MonsterModel_DropAllItems_Default_Should_Pass()
        {
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id = "head" });

            var item = ItemIndexViewModel.Instance.Dataset.FirstOrDefault();

            // Arrange
            var data = new MonsterModel
            {
                Head = item.Id,
                Necklass = item.Id,
                PrimaryHand = item.Id,
                OffHand = item.Id,
                RightFinger = item.Id,
                LeftFinger = item.Id,
                Feet = item.Id,
            };

            // Act
            var result = data.DropAllItems();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterModel_AddItem_Unknown_Should_Fail()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.AddItem(ItemLocationEnum.Unknown, "bogus");

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task MonsterModel_AddItem_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id = "head" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Id = "necklass" });

            var itemOld = ItemIndexViewModel.Instance.Dataset.FirstOrDefault();

            // Act

            // Add the second item, this will return the first item as the one replaced which is null
            var result = data.AddItem(ItemLocationEnum.PrimaryHand, itemOld.Id);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task MonsterModel_AddItem_Default_Replace_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id = "head" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Id = "necklass" });

            var itemOld = ItemIndexViewModel.Instance.Dataset.FirstOrDefault();
            var itemNew = ItemIndexViewModel.Instance.Dataset.LastOrDefault();

            // Add the first item
            data.AddItem(ItemLocationEnum.PrimaryHand, itemOld.Id);

            // Act

            // Add the second item, this will return the first item as the one replaced
            var result = data.AddItem(ItemLocationEnum.PrimaryHand, itemNew.Id);

            // Reset

            // Assert
            Assert.AreEqual(itemOld.Id, result.Id);
        }

        [Test]
        public async Task MonsterModel_GetItemBonus_Default_Attack_Should_Pass()
        {
            // Arrange
            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id="head" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Id = "necklass" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 300, Id = "PrimaryHand" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 4000, Id = "OffHand" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 50000, Id = "RightFinger" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 600000, Id = "LeftFinger" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 7000000, Id = "feet" });
            
            var data = new MonsterModel();

            // Add the first item
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("head")).Id);
            data.AddItem(ItemLocationEnum.Necklass, (await ItemIndexViewModel.Instance.ReadAsync("necklass")).Id);
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);
            data.AddItem(ItemLocationEnum.OffHand, (await ItemIndexViewModel.Instance.ReadAsync("OffHand")).Id);
            data.AddItem(ItemLocationEnum.RightFinger, (await ItemIndexViewModel.Instance.ReadAsync("RightFinger")).Id);
            data.AddItem(ItemLocationEnum.LeftFinger, (await ItemIndexViewModel.Instance.ReadAsync("LeftFinger")).Id);
            data.AddItem(ItemLocationEnum.Feet, (await ItemIndexViewModel.Instance.ReadAsync("feet")).Id);

            // Act

            // Add the second item, this will return the first item as the one replaced
            var result = data.GetItemBonus(AttributeEnum.Attack);

            // Reset

            // Assert
            Assert.AreEqual(7654320, result);
        }

        [Test]
        public async Task MonsterModel_GetAttackTotal_Default_Attack_Should_Pass()
        {
            // Arrange
            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id = "head" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Id = "necklass" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 300, Id = "PrimaryHand" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 4000, Id = "OffHand" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 50000, Id = "RightFinger" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 600000, Id = "LeftFinger" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 7000000, Id = "feet" });

            var data = new MonsterModel();

            // Add the first item
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("head")).Id);
            data.AddItem(ItemLocationEnum.Necklass, (await ItemIndexViewModel.Instance.ReadAsync("necklass")).Id);
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);
            data.AddItem(ItemLocationEnum.OffHand, (await ItemIndexViewModel.Instance.ReadAsync("OffHand")).Id);
            data.AddItem(ItemLocationEnum.RightFinger, (await ItemIndexViewModel.Instance.ReadAsync("RightFinger")).Id);
            data.AddItem(ItemLocationEnum.LeftFinger, (await ItemIndexViewModel.Instance.ReadAsync("LeftFinger")).Id);
            data.AddItem(ItemLocationEnum.Feet, (await ItemIndexViewModel.Instance.ReadAsync("feet")).Id);

            // Act

            // Add the second item, this will return the first item as the one replaced
            var result = data.GetAttackTotal;

            // Reset

            // Assert
            Assert.AreEqual(7654322, result);
        }

        [Test]
        public async Task MonsterModel_GetDefenseTotal_Default_Defense_Should_Pass()
        {
            // Arrange
            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 1, Id = "head" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 20, Id = "necklass" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 300, Id = "PrimaryHand" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 4000, Id = "OffHand" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 50000, Id = "RightFinger" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 600000, Id = "LeftFinger" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Defense, Value = 7000000, Id = "feet" });

            var data = new MonsterModel();

            // Add the first item
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("head")).Id);
            data.AddItem(ItemLocationEnum.Necklass, (await ItemIndexViewModel.Instance.ReadAsync("necklass")).Id);
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);
            data.AddItem(ItemLocationEnum.OffHand, (await ItemIndexViewModel.Instance.ReadAsync("OffHand")).Id);
            data.AddItem(ItemLocationEnum.RightFinger, (await ItemIndexViewModel.Instance.ReadAsync("RightFinger")).Id);
            data.AddItem(ItemLocationEnum.LeftFinger, (await ItemIndexViewModel.Instance.ReadAsync("LeftFinger")).Id);
            data.AddItem(ItemLocationEnum.Feet, (await ItemIndexViewModel.Instance.ReadAsync("feet")).Id);

            // Act

            // Add the second item, this will return the first item as the one replaced
            var result = data.GetDefenseTotal;

            // Reset

            // Assert
            Assert.AreEqual(7654321, result);
        }

        [Test]
        public async Task MonsterModel_GetDamageTotal_Default_Speed_Should_Pass()
        {
            // Arrange
            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 1, Id = "head" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 20, Id = "necklass" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 300, Id = "PrimaryHand" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 4000, Id = "OffHand" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 50000, Id = "RightFinger" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 600000, Id = "LeftFinger" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Speed, Value = 7000000, Id = "feet" });

            var data = new MonsterModel();

            // Add the first item
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("head")).Id);
            data.AddItem(ItemLocationEnum.Necklass, (await ItemIndexViewModel.Instance.ReadAsync("necklass")).Id);
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);
            data.AddItem(ItemLocationEnum.OffHand, (await ItemIndexViewModel.Instance.ReadAsync("OffHand")).Id);
            data.AddItem(ItemLocationEnum.RightFinger, (await ItemIndexViewModel.Instance.ReadAsync("RightFinger")).Id);
            data.AddItem(ItemLocationEnum.LeftFinger, (await ItemIndexViewModel.Instance.ReadAsync("LeftFinger")).Id);
            data.AddItem(ItemLocationEnum.Feet, (await ItemIndexViewModel.Instance.ReadAsync("feet")).Id);

            // Act

            // Add the second item, this will return the first item as the one replaced
            var result = data.GetSpeedTotal;

            // Reset

            // Assert
            Assert.AreEqual(7654321, result);
        }

        [Test]
        public async Task MonsterModel_GetDamageRollAttack_Default_Speed_Should_Pass()
        {
            // Arrange
            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Id = "head" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Id = "necklass" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 300, Id = "PrimaryHand" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 4000, Id = "OffHand" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 50000, Id = "RightFinger" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 600000, Id = "LeftFinger" });
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 7000000, Id = "feet" });

            var data = new MonsterModel();
            data.Level = 1;

            // Add the first item
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("head")).Id);
            data.AddItem(ItemLocationEnum.Necklass, (await ItemIndexViewModel.Instance.ReadAsync("necklass")).Id);
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);
            data.AddItem(ItemLocationEnum.OffHand, (await ItemIndexViewModel.Instance.ReadAsync("OffHand")).Id);
            data.AddItem(ItemLocationEnum.RightFinger, (await ItemIndexViewModel.Instance.ReadAsync("RightFinger")).Id);
            data.AddItem(ItemLocationEnum.LeftFinger, (await ItemIndexViewModel.Instance.ReadAsync("LeftFinger")).Id);
            data.AddItem(ItemLocationEnum.Feet, (await ItemIndexViewModel.Instance.ReadAsync("feet")).Id);

            Game.Helpers.DiceHelper.EnableForcedRolls();
            Game.Helpers.DiceHelper.SetForcedRollValue(1);

            // Act

            // Add the second item, this will return the first item as the one replaced
            var result = data.GetDamageRollValue();

            // Reset
            Game.Helpers.DiceHelper.DisableForcedRolls();
 
            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public async Task MonsterModel_GetDamageItemBonus_Default_Speed_Should_Pass()
        {
            // Arrange
            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 300, Id = "PrimaryHand" , Damage=1});

            var data = new MonsterModel();
            data.Level = 1;

            // Add the first item
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);

            Game.Helpers.DiceHelper.EnableForcedRolls();
            Game.Helpers.DiceHelper.SetForcedRollValue(1);

            // Act

            // Add the second item, this will return the first item as the one replaced
            var result = data.GetDamageItemBonus;

            // Reset
            Game.Helpers.DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task MonsterModel_GetDamageItemBonusString_Default_Speed_Should_Pass()
        {
            // Arrange
            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 300, Id = "PrimaryHand", Damage = 1 });

            var data = new MonsterModel();
            data.Level = 1;

            // Add the first item
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);

            Game.Helpers.DiceHelper.EnableForcedRolls();
            Game.Helpers.DiceHelper.SetForcedRollValue(1);

            // Act

            // Add the second item, this will return the first item as the one replaced
            var result = data.GetDamageItemBonusString;

            // Reset
            Game.Helpers.DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual("1D 1", result);
        }

        [Test]
        public async Task MonsterModel_GetDamageTotalString_Default_Speed_Should_Pass()
        {
            // Arrange
            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Attribute = AttributeEnum.Attack, Value = 300, Id = "PrimaryHand", Damage = 1 });

            var data = new MonsterModel();
            data.Level = 1;

            // Add the first item
            data.AddItem(ItemLocationEnum.PrimaryHand, (await ItemIndexViewModel.Instance.ReadAsync("PrimaryHand")).Id);

            Game.Helpers.DiceHelper.EnableForcedRolls();
            Game.Helpers.DiceHelper.SetForcedRollValue(1);

            // Act

            // Add the second item, this will return the first item as the one replaced
            var result = data.GetDamageTotalString;

            // Reset
            Game.Helpers.DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual("1 + 1D 1", result);
        }
    }
}