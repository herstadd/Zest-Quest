using NUnit.Framework;

using Game.Models;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Models
{
    [TestFixture]
    public class ScoreModelTests
    {
        [Test]
        public void ScoreModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ScoreModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void ScoreModel_Constructor_New_Item_Should_Copy()
        {
            // Arrange
            var dataNew = new ScoreModel();

            dataNew.Id = "oldID";

            dataNew.BattleNumber = 100;
            dataNew.ScoreTotal = 200;
            dataNew.GameDate = System.DateTime.MinValue;
            dataNew.AutoBattle = true;
            dataNew.TurnCount = 300;
            dataNew.RoundCount = 400;
            dataNew.MonsterSlainNumber = 500;
            dataNew.ExperienceGainedTotal = 600;
            dataNew.CharacterAtDeathList ="characters";
            dataNew.MonstersKilledList = "monsters";
            dataNew.ItemsDroppedList = "items";

            // Act
            var result = new ScoreModel(dataNew);

            // Reset

            // Assert 
            Assert.AreNotEqual("oldID", result.Id);
        }

        [Test]
        public void ScoreModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ScoreModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result.BattleNumber);
            Assert.IsNotNull(result.ScoreTotal);
            Assert.IsNotNull(result.GameDate);
            Assert.IsNotNull(result.AutoBattle);
            Assert.IsNotNull(result.TurnCount);
            Assert.IsNotNull(result.RoundCount);
            Assert.IsNotNull(result.MonsterSlainNumber);
            Assert.IsNotNull(result.ExperienceGainedTotal);

            Assert.AreEqual(string.Empty, result.CharacterAtDeathList);
            Assert.AreEqual(string.Empty, result.MonstersKilledList);
            Assert.AreEqual(string.Empty, result.ItemsDroppedList);

            Assert.AreEqual(0, result.ItemModelDropList.Count());
            Assert.AreEqual(0, result.MonsterModelDeathList.Count());
            Assert.AreEqual(0, result.CharacterModelDeathList.Count());
        }

        [Test]
        public void ScoreModel_Set_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ScoreModel();
            result.BattleNumber = 100;
            result.ScoreTotal = 200;
            result.GameDate = System.DateTime.MinValue;
            result.AutoBattle = true;
            result.TurnCount = 300;
            result.RoundCount = 400;
            result.MonsterSlainNumber = 500;
            result.ExperienceGainedTotal = 600;
            result.CharacterAtDeathList = "characters";
            result.MonstersKilledList = "monsters";
            result.ItemsDroppedList = "items";

            result.ItemModelDropList = new List<ItemModel> { new ItemModel { Name = "Item" } };
            result.MonsterModelDeathList = new List<PlayerInfoModel> { new PlayerInfoModel(new MonsterModel())};
            result.CharacterModelDeathList = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel()) };
            result.ItemModelSelectList = new List<ItemModel> { new ItemModel { Name = "Item" } };

            // Reset

            // Assert 
            Assert.AreEqual(100,result.BattleNumber);
            Assert.AreEqual(200,result.ScoreTotal);
            Assert.AreEqual(System.DateTime.MinValue,result.GameDate);
            Assert.AreEqual(true,result.AutoBattle);
            Assert.AreEqual(300,result.TurnCount);
            Assert.AreEqual(400,result.RoundCount);
            Assert.AreEqual(500,result.MonsterSlainNumber);
            Assert.AreEqual(600,result.ExperienceGainedTotal);
            Assert.AreEqual("characters",result.CharacterAtDeathList);
            Assert.AreEqual("monsters",result.MonstersKilledList) ;
            Assert.AreEqual("items",result.ItemsDroppedList);

            Assert.AreEqual("Item", result.ItemModelDropList.ElementAt(0).Name);
            Assert.AreEqual("Item", result.ItemModelSelectList.ElementAt(0).Name);
            Assert.AreEqual(PlayerTypeEnum.Monster, result.MonsterModelDeathList.ElementAt(0).PlayerType);
            Assert.AreEqual(PlayerTypeEnum.Character, result.CharacterModelDeathList.ElementAt(0).PlayerType);
        }

        [Test]
        public void ScoreModel_Update_Default_Should_Pass()
        {
            // Arrange
            var dataOriginal = new ScoreModel();

            var dataNew = new ScoreModel();
            dataNew.BattleNumber = 100;
            dataNew.ScoreTotal = 200;
            dataNew.GameDate = System.DateTime.MinValue;
            dataNew.AutoBattle = true;
            dataNew.TurnCount = 300;
            dataNew.RoundCount = 400;
            dataNew.MonsterSlainNumber = 500;
            dataNew.ExperienceGainedTotal = 600;
            dataNew.CharacterAtDeathList = "characters";
            dataNew.MonstersKilledList = "monsters";
            dataNew.ItemsDroppedList = "items";

            // Act
            var result = dataOriginal.Update(dataNew);

            // Reset

            // Assert 
            Assert.AreEqual(100, dataNew.BattleNumber);
            Assert.AreEqual(200, dataNew.ScoreTotal);
            Assert.AreEqual(System.DateTime.MinValue, dataNew.GameDate);
            Assert.AreEqual(true, dataNew.AutoBattle);
            Assert.AreEqual(300, dataNew.TurnCount);
            Assert.AreEqual(400, dataNew.RoundCount);
            Assert.AreEqual(500, dataNew.MonsterSlainNumber);
            Assert.AreEqual(600, dataNew.ExperienceGainedTotal);
            Assert.AreEqual("characters", dataNew.CharacterAtDeathList);
            Assert.AreEqual("monsters", dataNew.MonstersKilledList);
            Assert.AreEqual("items", dataNew.ItemsDroppedList);
        }

        [Test]
        public void ScoreModel_Update_InValid_Null_Should_Fail()
        {
            // Arrange
            var dataOriginal = new ScoreModel();
            dataOriginal.TurnCount = 2;

            // Act
            var result = dataOriginal.Update(null);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
            Assert.AreEqual(2, dataOriginal.TurnCount);
        }

        [Test]
        public void ScoreModel_AddToList_Default_Should_Pass()
        {
            // Arrange
            var dataScore = new ScoreModel();

            var data = new ItemModel
            {
                Name = "Item1",
                Location = ItemLocationEnum.Feet,
                Attribute = AttributeEnum.Attack,
                Value = 1,
                Range = 2,
                Damage = 3
            };

            // Act
            var result = dataScore.AddToList(data);

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
            Assert.AreNotEqual(string.Empty, dataScore.ItemsDroppedList);
        }

        [Test]
        public void ScoreModel_AddToList_InValid_Null_Should_Pass()
        {
            // Arrange
            var dataScore = new ScoreModel();

            // Act
            var result = dataScore.AddToList(null);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }
    }
}