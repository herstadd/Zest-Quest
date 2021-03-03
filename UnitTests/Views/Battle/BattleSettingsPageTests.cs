using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;

using Game;
using Game.Views;
using Game.Models;
using Game.ViewModels;
using Game.Helpers;

namespace UnitTests.Views
{
    [TestFixture]
    public class BattleSettingsPageTests
    {
        App app;
        BattleSettingsPage page;

       // public BattleSettingsPageTests() : base(true) { }

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

            page = new BattleSettingsPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void BattleSettingsPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BattleSettingsPage_CloseButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.CloseButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattleSettingsPage_AllowMonsterItems_Toggled_Default_Should_Pass()
        {
            // Arrange

            var control = (Switch)page.FindByName("AllowMonsterItemsSwitch");
            var current = control.IsToggled;

            ToggledEventArgs args = new ToggledEventArgs(current);

            // Act
            page.AllowMonsterItems_Toggled(null, args);

            // Reset

            // Assert
            Assert.IsTrue(!current); // Got to here, so it happened...
        }

        [Test]
        public void BattleSettingsPage_AllowMonsterItems_Toggled_True_Default_Should_Pass()
        {
            // Arrange

            var control = (Switch)page.FindByName("AllowMonsterItemsSwitch");
            var current = control.IsToggled;

            ToggledEventArgs args = new ToggledEventArgs(current);
            page.AllowMonsterItems_Toggled(null, args);

            control.IsToggled = true;

            // Act
            page.AllowMonsterItems_Toggled(null, args);

            // Reset

            // Assert
            Assert.IsTrue(!current); // Got to here, so it happened...
        }

        [Test]
        public void BattleSettingsPage_AllowCriticalMiss_Toggled_Default_Should_Pass()
        {
            // Arrange

            var control = (Switch)page.FindByName("AllowCriticalMissSwitch");
            var current = control.IsToggled;

            ToggledEventArgs args = new ToggledEventArgs(current);

            // Act
            page.AllowCriticalMiss_Toggled(null, args);

            // Reset

            // Assert
            Assert.IsTrue(!current); // Got to here, so it happened...
        }

        [Test]
        public void BattleSettingsPage_AllowCriticalMiss_Toggled_True_Default_Should_Pass()
        {
            // Arrange

            var control = (Switch)page.FindByName("AllowCriticalMissSwitch");
            var current = control.IsToggled;

            ToggledEventArgs args = new ToggledEventArgs(current);

            page.AllowCriticalMiss_Toggled(null, args);

            control.IsToggled = true;

            // Act
            page.AllowCriticalMiss_Toggled(null, args);

            // Reset

            // Assert
            Assert.IsTrue(!current); // Got to here, so it happened...
        }

        [Test]
        public void BattleSettingsPage_AllowCriticalHit_Toggled_Default_Should_Pass()
        {
            // Arrange

            var control = (Switch)page.FindByName("AllowCriticalHitSwitch");
            var current = control.IsToggled;

            ToggledEventArgs args = new ToggledEventArgs(current);

            // Act
            page.AllowCriticalHit_Toggled(null, args);

            // Reset

            // Assert
            Assert.IsTrue(!current); // Got to here, so it happened...
        }

        [Test]
        public void BattleSettingsPage_AllowCriticalHit_Toggled_True_Default_Should_Pass()
        {
            // Arrange

            var control = (Switch)page.FindByName("AllowCriticalHitSwitch");
            var current = control.IsToggled;

            ToggledEventArgs args = new ToggledEventArgs(current);
            page.AllowCriticalHit_Toggled(null, args);

            control.IsToggled = true;

            // Act
            page.AllowCriticalHit_Toggled(null, args);

            // Reset

            // Assert
            Assert.IsTrue(!current); // Got to here, so it happened...
        }

        [Test]
        public void BattleSettingsPage_BattleModePicker_Default_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnum.Unknown;

            var control = (Picker)page.FindByName("BattleModePicker");
            var currentIndex = control.SelectedIndex;
            var currentItem = control.SelectedItem;

            var args = new SelectedItemChangedEventArgs(currentItem, currentIndex);

            // Act
            page.BattleModePicker_Changed(null, args);

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.MapNext, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum);
        }

        [Test]
        public void BattleSettingsPage_BattleModePicker_InValid_Should_Fail()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnum.Unknown;

            var control = (Picker)page.FindByName("BattleModePicker");
            var currentIndex = control.SelectedIndex;
            var currentItem = control.SelectedItem;

            var args = new SelectedItemChangedEventArgs(currentItem, currentIndex);
            page.BattleModePicker_Changed(null, args);

            // Change it to to a bad one
            control.SelectedItem = null;

            // Act
            page.BattleModePicker_Changed(null, args);

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.MapNext, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum);
        }

        [Test]
        public void BattleSettingsPage_MonsterHitPicker_Valid_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            var control = (Picker)page.FindByName("MonsterHitPicker");
            var currentIndex = control.SelectedIndex;
            var currentItem = control.SelectedItem;

            var args = new SelectedItemChangedEventArgs(currentItem, currentIndex);
            page.MonsterHitPicker_Changed(null, args);

            // Act
            page.MonsterHitPicker_Changed(null, args);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Default, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum);
        }

        [Test]
        public void BattleSettingsPage_MonsterHitPicker_InValid_Should_Fail()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            var control = (Picker)page.FindByName("MonsterHitPicker");
            var currentIndex = control.SelectedIndex;
            var currentItem = control.SelectedItem;

            var args = new SelectedItemChangedEventArgs(currentItem, currentIndex);
            page.MonsterHitPicker_Changed(null, args);

            // Change it to to a bad one
            control.SelectedItem = null;

            // Act
            page.MonsterHitPicker_Changed(null, args);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Default, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum);
        }

        [Test]
        public void BattleSettingsPage_CharacterHitPicker_Valid_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;

            var control = (Picker)page.FindByName("CharacterHitPicker");
            var currentIndex = control.SelectedIndex;
            var currentItem = control.SelectedItem;

            var args = new SelectedItemChangedEventArgs(currentItem, currentIndex);
            page.CharacterHitPicker_Changed(null, args);

            // Act
            page.CharacterHitPicker_Changed(null, args);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Default, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum);
        }

        [Test]
        public void BattleSettingsPage_CharacterHitPicker_InValid_Should_Fail()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;

            var control = (Picker)page.FindByName("CharacterHitPicker");
            var currentIndex = control.SelectedIndex;
            var currentItem = control.SelectedItem;

            var args = new SelectedItemChangedEventArgs(currentItem, currentIndex);
            page.CharacterHitPicker_Changed(null, args);

            // Change it to to a bad one
            control.SelectedItem = null;

            // Act
            page.CharacterHitPicker_Changed(null, args);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Default, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum);
        }
    }
}