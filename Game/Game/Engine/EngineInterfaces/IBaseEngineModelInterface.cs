using System.Collections.Generic;
using Game.Models;

namespace Game.Engine.EngineInterfaces
{
    /// <summary>
    /// Holds the Data Structures for the Battle Engine
    /// </summary>
    public interface IBaseEngineModelInterface
    {
        // Store players
        List<PlayerInfoModel> PlayerList { get; set; }

        // Store maximum number of characters
        int MaxNumberPartyCharacters { get; set; }

        // Store maximum number of monsters
        int MaxNumberPartyMonsters { get; set; }

        // Stores the map
        MapModel MapModel { get; set; }

        // Store attacker for turn
        PlayerInfoModel CurrentAttacker { get; set; }

        // Store defender for turn
        PlayerInfoModel CurrentDefender { get; set; }

        // Store Battle state
        BattleStateEnum BattleStateEnum { get; set; }

        // Store Battle setting
        BattleSettingsModel BattleSettingsModel { get; set; }

        // Store Battle score
        ScoreModel BattleScore { get; set; }

        // Store the Battle message 
        BattleMessagesModel BattleMessagesModel { get; set; }

        // Items dropped
        List<ItemModel> ItemPool { get; set; }

        // Monsters in the battle
        List<PlayerInfoModel> MonsterList { get; set; }

        // Selected Characters in the battle
        List<PlayerInfoModel> CharacterList { get; set; }

        // What is the current action
        ActionEnum CurrentAction { get; set; }

        // What was the previous action
        ActionEnum PreviousAction { get; set; }

        // What is the current ability being used
        AbilityEnum CurrentActionAbility { get; set; }

        // Current location on the map
        CordinatesModel CurrentMapLocation { get; set; }

        // Location to move to on the map
        CordinatesModel MoveMapLocation { get; set; }

        // Stores the round state enum
        RoundEnum RoundStateEnum { get; set; }

        // Stores maximum number of rounds
        int MaxRoundCount { get; set; }

        // Stores maximum number of turns
        int MaxTurnCount { get; set; }        
    }
}