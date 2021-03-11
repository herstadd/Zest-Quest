using System;
using System.Collections.Generic;
using System.Linq;
using Game.Engine.EngineBase;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.GameRules;
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
        }

        /// <summary>
        /// Call to make a new set of monsters..
        /// </summary>
        public override bool NewRound()
        {
            return base.NewRound();
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
        /// Add 6 Unique random Monsters to each Round from Restautant
        /// <returns></returns>
        public override int AddMonstersToRound()
        {
          
            int TargetLevel = 1;

            if (EngineSettings.CharacterList.Count() > 0)
            {
                // Instead of Min, get the Max Character Level when adding monsters (linq is soo cool....)
                TargetLevel = Convert.ToInt32(EngineSettings.CharacterList.Min(m => m.Level));
            }

            for (var i = 0; i < EngineSettings.MaxNumberPartyMonsters; i++)
            {
                bool existed = false;
                var data = RandomPlayerHelper.GetRandomMonster(TargetLevel, EngineSettings.BattleSettingsModel.AllowMonsterItems);
               
                foreach (var monster in EngineSettings.MonsterList)
                {
                    // Not adding same monster type using their unique descriptions
                    if (data.Description == monster.Description)
                    {
                        existed = true;
                        break;
                    }
                }
                // IF monster type is not in the least add it to the board
                if (existed == false)
                {
                    EngineSettings.MonsterList.Add(new PlayerInfoModel(data));
                }
                else
                {
                    i--;
                }
            }

            return EngineSettings.MonsterList.Count();
        }

        /// <summary>
        /// At the end of the round
        /// Clear the ItemModel List
        /// Clear the MonsterModel List
        /// </summary>
        public override bool EndRound()
        {
            foreach (var data in EngineSettings.PlayerList.ToList())
            {
                if (data.Job == CharacterJobEnum.Pet)
                {
                    EngineSettings.PlayerList.Remove(data);
                }
            }

            foreach (var data in EngineSettings.CharacterList.ToList())
            {
                data.HadPet = false;
            }

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
        public override bool PickupItemsForAllCharacters()
        {
            // Will automatically assign items
            if (EngineSettings.BattleScore.AutoBattle)
            {
                return base.PickupItemsForAllCharacters();
            }
            
            // TODO: Determine what happens if not in autobattle mode
            return true;
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
        }

        /// <summary>
        /// Get the Next Player to have a turn
        /// </summary>
        public override PlayerInfoModel GetNextPlayerTurn()
        {
            return base.GetNextPlayerInList();
        }

        /// <summary>
        /// Remove Dead Players from the List
        /// </summary>
        public override List<PlayerInfoModel> RemoveDeadPlayersFromList()
        {
            return base.RemoveDeadPlayersFromList();
        }

        /// <summary>
        /// Order the Players in Turn Sequence
        /// </summary>
        public override List<PlayerInfoModel> OrderPlayerListByTurnOrder()
        {
            return base.OrderPlayerListByTurnOrder();
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
                        
                        //Health increases By 10% of the current max health up to current max health
                        var RecoverHealth = data.CurrentHealth + (10 * data.MaxHealth) / 100;
                        if (RecoverHealth < data.MaxHealth)
                        {
                            data.CurrentHealth = RecoverHealth;
                        }
                        else
                        {
                            data.CurrentHealth = data.MaxHealth;
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
                        if (data.Job == CharacterJobEnum.SushiChef)
                        {
                            data.Range = 20;
                        }
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
        }

        /// <summary>
        /// Pickup Items Dropped
        /// </summary>
        public override bool PickupItemsFromPool(PlayerInfoModel character)
        {
            if (EngineSettings.BattleScore.AutoBattle)
            {
                // Have the character, walk the items in the pool, and decide if any are better than current one.

                GetItemFromPoolIfBetter(character, ItemLocationEnum.Head);
                GetItemFromPoolIfBetter(character, ItemLocationEnum.Necklass);
                GetItemFromPoolIfBetter(character, ItemLocationEnum.PrimaryHand);
                GetItemFromPoolIfBetter(character, ItemLocationEnum.OffHand);
                GetItemFromPoolIfBetter(character, ItemLocationEnum.RightFinger);
                GetItemFromPoolIfBetter(character, ItemLocationEnum.LeftFinger);
                GetItemFromPoolIfBetter(character, ItemLocationEnum.Feet);
            } 

            // TODO: Figure out how to manually apply items when not in autobattle
            return true;
        }

        /// <summary>
        /// Swap out the item if it is better
        /// 
        /// Uses Value to determine
        /// </summary>
        public override bool GetItemFromPoolIfBetter(PlayerInfoModel character, ItemLocationEnum setLocation)
        {
            return base.GetItemFromPoolIfBetter(character, setLocation);
        }

        /// <summary>
        /// Swap the Item the character has for one from the pool
        /// 
        /// Drop the current item back into the Pool
        /// </summary>
        public override ItemModel SwapCharacterItem(PlayerInfoModel character, ItemLocationEnum setLocation, ItemModel PoolItem)
        {
            return base.SwapCharacterItem(character, setLocation, PoolItem);
        }

        /// <summary>
        /// For all characters in player list, remove their buffs
        /// </summary>
        public override bool RemoveCharacterBuffs()
        {
            return base.RemoveCharacterBuffs();
        }
    }
}