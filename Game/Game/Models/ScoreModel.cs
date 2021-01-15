using SQLite;
using System;
using System.Collections.Generic;

namespace Game.Models
{
    /// <summary>
    /// Item for the Game
    /// 
    /// The Items that a character can use, a Monster may drop, or may be randomly available.
    /// The items are stored in the DB, and during game time a random item is selected.
    /// The system supports CRUDi operatoins on the items
    /// When in test mode, a test set of items is loaded
    /// When in run mode the items from from the database
    /// When in online mode, the items come from an api call to a webservice
    /// 
    /// When characters or monsters die, they drop items into the Items Pool for the Battle
    /// 
    /// </summary>
    public class ScoreModel : BaseModel<ScoreModel>
    {
        // This battle number, incremental int from the last int in the database
        public int BattleNumber { get; set; }

        // Total Score
        public int ScoreTotal { get; set; }

        // The Date the game played, and when the score was saved
        public DateTime GameDate { get; set; }

        // Tracks if auto battle is true, or if user battle = false
        public bool AutoBattle { get; set; }

        // The number of turns the battle took to finish
        public int TurnCount { get; set; }

        // The number of rounds the battle took to finish
        public int RoundCount { get; set; }

        // The count of monsters slain during battle
        public int MonsterSlainNumber { get; set; }

        // The total experience points all the characters received during the battle
        public int ExperienceGainedTotal { get; set; }

        // A list of all the characters at the time of death and their stats.  
        // Only use Get only, set will be done by the Add feature.
        public string CharacterAtDeathList { get; set; } = string.Empty;

        // All of the monsters killed and their stats. 
        // Only use Get only, set will be done by the Add feature.
        public string MonstersKilledList { get; set; } = string.Empty;

        // All of the items dropped and their stats. 
        // Only use Get only, set will be done by the Add feature.
        public string ItemsDroppedList { get; set; } = string.Empty;

        // Add Characters to the List for Score, New Round, and Easier testing
        [Ignore]
        public List<PlayerInfoModel> CharacterModelDeathList { get; set; } = new List<PlayerInfoModel>();

        // Add Monsters to the List for Score, New Round, and Easier testing
        [Ignore]
        public List<PlayerInfoModel> MonsterModelDeathList { get; set; } = new List<PlayerInfoModel>();

        // Add Item to the List for Score, New Round, and Easier testing
        [Ignore]
        public List<ItemModel> ItemModelDropList { get; set; } = new List<ItemModel>();

        // Add the Selected Items to the List for Score, New Round, and Easier testing
        [Ignore]
        public List<ItemModel> ItemModelSelectList { get; set; } = new List<ItemModel>();

        /// <summary>
        /// Instantiate new Score 
        /// </summary>
        public ScoreModel()
        {
            GameDate = DateTime.Now;    // Set to be now by default.
            AutoBattle = false;         //assume user battle

            TurnCount = 0;
            RoundCount = 0;
            ExperienceGainedTotal = 0;
            MonsterSlainNumber = 0;
        }

        /// <summary>
        /// Constructor for loading score from SQL
        /// Takes a Score and make a scopy of it.
        /// </summary>
        /// <param name="data"></param>
        public ScoreModel(ScoreModel data)
        {
            // Id = data.Id;
            Update(data);
        }

        /// <summary>
        /// Update the score based on the passed in values. 
        /// </summary>
        /// <param name="newData"></param>
        public override bool Update(ScoreModel newData)
        {
            if (newData == null)
            {
                return false;
            }

            // Update all the fields in the Data, except for the Id
            Name = newData.Name;
            Description = newData.Description;

            BattleNumber = newData.BattleNumber;
            ScoreTotal = newData.ScoreTotal;
            GameDate = newData.GameDate;
            AutoBattle = newData.AutoBattle;
            TurnCount = newData.TurnCount;
            RoundCount = newData.RoundCount;
            MonsterSlainNumber = newData.MonsterSlainNumber;
            ExperienceGainedTotal = newData.ExperienceGainedTotal;
            CharacterAtDeathList = newData.CharacterAtDeathList;
            MonstersKilledList = newData.MonstersKilledList;
            ItemsDroppedList = newData.ItemsDroppedList;

            return true;
        }

        #region ScoreItems

        /// <summary>
        /// Calculate the Final Score
        /// </summary>
        /// <returns></returns>
        public int CalculateScore()
        {
            int result = ExperienceGainedTotal;

            return result;
        }

        /// <summary>
        /// All an item to the list of items for score and their stats
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddToList(ItemModel data)
        {
            if (data == null)
            {
                return false;
            }

            ItemsDroppedList += data.FormatOutput() + "\n";
            return true;
        }
        #endregion ScoreItems
    }
}