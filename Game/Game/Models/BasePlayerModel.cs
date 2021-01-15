using System;
using System.Collections.Generic;

using SQLite;

using Game.GameRules;
using Game.Helpers;
using Game.ViewModels;

namespace Game.Models
{
    /// <summary>
    /// Base Player that Characters and Monsters derive from
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BasePlayerModel<T> : BaseModel<T>
    {
        #region Attributes

        #region GameEngineAttributes
        // alive status, !alive will be removed from the list
        [Ignore]
        public bool Alive { get; set; } = true;

        // The type of player, character comes before monster
        [Ignore]
        public PlayerTypeEnum PlayerType { get; set; } = PlayerTypeEnum.Unknown;

        // TurnOrder
        [Ignore]
        public int Order { get; set; } = 0;

        // Remember who was first into the list...
        [Ignore]
        public int ListOrder { get; set; } = 0;

        #endregion GameEngineAttributes

        #region Buffs

        // Add to Health
        [Ignore]
        public int BuffHealthValue { get; set; } = 0;

        // Add to Attack
        [Ignore]
        public int BuffAttackValue { get; set; } = 0;

        // Add to defense
        [Ignore]
        public int BuffDefenseValue { get; set; } = 0;

        // Add to Speed
        [Ignore]
        public int BuffSpeedValue { get; set; } = 0;

        /// <summary>
        /// Clear all the Buffs
        /// </summary>
        public void ClearBuffs()
        {
            BuffHealthValue = 0;
            BuffAttackValue = 0;
            BuffDefenseValue = 0;
            BuffSpeedValue = 0;
        }

        /// <summary>
        /// Add to Health
        /// </summary>
        public int BuffHealth()
        {
            return BuffHealthValue += 5;
        }

        /// <summary>
        /// Add to Health
        /// </summary>
        public int BuffAttack()
        {
            return BuffAttackValue += 5;
        }

        /// <summary>
        /// Add to Health
        /// </summary>
        public int BuffDefense()
        {
            return BuffDefenseValue += 5;
        }

        /// <summary>
        /// Add to Health
        /// </summary>
        public int BuffSpeed()
        {
            return BuffSpeedValue += 5;
        }

        #endregion Buffs

        #region PlayerAttributes

        // Level of character or monster
        public int Level { get; set; } = 1;

        // Current Health
        public int CurrentHealth { get; set; } = 0;

        // Max Health
        public int MaxHealth { get; set; } = 0;

        // Total Experience Earned
        public int ExperienceTotal { get; set; } = 0;

        // The Experience available to given up
        public int ExperienceRemaining { get; set; }

        // Total speed, including level and items
        public int Speed { get; set; } = 0;

        // The defense score, to be used for defending against attacks
        public int Defense { get; set; } = 0;

        // The Attack score to be used when attacking
        public int Attack { get; set; } = 0;

        // The natural range for this Player, 1 is normal
        public int Range { get; set; } = 1;

        // The Difficulty scale to use when creating examples
        public DifficultyEnum Difficulty { get; set; } = DifficultyEnum.Unknown;

        // The Job for the Player
        public CharacterJobEnum Job { get; set; } = CharacterJobEnum.Unknown;

        #endregion PlayerAttributes

        #endregion Attributes

        #region Items
        // ItemModel is a string referencing the database table
        public string Head { get; set; } = null;

        // Feet is a string referencing the database table
        public string Feet { get; set; } = null;

        // Necklasss is a string referencing the database table
        public string Necklass { get; set; } = null;

        // PrimaryHand is a string referencing the database table
        public string PrimaryHand { get; set; } = null;

        // Offhand is a string referencing the database table
        public string OffHand { get; set; } = null;

        // RightFinger is a string referencing the database table
        public string RightFinger { get; set; } = null;

        // LeftFinger is a string referencing the database table
        public string LeftFinger { get; set; } = null;

        // Unique Drop Item for Monsters
        public string UniqueItem { get; set; } = null;
        #endregion Items

        #region AttributeDisplay

        // Following returns the values for each of the attributes with the modifiers

        #region Attack        
        [Ignore]
        // Return the attack value
        public int GetAttackLevelBonus { get { return LevelTableHelper.LevelDetailsList[Level].Attack; } }

        [Ignore]
        // Return the Attack with Item Bonus
        public int GetAttackItemBonus { get { return GetItemBonus(AttributeEnum.Attack); } }

        [Ignore]
        // Return the Attack with Item Bonus
        public int GetAttackJobBonus
        {
            get
            {
                var result = 0;

                switch (Job)
                {
                    case CharacterJobEnum.Cleric:
                        result = -1;
                        break;
                    case CharacterJobEnum.Fighter:
                        result = +2;
                        break;
                    case CharacterJobEnum.Unknown:
                    default:
                        break;
                }
                return result;
            }
        }

        [Ignore]
        // Return the Total of All Attack
        public int GetAttackTotal { get { return GetAttack(); } }
        #endregion Attack

        #region Defense
        [Ignore]
        // Return the Defense value
        public int GetDefenseLevelBonus { get { return LevelTableHelper.LevelDetailsList[Level].Defense; } }

        [Ignore]
        // Return the Defense with Item Bonus
        public int GetDefenseItemBonus { get { return GetItemBonus(AttributeEnum.Defense); } }

        [Ignore]
        // Return the Total of All Defense
        public int GetDefenseTotal { get { return GetDefense(); } }


        [Ignore]
        // Return the Attack with Item Bonus
        public int GetDefenseJobBonus
        {
            get
            {
                var result = 0;

                switch (Job)
                {
                    case CharacterJobEnum.Cleric:
                        result = +2;
                        break;
                    case CharacterJobEnum.Fighter:
                        result = -1;
                        break;
                    case CharacterJobEnum.Unknown:
                    default:
                        break;
                }
                return result;
            }
        }


        #endregion Defense

        #region Speed
        [Ignore]
        // Return the Speed value
        public int GetSpeedLevelBonus { get { return LevelTableHelper.LevelDetailsList[Level].Speed; } }

        [Ignore]
        // Return the Speed with Item Bonus
        public int GetSpeedItemBonus { get { return GetItemBonus(AttributeEnum.Speed); } }

        [Ignore]
        // Return the Total of All Speed
        public int GetSpeedTotal { get { return GetSpeed(); } }

        [Ignore]
        // Return the Attack with Item Bonus
        public int GetSpeedJobBonus
        {
            get
            {
                var result = 0;

                switch (Job)
                {
                    case CharacterJobEnum.Cleric:
                        result = 0;
                        break;
                    case CharacterJobEnum.Fighter:
                        result = +1;
                        break;
                    case CharacterJobEnum.Unknown:
                    default:
                        break;
                }
                return result;
            }
        }
        #endregion Speed

        #region CurrentHealth
        [Ignore]
        // Return the CurrentHealth value
        public int GetCurrentHealthLevelBonus { get { return 0; } }

        [Ignore]
        // Return the CurrentHealth with Item Bonus
        public int GetCurrentHealthItemBonus { get { return GetItemBonus(AttributeEnum.CurrentHealth); } }

        [Ignore]
        // Return the Total of All CurrentHealth
        public int GetCurrentHealthTotal { get { return GetCurrentHealth(); } }
        #endregion CurrentHealth

        #region MaxHealth
        [Ignore]
        // Return the MaxHealth value
        public int GetMaxHealthLevelBonus { get { return 0; } }

        [Ignore]
        // Return the MaxHealth with Item Bonus
        public int GetMaxHealthItemBonus { get { return GetItemBonus(AttributeEnum.MaxHealth); } }

        [Ignore]
        // Return the Total of All MaxHealth
        public int GetMaxHealthTotal { get { return GetMaxHealth(); } }
        #endregion MaxHealth

        #region Damage
        [Ignore]
        // Return the Damage value, it is 25% of the Level rounded up
        public int GetDamageLevelBonus { get { return Convert.ToInt32(Math.Ceiling(Level * .25)); } }

        [Ignore]
        // Return the Damage with Item Bonus
        public int GetDamageItemBonus
        {
            get
            {
                var myItem = ItemIndexViewModel.Instance.GetItem(PrimaryHand);
                if (myItem == null)
                {
                    return 0;
                }
                return myItem.Damage;
            }
        }

        [Ignore]
        // Return the Damage Dice if there is one
        public string GetDamageItemBonusString
        {
            get
            {
                var data = GetDamageItemBonus;
                if (data == 0)
                {
                    return "-";
                }

                return string.Format("1D {0}", data);
            }
        }

        [Ignore]
        // Return the Total of All Damage
        public string GetDamageTotalString
        {
            get
            {

                if (GetDamageItemBonusString.Equals("-"))
                {
                    return GetDamageLevelBonus.ToString();
                }

                return GetDamageLevelBonus.ToString() + " + " + GetDamageItemBonusString;

            }
        }
        #endregion Damage

        #endregion AttributeDisplay

        #region Methods

        #region BasicMethods

        /// <summary>
        /// Constructor for BasePlayer
        /// </summary>
        public BasePlayerModel()
        {
            Guid = Id;
        }

        /// <summary>
        /// Format Output
        /// </summary>
        /// <returns></returns>
        public virtual string FormatOutput() { return ""; }

        #endregion BasicMethods

        #region GetAttributeValues

        /// <summary>
        /// Return the Range for the Attack Distance
        /// </summary>
        /// <returns></returns>
        public int GetRange()
        {
            // Base Attack
            var myReturn = Range;

            // Get Attack bonus from Items
            myReturn += GetItemRange();

            return myReturn;
        }

        /// <summary>
        /// Return the Total Attack Value
        /// </summary>
        /// <returns></returns>
        public int GetAttack()
        {
            // Base Attack
            var myReturn = Attack;

            // Attack Bonus from Level
            myReturn += GetAttackLevelBonus;

            // Get Attack bonus from Items
            myReturn += GetAttackItemBonus;

            // Add Job Bonus
            myReturn += GetAttackJobBonus;

            // Add any Round Buffs
            myReturn += BuffAttackValue;

            return myReturn;
        }

        /// <summary>
        /// Return the Total Defense Value
        /// </summary>
        /// <returns></returns>
        public int GetDefense()
        {
            // Base Defense
            var myReturn = Defense;

            // Defense Bonus from Level
            myReturn += GetDefenseLevelBonus;

            // Get Defense bonus from Items
            myReturn += GetDefenseItemBonus;

            myReturn += GetDefenseJobBonus;

            // Add any Round Buffs
            myReturn += BuffDefenseValue;

            return myReturn;
        }

        /// <summary>
        /// Return the Total Speed Value
        /// </summary>
        /// <returns></returns>
        public int GetSpeed()
        {
            // Base Speed
            var myReturn = Speed;

            // Speed Bonus from Level
            myReturn += GetSpeedLevelBonus;

            // Get Speed bonus from Items
            myReturn += GetSpeedItemBonus;

            myReturn += GetSpeedJobBonus;

            // Add any Round Buffs
            myReturn += BuffSpeedValue;

            return myReturn;
        }

        /// <summary>
        /// Return the Total CurrentHealth Value
        /// </summary>
        /// <returns></returns>
        public int GetCurrentHealth()
        {
            // Base CurrentHealth
            var myReturn = CurrentHealth;

            // CurrentHealth Bonus from Level
            myReturn += GetCurrentHealthLevelBonus;

            // Get CurrentHealth bonus from Items
            myReturn += GetCurrentHealthItemBonus;

            // Add any Round Buffs
            myReturn += BuffHealthValue;

            return myReturn;
        }

        /// <summary>
        /// Return the Total MaxHealth Value
        /// </summary>
        /// <returns></returns>
        public int GetMaxHealth()
        {
            // Base MaxHealth
            var myReturn = MaxHealth;

            // MaxHealth Bonus from Level
            myReturn += GetMaxHealthLevelBonus;

            // Get MaxHealth bonus from Items
            myReturn += GetMaxHealthItemBonus;

            return myReturn;
        }

        #endregion GetAttributeValues

        #region BattleMethods
        /// <summary>
        /// Take Damage
        /// If the damage recived, is > health, then death occurs
        /// Return the number of experience received for this attack 
        /// monsters give experience to characters.  Characters don't accept expereince from monsters
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public bool TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                return false;
            }

            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;

                // Death...
                CauseDeath();
            }

            return true;
        }

        /// <summary>
        /// Roll the Damage Dice, and add to the Damage
        /// </summary>
        /// <returns></returns>
        public int GetDamageRollValue()
        {
            var myReturn = 0;

            var myItem = ItemIndexViewModel.Instance.GetItem(PrimaryHand);
            if (myItem != null)
            {
                // Dice of the weapon.  So sword of Damage 10 is d10
                myReturn += DiceHelper.RollDice(1, myItem.Damage);
            }

            // Add in the Level as extra damage per game rules
            myReturn += GetDamageLevelBonus;

            return myReturn;
        }

        // Death
        // Alive turns to False
        public bool CauseDeath()
        {
            Alive = false;
            return Alive;
        }

        #endregion BattleMethods

        #region LevelMethods

        /// <summary>
        /// Add Experience
        /// </summary>
        /// <param name="newExperience"></param>
        /// <returns></returns>
        public bool AddExperience(int newExperience)
        {
            // Don't allow going lower in experience
            if (newExperience < 0)
            {
                return false;
            }

            // Increment the Experience
            ExperienceTotal += newExperience;

            // Can't level UP if at max.
            if (Level >= LevelTableHelper.MaxLevel)
            {
                return false;
            }

            // Then check for Level UP
            // If experience is higher than the experience at the next level, level up is OK.
            if (ExperienceTotal >= LevelTableHelper.LevelDetailsList[Level + 1].Experience)
            {
                return LevelUp();
            }
            return false;
        }

        /// <summary>
        /// Calculate The amount of Experience to give
        /// Reduce the remaining by what was given
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public int CalculateExperienceEarned(int damage)
        {
            if (damage < 1)
            {
                return 0;
            }

            int remainingHealth = Math.Max(CurrentHealth - damage, 0); // Go to 0 is OK...
            double rawPercent = (double)remainingHealth / (double)CurrentHealth;
            double deltaPercent = 1 - rawPercent;
            var pointsAllocate = (int)Math.Floor(ExperienceRemaining * deltaPercent);

            // Catch rounding of low values, and force to 1.
            if (pointsAllocate < 1)
            {
                pointsAllocate = 1;
            }

            // Take away the points from remaining experience
            ExperienceRemaining -= pointsAllocate;
            if (ExperienceRemaining < 0)
            {
                pointsAllocate = 1;
            }

            return pointsAllocate;
        }

        // Level Up
        public bool LevelUp()
        {
            // Walk the Level Table descending order
            // Stop when experience is >= experience in the table
            for (var i = LevelTableHelper.LevelDetailsList.Count - 1; i > 0; i--)
            {
                // Check the Level
                // If the Level is > Experience for the Index, increment the Level.
                if (LevelTableHelper.LevelDetailsList[i].Experience <= ExperienceTotal)
                {
                    var NewLevel = LevelTableHelper.LevelDetailsList[i].Level;

                    // When leveling up, the current health is adjusted up by an offset of the MaxHealth, rather than full restore
                    var OldCurrentHealth = CurrentHealth;
                    var OldMaxHealth = MaxHealth;

                    // Set new Health
                    // New health, is d10 of the new level.  So leveling up 1 level is 1 d10, leveling up 2 levels is 2 d10.
                    var NewHealthAddition = DiceHelper.RollDice(NewLevel - Level, 10);

                    // Increment the Max health
                    MaxHealth += NewHealthAddition;

                    // Calculate new current health
                    // old max was 10, current health 8, new max is 15 so (15-(10-8)) = current health
                    CurrentHealth = (MaxHealth - (OldMaxHealth - OldCurrentHealth));

                    // Set the new level
                    Level = NewLevel;

                    // Done, exit
                    return true;
                }
            }

            return false;
        }

        // Level up to a number, say Level 3
        public int LevelUpToValue(int Value)
        {
            // Adjust the experience to the min for that level.
            // That will trigger level up to happen

            if (Value < 0)
            {
                // Skip, and return old level
                return Level;
            }

            if (Value <= Level)
            {
                // Skip, and return old level
                return Level;
            }

            if (Value > LevelTableHelper.MaxLevel)
            {
                return Level;
            }

            AddExperience(LevelTableHelper.LevelDetailsList[Value].Experience + 1);

            return Level;
        }

        #endregion LevelMethods

        #region Items

        /// <summary>
        /// Get the Range value for the equipped primary weapon
        /// 
        /// If it has a positive value, return that
        /// 
        /// Else return 0
        /// </summary>
        /// <returns></returns>
        public int GetItemRange()
        {
            var weapon = GetItemByLocation(ItemLocationEnum.PrimaryHand);
            if (weapon == null)
            {
                return 0;
            }

            if (weapon.Range < 0)
            {
                return 0;
            }

            return weapon.Range;
        }

        /// <summary>
        /// Get the Item at a known string location (head, foot etc.)
        /// </summary>
        /// <param name="itemString"></param>
        /// <returns></returns>
        public ItemModel GetItem(string itemString)
        {
            return ItemIndexViewModel.Instance.GetItem(itemString);
        }

        // Drop All Items
        // Return a list of items for the pool of items
        public List<ItemModel> DropAllItems()
        {
            var myReturn = new List<ItemModel>();

            // Drop all Items
            ItemModel myItem;

            myItem = RemoveItem(ItemLocationEnum.Head);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            myItem = RemoveItem(ItemLocationEnum.Necklass);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            myItem = RemoveItem(ItemLocationEnum.PrimaryHand);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            myItem = RemoveItem(ItemLocationEnum.OffHand);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            myItem = RemoveItem(ItemLocationEnum.RightFinger);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            myItem = RemoveItem(ItemLocationEnum.LeftFinger);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            myItem = RemoveItem(ItemLocationEnum.Feet);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            return myReturn;
        }

        // Remove ItemModel from a set location
        // Does this by adding a new ItemModel of Null to the location
        // This will return the previous ItemModel, and put null in its place
        // Returns the ItemModel that was at the location
        // Nulls out the location
        public ItemModel RemoveItem(ItemLocationEnum itemlocation)
        {
            var myReturn = AddItem(itemlocation, null);

            // Save Changes
            return myReturn;
        }

        // Get the ItemModel at a known string location (head, foot etc.)
        public ItemModel GetItemByLocation(ItemLocationEnum itemLocation)
        {
            switch (itemLocation)
            {
                case ItemLocationEnum.Head:
                    return GetItem(Head);

                case ItemLocationEnum.Necklass:
                    return GetItem(Necklass);

                case ItemLocationEnum.PrimaryHand:
                    return GetItem(PrimaryHand);

                case ItemLocationEnum.OffHand:
                    return GetItem(OffHand);

                case ItemLocationEnum.RightFinger:
                    return GetItem(RightFinger);

                case ItemLocationEnum.LeftFinger:
                    return GetItem(LeftFinger);

                case ItemLocationEnum.Feet:
                    return GetItem(Feet);
            }

            return null;
        }

        // Add ItemModel
        // Looks up the ItemModel
        // Puts the ItemModel ID as a string in the location slot
        // If ItemModel is null, then puts null in the slot
        // Returns the ItemModel that was in the location
        public ItemModel AddItem(ItemLocationEnum itemLocation, string itemID)
        {
            var myReturn = GetItemByLocation(itemLocation);

            switch (itemLocation)
            {
                case ItemLocationEnum.Feet:
                    Feet = itemID;
                    break;

                case ItemLocationEnum.Head:
                    Head = itemID;
                    break;

                case ItemLocationEnum.Necklass:
                    Necklass = itemID;
                    break;

                case ItemLocationEnum.PrimaryHand:
                    PrimaryHand = itemID;
                    break;

                case ItemLocationEnum.OffHand:
                    OffHand = itemID;
                    break;

                case ItemLocationEnum.RightFinger:
                    RightFinger = itemID;
                    break;

                case ItemLocationEnum.LeftFinger:
                    LeftFinger = itemID;
                    break;

                default:
                    myReturn = null;
                    break;
            }

            return myReturn;
        }

        // Walk all the Items on the Character.
        // Add together all Items that modify the Attribute Enum Passed in
        // Return the sum
        public int GetItemBonus(AttributeEnum attributeEnum)
        {
            var myReturn = 0;
            ItemModel myItem;

            myItem = GetItem(Head);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = GetItem(Necklass);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = GetItem(PrimaryHand);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = GetItem(OffHand);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = GetItem(RightFinger);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = GetItem(LeftFinger);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = GetItem(Feet);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            return myReturn;
        }

        /// <summary>
        /// Get the Items the Character has
        /// </summary>
        /// <returns></returns>
        public string ItemSlotsFormatOutput()
        {
            var myReturn = "";

            var data = ItemIndexViewModel.Instance.GetItem(UniqueItem);
            if (data != null)
            {
                myReturn += data.FormatOutput();
            }

            data = ItemIndexViewModel.Instance.GetItem(Head);
            if (data != null)
            {
                myReturn += data.FormatOutput();
            }

            data = ItemIndexViewModel.Instance.GetItem(Necklass);
            if (data != null)
            {
                myReturn += data.FormatOutput();
            }

            data = ItemIndexViewModel.Instance.GetItem(PrimaryHand);
            if (data != null)
            {
                myReturn += data.FormatOutput();
            }

            data = ItemIndexViewModel.Instance.GetItem(OffHand);
            if (data != null)
            {
                myReturn += data.FormatOutput();
            }

            data = ItemIndexViewModel.Instance.GetItem(RightFinger);
            if (data != null)
            {
                myReturn += data.FormatOutput();
            }

            data = ItemIndexViewModel.Instance.GetItem(LeftFinger);
            if (data != null)
            {
                myReturn += data.FormatOutput();
            }

            data = ItemIndexViewModel.Instance.GetItem(Feet);
            if (data != null)
            {
                myReturn += data.FormatOutput();
            }

            return myReturn.Trim();
        }

        #endregion Items

        #endregion Methods
    }
}