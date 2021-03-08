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

        [Test]
        public void RoundEngine_MakePlayerList_HomeCook_Alive_With_CurrentHealth_20_Out_OF_20_Recovering_Should_Return_20_CurrentHealth()
        {
            /* 
             * Test Home Cook Specific Passive Ability .  
             * 
             * after first round a Home Cook still alive so it should be recovered by 10% of current max Health
             * Up to max health.
             * 
             * 1 Character
             *            
             *      1 Home Cook with current health:10 & current max health:20
             * 
             * 1 Monsters
             *      1 EvilRefrigerator
             * 
             * 
             *  HomeCook still alive and it's recovery should be 22 but because it's more than max health,20,
             *  it will stay at current max which is 20
             * 
             * 
             */

            //Arrange
            BattleEngine.EngineSettings.PlayerList.Clear();

            // Add Characters
            BattleEngine.EngineSettings.MaxNumberPartyCharacters = 1;

            var HomeCook = new PlayerInfoModel(
                              new CharacterModel
                              {
                                  Job = CharacterJobEnum.HomeCook,
                              });

            HomeCook.CurrentHealth = 20;
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
            Assert.AreEqual(20, HomeCookCurrentHealth);

        }


        [Test]
        public void RoundEngine_MakePlayerList_SushiChef_Can_Attack_From_AnyWhere_Range_Should_Return_20()
        {
            /* 
             * Test SushiChef Chef Specific Passive Ability .  
             * 
             * When a SushiChef selected as a characterList it will have range of 20 to attack from anywhere 
             * 
             * 
             * 1 Character
             *   
             *      1 SushiChef
             * 
             * 
             * 
             * SushiChef range become 20 when added to character list in the game
             * 
             * 
             */

            //Arrange
            BattleEngine.EndBattle();

            // Add Characters
            BattleEngine.EngineSettings.MaxNumberPartyCharacters = 1;

            var SushiChef = new PlayerInfoModel(
                              new CharacterModel
                              {
                                  Job = CharacterJobEnum.SushiChef,
                              });



            BattleEngine.EngineSettings.CharacterList.Add(SushiChef);


            RoundEngine RoundEngine = new RoundEngine();

            //set turn count to 1
            RoundEngine.EngineSettings.BattleScore.TurnCount = 0;

            //Act
            RoundEngine.MakePlayerList();
            var SushiChefRangeValue = RoundEngine.EngineSettings.CharacterList[0].Range;

            //Reset
            BattleEngine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;
            BattleEngine.EngineSettings.PlayerList.Clear();
            BattleEngine.EngineSettings.CharacterList.Clear();
            RoundEngine.EngineSettings.CharacterList.Clear();

            //Assert
            Assert.AreEqual(20, SushiChefRangeValue);

        }



        [Test]
        public void RoundEngine_AddMonstersToRound_All_6_Monsters_Have_Different_Type_Should_Return_True()
        {
            /* 
             * Test only monsters with unique type add to the playerlist.  
             * 
             * 6 random unique type Monsters should Add to the Playerlist
             * 
             *
             * 
             * 
             *  all the Monsters selected should has a unique type 
             * 
             * 
             */

            //Arrange
            BattleEngine.EngineSettings.PlayerList.Clear();
          
         
            // set engine to add 6 monsters
            BattleEngine.EngineSettings.MaxNumberPartyMonsters = 6;

            RoundEngine RoundEngine = new RoundEngine();

            //set turn count to 1
            RoundEngine.EngineSettings.BattleScore.TurnCount = 1;

            //Act
            RoundEngine.AddMonstersToRound();
            var result = true;

            // Check all mosnters have a unique type using their unique type descriptions
            foreach(var Mosnter in RoundEngine.EngineSettings.PlayerList)
            {
                foreach (var NewMonster in RoundEngine.EngineSettings.PlayerList)
                {
                    if ( Mosnter.Description == NewMonster.Description)
                    {
                        result = false;
                        break;
                    }
                }

                if(result == false)
                {
                    break;
                }
            }

            //Reset
            BattleEngine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;
            BattleEngine.EngineSettings.PlayerList.Clear();

            //Assert
            Assert.AreEqual(true, result);

        }
    }
}

