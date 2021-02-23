using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class PlayerInfoModelTests
    {
        [Test]
        public void PlayerInfoModel_Constructor_Default_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel();

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            
            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Monster_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        //[Test]
        //public void PlayerInfoModel_Constructor_Character_Fighter_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new CharacterModel { Job = CharacterJobEnum.Fighter};

        //    // Act
        //    var result = new PlayerInfoModel(data);

        //    // Reset

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //[Test]
        //public void PlayerInfoModel_Constructor_Character_Cleric_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new CharacterModel { Job = CharacterJobEnum.Cleric};

        //    // Act
        //    var result = new PlayerInfoModel(data);

        //    // Reset

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        [Test]
        public void PlayerInfoModel_Constructor_Character_Unknown_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.Unknown };

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_SousChef_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.SousChef };

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_HeadChef_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.HeadChef };

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_SchoolChef_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.SchoolChef };

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_SushiChef_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.SushiChef };

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_CatChef_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.CatChef };

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_HomeCook_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.HomeCook };

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_IsAbilityAvailable_Available_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.SousChef });

            // Act
            var result = data.IsAbilityAvailable(AbilityEnum.Heal);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void PlayerInfoModel_IsAbilityAvailable_Available_Zero_Should_Fail()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.SousChef });
            data.AbilityTracker[AbilityEnum.Heal] = 0;

            // Act
            var result = data.IsAbilityAvailable(AbilityEnum.Heal);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PlayerInfoModel_SelectHealingAbility_SousChef_Heal_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.SousChef });
            data.AbilityTracker[AbilityEnum.Heal] = 1;

            data.CurrentHealth = 1;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Heal, result);
        }

        [Test]
        public void PlayerInfoModel_SelectHealingAbility_SousChef_Heal_Not_Needed_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.SousChef });
            data.AbilityTracker[AbilityEnum.Heal] = 1;

            data.CurrentHealth = 100;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void PlayerInfoModel_SelectHealingAbility_SousChef_Heal_Not_Available_Should_Return_Unknown()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.SousChef });
            data.AbilityTracker[AbilityEnum.Heal] = 0;
            data.AbilityTracker[AbilityEnum.Bandage] = 0;

            data.CurrentHealth = 1;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void PlayerInfoModel_SelectHealingAbility_Default_Bandage_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Unknown });
            data.AbilityTracker[AbilityEnum.Bandage] = 1;

            data.CurrentHealth = 1;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Bandage, result);
        }

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_CatChef_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.CatChef });
            data.AbilityTracker[AbilityEnum.Nimble] = 1;

            // Act
            var result = data.SelectAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Nimble, result);
        }

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_SousChef_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.SousChef });
            data.AbilityTracker[AbilityEnum.Quick] = 1;

            // Act
            var result = data.SelectAbilityToUse();

            // Reset

            // Assert
        }

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_Monster_Should_Return_False()
        {
            // Arrange
            var data = new PlayerInfoModel(new MonsterModel());

            // Act
            var result = data.SelectAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_SousChef_Heal_Should_Skip()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.SousChef });
            data.AbilityTracker[AbilityEnum.Quick] = 0;
            data.AbilityTracker[AbilityEnum.Barrier] = 0;
            data.AbilityTracker[AbilityEnum.Curse] = 0;

            // Act
            var result = data.SelectAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }
    }
}