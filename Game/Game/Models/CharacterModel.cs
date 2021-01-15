using Game.GameRules;

namespace Game.Models
{
    /// <summary>
    /// Characters
    /// 
    /// Derive from BasePlayerModel
    /// </summary>
    public class CharacterModel : BasePlayerModel<CharacterModel>
    {
        /// <summary>
        /// Default character
        /// 
        /// Gets a type, guid, name and description
        /// </summary>
        public CharacterModel()
        {
            PlayerType = PlayerTypeEnum.Character;
            Guid = Id;
            Name = "Elf";
            Description = "Happy Elf";
            Level = 1;
            ImageURI = "item.png";
            ExperienceTotal = 0;
            ExperienceRemaining = LevelTableHelper.LevelDetailsList[Level + 1].Experience - 1;

            // Default to unknown, which is no special job
            Job = CharacterJobEnum.Unknown; 
        }

        /// <summary>
        /// Create a copy
        /// </summary>
        /// <param name="data"></param>
        public CharacterModel(CharacterModel data)
        {
            Update(data);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="newData"></param>
        /// <returns></returns>
        public override bool Update(CharacterModel newData)
        {
            if (newData == null)
            {
                return false;
            }

            PlayerType = newData.PlayerType;
            Guid = newData.Guid;
            Name = newData.Name;
            Description = newData.Description;
            Level = newData.Level;
            ImageURI = newData.ImageURI;

            // Difficulty = newData.Difficulty;

            Speed = newData.Speed;
            Defense = newData.Defense;
            Attack = newData.Attack;

            ExperienceTotal = newData.ExperienceTotal;
            ExperienceRemaining = newData.ExperienceRemaining;
            CurrentHealth = newData.CurrentHealth;
            MaxHealth = newData.MaxHealth;

            Head = newData.Head;
            Necklass = newData.Necklass;
            PrimaryHand = newData.PrimaryHand;
            OffHand = newData.OffHand;
            RightFinger = newData.RightFinger;
            LeftFinger = newData.LeftFinger;
            Feet = newData.Feet;
            UniqueItem = newData.UniqueItem;

            // Update the Job
            Job = newData.Job;

            return true;
        }

        /// <summary>
        /// Helper to combine the attributes into a single line, to make it easier to display the item as a string
        /// </summary>
        /// <returns></returns>
        public override string FormatOutput()
        {
            var myReturn = string.Empty;
            myReturn += Name;
            myReturn += " , " + Description;
            myReturn += " , a " + Job.ToMessage();
            myReturn += " , Level : " + Level.ToString();
            myReturn += " , Total Experience : " + ExperienceTotal;
            myReturn += " , Attack :" + GetAttackTotal;
            myReturn += " , Defense :" + GetDefenseTotal;
            myReturn += " , Speed :" + GetSpeedTotal;
            myReturn += " , Items : " + ItemSlotsFormatOutput();
            myReturn += " , Damage : " + GetDamageTotalString;

            return myReturn;
        }
    }
}