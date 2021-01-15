using System.Collections.Generic;

using Game.Models;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Engine.EngineBase;

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
            // Choose Action.  Such as Move, Attack etc.

            // INFO: Teams, if you have other actions they would go here.

            // If the action is not set, then try to set it or use Attact

            // Based on the current action...

            // Increment Turn Count so you know what turn number

            // Save the Previous Action off

            // Reset the Action to unknown for next time

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determine what Actions to do
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public override ActionEnum DetermineActionChoice(PlayerInfoModel Attacker)
        {
            // If it is the characters turn, and NOT auto battle, use what was sent into the engine

            /*
             * The following is Used for Monsters, and Auto Battle Characters
             * 
             * Order of Priority
             * If can attack Then Attack
             * Next use Ability or Move
             */

            // Assume Move if nothing else happens

            // Check to see if ability is avaiable

            // See if Desired Target is within Range, and if so attack away

            throw new System.NotImplementedException();
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

            // If the Monster the calculate the options
            if (Attacker.PlayerType == PlayerTypeEnum.Monster)
            {
                // For Attack, Choose Who

                // Get X, Y for Defender

                // Get X, Y for the Attacker

                // Find Location Nearest to Defender that is Open.

                // Get the Open Locations

                // Format a message to show

                throw new System.NotImplementedException();
            }

            return true;
        }

        /// <summary>
        /// Decide to use an Ability or not
        /// 
        /// Set the Ability
        /// </summary>
        public override bool ChooseToUseAbility(PlayerInfoModel Attacker)
        {
            // See if healing is needed.

            // If not needed, then role dice to see if other ability should be used
            // Choose the % chance
            // Select the ability

            // Don't try

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Use the Ability
        /// </summary>
        public override bool UseAbility(PlayerInfoModel Attacker)
        {
            throw new System.NotImplementedException();
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

            // Manage autobattle

            // Do Attack

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Decide which to attack
        /// </summary>
        public override PlayerInfoModel AttackChoice(PlayerInfoModel data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Pick the Character to Attack
        /// </summary>
        public override PlayerInfoModel SelectCharacterToAttack()
        {
            // Select first in the list

            // TODO: Teams, You need to implement your own Logic can not use mine.

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Pick the Monster to Attack
        /// </summary>
        public override PlayerInfoModel SelectMonsterToAttack()
        {
            // Select first one to hit in the list for now...
            // Attack the Weakness (lowest HP) MonsterModel first 

            // TODO: Teams, You need to implement your own Logic can not use mine.

            throw new System.NotImplementedException();

        }

        /// <summary>
        /// // MonsterModel Attacks CharacterModel
        /// </summary>
        public override bool TurnAsAttack(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            // Set Messages to empty

            // Do the Attack

            // Hackathon
            // ?? Hackathon Scenario ?? 

            // See if the Battle Settings Overrides the Roll

            // Based on the Hit Status, what to do...
            // It's a Miss

            // It's a Hit

            //Calculate Damage

            // Apply the Damage

            // Check if Dead and Remove

            // If it is a character apply the experience earned

            // Battle Message 

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// See if the Battle Settings will Override the Hit
        /// Return the Override for the HitStatus
        /// </summary>
        public override HitStatusEnum BattleSettingsOverride(PlayerInfoModel Attacker)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Return the Override for the HitStatus
        /// </summary>
        public override HitStatusEnum BattleSettingsOverrideHitStatusEnum(HitStatusEnum myEnum)
        {
            // Based on the Hit Status, establish a message

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Apply the Damage to the Target
        /// </summary>
        public override void ApplyDamage(PlayerInfoModel Target)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calculate the Attack, return if it hit or missed.
        /// </summary>
        public override HitStatusEnum CalculateAttackStatus(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Calculate Experience
        /// Level up if needed
        /// </summary>
        public override bool CalculateExperience(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// If Dead process Target Died
        /// </summary>
        public override bool RemoveIfDead(PlayerInfoModel Target)
        {
            throw new System.NotImplementedException();
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
            // Mark Status in output

            // Removing the 

            // INFO: Teams, Hookup your Boss if you have one...

            // Using a switch so in the future additional PlayerTypes can be added (Boss...)
            // Add the Character to the killed list

            // Add one to the monsters killed count...

            // Add the MonsterModel to the killed list

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Drop Items
        /// </summary>
        public override int DropItems(PlayerInfoModel Target)
        {
            // Drop Items to ItemModel Pool

            // I feel generous, even when characters die, random drops happen :-)
            // If Random drops are enabled, then add some....

            // Add to ScoreModel

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Roll To Hit
        /// </summary>
        /// <param name="AttackScore"></param>
        /// <param name="DefenseScore"></param>
        public override HitStatusEnum RollToHitTarget(int AttackScore, int DefenseScore)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Will drop between 1 and 4 items from the ItemModel set...
        /// </summary>
        public override List<ItemModel> GetRandomMonsterItemDrops(int round)
        {
            // TODO: Teams, You need to implement your own modification to the Logic cannot use mine as is.

            // You decide how to drop monster items, level, etc.

            // The Number drop can be Up to the Round Count, but may be less.  
            // Negative results in nothing dropped

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Critical Miss Problem
        /// </summary>
        public override bool DetermineCriticalMissProblem(PlayerInfoModel attacker)
        {
            throw new System.NotImplementedException();
        }
    }
}