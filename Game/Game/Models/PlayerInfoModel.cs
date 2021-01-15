using System.Collections.Generic;

using Game.GameRules;

namespace Game.Models
{
    /// <summary>
    /// Player for the game.
    /// 
    /// Either Monster or Character
    /// 
    /// Constructor Player to Player used a T in Round
    /// </summary>
    public class PlayerInfoModel : BasePlayerModel<PlayerInfoModel>
    {
        // Track the Abilities in the Battle
        // The Ability will be the List of Abilities per Job, and a count of how many times they can use it per round
        public Dictionary<AbilityEnum, int> AbilityTracker = new Dictionary<AbilityEnum, int>();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PlayerInfoModel() { }

        /// <summary>
        /// Copy from one PlayerInfoModel into Another
        /// </summary>
        /// <param name="data"></param>
        public PlayerInfoModel(PlayerInfoModel data)
        {
            PlayerType = data.PlayerType;
            Guid = data.Guid;
            Alive = data.Alive;
            ExperienceTotal = data.ExperienceTotal;
            ExperienceRemaining = data.ExperienceRemaining;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;

            // Set the Base Attributes
            Speed = data.Speed;
            Range = data.Range;
            Defense = data.Defense;
            Attack = data.Attack;
            MaxHealth = data.MaxHealth;
            CurrentHealth = data.CurrentHealth;

            ImageURI = data.ImageURI;

            // Set the strings for the items
            Head = data.Head;
            Necklass = data.Necklass;
            PrimaryHand = data.PrimaryHand;
            OffHand = data.OffHand;
            RightFinger = data.RightFinger;
            LeftFinger = data.LeftFinger;
            Feet = data.Feet;
            UniqueItem = data.UniqueItem;

            Difficulty = data.Difficulty;

            Job = data.Job;

            AbilityTracker = data.AbilityTracker;
        }

        /// <summary>
        /// Create PlayerInfoModel from character
        /// </summary>
        /// <param name="data"></param>
        public PlayerInfoModel(CharacterModel data)
        {
            PlayerType = data.PlayerType;
            Guid = data.Guid;
            Alive = data.Alive;
            ExperienceTotal = data.ExperienceTotal;
            ExperienceRemaining = data.ExperienceRemaining;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;

            // Set the Base Attributes
            Speed = data.Speed;
            Range = data.Range;
            Defense = data.Defense;
            Attack = data.Attack;
            MaxHealth = data.MaxHealth;
            CurrentHealth = data.CurrentHealth;

            ImageURI = data.ImageURI;

            // Set the strings for the items
            Head = data.Head;
            Necklass = data.Necklass;
            PrimaryHand = data.PrimaryHand;
            OffHand = data.OffHand;
            RightFinger = data.RightFinger;
            LeftFinger = data.LeftFinger;
            Feet = data.Feet;
            UniqueItem = data.UniqueItem;

            Difficulty = data.Difficulty;

            Job = data.Job;

            // Give the copy a differet quid, so it can be used in the battles as a copy
            Guid = System.Guid.NewGuid().ToString();

            // Set current experience to be 1 above minimum.
            ExperienceTotal = LevelTableHelper.LevelDetailsList[Level - 1].Experience + 1;

            // TODO: Mike, Refactor this, so it is in a helper, and call it on level up as well.
            switch (Job)
            {
                case CharacterJobEnum.Cleric:

                    foreach (var item in AbilityEnumHelper.GetListCleric)
                    {
                        AbilityTracker.Add(AbilityEnumHelper.ConvertStringToEnum(item), Level);
                    }
                    break;

                case CharacterJobEnum.Fighter:
                    foreach (var item in AbilityEnumHelper.GetListFighter)
                    {
                        AbilityTracker.Add(AbilityEnumHelper.ConvertStringToEnum(item), Level);
                    }
                    break;

                default:
                    foreach (var item in AbilityEnumHelper.GetListOthers)
                    {
                        AbilityTracker.Add(AbilityEnumHelper.ConvertStringToEnum(item), Level);
                    }
                    break;
            }
        }

        /// <summary>
        /// Crate PlayerInfoModel from Monster
        /// </summary>
        /// <param name="data"></param>
        public PlayerInfoModel(MonsterModel data)
        {
            PlayerType = data.PlayerType;
            Guid = data.Guid;
            Alive = data.Alive;
            ExperienceTotal = data.ExperienceTotal;
            ExperienceRemaining = data.ExperienceRemaining;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            Speed = data.GetSpeed();
            ImageURI = data.ImageURI;
            MaxHealth = data.GetMaxHealthTotal;
            CurrentHealth = data.GetCurrentHealthTotal;

            // Set the Base Attributes
            Speed = data.Speed;
            Range = data.Range;
            Defense = data.Defense;
            Attack = data.Attack;
            MaxHealth = data.MaxHealth;
            CurrentHealth = data.CurrentHealth;

            // Set the strings for the items
            Head = data.Head;
            Necklass = data.Necklass;
            PrimaryHand = data.PrimaryHand;
            OffHand = data.OffHand;
            RightFinger = data.RightFinger;
            LeftFinger = data.LeftFinger;
            Feet = data.Feet;

            UniqueItem = data.UniqueItem;

            Difficulty = data.Difficulty;

            Job = data.Job;

            // Give the copy a differet quid, so it can be used in the battles as a copy
            Guid = System.Guid.NewGuid().ToString();

            // Set amount to give to be 1 below max for that level.
            ExperienceRemaining = LevelTableHelper.LevelDetailsList[Level + 1].Experience - 1;

            // Adding abilities for monsters, why not, they work hard for a living
            foreach (var item in AbilityEnumHelper.GetListOthers)
            {
                AbilityTracker.Add(AbilityEnumHelper.ConvertStringToEnum(item), Level);
            }

        }

        public override string FormatOutput()
        {
            var myReturn = string.Empty;
            myReturn += Name;
            myReturn += " , " + Description;
            myReturn += " , a " + Job.ToMessage();
            myReturn += " , Level : " + Level.ToString();

            if (PlayerType == PlayerTypeEnum.Character)
            {
                myReturn += " , Total Experience : " + ExperienceTotal;
                myReturn += " , Damage : " + GetDamageTotalString;
                myReturn += " , Attack :" + GetAttackTotal;
                myReturn += " , Defense :" + GetDefenseTotal;
                myReturn += " , Speed :" + GetSpeedTotal;
            }

            myReturn += " , Items : " + ItemSlotsFormatOutput();

            return myReturn;
        }

        #region Abilities

        /// <summary>
        /// Check to see if healing would help
        /// 
        /// if not, return unknown
        /// </summary>
        /// <returns></returns>
        public AbilityEnum SelectHealingAbility()
        {
            // Save the Health for when it is needed
            // If health is 25% or less of max health, try to heal
            if (GetCurrentHealth() < (GetMaxHealth() * .25))
            {
                // Try to use Heal or Bandage
                if (IsAbilityAvailable(AbilityEnum.Heal))
                {
                    return AbilityEnum.Heal;
                }

                if (IsAbilityAvailable(AbilityEnum.Bandage))
                {
                    return AbilityEnum.Bandage;
                }
            }

            return AbilityEnum.Unknown;
        }

        /// <summary>
        /// Walk the Abilities and return one to use
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public AbilityEnum SelectAbilityToUse()
        {
            // Walk the other abilities and see which can be used
            foreach (var ability in AbilityTracker)
            {
                var data = ability.Key;

                // Skip over Heal and Bandage because covered in healing
                if (data == AbilityEnum.Heal)
                {
                    continue;
                }

                if (data == AbilityEnum.Bandage)
                {
                    continue;
                }

                var result = AbilityTracker.TryGetValue(data, out int remaining);
                if (remaining > 0)
                {
                    // Got one so can prepare it to be used
                    return data;
                }
            }

            return AbilityEnum.Unknown;
        }

        public bool IsAbilityAvailable(AbilityEnum ability)
        {
            var avaible = AbilityTracker.TryGetValue(ability, out int remaining);
            if (avaible == false)
            {
                // does not exist
                return false;
            }

            if (remaining < 1)
            {
                // out of tries
                return false;
            }

            return true;
        }

        /// <summary>
        /// Use the Ability
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool UseAbility(AbilityEnum ability)
        {
            var avaible = AbilityTracker.TryGetValue(ability, out int remaining);
            if (avaible == false)
            {
                // does not exist
                return false;
            }

            if (remaining < 1)
            {
                // out of tries
                return false;
            }

            switch (ability)
            {
                case AbilityEnum.Heal:
                case AbilityEnum.Bandage:
                    BuffHealth();
                    break;

                case AbilityEnum.Toughness:
                case AbilityEnum.Barrier:
                    BuffDefense();
                    break;

                case AbilityEnum.Curse:
                case AbilityEnum.Focus:
                    BuffAttack();
                    break;

                case AbilityEnum.Quick:
                case AbilityEnum.Nimble:
                    BuffSpeed();
                    break;
            }

            // Reduce the count
            AbilityTracker[ability] = remaining - 1;

            return true;
        }
        #endregion Abilities

    }
}