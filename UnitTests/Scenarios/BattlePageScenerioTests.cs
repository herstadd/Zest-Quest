using System.Threading.Tasks;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;

using NUnit.Framework;

using Game.Helpers;
using Game.ViewModels;
using Game.Views;
using Game.Engine;
using Game.Models;
using Game;

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

            page = new BattlePage();
        }

        [TearDown]
        public void TearDown()
        {
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

       //[Test]
       // public void BattlePage_RunBattle_Monsters_1_Should_Pass()
       // {
       //     //Arrange

       //     // Add Characters

       //     page.EngineViewModel.MaxNumberPartyCharacters = 1;

       //     var CharacterPlayerMike = new PlayerInfoModel(
       //                     new CharacterModel
       //                     {
       //                         Speed = -1,
       //                         Level = 10,
       //                         CurrentHealth = 11,
       //                         ExperienceTotal = 1,
       //                         ExperienceRemaining = 1,
       //                         Name = "Mike",
       //                         ListOrder = 1,
       //                     });

       //     page.EngineViewModel.CharacterList.Add(CharacterPlayerMike);


       //     // Add Monsters

       //     // Need to set the Monster count to 1, so the battle goes to Next Round Faster
       //     page.EngineViewModel.Engine.EngineSettings.MaxNumberPartyMonsters = 1;


       //     page.EngineViewModel.SetCurrentDefender( page.EngineViewModel.PlayerList.Where(m => m.PlayerType == PlayerTypeEnum.Monster).FirstOrDefault();
       //     page.EngineViewModel.Engine.Round.SetCurrentAttacker(page.EngineViewModel.PlayerList.Where(m => m.PlayerType == PlayerTypeEnum.Character).FirstOrDefault();

       //     //Act
       //     RoundEnum result;

       //     // First Character Hits
       //     page.AttackButton_Clicked(null, null);
       //     result = page.EngineViewModel.Engine.RoundStateEnum;
       //     Assert.AreEqual(RoundEnum.NextTurn, result);

       //     // Monsters Turn
       //     page.AttackButton_Clicked(null, null);
       //     result = page.EngineViewModel.Engine.RoundStateEnum;
       //     Assert.AreEqual(RoundEnum.NextTurn, result);

       //     //// loop until game over
       //     //do
       //     //{
       //     //    page.AttackButton_Clicked(null, null);
       //     //    result = page.EngineViewModel.Engine.RoundStateEnum;
       //     //    Assert.AreEqual(RoundEnum.NextTurn, result);
       //     //}
       //     //while (result != RoundEnum.GameOver);

       //     //Reset

       //     //Assert
       //     Assert.AreEqual(true, true);
       // }
    }
}