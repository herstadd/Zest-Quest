using Game.Models;
using Game.GameRules;
using System.Collections.Generic;

namespace Game.Helpers
{
    /// <summary>
    /// Helper class to get the list of data from default data for all types available
    /// </summary>
    public static class DefaultDataHelper
    {
        public static List<CharacterModel> CharacterList = null;
        public static List<MonsterModel> MonsterList = null;
        public static List<ItemModel> ItemList = null;
        public static List<ScoreModel> ScoreList = null;

        /// <summary>
        /// Constructor
        /// </summary>
        static DefaultDataHelper()
        {
            if(CharacterList == null )
            {
                CharacterList = DefaultData.LoadData(new CharacterModel());               
            }

            if (MonsterList == null)
            {
                MonsterList = DefaultData.LoadData(new MonsterModel());           
            }

            if (ItemList == null)
            {          
                ItemList = DefaultData.LoadData(new ItemModel());
            }

            if (ScoreList == null)
            {              
                ScoreList = DefaultData.LoadData(new ScoreModel());
            }

        }

        /// <summary>
        /// Gets the character from default data matching the passed in target enum 
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        public static CharacterModel GetCharacter(CharacterJobEnum Target)
        {

            foreach (CharacterModel character in CharacterList)
            {
                if (character.Job == Target)
                {
                    return character;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the monster from default data matching the passed in target enum
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        public static MonsterModel GetMonster(MonsterTypeEnum Target)
        {
            foreach (MonsterModel monster in MonsterList)
            {
                if (monster.MonsterType == Target)
                {
                    return monster;
                }
            }
            return null;
        }
    }
}