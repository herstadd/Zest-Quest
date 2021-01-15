using Game.Models;
using System.Collections.Generic;

namespace Game.GameRules
{
    /// <summary>
    /// Helper to manage the Level Table Data
    /// </summary>
    public static class LevelTableHelper
    {

        // Level Max
        public const int MaxLevel = 20;

        // List of all the levels
        public static List<LevelDetailsModel> LevelDetailsList { get; } = new List<LevelDetailsModel>();

        /// <summary>
        /// Constructor calls to clear the data
        /// </summary>
        static LevelTableHelper()
        {
            ClearAndLoadDataTable();
        }

        /// <summary>
        /// Clear the data and relaod it
        /// </summary>
        public static bool ClearAndLoadDataTable()
        {
            LevelDetailsList.Clear();
            LoadLevelData();

            return true;
        }

        /// <summary>
        /// Load the data for each level
        /// </summary>
        public static int LoadLevelData()
        {
            // Init the level list, going to index into it like an array, so making 0 be a null value.  That way Level can be Array Index.
            LevelDetailsList.Add(new LevelDetailsModel(0, 0, 0, 0, 0));

            // Character Level Chart...

            // Sequence is Level,Experience,Attack,Defense,Speed

            LevelDetailsList.Add(new LevelDetailsModel(1, 0, 1, 1, 1));
            LevelDetailsList.Add(new LevelDetailsModel(2, 300, 1, 2, 1));
            LevelDetailsList.Add(new LevelDetailsModel(3, 900, 2, 3, 1));
            LevelDetailsList.Add(new LevelDetailsModel(4, 2700, 2, 3, 1));
            LevelDetailsList.Add(new LevelDetailsModel(5, 6500, 2, 4, 2));
            LevelDetailsList.Add(new LevelDetailsModel(6, 14000, 3, 4, 2));
            LevelDetailsList.Add(new LevelDetailsModel(7, 23000, 3, 5, 2));
            LevelDetailsList.Add(new LevelDetailsModel(8, 34000, 3, 5, 2));
            LevelDetailsList.Add(new LevelDetailsModel(9, 48000, 3, 5, 2));
            LevelDetailsList.Add(new LevelDetailsModel(10, 64000, 4, 6, 3));
            LevelDetailsList.Add(new LevelDetailsModel(11, 85000, 4, 6, 3));
            LevelDetailsList.Add(new LevelDetailsModel(12, 100000, 4, 6, 3));
            LevelDetailsList.Add(new LevelDetailsModel(13, 120000, 4, 7, 3));
            LevelDetailsList.Add(new LevelDetailsModel(14, 140000, 5, 7, 3));
            LevelDetailsList.Add(new LevelDetailsModel(15, 165000, 5, 7, 4));
            LevelDetailsList.Add(new LevelDetailsModel(16, 195000, 5, 8, 4));
            LevelDetailsList.Add(new LevelDetailsModel(17, 225000, 5, 8, 4));
            LevelDetailsList.Add(new LevelDetailsModel(18, 265000, 6, 8, 4));
            LevelDetailsList.Add(new LevelDetailsModel(19, 305000, 7, 9, 4));
            LevelDetailsList.Add(new LevelDetailsModel(20, 355000, 8, 10, 5));

            // Level 21, is for Monster Experience points...
            LevelDetailsList.Add(new LevelDetailsModel(21, 400000, 0, 0, 0));

            return LevelDetailsList.Count;
        }
    }
}