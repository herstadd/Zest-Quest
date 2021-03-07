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
    class RoundEngineScenarioTests
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
        public void RoundEngine_MakePlayerList_HomeCook_Alive_With_CurrentHealth_10_Out_OF_20_Recovering_Should_Return_12_CurrentHealth()
        {
            /* 
             * Test Home Cook Specific Passive Ability .  
             * 
             * after first round a Home Cook still alive so it should be recovered by 10% of current max Health
             * 
             * 1 Character
             *            
             *      1 Home Cook with current health:10 & current max health:20
             * 
             * 1 Monsters
             *      1 EvilRefrigerator
             * 
             * 
             *  HomeCook still alive Now Home Cook current health is 12/20 
             * 
             * 
             */

            //Arrange
            BattleEngine.EndBattle();

            // Add Characters
            BattleEngine.EngineSettings.MaxNumberPartyCharacters = 1;

            var HomeCook = new PlayerInfoModel(
                              new CharacterModel
                              {
                                  Job = CharacterJobEnum.HomeCook,                                 
                              });

            HomeCook.CurrentHealth = 10;
            HomeCook.MaxHealth = 20;
     

            BattleEngine.EngineSettings.PlayerList.Add(HomeCook);


            // Add Monsters
            var EvilRefrigerator = new PlayerInfoModel(
                new MonsterModel
                {
                    MonsterType = MonsterTypeEnum.EvilRefrigerator,
                });

            BattleEngine.EngineSettings.PlayerList.Add(EvilRefrigerator);
            BattleEngine.EngineSettings.MaxNumberPartyMonsters = 1;

            RoundEngine RoundEngine = new RoundEngine();

            //set turn count to 1
            RoundEngine.EngineSettings.BattleScore.TurnCount = 1;

            //Act
            RoundEngine.MakePlayerList();
            var HomeCookCurrentHealth = RoundEngine.EngineSettings.PlayerList[0].CurrentHealth;

            //Reset
            BattleEngine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;

            //Assert
            Assert.AreEqual(12, HomeCookCurrentHealth);

        }
    }
}

