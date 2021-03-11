using NUnit.Framework;

using Game.Models;
using System.Threading.Tasks;
using Game.ViewModels;
using Game.Helpers;

namespace Scenario
{
    [TestFixture]
    public class HackathonScenarioTests
    {
        #region TestSetup
        readonly BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        [SetUp]
        public void Setup()
        {
            // Choose which engine to run
            EngineViewModel.SetBattleEngineToGame();

            // Put seed data into the system for all tests
            EngineViewModel.Engine.Round.ClearLists();

            //Start the Engine in AutoBattle Mode
            EngineViewModel.Engine.StartBattle(false);

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = false;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss = false;
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Scenario0
        [Test]
        public void HakathonScenario_Scenario_0_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      #
            *      
            * Description: 
            *      <Describe the scenario>
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      <List Files Changed>
            *      <List Classes Changed>
            *      <List Methods Changed>
            * 
            * Test Algrorithm:
            *      <Step by step how to validate this change>
            * 
            * Test Conditions:
            *      <List the different test conditions to make>
            * 
            * Validation:
            *      <List how to validate this change>
            *  
            */

            // Arrange

            // Act

            // Assert
           

            // Act
            var result = EngineViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Scenario0

        #region Scenario1
        [Test]
        public async Task HackathonScenario_1_Mike_Dies_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      1
            *      
            * Description: 
            *      Make a Character called Mike, who dies in the first round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create Character named Mike
            *      Set speed to -1 so he is really slow
            *      Set Max health to 1 so he is weak
            *      Set Current Health to 1 so he is weak
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Mike is not in the Player List
            *      Verify Round Count is 1
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1, // Will go last...
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            //Act
            var result = await EngineViewModel.AutoBattleEngine.RunAutoBattle();

            //Reset
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, EngineViewModel.Engine.EngineSettings.PlayerList.Find(m => m.Name.Equals("Mike")));
            //Assert.AreEqual(1, EngineViewModel.Engine.EngineSettings.BattleScore.RoundCount);
        }
        #endregion Scenario1

        #region Scenario2
        [Test]
        public async Task HackathonScenario_2_Bob_Always_Miss_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      2
            *      
            * Description: 
            *      Make a Character called Bob, who always misses hitting
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      TurnAsAttack function in TurnEngine.cs 
            *      - If the Attacker's name is Bob, it will return false;
            * 
            * Test Algrorithm:
            *      Create Character named Bob
            *  
            *      Startup Battle
            *      Run Battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify TurnAsAttack Returned False
            *      Verify Bob is not in the Player List
            *      Verify current health of the monster in the list is still max health
            *      
            */

            //Arrange

            // Set Character Conditions
            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 3,
                                Level = 1,
                                CurrentHealth = 10,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Bob",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            // Set Monster Conditions
            EngineViewModel.Engine.EngineSettings.MaxNumberPartyMonsters = 1;

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            //Act
            var result = await EngineViewModel.AutoBattleEngine.RunAutoBattle();
            var MonsterCurrHealth = EngineViewModel.Engine.EngineSettings.MonsterList[0].CurrentHealth;
            var MonsterMaxHealth = EngineViewModel.Engine.EngineSettings.MonsterList[0].MaxHealth;

            //Reset
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;
            EngineViewModel.Engine.EngineSettings.MonsterList.Clear();

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, EngineViewModel.Engine.EngineSettings.PlayerList.Find(m => m.Name.Equals("Bob")));
            Assert.AreEqual(MonsterMaxHealth, MonsterCurrHealth);
        }
        #endregion Scenario2

        #region Scenario4
        [Test]
        public void HackathonScenario_4_Player_Critical_Hit_Should_Return_2()
        {
            /* 
            * Scenario Number:  
            *      4
            *      
            * Description: 
            *      Make a character who will critical hit a monster
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create Character
            *      Set speed to 100 so really fast
            *      Set Max health to 1 so he is weak
            *      Set Current Health to 1 so he is weak
            *      
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify DamageAmount is 2 instead of 1
            *  
            */

            //Arrange

            Game.Engine.EngineGame.TurnEngine TurnEngine = new Game.Engine.EngineGame.TurnEngine();
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Set Character Conditions

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100, // Will go first...
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                            });

            var MonsterFridge = new PlayerInfoModel(
                            new MonsterModel
                            {
                                MonsterType = MonsterTypeEnum.EvilRefrigerator,
                                Name = "Frigid",
                            });

            // Allow critical hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = true;

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            //Act
            var result = TurnEngine.TurnAsAttack(CharacterPlayerMike, MonsterFridge);

            //Reset
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = false;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(2, EngineViewModel.Engine.EngineSettings.BattleMessagesModel.DamageAmount);
        }
        #endregion Scenario4

        #region Scenario10
        [Test]
        public void HackathonScenario_10_Player_Die_Should_Revive_Max_Health()
        {
            /* 
            * Scenario Number:  
            *      10
            *      
            * Description: 
            *      Make a character who will get hit and die then check if they revive with CurrentHealth == MaxHealth
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Add class variable to BasePlayerModel.cs
            *      Change ApplyDamage in TurnEngine.cs
            * 
            * Test Algrorithm:
            *      Create Character
            *      Set Max health to 10
            *      Set Current Health to 1 so he is weak
            *      Have the character take 2 damage so they would die
            *      
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify damage check returned -1
            *      Verify CurrentHealth is 10 (equal to MaxHealth) instead of 1
            *  
            */

            //Arrange

            Game.Engine.EngineGame.TurnEngine TurnEngine = new Game.Engine.EngineGame.TurnEngine();
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Set Character Conditions

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100, // Will go first...
                                Level = 1,
                                CurrentHealth = 1,
                                MaxHealth = 10,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                Job = CharacterJobEnum.HeadChef,
                                PlayerType = PlayerTypeEnum.Character,
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            // Allow critical hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = true;

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;
            EngineViewModel.Engine.EngineSettings.BattleMessagesModel.DamageAmount = 2;

            //Act
            var result = TurnEngine.ApplyDamage(CharacterPlayerMike);

            //Reset
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = false;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;
            EngineViewModel.Engine.EngineSettings.BattleMessagesModel.DamageAmount = 0;
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(-1, result);
            Assert.AreEqual(10, CharacterPlayerMike.CurrentHealth);
        }

        public void HackathonScenario_10_Player_Die_Should_Revive_Not_Revive_Second_Time_Return_Damage_Amount()
        {
            /* 
            * Scenario Number:  
            *      10
            *      
            * Description: 
            *      Make a character who will get hit and die then check if they revive with CurrentHealth == MaxHealth
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Add class variable to BasePlayerModel.cs
            *      Change ApplyDamage in TurnEngine.cs
            * 
            * Test Algrorithm:
            *      Create Character
            *      Set Max health to 10
            *      Set Current Health to 1 so he is weak
            *      Set SavedByMax to true
            *      Have the character take 2 damage so they would die
            *      
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify damage check returned 2
            *      Verify CurrentHealth is 0
            *      Verify character is removed
            *  
            */

            //Arrange

            Game.Engine.EngineGame.TurnEngine TurnEngine = new Game.Engine.EngineGame.TurnEngine();
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Set Character Conditions

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100, // Will go first...
                                Level = 1,
                                CurrentHealth = 1,
                                MaxHealth = 10,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                Job = CharacterJobEnum.HeadChef,
                                PlayerType = PlayerTypeEnum.Character,
                                SavedByMax = true,
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            // Allow critical hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = true;

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;
            EngineViewModel.Engine.EngineSettings.BattleMessagesModel.DamageAmount = 2;

            //Act
            var result = TurnEngine.ApplyDamage(CharacterPlayerMike);

            //Reset
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = false;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;
            EngineViewModel.Engine.EngineSettings.BattleMessagesModel.DamageAmount = 0;
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(2, result);
            Assert.AreEqual(0, CharacterPlayerMike.CurrentHealth);
            Assert.AreEqual(null, EngineViewModel.Engine.EngineSettings.PlayerList.Find(m => m.Name.Equals("Mike")));
        }
        #endregion Scenario10

        #region Scenario36
        [Test]
        public void HackathonScenario_36_Character_Damaged_And_Pet_Spawns_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *       36
            *      
            * Description: 
            *      Make a Character called GetPet who gets hit and then gets a pet
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine.cs:  Add in a check to remove any pets and clear any flags for characters having had pets
            *      TurnEngine.cs:  Add in code to create a new pet for a character only the first time they get hit
            *      CharacterJobEnum.cs: Add new Pet enum
            *      BasePlayerModel.cs:  Create HadPet bool to keep track if a character had a pet
            *      CharacterModel.cs:  Create HadPet bool to keep track if a character had a pet
            *      MapModel.cs: Create new function to put pet onto empty square on grid
            *      PlayerInfoModel.cs:  Update HadPet for player info model.
            *      
            * 
            * Test Algrorithm:
            *      Create Character named GetPet
            *      GetPet character gets hit and as a result receives a pet            *      
            * 
            * Test Conditions:
            *      Check for pet's name existing in player list
            *      Check that first GetPet character has a pet
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Player with name "Pet Smiling Sun" exists
            *      Verify GetPet character has a pet
            */

            // Arrange
            EngineViewModel.Engine.EndBattle();
            EngineViewModel.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Unknown;
            EngineViewModel.Engine.EngineSettings.PlayerList.Clear();
            EngineViewModel.Engine.EngineSettings.CharacterList.Clear();
            EngineViewModel.Engine.EngineSettings.MonsterList.Clear();

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            EngineViewModel.Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            var CharacterToGetPet = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 100,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 10,
                                Name = "GetPet",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterToGetPet);

            // Force a Hit
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            var result_first_character = EngineViewModel.Engine.Round.Turn.TurnAsAttack(MonsterPlayer, CharacterToGetPet);

            // Reset
            DiceHelper.DisableForcedRolls();
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            // Assert
            Assert.AreEqual(true, result_first_character);
            Assert.AreEqual(true, CharacterToGetPet.HadPet);
            Assert.NotNull(EngineViewModel.Engine.EngineSettings.PlayerList.Find(m => m.Name.Equals("Pet Smiling Sun")));
        }

        [Test]
        public void HackathonScenario_36_Second_Damaged_Character_Should_Not_Get_Pet_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *       36
            *      
            * Description: 
            *      Make a Character called GetPet who gets hit and then gets a pet and another named
            *      GetNoPet who will not get a pet because they are number 2 in line and a pet already exists
            *      for GetPet.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine.cs:  Add in a check to remove any pets and clear any flags for characters having had pets
            *      TurnEngine.cs:  Add in code to create a new pet for a character only the first time they get hit
            *      CharacterJobEnum.cs: Add new Pet enum
            *      BasePlayerModel.cs:  Create HadPet bool to keep track if a character had a pet
            *      CharacterModel.cs:  Create HadPet bool to keep track if a character had a pet
            *      MapModel.cs: Create new function to put pet onto empty square on grid
            *      PlayerInfoModel.cs:  Update HadPet for player info model.
            *      
            * 
            * Test Algrorithm:
            *      Create Character named GetPet
            *      Create Character name GetNoPet
            *      GetPet character gets hit and as a result receives a pet
            *      GetNoPet character gets hit and does not receive a pet because GetPet has one
            *      
            * 
            * Test Conditions:
            *      Check for pet's name existing in player list
            *      Check that first GetPet character has a pet
            *      Check that second GetNoPet character has no pet
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Player with name "Pet Smiling Sun" exists
            *      Verify GetPet character has a pet
            *      Verify that GetNoPet character has no pet
            */

            // Arrange
            EngineViewModel.Engine.EndBattle();
            EngineViewModel.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Unknown;
            EngineViewModel.Engine.EngineSettings.PlayerList.Clear();
            EngineViewModel.Engine.EngineSettings.CharacterList.Clear();
            EngineViewModel.Engine.EngineSettings.MonsterList.Clear();

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            EngineViewModel.Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            var CharacterToGetPet = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 100,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 10,
                                Name = "GetPet",
                            });

            var CharacterNotToGetPet = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 100,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 10,
                                Name = "GetNoPet",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterToGetPet);
            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterNotToGetPet);

            // Force a Hit
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            var result_first_character = EngineViewModel.Engine.Round.Turn.TurnAsAttack(MonsterPlayer, CharacterToGetPet);
            var result_second_character = EngineViewModel.Engine.Round.Turn.TurnAsAttack(MonsterPlayer, CharacterNotToGetPet);

            // Reset
            DiceHelper.DisableForcedRolls();
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            // Assert
            Assert.AreEqual(true, result_first_character);
            Assert.AreEqual(true, result_second_character);
            Assert.AreEqual(false, CharacterNotToGetPet.HadPet);
            Assert.AreEqual(true, CharacterToGetPet.HadPet);
        }

        [Test]
        public void HackathonScenario_36_Character_That_Had_Pet_Should_Not_Get_Another_This_Round_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *       36
            *      
            * Description: 
            *      Ensure that a pet is not generated if a character used to have a pet in the past during this round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine.cs:  Add in a check to remove any pets and clear any flags for characters having had pets
            *      TurnEngine.cs:  Add in code to create a new pet for a character only the first time they get hit
            *      CharacterJobEnum.cs: Add new Pet enum
            *      BasePlayerModel.cs:  Create HadPet bool to keep track if a character had a pet
            *      CharacterModel.cs:  Create HadPet bool to keep track if a character had a pet
            *      MapModel.cs: Create new function to put pet onto empty square on grid
            *      PlayerInfoModel.cs:  Update HadPet for player info model.
            *      
            * 
            * Test Algrorithm:
            *      Create Character named GetPet
            *      Denote that they used to have a pet, but don't give them a pet
            *      Create Character GetNoPet
            *      
            * 
            * Test Conditions:
            *      Check that first GetPet character had a pet
            *      Check that second GetNoPet character has no pet
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify GetPet character had a pet
            *      Verify that GetNoPet character has no pet
            */

            // Arrange
            EngineViewModel.Engine.EndBattle();
            EngineViewModel.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Unknown;
            EngineViewModel.Engine.EngineSettings.PlayerList.Clear();
            EngineViewModel.Engine.EngineSettings.CharacterList.Clear();
            EngineViewModel.Engine.EngineSettings.MonsterList.Clear();

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            EngineViewModel.Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            var CharacterToGetPet = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 100,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 10,
                                Name = "GetPet",
                            });

            var CharacterNotToGetPet = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 100,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 10,
                                Name = "GetNoPet",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterToGetPet);
            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterNotToGetPet);

            // Force a Hit
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            CharacterToGetPet.HadPet = true;
            var result_second_character = EngineViewModel.Engine.Round.Turn.TurnAsAttack(MonsterPlayer, CharacterNotToGetPet);

            // Reset
            DiceHelper.DisableForcedRolls();
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            // Assert
            Assert.AreEqual(true, result_second_character);
            Assert.AreEqual(false, CharacterNotToGetPet.HadPet);
            Assert.AreEqual(true, CharacterToGetPet.HadPet);
        }


        #endregion Scenario36

        #region Scenario38

        [Test]
        public void HackathonScenario_38_Character_Test_Stub_Should_Pass_TODO()
        {
            /* 
            * Scenario Number:  
            *       38
            *      
            * Description: 
            *      Ensure that a pet is not generated if a character used to have a pet in the past during this round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine.cs:  Add in a check to remove any pets and clear any flags for characters having had pets
            *      TurnEngine.cs:  Add in code to create a new pet for a character only the first time they get hit
            *      CharacterJobEnum.cs: Add new Pet enum
            *      BasePlayerModel.cs:  Create HadPet bool to keep track if a character had a pet
            *      CharacterModel.cs:  Create HadPet bool to keep track if a character had a pet
            *      MapModel.cs: Create new function to put pet onto empty square on grid
            *      PlayerInfoModel.cs:  Update HadPet for player info model.
            *      
            * 
            * Test Algrorithm:
            *      Create Character named GetPet
            *      Denote that they used to have a pet, but don't give them a pet
            *      Create Character GetNoPet
            *      
            * 
            * Test Conditions:
            *      Check that first GetPet character had a pet
            *      Check that second GetNoPet character has no pet
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify GetPet character had a pet
            *      Verify that GetNoPet character has no pet
            */

            // Arrange
            EngineViewModel.Engine.EndBattle();
            EngineViewModel.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Unknown;
            EngineViewModel.Engine.EngineSettings.PlayerList.Clear();
            EngineViewModel.Engine.EngineSettings.CharacterList.Clear();
            EngineViewModel.Engine.EngineSettings.MonsterList.Clear();

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            EngineViewModel.Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            var CharacterToGetPet = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 100,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 10,
                                Name = "GetPet",
                            });

            var CharacterNotToGetPet = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 100,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 10,
                                Name = "GetNoPet",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterToGetPet);
            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterNotToGetPet);

            // Force a Hit
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            CharacterToGetPet.HadPet = true;
            var result_second_character = EngineViewModel.Engine.Round.Turn.TurnAsAttack(MonsterPlayer, CharacterNotToGetPet);

            // Reset
            DiceHelper.DisableForcedRolls();
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            // Assert
            Assert.AreEqual(true, result_second_character);
            Assert.AreEqual(false, CharacterNotToGetPet.HadPet);
            Assert.AreEqual(true, CharacterToGetPet.HadPet);
        }


        #endregion Scenario38
    }

}
