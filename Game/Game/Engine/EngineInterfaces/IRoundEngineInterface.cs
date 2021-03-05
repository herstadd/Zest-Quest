using System.Collections.Generic;

using Game.Models;

namespace Game.Engine.EngineInterfaces
{
    /// <summary>
    /// Round Engine Interface
    /// </summary>
    public interface IRoundEngineInterface
    {
        /// <summary>
        /// The turn variable
        /// </summary>
        ITurnEngineInterface Turn { get; set; }

        /// <summary>
        /// Clear the List between Rounds
        /// </summary>
        /// <returns></returns>
        bool ClearLists();

        /// <summary>
        /// Start a new round with new monsters
        /// </summary>
        /// <returns></returns>
        bool NewRound();

        /// <summary>
        /// Add the monsters to the round
        /// </summary>
        /// <returns></returns>
        int AddMonstersToRound();

        /// <summary>
        /// Clean up at the end of the round
        /// </summary>
        /// <returns></returns>
        bool EndRound();

        /// <summary>
        /// Items that were picked up by Characters
        /// </summary>
        bool PickupItemsForAllCharacters();

        /// <summary>
        /// Set the Current Attacker
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        bool SetCurrentAttacker(PlayerInfoModel player);

        /// <summary>
        /// Set the Current Attacker
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        bool SetCurrentDefender(PlayerInfoModel player);

        /// <summary>
        /// Manage next turn
        /// </summary>
        /// <returns></returns>
        RoundEnum RoundNextTurn();

        /// <summary>
        /// Get the Next Player to have a turn
        /// </summary>
        /// <returns></returns>
        PlayerInfoModel GetNextPlayerTurn();

        /// <summary>
        /// Remove deal player
        /// </summary>
        /// <returns></returns>
        List<PlayerInfoModel> RemoveDeadPlayersFromList();

        /// <summary>
        /// Order the player's turn
        /// </summary>
        /// <returns></returns>
        List<PlayerInfoModel> OrderPlayerListByTurnOrder();

        /// <summary>
        /// Which players are playing
        /// </summary>
        /// <returns></returns>
        List<PlayerInfoModel> MakePlayerList();

        /// <summary>
        /// Get the Information about the Player
        /// </summary>
        /// <returns></returns>
        PlayerInfoModel GetNextPlayerInList();

        /// <summary>
        /// Pickup Items Dropped
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        bool PickupItemsFromPool(PlayerInfoModel character);

        /// <summary>
        /// Only pick up item if is better
        /// </summary>
        /// <param name="character"></param>
        /// <param name="setLocation"></param>
        /// <returns></returns>
        bool GetItemFromPoolIfBetter(PlayerInfoModel character, ItemLocationEnum setLocation);

        /// <summary>
        /// Swap for a better item
        /// </summary>
        /// <param name="character"></param>
        /// <param name="setLocation"></param>
        /// <param name="PoolItem"></param>
        /// <returns></returns>
        ItemModel SwapCharacterItem(PlayerInfoModel character, ItemLocationEnum setLocation, ItemModel PoolItem);
        
        /// <summary>
        /// Remove Character Buffs
        /// </summary>
        /// <returns></returns>
        bool RemoveCharacterBuffs();

        /// <summary>
        /// Who is player this round?
        /// </summary>
        /// <returns></returns>
        List<PlayerInfoModel> PlayerList();
    }
}
