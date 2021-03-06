using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using NUnit.Framework;

using Xamarin.Forms.Mocks;

using Game.ViewModels;
using Game.Models;

namespace UnitTests.ViewModels
{
    public class BattleEngineViewModelTests
    {
        BattleEngineViewModel ViewModel;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            ViewModel = BattleEngineViewModel.Instance;
        }

        [Test]
        public void BattleEngineViewModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BattleEngineViewModel_Constructor_BattleEngine_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result.Engine);
        }

        [Test]
        public void BattleEngineViewModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result.DatabaseCharacterList);
            Assert.IsNotNull(result.PartyCharacterList);
        }

        [Test]
        public void BattleEngineViewModel_Add_Default_Should_Pass()
        {
            // Arrange
            var result = ViewModel;

            var countBefore = result.DatabaseCharacterList.Count();

            // Act
            result.DatabaseCharacterList.Add(new CharacterModel());
            result.PartyCharacterList.Add(new CharacterModel());


            // Reset

            // Assert
            Assert.AreEqual(countBefore + 1, result.DatabaseCharacterList.Count());
            Assert.AreEqual(1, result.PartyCharacterList.Count());
        }

        [Test]
        public void BattleEngineViewModel_Set_Default_Should_Pass()
        {
            // Arrange
            var result = ViewModel;

            var countBefore = result.DatabaseCharacterList.Count();

            // Act
            result.DatabaseCharacterList = new ObservableCollection<CharacterModel>();
            result.PartyCharacterList = new ObservableCollection<CharacterModel>();


            // Reset

            // Assert
            Assert.AreEqual(0, result.DatabaseCharacterList.Count());
            Assert.AreEqual(0, result.PartyCharacterList.Count());
        }
    }
}