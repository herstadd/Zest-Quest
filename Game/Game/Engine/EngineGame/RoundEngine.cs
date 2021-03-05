using System.Collections.Generic;
using Game.Engine.EngineBase;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Models;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// Manages the Rounds
    /// </summary>
    public class RoundEngine : RoundEngineBase, IRoundEngineInterface
    {
        // Hold the BaseEngine
        public new EngineSettingsModel EngineSettings = EngineSettingsModel.Instance;

        // The Turn Engine
        //public new ITurnEngineInterface Turn
        //{
        //    get
        //    {
        //        if (base.Turn == null)
        //        {
        //            base.Turn = new TurnEngine();
        //        }
        //        return base.Turn;
        //    }
        //    set { base.Turn = Turn; }
        //}

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <returns></returns>
        public RoundEngine()
        {
            Turn = new TurnEngine();
        }

        /// <summary>
        /// Clear the List between Rounds
        /// </summary>
        public override bool ClearLists()
        {
            return base.ClearLists();

            EngineSettings.ItemPool.Clear();
            EngineSettings.MonsterList.Clear();
            return true;
        }

        /// <summary>
        /// Call to make a new set of monsters..
        /// </summary>
        public override bool NewRound()
        {
            return base.NewRound();
            
            // End the existing round
            EndRound();

            // Remove Character Buffs
            RemoveCharacterBuffs();

            // Populate New Monsters..
            AddMonstersToRound();

            // Make the BaseEngine.PlayerList
            MakePlayerList();

            // Set Order for the Round
            OrderPlayerListByTurnOrder();

            // Populate BaseEngine.MapModel with Characters and Monsters
            EngineSettings.MapModel.PopulateMapModel(EngineSettings.PlayerList);

            // Update Score for the RoundCount
            EngineSettings.BattleScore.RoundCount++;

            return true;
        }

        /// <summary>
        /// Add Monsters to the Round
        /// 
        /// Because Monsters can be duplicated, will add 1, 2, 3 to their name
        ///   
        /*
            * Hint: 
            * I don't have crudi monsters yet so will add 6 new ones..
            * If you have crudi monsters, then pick from the list

            * Consdier how you will scale the monsters up to be appropriate for the characters to fight
            * 
            */
        /// </summary>
        /// <returns></returns>
        public override int AddMonstersToRound()
        {
            // TODO: Teams, You need to implement your own Logic can not use mine.

            return base.AddMonstersToRound();
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// At the end of the round
        /// Clear the ItemModel List
        /// Clear the MonsterModel List
        /// </summary>
        public override bool EndRound()
        {
            return base.EndRound();
            // In Auto Battle this happens and the characters get their items, In manual mode need to do it manualy
            if (EngineSettings.BattleScore.AutoBattle)
            {
                PickupItemsForAllCharacters();
            }

            // Reset Monster and Item Lists
            ClearLists();

            return true;
        }

        /// <summary>
        /// For each character pickup the items
        /// </summary>
        public override void PickupItemsForAllCharacters()
        {
            base.PickupItemsForAllCharacters();
            return;
            // In Auto Battle this happens and the characters get their items
            // When called manualy, make sure to do the character pickup before calling EndRound

            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// Manage Next Turn
        /// 
        /// Decides Who's Turn
        /// Remembers Current Player
        /// 
        /// Starts the Turn
        /// 
        /// </summary>
        public override RoundEnum RoundNextTurn()
        {
            return base.RoundNextTurn();
            // No characters, game is over..

            // Check if round is over

            // If in Auto Battle pick the next attacker

            // Do the turn..

            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get the Next Player to have a turn
        /// </summary>
        public override PlayerInfoModel GetNextPlayerTurn()
        {
            return base.GetNextPlayerInList();
            // Remove the Dead

            // Get Next Player

            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// Remove Dead Players from the List
        /// </summary>
        public override List<PlayerInfoModel> RemoveDeadPlayersFromList()
        {
            return base.RemoveDeadPlayersFromList();
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// Order the Players in Turn Sequence
        /// </summary>
        public override List<PlayerInfoModel> OrderPlayerListByTurnOrder()
        {
            return base.OrderPlayerListByTurnOrder();
            // TODO Teams: Implement the order

            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// Who is Playing this round?
        /// </summary>
        public override List<PlayerInfoModel> MakePlayerList()
        {
            // return base.MakePlayerList();

            // HomeCooks after winning each round their current health will be recovered           
            foreach (var data in EngineSettings.PlayerList)
            {
                if (data.Alive)
                {                 
                    if (data.Job == CharacterJobEnum.HomeCook)
                    {
                        // hold HomeCook original health
                        var HomeCookOrignalHealth = 0;

                        // Find HomeCook original health
                        foreach (var chef in EngineSettings.CharacterList)
                        {
                            if (chef.Job == CharacterJobEnum.HomeCook)
                            {
                                HomeCookOrignalHealth = chef.MaxHealth;
                                break;
                            }
                        }

                        //Health increases By 10% of the original health up to current max health
                        var RecoverHealth = data.CurrentHealth + (10 * HomeCookOrignalHealth) / 100;
                        if(RecoverHealth < data.MaxHealth)
                        {
                            data.CurrentHealth = RecoverHealth;
                        }
                    }
                }
            }

            // Remember the Insert order, used for Sorting
            var ListOrder = EngineSettings.PlayerList.Count;

            // Adding Characters at the first round
            if (EngineSettings.BattleScore.TurnCount == 0)
            {

                // Start from a clean list of players
                EngineSettings.PlayerList.Clear();
               
                foreach (var data in EngineSettings.CharacterList)
                {
                    if (data.Alive)
                    {
                        EngineSettings.PlayerList.Add(
                            new PlayerInfoModel(data)
                            {
                            // Remember the order
                            ListOrder = ListOrder
                            });

                        ListOrder++;
                    }
                }
            }

            // Adding new Random Monsters at each round
            foreach (var data in EngineSettings.MonsterList)
            {
                if (data.Alive)
                {
                    EngineSettings.PlayerList.Add(
                        new PlayerInfoModel(data)
                        {
                            // Remember the order
                            ListOrder = ListOrder
                        });

                    ListOrder++;
                }
            }

            return EngineSettings.PlayerList;       
        }

        /// <summary>
        /// Get the Information about the Player
        /// </summary>
        public override PlayerInfoModel GetNextPlayerInList()
        {
            return base.GetNextPlayerInList();
            // Walk the list from top to bottom
            // If Player is found, then see if next player exist, if so return that.
            // If not, return first player (looped)

            // If List is empty, return null

            // No current player, so set the first one

            // Find current player in the list

            // If at the end of the list, return the first element

            // Return the next element

            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// Pickup Items Dropped
        /// </summary>
        public override bool PickupItemsFromPool(PlayerInfoModel character)
        {
            return base.PickupItemsFromPool(character);
            // TODO: Teams, You need to implement your own Logic if not using auto apply

            // I use the same logic for Auto Battle as I do for Manual Battle

            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// Swap out the item if it is better
        /// 
        /// Uses Value to determine
        /// </summary>
        public override bool GetItemFromPoolIfBetter(PlayerInfoModel character, ItemLocationEnum setLocation)
        {
            return base.GetItemFromPoolIfBetter(character, setLocation);
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// Swap the Item the character has for one from the pool
        /// 
        /// Drop the current item back into the Pool
        /// </summary>
        public override ItemModel SwapCharacterItem(PlayerInfoModel character, ItemLocationEnum setLocation, ItemModel PoolItem)
        {
            return base.SwapCharacterItem(character, setLocation, PoolItem);
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// For all characters in player list, remove their buffs
        /// </summary>
        public override bool RemoveCharacterBuffs()
        {
            return base.RemoveCharacterBuffs();
            //throw new System.NotImplementedException();
        }
    }
}