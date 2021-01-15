using System.Collections.Generic;
using Game.Models;

namespace Game.Engine.EngineInterfaces
{
    /// <summary>
    /// Holds the Data Structures for the Battle Engine
    /// </summary>
    public interface IBaseEngineModelInterface
    {
        List<PlayerInfoModel> PlayerList { get; set; }

        int MaxNumberPartyCharacters { get; set; }

        int MaxNumberPartyMonsters { get; set; }

        MapModel MapModel { get; set; }

        PlayerInfoModel CurrentAttacker { get; set; }

        PlayerInfoModel CurrentDefender { get; set; }

        BattleStateEnum BattleStateEnum { get; set; }

        BattleSettingsModel BattleSettingsModel { get; set; }


        ScoreModel BattleScore { get; set; }

        BattleMessagesModel BattleMessagesModel { get; set; }

        List<ItemModel> ItemPool { get; set; }

        List<PlayerInfoModel> MonsterList { get; set; }

        List<PlayerInfoModel> CharacterList { get; set; }


        ActionEnum CurrentAction { get; set; }

        ActionEnum PreviousAction { get; set; }

        AbilityEnum CurrentActionAbility { get; set; }

        CordinatesModel CurrentMapLocation { get; set; }

        CordinatesModel MoveMapLocation { get; set; }

        RoundEnum RoundStateEnum { get; set; }


        int MaxRoundCount { get; set; }

        int MaxTurnCount { get; set; }

 

        
    }
}