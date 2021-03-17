using Xamarin.Forms;
using Xamarin.Forms.Mocks;

using NUnit.Framework;

using Game.ViewModels;
using Game.Views;
using Game;
using Game.Models;
using System.Linq;

namespace Scenario
{
    [TestFixture]
    public class BattlePageScenarioTests
    {
        App app;
        BattlePage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            // Choose which engine to run
            BattleEngineViewModel.Instance.SetBattleEngineToGame();

            page = new BattlePage();
        }

        [TearDown]
        public void TearDown()
        {
            BattleEngineViewModel.Instance.EngineGame.EndBattle();
            Application.Current = null;
        }

        [Test]
        public void BattlePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BattlePage_RunBattle_Set_Attacker_Set_Defender_Attack_Returns_RoundEnum_NextTurn()
        {
            // Arrange

            //  Add Characters
            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Job = CharacterJobEnum.HeadChef,                                
                                Name = "Doug",
                                ListOrder = 1,
                            });

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(CharacterPlayerMike);

            //  Add Monsters
            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyMonsters = 1;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel() { PlayerType = PlayerTypeEnum.Monster});

           
           // Act
            RoundEnum result;

            // Set defender and attacker
            page.SetAttackerAndDefender();

            //Hit
            page.NextAttackExample();           

            result = BattleEngineViewModel.Instance.Engine.EngineSettings.RoundStateEnum;

            //Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.RoundStateEnum = RoundEnum.GameOver;
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();

            //Assert
            Assert.AreEqual(RoundEnum.NextTurn, result);       
        }
    }
}