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
        // List of Default Characters
        public static List<CharacterModel> CharacterList = null;

        // List of Default Monsters
        public static List<MonsterModel> MonsterList = null;

        /// <summary>
        /// DefaultDataHelper Constructor and load data
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