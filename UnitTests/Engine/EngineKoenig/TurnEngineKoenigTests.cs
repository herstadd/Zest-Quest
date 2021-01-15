using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using Game.ViewModels;
using Game.Engine.EngineKoenig;
using Game.Engine.EngineModels;

namespace UnitTests.Engine.EngineKoenig
{
    [TestFixture]
    public class TurnEngineKoenigTests
    {
        #region TestSetup
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();
            Engine.StartBattle(true);   // Start engine in auto battle mode
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void TurnEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor

        #region Attack
        [Test]
        public void TurnEngine_Attack_Valid_Empty_Monster_List_Should_Fail()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            // Act
            var result = Engine.Round.Turn.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_Attack_InValid_Empty_Character_List_Should_Fail()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new MonsterModel());

            // Cause an error by making the list empty
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CurrentDefender = null;
            Engine.EngineSettings.CurrentAttacker = null;

            Engine.StartBattle(true);   // Clear the Engine

            // Act
            var result = Engine.Round.Turn.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_Attack_Valid_Correct_List_Should_Pass()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel();
            Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

            // Act
            var result = Engine.Round.Turn.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion Attack

        #region SelectMonsterToAttack
        [Test]
        public void TurnEngine_SelectMonsterToAttack_InValid_Null_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.EngineSettings.PlayerList;

            Engine.EngineSettings.PlayerList = null;

            // Act
            var result = Engine.Round.Turn.SelectMonsterToAttack();

            // Reset

            // Restore the List
            Engine.EngineSettings.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectMonsterToAttack_InValid_Empty_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.EngineSettings.PlayerList;

            Engine.EngineSettings.PlayerList = new List<PlayerInfoModel>();

            // Act
            var result = Engine.Round.Turn.SelectMonsterToAttack();

            // Reset

            // Restore the List
            Engine.EngineSettings.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectMonsterToAttack_InValid_Dead_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.EngineSettings.PlayerList;

            Engine.EngineSettings.PlayerList = new List<PlayerInfoModel>();

            var data = new PlayerInfoModel(new MonsterModel());
            data.Alive = false;
            Engine.EngineSettings.PlayerList.Add(data);

            // Act
            var result = Engine.Round.Turn.SelectMonsterToAttack();

            // Reset

            // Restore the List
            Engine.EngineSettings.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectMonsterToAttack_InValid_Dead_Character_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.EngineSettings.PlayerList;

            Engine.EngineSettings.PlayerList = new List<PlayerInfoModel>();

            var data = new PlayerInfoModel(new MonsterModel());
            data.Alive = false;
            data.PlayerType = PlayerTypeEnum.Character;
            Engine.EngineSettings.PlayerList.Add(data);

            // Act
            var result = Engine.Round.Turn.SelectMonsterToAttack();

            // Reset

            // Restore the List
            Engine.EngineSettings.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectMonsterToAttack_InValid_Alive_Character_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.EngineSettings.PlayerList;

            Engine.EngineSettings.PlayerList = new List<PlayerInfoModel>();

            var data = new PlayerInfoModel(new MonsterModel());
            data.Alive = true;
            data.PlayerType = PlayerTypeEnum.Character;
            Engine.EngineSettings.PlayerList.Add(data);

            // Act
            var result = Engine.Round.Turn.SelectMonsterToAttack();

            // Reset

            // Restore the List
            Engine.EngineSettings.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectMonsterToAttack_Valid_List_Should_Pass()
        {
            // Arrange

            // remember the list
            var saveList = Engine.EngineSettings.PlayerList;

            Engine.EngineSettings.PlayerList = new List<PlayerInfoModel>();

            var data = new PlayerInfoModel(new MonsterModel());
            Engine.EngineSettings.PlayerList.Add(data);

            // Act
            var result = Engine.Round.Turn.SelectMonsterToAttack();

            // Reset

            // Restore the List
            Engine.EngineSettings.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreNotEqual(null, result);
        }
        #endregion SelectMonsterToAttack

        #region SelectCharacterToAttack
        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Null_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.EngineSettings.PlayerList;

            Engine.EngineSettings.PlayerList = null;

            // Act
            var result = Engine.Round.Turn.SelectCharacterToAttack();

            // Reset

            // Restore the List
            Engine.EngineSettings.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Empty_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.EngineSettings.PlayerList;

            Engine.EngineSettings.PlayerList = new List<PlayerInfoModel>();

            // Act
            var result = Engine.Round.Turn.SelectCharacterToAttack();

            // Reset

            // Restore the List
            Engine.EngineSettings.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Dead_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.EngineSettings.PlayerList;

            Engine.EngineSettings.PlayerList = new List<PlayerInfoModel>();

            var data = new PlayerInfoModel(new CharacterModel());
            data.Alive = false;
            Engine.EngineSettings.PlayerList.Add(data);

            // Act
            var result = Engine.Round.Turn.SelectCharacterToAttack();

            // Reset

            // Restore the List
            Engine.EngineSettings.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Dead_Monster_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.EngineSettings.PlayerList;

            Engine.EngineSettings.PlayerList = new List<PlayerInfoModel>();

            var data = new PlayerInfoModel(new CharacterModel());
            data.Alive = false;
            data.PlayerType = PlayerTypeEnum.Monster;
            Engine.EngineSettings.PlayerList.Add(data);

            // Act
            var result = Engine.Round.Turn.SelectCharacterToAttack();

            // Reset

            // Restore the List
            Engine.EngineSettings.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Alive_Monster_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.EngineSettings.PlayerList;

            Engine.EngineSettings.PlayerList = new List<PlayerInfoModel>();

            var data = new PlayerInfoModel(new CharacterModel());
            data.Alive = true;
            data.PlayerType = PlayerTypeEnum.Monster;
            Engine.EngineSettings.PlayerList.Add(data);

            // Act
            var result = Engine.Round.Turn.SelectCharacterToAttack();

            // Reset

            // Restore the List
            Engine.EngineSettings.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_Valid_List_Should_Pass()
        {
            // Arrange

            // remember the list
            var saveList = Engine.EngineSettings.PlayerList;

            Engine.EngineSettings.PlayerList = new List<PlayerInfoModel>();

            var data = new PlayerInfoModel(new CharacterModel());
            Engine.EngineSettings.PlayerList.Add(data);

            // Act
            var result = Engine.Round.Turn.SelectCharacterToAttack();

            // Reset

            // Restore the List
            Engine.EngineSettings.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreNotEqual(null, result);
        }
        #endregion SelectCharacterToAttack

        #region RollToHitTarget

        [Test]
        public void TurnEngine_RolltoHitTarget_Hit_Should_Pass()
        {
            // Arrange
            var AttackScore = 10;
            var DefenseScore = 0;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(3); // Always roll a 3.
            
            // Act
            var result = Engine.Round.Turn.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }

        [Test]
        public void TurnEngine_RolltoHitTarget_Miss_Should_Pass()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);

            // Act
            var result = Engine.Round.Turn.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        [Test]
        public void TurnEngine_RolltoHitTarget_Forced_1_Should_Miss()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);

            // Act
            var result = Engine.Round.Turn.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        [Test]
        public void TurnEngine_RolltoHitTarget_Forced_20_Should_Hit()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            var result = Engine.Round.Turn.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }

        [Test]
        public void TurnEngine_RolltoHitTarget_Valid_Forced_1_Critical_Miss_Should_Return_CriticalMiss()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);

            var oldSeting = EngineSettingsModel.Instance.BattleSettingsModel.AllowCriticalMiss;
            EngineSettingsModel.Instance.BattleSettingsModel.AllowCriticalMiss = true;

            // Act
            var result = Engine.Round.Turn.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.DisableForcedRolls();
            EngineSettingsModel.Instance.BattleSettingsModel.AllowCriticalMiss = oldSeting;

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalMiss, result);
        }

        [Test]
        public void TurnEngine_RolltoHitTarget_Valid_Forced_20_Critical_Hit_Should_Return_CriticalHit()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            var oldSeting = EngineSettingsModel.Instance.BattleSettingsModel.AllowCriticalHit;
            EngineSettingsModel.Instance.BattleSettingsModel.AllowCriticalHit = true;

            // Act
            var result = Engine.Round.Turn.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.DisableForcedRolls();
            EngineSettingsModel.Instance.BattleSettingsModel.AllowCriticalHit = oldSeting;

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalHit, result);
        }
        #endregion RollToHitTarget

        #region TakeTurn
        [Test]
        public void TurnEngine_TakeTurn_Default_Should_Pass()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            // Act
            var result = Engine.Round.Turn.TakeTurn(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TakeTurn_Ability_Should_Pass()
        {
            // Arrange

            Engine.EngineSettings.CurrentAction = ActionEnum.Ability;
            Engine.EngineSettings.CurrentActionAbility = AbilityEnum.Bandage;

            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            // Act
            var result = Engine.Round.Turn.TakeTurn(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TakeTurn_Move_Should_Pass()
        {
            // Arrange

            Engine.EngineSettings.CurrentAction = ActionEnum.Move;

            var character  = new PlayerInfoModel(new CharacterModel());
            var monster   = new PlayerInfoModel(new CharacterModel());

            Engine.EngineSettings.PlayerList.Add(character);
            Engine.EngineSettings.PlayerList.Add(monster);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            // Act
            var result = Engine.Round.Turn.TakeTurn(character);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TakeTurn_InValid_ActionEnum_Unknown_Should_Set_Action_To_Attack()
        {
            // Arrange

            Engine.EngineSettings.CurrentAction = ActionEnum.Move;

            var character = new PlayerInfoModel(new CharacterModel());
            var monster = new PlayerInfoModel(new CharacterModel());

            Engine.EngineSettings.PlayerList.Add(character);
            Engine.EngineSettings.PlayerList.Add(monster);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            // Set current action to unknonw
            EngineSettingsModel.Instance.CurrentAction = ActionEnum.Unknown;

            // Set Autobattle to false
            EngineSettingsModel.Instance.BattleScore.AutoBattle = false;


            // Act
            var result = Engine.Round.Turn.TakeTurn(character);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion TakeTurn

        #region DropItems
        [Test]
        public void TurnEngine_DropItems_Valid_No_Items_Should_Return_0()
        {
            // Arrange
            var player = new CharacterModel();

            var PlayerInfo = new PlayerInfoModel(player);

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(0);

            // Act
            var result = Engine.Round.Turn.DropItems(PlayerInfo);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TurnEngine_DropItems_Valid_Character_Items_2_Should_Return_2()
        {
            // Arrange
            var player = new CharacterModel
            {
                Head = ItemIndexViewModel.Instance.Dataset.FirstOrDefault().Id,
                Feet = ItemIndexViewModel.Instance.Dataset.FirstOrDefault().Id,
            };

            var PlayerInfo = new PlayerInfoModel(player);

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(0);

            // Act
            var result = Engine.Round.Turn.DropItems(PlayerInfo);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void TurnEngine_DropItems_Valid_Monster_Items_0_Random_Drop_1_Should_Return_1()
        {
            // Arrange
            var player = new CharacterModel();

            var PlayerInfo = new PlayerInfoModel(player);

            DiceHelper.EnableForcedRolls();
            
            // Drop is 0-Number, so 2 will yield 1
            DiceHelper.SetForcedRollValue(2);   

            // Act
            var result = Engine.Round.Turn.DropItems(PlayerInfo);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(1, result);
        }
        #endregion DropItems

        #region TargetDied
        [Test]
        public void TurnEngine_TargedDied_Valid_Character_Should_Pass()
        {
            // Arrange
            var player = new CharacterModel();

            var PlayerInfo = new PlayerInfoModel(player);
            Engine.EngineSettings.CharacterList.Add(PlayerInfo);

            // Act
            var result = Engine.Round.Turn.TargetDied(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TargedDied_Valid_Monseter_Should_Pass()
        {
            // Arrange
            var player = new MonsterModel();

            var PlayerInfo = new PlayerInfoModel(player);
            Engine.EngineSettings.CharacterList.Add(PlayerInfo);

            // Act
            var result = Engine.Round.Turn.TargetDied(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion TargetDied

        #region TurnAsAttack
        [Test]
        public void TurnEngine_TurnAsAttack_Valid_Character_Attacks_Null_Should_Fail()
        {
            // Arrange
            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(CharacterPlayer, null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Valid_Null_Attacks_Character_Should_Fail()
        {
            // Arrange
            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(null, CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Valid_Character_Attacks_Monster_Miss_Should_Pass()
        {
            // Arrange
            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(CharacterPlayer, MonsterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Valid_Character_Attacks_Monster_Hit_Should_Pass()
        {
            // Arrange
            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(CharacterPlayer, MonsterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Valid_Character_Attacks_Monster_Hit_Death_Should_Pass()
        {
            // Arrange
            var Character = new CharacterModel();
            Character.CurrentHealth = 1;
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(CharacterPlayer, MonsterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Valid_Monster_Attacks_Character_Miss_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(MonsterPlayer, CharacterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Valid_Monster_Attacks_Character_Hit_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(MonsterPlayer, CharacterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Valid_Force_Critical_Hit_Monster_Attacks_Character_Hit_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            var oldSetting = Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit;
            Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = true;

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(MonsterPlayer, CharacterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();
            Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = oldSetting;

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Valid_Force_Critical_Miss_Monster_Attacks_Character_Hit_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);

            var oldSetting = Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss;
            Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss = true;

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(MonsterPlayer, CharacterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();
            Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss = oldSetting;

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion TurnAsAttack

        #region RemoveIfDead
        [Test]
        public void TurnEngine_RemoveIfDead_Valid_Dead_True_Should_Return_False()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                CurrentHealth = 1,
                Alive = true,
                Guid="me"
            };

            var PlayerInfo = new PlayerInfoModel(Monster);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(PlayerInfo);
            Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.Turn.RemoveIfDead(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_RemoveIfDead_Valid_Dead_false_Should_Return_true()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                CurrentHealth = 1,
                Alive = true,
                Guid = "me"
            };

            var PlayerInfo = new PlayerInfoModel(Monster);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(PlayerInfo);
            Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.Turn.RemoveIfDead(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion RemoveIfDead

        #region TurnAsAttack
        [Test]
        public void TurnEngine_TurnAsAttack_Valid_Character_Attacks_Monster_Levels_Up_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel();

            var CharacterPlayer = new PlayerInfoModel(Character);

            CharacterPlayer.ExperienceTotal = 300;    // Enough for next level

            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(CharacterPlayer,MonsterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(2, CharacterPlayer.Level);
        }
        #endregion TurnAsAttack

        #region UseAbility
        [Test]
        public void TurnEngine_UseAbility_InValid_Ability_Null_Should_Fail()
        {
            // Arrange
            Engine.EngineSettings.CurrentActionAbility = AbilityEnum.Unknown;
            
            var characterPlayer = new PlayerInfoModel(new CharacterModel { Job=CharacterJobEnum.Unknown});

            // remove it so it is not found
            characterPlayer.AbilityTracker.Remove(AbilityEnum.Unknown);

            // Act
            var result = Engine.Round.Turn.UseAbility(characterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_UseAbility_InValid_Ability_Count_0_Should_Fail()
        {
            // Arrange
            Engine.EngineSettings.CurrentActionAbility = AbilityEnum.Unknown;

            var characterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Unknown });

            // remove it so it is not found
            characterPlayer.AbilityTracker[AbilityEnum.Unknown] = 0;

            // Act
            var result = Engine.Round.Turn.UseAbility(characterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_UseAbility_Valid_Ability_Heal_1_Should_Pass()
        {
            // Arrange

            var characterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Unknown });

            // remove it so it is not found
            characterPlayer.AbilityTracker.Add(AbilityEnum.Heal, 1);
            Engine.EngineSettings.CurrentActionAbility = AbilityEnum.Heal;

            // Act
            var result = Engine.Round.Turn.UseAbility(characterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_UseAbility_Valid_Ability_Toughness_1_Should_Pass()
        {
            // Arrange

            var characterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Unknown });

            // remove it so it is not found
            characterPlayer.AbilityTracker.Add(AbilityEnum.Toughness,1);
            Engine.EngineSettings.CurrentActionAbility = AbilityEnum.Toughness;

            // Act
            var result = Engine.Round.Turn.UseAbility(characterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_UseAbility_Valid_Ability_Quick_1_Should_Pass()
        {
            // Arrange

            var characterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Unknown });

            // remove it so it is not found
            characterPlayer.AbilityTracker.Add(AbilityEnum.Quick, 1);
            Engine.EngineSettings.CurrentActionAbility = AbilityEnum.Quick;

            // Act
            var result = Engine.Round.Turn.UseAbility(characterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_UseAbility_Valid_Ability_Curse_1_Should_Pass()
        {
            // Arrange

            var characterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Unknown });

            // remove it so it is not found
            characterPlayer.AbilityTracker.Add(AbilityEnum.Curse, 1);
            Engine.EngineSettings.CurrentActionAbility = AbilityEnum.Curse;

            // Act
            var result = Engine.Round.Turn.UseAbility(characterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion UseAbility

        #region BattleSettings
        [Test]
        public void TurnEngine_BattleSettingsOverrideHitStatusEnum_Valid_Hit_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.Round.Turn.BattleSettingsOverrideHitStatusEnum(HitStatusEnum.Hit);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }

        [Test]
        public void TurnEngine_BattleSettingsOverrideCriticalHitStatusEnum_Valid_CriticalHit_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.Round.Turn.BattleSettingsOverrideHitStatusEnum(HitStatusEnum.CriticalHit);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalHit, result);
        }

        [Test]
        public void TurnEngine_BattleSettingsOverrideCriticalMissStatusEnum_Valid_CriticalMiss_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.Round.Turn.BattleSettingsOverrideHitStatusEnum(HitStatusEnum.CriticalMiss);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalMiss, result);
        }

        [Test]
        public void TurnEngine_BattleSettingsOverrideMissStatusEnum_Valid_Miss_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.Round.Turn.BattleSettingsOverrideHitStatusEnum(HitStatusEnum.Miss);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        [Test]
        public void TurnEngine_DetermineCriticalMissProblem_InValid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = Engine.Round.Turn.DetermineCriticalMissProblem(null);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_DetermineCriticalMissProblem_Valid_Monster_Drops_Random_Should_Pass()
        {
            // Arrange
            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(6);

            // Act
            var result = Engine.Round.Turn.DetermineCriticalMissProblem(MonsterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion BattleSettings

        #region DetermineActionChoice
        [Test]
        public void TurnEngine_DetermineActionChoice_Valid_Monster_Should_Return_CurrentAction()
        {
            // Arrange
            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());

            MonsterPlayer.CurrentHealth = 1;
            MonsterPlayer.MaxHealth = 1000;

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;

            // Act
            var result = Engine.Round.Turn.DetermineActionChoice(MonsterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(ActionEnum.Ability, result);
        }

        [Test]
        public void TurnEngine_DetermineActionChoice_Valid_Character_Should_Return_CurrentAction()
        {
            // Arrange
            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

            CharacterPlayer.CurrentHealth = 1;
            CharacterPlayer.MaxHealth = 1000;

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.Round.Turn.DetermineActionChoice(CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(ActionEnum.Ability, result);
        }

        [Test]
        public void TurnEngine_DetermineActionChoice_Valid_Character_Range_Should_Return_Attack()
        {
            // Arrange

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());
            
            // Get the longest range weapon in stock.
            var weapon = ItemIndexViewModel.Instance.Dataset.Where(m => m.Range > 1).ToList().OrderByDescending(m => m.Range).FirstOrDefault();
            CharacterPlayer.PrimaryHand = weapon.Id;
            Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            Engine.EngineSettings.PlayerList.Add(new PlayerInfoModel(Monster));
            Engine.EngineSettings.PlayerList.Add(new PlayerInfoModel(Monster));

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.Round.Turn.DetermineActionChoice(CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(ActionEnum.Attack, result);
        }
        #endregion DetermineActionChoice

        #region ChooseToUseAbility
        [Test]
        public void TurnEngine_ChooseToUseAbility_Valid_Heal_Should_Return_True()
        {
            // Arrange

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

            // Get the longest range weapon in stock.
            var weapon = ItemIndexViewModel.Instance.Dataset.Where(m => m.Range > 1).ToList().OrderByDescending(m => m.Range).FirstOrDefault();
            CharacterPlayer.PrimaryHand = weapon.Id;
            CharacterPlayer.CurrentHealth = 1;
            CharacterPlayer.MaxHealth = 100;

            Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.Round.Turn.ChooseToUseAbility(CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_ChooseToUseAbility_InValid_Roll_9_Should_Return_False()
        {
            // Arrange

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

            // Get the longest range weapon in stock.
            var weapon = ItemIndexViewModel.Instance.Dataset.Where(m => m.Range > 1).ToList().OrderByDescending(m => m.Range).FirstOrDefault();
            CharacterPlayer.PrimaryHand = weapon.Id;

            Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(9);
            // Act
            var result = Engine.Round.Turn.ChooseToUseAbility(CharacterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_ChooseToUseAbility_InValid_Roll_2_No_Ability_Should_Return_False()
        {
            // Arrange

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

            // Get the longest range weapon in stock.
            var weapon = ItemIndexViewModel.Instance.Dataset.Where(m => m.Range > 1).ToList().OrderByDescending(m => m.Range).FirstOrDefault();
            CharacterPlayer.PrimaryHand = weapon.Id;
            CharacterPlayer.AbilityTracker.Clear();

            Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);
            // Act
            var result = Engine.Round.Turn.ChooseToUseAbility(CharacterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_ChooseToUseAbility_Valid_Roll_2_Yes_Ability_Should_Return_True()
        {
            // Arrange

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric});

            // Get the longest range weapon in stock.
            var weapon = ItemIndexViewModel.Instance.Dataset.Where(m => m.Range > 1).ToList().OrderByDescending(m => m.Range).FirstOrDefault();
            CharacterPlayer.PrimaryHand = weapon.Id;

            Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);
            // Act
            var result = Engine.Round.Turn.ChooseToUseAbility(CharacterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion ChooseToUseAbility

        #region MoveAsTurn
        [Test]
        public void TurnEngine_MoveAsTurn_Valid_Character_Should_Pass()
        {
            // Arrange

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });

            Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.Round.Turn.MoveAsTurn(CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_MoveAsTurn_Valid_Monster_Should_Pass()
        {
            // Arrange

            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());
            Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.Round.Turn.MoveAsTurn(MonsterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_MoveAsTurn_Invalid_Monster_InValid_No_Defender_Should_Fail()
        {
            // Arrange

            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());

            // Remove everyone
            Engine.EngineSettings.PlayerList.Clear();

            Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.Round.Turn.MoveAsTurn(MonsterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_MoveAsTurn_Invalid_Monster_InValid_Defender_Not_On_Map_Should_Fail()
        {
            // Arrange
            var CharacterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            // Not on map.... 
            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());
            Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.Round.Turn.MoveAsTurn(MonsterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_MoveAsTurn_Invalid_Monster_InValid_Attacker_Not_On_Map_Should_Fail()
        {
            // Arrange

            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());
            Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            // Add player after map is made, so player is not on the map

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.Round.Turn.MoveAsTurn(MonsterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion MoveAsTurn
    }
}