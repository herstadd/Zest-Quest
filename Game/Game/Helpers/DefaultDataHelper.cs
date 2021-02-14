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
        static List<CharacterModel> CharacterList = null;
        static List<MonsterModel> MonsterList = null;
        static List<ItemModel> ItemList = null;
        static List<ScoreModel> ScoreList = null;

        /// <summary>
        /// Constructor
        /// </summary>
        static DefaultDataHelper()
        {
            if(CharacterList == null || MonsterList == null ||
                ItemList == null || ScoreList == null)
            {
                CharacterList = DefaultData.LoadData(new CharacterModel());
                MonsterList = DefaultData.LoadData(new MonsterModel());
                ItemList = DefaultData.LoadData(new ItemModel());
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

        /// <summary>
        /// Gets the item from default data matching the passed in target enum
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        public static ItemModel GetItem(ItemModelEnum Target)
        {
            foreach (ItemModel item in ItemList)
            {
                if (item.Type == Target)
                {
                    return item;
                }
            }
            return null;
        }
    }
}