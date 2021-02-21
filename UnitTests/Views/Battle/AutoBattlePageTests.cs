using NUnit.Framework;

using Game;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.Helpers;
using Game.Models;
using Game.Engine;
using Game.ViewModels;

namespace UnitTests.Views
{
    [TestFixture]
    public class AutoBattlePageTests
    {
        App app;
        AutoBattlePage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            // For now, set the engine to the Koenig Engine, change when ready 
            BattleEngineViewModel.Instance.SetBattleEngineToKoenig();

            page = new AutoBattlePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void AutoBattlePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AutoBattlePage_AttackButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(3);

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(3);

            var data = new CharacterModel { Level = 1, MaxHealth = 10 };

            page.AutoBattle.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            page.AutoBattle.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            page.AutoBattle.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            page.AutoBattle.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            page.AutoBattle.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            page.AutoBattle.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));

            // Act
            page.AutobattleButton_Clicked(null, null);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}