using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using NUnit.Framework;

using Game.Engine.EngineGame;
using Game.Models;
using Game.Helpers;
using Game.ViewModels;
using Game.Engine.EngineModels;

namespace UnitTests.Scenarios
{
    [TestFixture]
    class TurnEngineScenarioTests
    {
        BattleEngine BattleEngine;

        [SetUp]
        public void Setup()
        {
            BattleEngine = new BattleEngine();
        }

        [TearDown]
        public void TearDown()
        {
            BattleEngine.EndBattle();
        }

        [Test]
        public void TurnEngine_TargetDied_SchoolChef_Died_And_HeadChef_With_Attack_Value_10_Should_Return_BuffAttackValue_2()
        {
            /* 
             * Test School Chef Specific Passive Ability .  
             * 
             * When a School Chef dies, provides a 20% attack buff to the rest of 
             * the team
             * 
             * 2 Character
             *   
             *      1 School Chef
             *      1 Head Chef with attack value of 10 with BuffAttackValue = 0 
             * 
             * 1 Monsters
             *      1 EvilRefrigerator
             * 
             * 
             * When School Chef dies then Head Chef BuffAttackValue increases to 2
             * 
             * 
             */

            //Arrange
            BattleEngine.EndBattle();
            BattleEngine.EngineSettings.CharacterList.Clear();
            BattleEngine.EngineSettings.MonsterList.Clear();
            BattleEngine.EngineSettings.BattleStateEnum = BattleStateEnum.Unknown;

            // Add Characters
            BattleEngine.EngineSettings.MaxNumberPartyCharacters = 2;

            var SchoolChef = new PlayerInfoModel(
                              new CharacterModel
                              {
                                  Job = CharacterJobEnum.SchoolChef,
                              });

            var HeadChef = new PlayerInfoModel(
                new CharacterModel
                {
                    Job = CharacterJobEnum.HeadChef,
                    Attack = 10,
                });

            BattleEngine.EngineSettings.CharacterList.Add(SchoolChef);
            BattleEngine.EngineSettings.CharacterList.Add(HeadChef);


            // Add Monsters
            var EvilRefrigerator = new PlayerInfoModel(
                new MonsterModel
                {
                    MonsterType = MonsterTypeEnum.EvilRefrigerator,
                });

            BattleEngine.EngineSettings.MonsterList.Add(EvilRefrigerator);
            BattleEngine.EngineSettings.MaxNumberPartyMonsters = 1;

            TurnEngine TurnEnging = new TurnEngine();

            //Act
            TurnEnging.TargetDied(SchoolChef);
            var HeadChefBuffAttackValue = BattleEngine.EngineSettings.CharacterList[0].BuffAttackValue;

            //Reset
            BattleEngine.EngineSettings.CharacterList.Remove(SchoolChef);
            BattleEngine.EngineSettings.CharacterList.Remove(HeadChef);
            BattleEngine.EngineSettings.MonsterList.Remove(EvilRefrigerator);
            BattleEngine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;


            //Assert
            Assert.AreEqual(2, HeadChefBuffAttackValue);

        }

        [Test]
        public void TurnEngine_TargetDied_CatChef_Died_Should_Revive()
        {
            /* 
             * Test Cat Chef Specific Passive Ability .  
             * 
             * When a Cat Chef dies, 50% chance of revival with max health cut in half
             * 
             * 1 Character
             *   
             *      1 Cat Chef
             * 
             * 1 Monsters
             *      1 EvilRefrigerator
             * 
             * 
             * When Cat Chef dies, max health cut in half if revived
             * 
             * 
             */

            //Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);
            BattleEngine.EndBattle();

            // Add Characters
            BattleEngine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CatChef = new PlayerInfoModel(
                              new CharacterModel
                              {
                                  Job = CharacterJobEnum.CatChef,
                                  MaxHealth = 100
                              });


            BattleEngine.EngineSettings.CharacterList.Add(CatChef);

            // Add Monsters
            var EvilRefrigerator = new PlayerInfoModel(
                new MonsterModel
                {
                    MonsterType = MonsterTypeEnum.EvilRefrigerator,
                });

            BattleEngine.EngineSettings.MonsterList.Add(EvilRefrigerator);
            BattleEngine.EngineSettings.MaxNumberPartyMonsters = 1;

            TurnEngine TurnEngine = new TurnEngine();

            //Act
            TurnEngine.TargetDied(CatChef);
            var CatChefAlive = TurnEngine.EngineSettings.CharacterList[0].Alive;
            var CatChefHealth = TurnEngine.EngineSettings.CharacterList[0].MaxHealth;

            //Reset
            DiceHelper.DisableForcedRolls();
            BattleEngine.EngineSettings.CharacterList.Remove(CatChef);
            BattleEngine.EngineSettings.MonsterList.Remove(EvilRefrigerator);

            //Assert
            Assert.AreEqual(true, CatChefAlive);
            Assert.AreEqual(50, CatChefHealth);
        }

        [Test]
        public void TurnEngine_SousChef_Can_Pass_Wall_Should_Pass()
        {
            /* 
             * Test Sous Chef Specific Passive Ability   
             * 
             * When a monster is far away, Sous Chef can pass a wall to get closer to the monster
             * 
             *  Character
             *   
             *      1 Sous Chef
             * 
             * 1 Monsters
             *      1 EvilRefrigerator
             * 
             * 
             * When it's Sous Chef's turn, Sous chef will pass a wall and move closer to the monster.
             * 
             * 
             */

            //Arrange
            BattleEngine.EndBattle();

            // Create PlayerList
            var PlayerList = new List<PlayerInfoModel>();

            // Add Character
            BattleEngine.EngineSettings.MaxNumberPartyCharacters = 1;
            var SosuChef = new PlayerInfoModel(
                              new CharacterModel
                              {
                                  Job = CharacterJobEnum.SousChef,
                              });
            PlayerList.Add(SosuChef);
            //BattleEngine.EngineSettings.CharacterList.Add(SosuChef);

            // Add Monster
            BattleEngine.EngineSettings.MaxNumberPartyMonsters = 1;
            var EvilRefrigerator = new PlayerInfoModel(new MonsterModel { });
            PlayerList.Add(EvilRefrigerator);
            //BattleEngine.EngineSettings.MonsterList.Add(EvilRefrigerator);

            // Populate the character and monster in the map
            BattleEngine.EngineSettings.MapModel.PopulateMapModel(PlayerList);

            // Create a location for the chef in the map
            MapModelLocation playerNext = new MapModelLocation();
            playerNext.Row = 0;
            playerNext.Column = 1;

            // Create a location for the monster in the map
            MapModelLocation monsterNext = new MapModelLocation();
            monsterNext.Row = 4;
            monsterNext.Column = 1;

            // Get the current locations of the monster and chef
            var CurrentLocationPlayer = BattleEngine.EngineSettings.MapModel.GetLocationForPlayer(SosuChef);
            var CurrentlocationMonster = BattleEngine.EngineSettings.MapModel.GetLocationForPlayer(EvilRefrigerator);

            // Force both monster and chef to move to the desingated locations
            BattleEngine.EngineSettings.MapModel.MovePlayerOnMap(CurrentLocationPlayer, playerNext);
            BattleEngine.EngineSettings.MapModel.MovePlayerOnMap(CurrentlocationMonster, monsterNext);

            // Create a TurnEnging
            TurnEngine TurnEnging = new TurnEngine();

            //Act
            // Operate only 1 turn
            TurnEnging.TakeTurn(SosuChef);

            // Get the location of the character
            var result = BattleEngine.EngineSettings.MapModel.GetEmptyLocationsSousChef(monsterNext, playerNext);

            //Reset
            BattleEngine.EngineSettings.CharacterList.Remove(SosuChef);
            BattleEngine.EngineSettings.CharacterList.Remove(EvilRefrigerator);

            //Assert
            Assert.AreEqual(5, result.Row);
            Assert.AreEqual(1, result.Column);
        }
    }
}
