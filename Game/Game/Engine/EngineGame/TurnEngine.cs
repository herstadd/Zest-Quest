using System.Collections.Generic;
using System.Linq;

using Game.Models;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Engine.EngineBase;
using System.Diagnostics;
using Game.Helpers;
using Game.ViewModels;
using Game.GameRules;
using System;

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
            // Note, instead of modifying this function, we modified the following DetermineActionChoice function
            //   to control what players do.  This gave us a wider variety of options.
            return base.TakeTurn(Attacker);
        }

        /// <summary>
        /// Determine what Actions to do
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public override ActionEnum DetermineActionChoice(PlayerInfoModel Attacker)
        {
            /*
             * The following is Used for Monsters, and Auto Battle Characters, and now for characters!
             * 
             * Order of Priority
             * If can attack Then Attack
             * Next use Move, not ability
             */

            EngineSettings.CurrentAction = ActionEnum.Move;

            // See if Desired Target is within Range, and if so attack away
            if (EngineSettings.MapModel.IsTargetInRange(Attacker, AttackChoice(Attacker)))
            {
                EngineSettings.CurrentAction = ActionEnum.Attack;
            }

            return EngineSettings.CurrentAction;
        }

        /// <summary>
        /// Find a Desired Target
        /// Move close to them
        /// Get to move the number of Speed
        /// </summary>
        public override bool MoveAsTurn(PlayerInfoModel Attacker)
        {
            /*
             * Updated from Mike's logic.  Characters and monsters will now move only one space at a time and will move towards the character they're 
             * looking to attack.  Sometimes they will also move the wrong direction because they're not too smart.
             * 
             * If no open spaces, return false
             * 
             */

            // For Attack, Choose Who
            EngineSettings.CurrentDefender = AttackChoice(Attacker);

            if (EngineSettings.CurrentDefender == null)
            {
                return false;
            }

            // Get X, Y for Defender
            var locationDefender = EngineSettings.MapModel.GetLocationForPlayer(EngineSettings.CurrentDefender);
            if (locationDefender == null)
            {
                return false;
            }

            var locationAttacker = EngineSettings.MapModel.GetLocationForPlayer(Attacker);
            if (locationAttacker == null)
            {
                return false;
            }

            // Find Location Nearest to Defender that is Open.


            // Get the Open Locations
            //var openSquare = EngineSettings.MapModel.ReturnClosestEmptyLocation(locationDefender);
            var openSquare = EngineSettings.MapModel.ReturnNextEmptyLocation(locationDefender, locationAttacker, Attacker.Job);

            Debug.WriteLine(string.Format("{0} moves from {1},{2} to {3},{4}", locationAttacker.Player.Name, locationAttacker.Column, locationAttacker.Row, openSquare.Column, openSquare.Row));

            EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + EngineSettings.BattleMessagesModel.SeattleSlip + EngineSettings.CurrentDefender.Name;

            return EngineSettings.MapModel.MovePlayerOnMap(locationAttacker, openSquare);

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

            if (Defender != null)
                Debug.WriteLine("Character to attack:\t" + Defender.Name + "\tCurrent Health:\t" + Defender.CurrentHealth);

            return Defender;
        }

        /// <summary>
        /// Pick the Monster to Attack
        /// </summary>
        public override PlayerInfoModel SelectMonsterToAttack()
        {
            if(EngineSettings.CurrentAttacker != null)
            {
                if (EngineSettings.CurrentAttacker.Name == "Bob")
                {
                    return null;
                }
            }

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
            // Now, we attack the monster with the highest attack value

            var Defender = EngineSettings.PlayerList
                .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Monster)
                //.OrderBy(m => m.CurrentHealth).FirstOrDefault();
                .OrderBy(m => m.Attack).LastOrDefault();

            if(Defender != null)
                Debug.WriteLine("Monster to attack:\t" + Defender.Name + "\tAttack Value:\t" + Defender.Attack);

            return Defender;

        }

        /// <summary>
        /// // MonsterModel Attacks CharacterModel
        /// </summary>
        public override bool TurnAsAttack(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            if (Attacker == null)
            {
                return false;
            }

            if (Target == null)
            {
                return false;
            }

            // Set Messages to empty
            EngineSettings.BattleMessagesModel.ClearMessages();

            // Do the Attack
            CalculateAttackStatus(Attacker, Target);

            // See if the Battle Settings Overrides the Roll
            EngineSettings.BattleMessagesModel.HitStatus = BattleSettingsOverride(Attacker);

            switch (EngineSettings.BattleMessagesModel.HitStatus)
            {
                case HitStatusEnum.Miss:
                    // It's a Miss

                    break;

                case HitStatusEnum.CriticalMiss:
                    // It's a Critical Miss, so Bad things may happen
                    DetermineCriticalMissProblem(Attacker);

                    break;

                case HitStatusEnum.CriticalHit:
                case HitStatusEnum.Hit:
                    // It's a Hit

                    //Calculate Damage
                    EngineSettings.BattleMessagesModel.DamageAmount = Attacker.GetDamageRollValue();

                    // If critical Hit, double the damage
                    if (EngineSettings.BattleMessagesModel.HitStatus == HitStatusEnum.CriticalHit)
                    {
                        EngineSettings.BattleMessagesModel.DamageAmount *= 2;
                    }

                    // Apply the Damage
                    ApplyDamage(Target);

                    EngineSettings.BattleMessagesModel.TurnMessageSpecial = EngineSettings.BattleMessagesModel.GetCurrentHealthMessage();

                    // Check if Dead and Remove
                    RemoveIfDead(Target);

                    // If it is a character apply the experience earned
                    CalculateExperience(Attacker, Target);

                    break;
            }

            //create a pet for character if they were damaged
            CreatePetForCharacter(Target);


            EngineSettings.BattleMessagesModel.TurnMessage += Attacker.Name + EngineSettings.BattleMessagesModel.AttackStatus + Target.Name + EngineSettings.BattleMessagesModel.TurnMessageSpecial + EngineSettings.BattleMessagesModel.ExperienceEarned;
            Debug.WriteLine(EngineSettings.BattleMessagesModel.TurnMessage);

            return true;

        }

        /// <summary>
        /// Creates a new pet for target character if no pets exist yet
        /// </summary>
        /// <param name="Target">Character who may need a pet</param>
        void CreatePetForCharacter(PlayerInfoModel Target)
        {
            //If character is a pet, they don't need another pet
            if(Target.Job == CharacterJobEnum.Pet)
            {
                return;
            }

            //If player is not a character, they don't need a pet
            if (Target.PlayerType != PlayerTypeEnum.Character)
            {
                return;
            }

            //if character didn't receive damage, they don't get a pet (yet)
            if (EngineSettings.BattleMessagesModel.DamageAmount == 0)
            {
                return;
            }

            //if there are no active characters, don't make a pet
            if (EngineSettings.CharacterList.Count == 0)
            {
                return;
            }

            //Check to see if anyone else has a pet, if so, don't create another
            foreach (var data in EngineSettings.PlayerList)
            {
                if (data.Job == CharacterJobEnum.Pet)
                {
                    return;
                }
            }

            //check to see if anyone had a pet this round
            foreach (var data in EngineSettings.CharacterList)
            {
                //if someone had a pet this round, don't make another
                if (data.HadPet == true)
                {
                    return;
                }
            }

            //Create a new pet
            var NewPet = new PlayerInfoModel(
                    new CharacterModel
                    {
                        Speed = 1,
                        Level = 1,
                        CurrentHealth = 1,
                        ExperienceTotal = 1,
                        ExperienceRemaining = 1,
                        Name = "Pet Smiling Sun",
                        Job = CharacterJobEnum.Pet,
                        ImageURI = "smiling_sun.png"
                    });

            EngineSettings.PlayerList.Add(NewPet);
            EngineSettings.MapModel.AddNewCharacterToGrid(NewPet);
            
            //Note that character now has a pet
            Target.HadPet = true;
            Debug.WriteLine("Added new pet");
            EngineSettings.BattleMessagesModel.TurnMessage += NewPet.Name + " jumps in to rescue " + Target.Name + "\n";
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
            if(Target.PlayerType == PlayerTypeEnum.Character &&
                Target.Job != CharacterJobEnum.Pet &&
                Target.CurrentHealth - EngineSettings.BattleMessagesModel.DamageAmount <= 0 && 
                !Target.SavedByMax)
            {
                Target.SavedByMax = true;
                Target.CurrentHealth = Target.MaxHealth;
                EngineSettings.BattleMessagesModel.TurnMessage += "Miracle Max saves " + Target.Name + " giving them a second chance at life!\n";
                return -1;
            }
            Target.TakeDamage(EngineSettings.BattleMessagesModel.DamageAmount);
            EngineSettings.BattleMessagesModel.CurrentHealth = Target.GetCurrentHealthTotal;

            return EngineSettings.BattleMessagesModel.DamageAmount;
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
            if(Target.PlayerType == PlayerTypeEnum.Monster)
            {
                var ChanceToRevive = (DiceHelper.RollDice(1, 100) + 1);
                if((BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.EnableSleeplessZombie)
                        && (Convert.ToInt32(BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.SleeplessZombiePercent)
                                >= ChanceToRevive))
                {
                    Target.CurrentHealth = Target.MaxHealth / 2;
                    Target.Name = "Zombie " + Target.Name;
                    return true;
                }
            }    
            
            if (Target.Job == CharacterJobEnum.CatChef)
            {
                //50% chance of new life
                var CatLive = DiceHelper.RollDice(1, 2);
                if (CatLive == 1)
                {
                    Target.MaxHealth = Target.MaxHealth / 2;
                    Target.CurrentHealth = Target.MaxHealth;
                    if (Target.CurrentHealth != 0)
                    {
                        EngineSettings.BattleMessagesModel.TurnMessageSpecial = " yet Cat Chef is revived with half life! ";
                        Target.Alive = true;
                        return true;
                    }
                }
                //else, if both if statements aren't satisfied, cat defeated
            }

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
                            chef.BuffAttackValue += (20 * chef.Attack) / 100;
                        }
                     
                    }

                    // Add the Character to the killed list
                    EngineSettings.BattleScore.CharacterAtDeathList += Target.FormatOutput() + "\n";

                    EngineSettings.BattleScore.CharacterModelDeathList.Add(Target);

                    if (EngineSettings.BattleStateEnum != BattleStateEnum.Unknown)
                    {
                        DropItems(Target);
                    }

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
            // INFO: Teams, work out how you want to drop items. // updating
            var DroppedMessage = "\nItems Dropped : \n";

            // Drop Items to ItemModel Pool
            var myItemList = Target.DropAllItems();

            var ItemToAdd = Target.UniqueItem;

            //if the monster has a unique drop item, add it here
            if ((ItemToAdd != null) && (ItemToAdd != "None"))
            {
                var ItemModelItemToAdd = ItemIndexViewModel.Instance.GetItem(ItemToAdd, true);
                myItemList.Add(ItemModelItemToAdd);
            }

            // Regardless of whether the character had a unique drop, maybe add another item drop
            myItemList.AddRange(GetRandomMonsterItemDrops(EngineSettings.BattleScore.RoundCount));

            // Add to ScoreModel
            foreach (var ItemModel in myItemList)
            {
                EngineSettings.BattleScore.ItemsDroppedList += ItemModel.FormatOutput() + "\n";
                DroppedMessage += ItemModel.Name + "\n";
            }

            EngineSettings.ItemPool.AddRange(myItemList);

            if (myItemList.Count == 0)
            {
                DroppedMessage = " Nothing dropped. ";
            }

            EngineSettings.BattleMessagesModel.DroppedMessage = DroppedMessage;

            EngineSettings.BattleScore.ItemModelDropList.AddRange(myItemList);

            return myItemList.Count();
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
            // We changed the number to drop

            // You decide how to drop monster items, level, etc.

            // Vary amount of items dropped between 0 and 1 regardless of level
            var NumberToDrop = (DiceHelper.RollDice(1, 2) - 1);

            var DropItems = new List<ItemModel>();

            for (var i = 0; i < NumberToDrop; i++)
            {
                // Get a random Unique Item
                var ItemToAdd = ItemIndexViewModel.Instance.GetItem(RandomPlayerHelper.GetMonsterUniqueItem());
                DropItems.Add(ItemToAdd);
            }

            return DropItems;


            //return base.GetRandomMonsterItemDrops(round);
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