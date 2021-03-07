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
            var HeadChefBuffAttackValue = TurnEnging.EngineSettings.CharacterList[0].BuffAttackValue;

            //Reset

            //Assert
            Assert.AreEqual(2, HeadChefBuffAttackValue);

        }
    }
}
