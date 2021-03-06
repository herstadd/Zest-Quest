using System.Collections.Generic;
using System.Linq;

using Game.Models;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Engine.EngineBase;
using System.Diagnostics;

namespace Game.Engine.EngineGame
{
    /* 
     * Need to decide who takes the next turn
     * Target to Attack
     * Should Move, or Stay put (can hit with weapon range?)
     * Death
     * Manage Round...
     * 
     */

    /// <summary>
    /// Engine controls the turns
    /// 
    /// A turn is when a Character takes an action or a Monster takes an action
    /// 
    /// </summary>
    public class TurnEngine : TurnEngineBase, ITurnEngineInterface
    {
        #region Algrorithm
        // Attack or Move
        // Roll To Hit
        // Decide Hit or Miss
        // Decide Damage
        // Death
        // Drop Items
        // Turn Over
        #endregion Algrorithm

        // Hold the BaseEngine
        public new EngineSettingsModel EngineSettings = EngineSettingsModel.Instance;

        /// <summary>
        /// CharacterModel Attacks...
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public override bool TakeTurn(PlayerInfoModel Attacker)
        {
            // INFO: Teams, work out your turn logic
            return base.TakeTurn(Attacker);
        }

        /// <summary>
        /// Determine what Actions to do
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public override ActionEnum DetermineActionChoice(PlayerInfoModel Attacker)
        {
            return base.DetermineActionChoice(Attacker);
        }

        /// <summary>
        /// Find a Desired Target
        /// Move close to them
        /// Get to move the number of Speed
        /// </summary>
        public override bool MoveAsTurn(PlayerInfoModel Attacker)
        {

            /*
             * TODO: TEAMS Work out your own move logic if you are implementing move
             * 
             * Mike's Logic
             * The monster or charcter will move to a different square if one is open
             * Find the Desired Target
             * Jump to the closest space near the target that is open
             * 
             * If no open spaces, return false
             * 
             */

            return base.MoveAsTurn(Attacker);
        }

        /// <summary>
        /// Decide to use an Ability or not
        /// 
        /// Set the Ability
        /// </summary>
        public override bool ChooseToUseAbility(PlayerInfoModel Attacker)
        {
            // INFO: Teams, consider if you have abilities
            return base.ChooseToUseAbility(Attacker);
        }

        /// <summary>
        /// Use the Ability
        /// </summary>
        public override bool UseAbility(PlayerInfoModel Attacker)
        {
            // INFO: Teams, consider if you have abilities
            return base.UseAbility(Attacker);
        }

        /// <summary>
        /// Attack as a Turn
        /// 
        /// Pick who to go after
        /// 
        /// Determine Attack Score
        /// Determine DefenseScore
        /// 
        /// Do the Attack
        /// 
        /// </summary>
        public override bool Attack(PlayerInfoModel Attacker)
        {
            // INFO: Teams, AttackChoice will auto pick the target, good for auto battle
            return base.Attack(Attacker);
        }

        /// <summary>
        /// Decide which to attack
        /// </summary>
        public override PlayerInfoModel AttackChoice(PlayerInfoModel data)
        {
            return base.AttackChoice(data);
        }

        /// <summary>
        /// Pick the Character to Attack
        /// </summary>
        public override PlayerInfoModel SelectCharacterToAttack()
        {
            if (EngineSettings.PlayerList == null)
            {
                return null;
            }

            if (EngineSettings.PlayerList.Count < 1)
            {
                return null;
            }

            // Select Character with most health to attack first

            var Defender = EngineSettings.PlayerList
                .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Character)
                .OrderBy(m => m.CurrentHealth).LastOrDefault();

            Debug.WriteLine("Character to attack:\t" + Defender.Name + "\tCurrent Health:\t" + Defender.CurrentHealth);

            return Defender;
        }

        /// <summary>
        /// Pick the Monster to Attack
        /// </summary>
        public override PlayerInfoModel SelectMonsterToAttack()
        {
            if (EngineSettings.PlayerList == null)
            {
                return null;
            }

            if (EngineSettings.PlayerList.Count < 1)
            {
                return null;
            }

            // Select first one to hit in the list for now...
            // Used to be that we attacked the Weakness (lowest HP) MonsterModel first
            // Now, we attack the monster with the lowest attack value

            var Defender = EngineSettings.PlayerList
                .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Monster)
                //.OrderBy(m => m.CurrentHealth).FirstOrDefault();
                .OrderBy(m => m.Attack).LastOrDefault();

            Debug.WriteLine("Monster to attack:\t" + Defender.Name + "\tAttack Value:\t" + Defender.Attack);

            return Defender;

        }

        /// <summary>
        /// // MonsterModel Attacks CharacterModel
        /// </summary>
        public override bool TurnAsAttack(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            return base.TurnAsAttack(Attacker, Target);
        }

        /// <summary>
        /// See if the Battle Settings will Override the Hit
        /// Return the Override for the HitStatus
        /// </summary>
        public override HitStatusEnum BattleSettingsOverride(PlayerInfoModel Attacker)
        {
            return base.BattleSettingsOverride(Attacker);
        }

        /// <summary>
        /// Return the Override for the HitStatus
        /// </summary>
        public override HitStatusEnum BattleSettingsOverrideHitStatusEnum(HitStatusEnum myEnum)
        {
            return base.BattleSettingsOverrideHitStatusEnum(myEnum);
        }

        /// <summary>
        /// Apply the Damage to the Target
        /// </summary>
        public override int ApplyDamage(PlayerInfoModel Target)
        {
            return base.ApplyDamage(Target);
        }

        /// <summary>
        /// Calculate the Attack, return if it hit or missed.
        /// </summary>
        public override HitStatusEnum CalculateAttackStatus(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            return base.CalculateAttackStatus(Attacker, Target);
        }

        /// <summary>
        /// Calculate Experience
        /// Level up if needed
        /// </summary>
        public override bool CalculateExperience(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            return base.CalculateExperience(Attacker, Target);
        }

        /// <summary>
        /// If Dead process Target Died
        /// </summary>
        public override bool RemoveIfDead(PlayerInfoModel Target)
        {
            return base.RemoveIfDead(Target);
        }

        /// <summary>
        /// Target Died
        /// 
        /// Process for death...
        /// 
        /// Returns the count of items dropped at death
        /// </summary>
        public override bool TargetDied(PlayerInfoModel Target)
        {
            // INFO: Teams, Hookup your Boss if you have one...
            //return base.TargetDied(Target);

            bool found;

            // Mark Status in output
            EngineSettings.BattleMessagesModel.TurnMessageSpecial = " and causes death. ";

            // Removing the 
            EngineSettings.MapModel.RemovePlayerFromMap(Target);

            // INFO: Teams, Hookup your Boss if you have one...

            // Using a switch so in the future additional PlayerTypes can be added (Boss...)
            switch (Target.PlayerType)
            {
                case PlayerTypeEnum.Character:
                    // When a school chef dies 20% attack buff will be added to all chefs
                    if(Target.Job == CharacterJobEnum.SchoolChef)
                    {
                        foreach(var chef in EngineSettings.CharacterList)
                        {
                            chef.BuffAttackValue = (20 * chef.Attack) / 100;
                        }
                    }

                    // Add the Character to the killed list
                    EngineSettings.BattleScore.CharacterAtDeathList += Target.FormatOutput() + "\n";

                    EngineSettings.BattleScore.CharacterModelDeathList.Add(Target);

                    DropItems(Target);

                    found = EngineSettings.CharacterList.Remove(EngineSettings.CharacterList.Find(m => m.Guid.Equals(Target.Guid)));
                    found = EngineSettings.PlayerList.Remove(EngineSettings.PlayerList.Find(m => m.Guid.Equals(Target.Guid)));

                    return true;

                case PlayerTypeEnum.Monster:
                default:
                    // Add one to the monsters killed count...
                    EngineSettings.BattleScore.MonsterSlainNumber++;

                    // Add the MonsterModel to the killed list
                    EngineSettings.BattleScore.MonstersKilledList += Target.FormatOutput() + "\n";

                    EngineSettings.BattleScore.MonsterModelDeathList.Add(Target);

                    DropItems(Target);

                    found = EngineSettings.MonsterList.Remove(EngineSettings.MonsterList.Find(m => m.Guid.Equals(Target.Guid)));
                    found = EngineSettings.PlayerList.Remove(EngineSettings.PlayerList.Find(m => m.Guid.Equals(Target.Guid)));

                    return true;
            }
        }

        /// <summary>
        /// Drop Items
        /// </summary>
        public override int DropItems(PlayerInfoModel Target)
        {
            // INFO: Teams, work out how you want to drop items.
            return base.DropItems(Target);
        }

        /// <summary>
        /// Roll To Hit
        /// </summary>
        /// <param name="AttackScore"></param>
        /// <param name="DefenseScore"></param>
        public override HitStatusEnum RollToHitTarget(int AttackScore, int DefenseScore)
        {
            return base.RollToHitTarget(AttackScore, DefenseScore);
        }

        /// <summary>
        /// Will drop between 1 and 4 items from the ItemModel set...
        /// </summary>
        public override List<ItemModel> GetRandomMonsterItemDrops(int round)
        {
            // TODO: Teams, You need to implement your own modification to the Logic cannot use mine as is.
            return base.GetRandomMonsterItemDrops(round);
        }

        /// <summary>
        /// Critical Miss Problem
        /// </summary>
        public override bool DetermineCriticalMissProblem(PlayerInfoModel attacker)
        {
            return base.DetermineCriticalMissProblem(attacker);
        }
    }
}