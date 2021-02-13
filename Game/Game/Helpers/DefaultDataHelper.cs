using Game.Models;
using Game.GameRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Helpers
{
    public static class DefaultDataHelper
    {
        static List<CharacterModel> CharacterList = null;
        static List<MonsterModel> MonsterList = null;
        static List<ItemModel> ItemList = null;
        static List<ScoreModel> ScoreList = null;

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