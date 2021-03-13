using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Helpers;
using Game.Models;
using Game.ViewModels;

namespace Game.Models
{
    /// <summary>
    /// Represent the Map
    /// 
    /// The Cordinates
    /// What is at that location
    /// 
    /// </summary>
    public class MapModel
    {
        // The X axies Size
        public int MapXAxiesCount = 6;

        // The Y axies Size
        public int MapYAxiesCount = 6;

        // The Map Locations
        public MapModelLocation[,] MapGridLocation;

        public PlayerInfoModel EmptySquare = new PlayerInfoModel { PlayerType = PlayerTypeEnum.Unknown, ImageURI= "emptyspace_new.png" };

        public MapModel()
        {
            // Create the Map
            MapGridLocation = new MapModelLocation[MapXAxiesCount, MapYAxiesCount];

            ClearMapGrid();
        }

        /// <summary>
        /// Create an Empty Map
        /// </summary>
        /// <returns></returns>
        public bool ClearMapGrid()
        {
            //Populate Map with Empty Values
            for (var x = 0; x < MapXAxiesCount; x++)
            {
                for (var y = 0; y < MapYAxiesCount; y++)
                {
                    // Populate the entire map with blank
                    MapGridLocation[x, y] = new MapModelLocation { Row = y, Column = x, Player = EmptySquare };
                }
            }
            return true;
        }

        /// <summary>
        /// Initialize the Data Structure
        /// Add Characters and Monsters to the Map
        /// </summary>
        /// <param name="PlayerList"></param>
        /// <returns></returns>
        public bool PopulateMapModel(List<PlayerInfoModel> PlayerList)
        {
            ClearMapGrid();

            int x = 0;
            int y = 0;
            foreach (var data in PlayerList.Where(m => m.PlayerType == PlayerTypeEnum.Character))
            {
                MapGridLocation[x, y].Player = data;

                // If too many to fit on a row, start at the next row
                x++;
                if (x >= MapXAxiesCount)
                {
                    x = 0;
                    y++;
                }
            }

            x = 0;
            y = MapYAxiesCount - 1;
            foreach (var data in PlayerList.Where(m => m.PlayerType == PlayerTypeEnum.Monster))
            {
                MapGridLocation[x, y].Player = data;

                // If too many to fit on a row, start at the next row
                x++;
                if (x >= MapXAxiesCount)
                {
                    x = 0;
                    y--;
                }
            }

            return true;
        }

        /// <summary>
        /// Add character to grid
        /// </summary>
        /// <param name="NewPlayer">new character to add to grid</param>
        /// <returns></returns>
        public bool AddNewCharacterToGrid(PlayerInfoModel NewPlayer)
        {            
            for(int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if (IsEmptySquare(x, y))
                    {
                        MapGridLocation[x, y].Player = NewPlayer;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Changes the Row and Column for the Player
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool MovePlayerOnMap(MapModelLocation data, MapModelLocation target)
        {
            if (target.Column < 0)
            {
                return false;
            }

            if (target.Row < 0)
            {
                return false;
            }

            if (target.Column >= MapXAxiesCount)
            {
                return false;
            }

            if (target.Row >= MapYAxiesCount)
            {
                return false;
            }

            if((data.Row == target.Row) && (data.Column == target.Column))
            {
                return false;
            }

            MapGridLocation[target.Column, target.Row].Player = data.Player;

            // Clear out the old location
            MapGridLocation[data.Column, data.Row].Player = EmptySquare;

            return true;
        }

        /// <summary>
        /// Remove the Player from the Map
        /// Replaces with Empty Square
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool RemovePlayerFromMap(PlayerInfoModel data)
        {
            if (data== null)
            {
                return false;
            }

            for (var x = 0; x < MapXAxiesCount; x++)
            {
                for (var y = 0; y < MapYAxiesCount; y++)
                {
                    if (MapGridLocation[x, y].Player.Guid.Equals(data.Guid))
                    {
                        MapGridLocation[x, y] = new MapModelLocation { Column = x, Row = y, Player = EmptySquare};
                        return true;
                    }
                }
            }

            // Not found
            return false;
        }

        /// <summary>
        /// Clear all Locations of the Selected Bool
        /// 
        /// Mike does not use this in the example battle grammar
        /// 
        /// TODO: INFO  Could be helpfull to track what is selected for actions etc
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ClearSelection()
        {
            foreach (var data in MapGridLocation)
            {
                data.IsSelectedTarget = false;
            }

            return true;
        }

        /// <summary>
        /// Find the Player on the map
        /// Return their information
        /// 
        /// If they don't exist, return null
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public MapModelLocation GetLocationForPlayer(PlayerInfoModel player)
        {
            if (player == null)
            {
                return null;
            }

            foreach (var data in MapGridLocation)
            {
                if (data.Player.Guid.Equals(player.Guid))
                {
                    return data;
                }
            }

            return null;
        }

        /// <summary>
        /// Return who is at the location
        /// Could be Character, Monster or Empty
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public PlayerInfoModel GetPlayerAtLocation(int x, int y)
        {
            return MapGridLocation[x, y].Player;
        }

        /// <summary>
        /// Is the location empty?
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool IsEmptySquare(int x, int y)
        {
            var player = MapGridLocation[x, y].Player;

            // Unknown is Empty
            if (player.PlayerType == PlayerTypeEnum.Unknown)
            {
                return true;
            }

            // Occupied
            return false;
        }

        /// <summary>
        /// Return all Empty Locations on the map
        /// </summary>
        /// <returns></returns>
        public List<MapModelLocation> GetEmptyLocations()
        {
            var Result = new List<MapModelLocation>();

            foreach (var data in MapGridLocation)
            {
                if (data.Player.PlayerType == PlayerTypeEnum.Unknown)
                {
                    Result.Add(data);
                }
            }

            return Result;
        }

        /// <summary>
        /// Walk the Map and Find the Location that is close to the target
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        public MapModelLocation ReturnClosestEmptyLocation(MapModelLocation Target)
        {
            MapModelLocation Result = null;

            int LowestDistance = int.MaxValue;

            foreach (var data in GetEmptyLocations())
            {
                var distance = CalculateDistance(data, Target);
                if (distance < LowestDistance)
                {
                    Result = data;
                    LowestDistance = distance;
                }
            }

            return Result;
        }

        /// <summary>
        /// Return the next adjacent empty location that is closest to the target
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        public MapModelLocation ReturnNextEmptyLocation(MapModelLocation Target, MapModelLocation OriginalLocation, CharacterJobEnum Job)
        {
            MapModelLocation Result = OriginalLocation;


            int LowestDistance = int.MaxValue;

            // Find next empty location for Sous Chef
            if(Job == CharacterJobEnum.SousChef)
            {
                Result = GetEmptyLocationsSousChef(Target, OriginalLocation);
                LowestDistance = CalculateDistance(Result, Target);
            }
            // Find next empty location for other player
            else
            {
                var ChanceToSlip = (DiceHelper.RollDice(1, 100) + 1);
                foreach (var data in GetEmptyLocations())
                {
                    var distance = CalculateDistance(data, Target);

                    //Normal mode, move character to close-by location                    
                    if ((distance < LowestDistance) && (CalculateDistance(OriginalLocation, data) < 2))
                    {
                        Result = data;
                        LowestDistance = distance;
                        BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.SeattleSlip = " moves closer to ";
                    }

                    //SeattleWinter, move character to far away location
                    if ((BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.EnableSeattleWinter)
                        && (Convert.ToInt32(BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.SeattleWinterSlippingPercent)
                                >= ChanceToSlip))
                    {
                        var NewPositionInLocation = DiceHelper.RollDice(1, GetEmptyLocations().Count() - 1);
                        var data2 = GetEmptyLocations().ElementAt(NewPositionInLocation);
                        Result = data2;
                        LowestDistance = distance;
                        BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.SeattleSlip = " slips and randomly towards ";
                        return Result;
                        
                    }
                }
            }
            
            return Result;
        }

        /// <summary>
        /// Get the next empty location for Sous Chef
        /// </summary>
        /// <param name="Target"></param>
        /// <param name="OriginalLocation"></param>
        /// <returns></returns>
        public MapModelLocation GetEmptyLocationsSousChef(MapModelLocation Target, MapModelLocation OriginalLocation) {
            MapModelLocation Result = OriginalLocation;
            var LowestDistance = CalculateDistance(Result, Target);
            int x = 0;
            int y = 0;

            // Check if next row is out of range
            if (OriginalLocation.Row + 1 == MapXAxiesCount)
            {
                y = 0;
                x = OriginalLocation.Column;
                var IsPossible = GetShortestLocation(x, y, Target, LowestDistance);
                if(IsPossible != null)
                {
                    Result = IsPossible;
                    LowestDistance = CalculateDistance(Result, Target);
                }
            } 
            else 
            {
                y = OriginalLocation.Row + 1;
                x = OriginalLocation.Column;
                var IsPossible = GetShortestLocation(x, y, Target, LowestDistance);
                if (IsPossible != null)
                {
                    Result = IsPossible;
                    LowestDistance = CalculateDistance(Result, Target);
                }
            }

            // Check if previous row is out of range
            if (OriginalLocation.Row - 1 < 0)
            {
                y = MapXAxiesCount - 1;
                x = OriginalLocation.Column;
                var IsPossible = GetShortestLocation(x, y, Target, LowestDistance);
                if (IsPossible != null)
                {
                    Result = IsPossible;
                    LowestDistance = CalculateDistance(Result, Target);
                }
            } 
            else
            {
                y = OriginalLocation.Row - 1;
                x = OriginalLocation.Column;
                var IsPossible = GetShortestLocation(x, y, Target, LowestDistance);
                if (IsPossible != null)
                {
                    Result = IsPossible;
                    LowestDistance = CalculateDistance(Result, Target);
                }
            }

            // Check if next column is out of range
            if (OriginalLocation.Column + 1 == MapYAxiesCount)
            {
                y = OriginalLocation.Row;
                x = 0;
                var IsPossible = GetShortestLocation(x, y, Target, LowestDistance);
                if (IsPossible != null)
                {
                    Result = IsPossible;
                    LowestDistance = CalculateDistance(Result, Target);
                }
            }
            else
            {
                y = OriginalLocation.Row;
                x = OriginalLocation.Column + 1;
                var IsPossible = GetShortestLocation(x, y, Target, LowestDistance);
                if (IsPossible != null)
                {
                    Result = IsPossible;
                    LowestDistance = CalculateDistance(Result, Target);
                }
            }

            // Check if previous column is out of range
            if (OriginalLocation.Column - 1 < 0)
            {
                y = OriginalLocation.Row;
                x = MapYAxiesCount - 1;
                var IsPossible = GetShortestLocation(x, y, Target, LowestDistance);
                if (IsPossible != null)
                {
                    Result = IsPossible;
                    LowestDistance = CalculateDistance(Result, Target);
                }
            }
            else
            {
                y = OriginalLocation.Row;
                x = OriginalLocation.Column - 1;
                var IsPossible = GetShortestLocation(x, y, Target, LowestDistance);
                if (IsPossible != null)
                {
                    Result = IsPossible;
                    LowestDistance = CalculateDistance(Result, Target);
                }
            }

            return Result;
        }

        /// <summary>
        /// Find the shortest location from the Sous Chef's surrounding
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Target"></param>
        /// <param name="LowestDistance"></param>
        /// <returns></returns>
        public MapModelLocation GetShortestLocation(int x, int y, MapModelLocation Target, int LowestDistance)
        {
            if (MapGridLocation[x, y].Player.PlayerType == PlayerTypeEnum.Unknown)
            {
                var temp = CalculateDistance(MapGridLocation[x, y], Target);
                if (temp < LowestDistance)
                {
                    return MapGridLocation[x, y];
                }
            }
            return null;
        }

        /// <summary>
        /// See if the Attacker is next to the Defender by the distance of Range
        /// 
        /// If either the X or Y distance is less than or equal the range, then they can hit
        /// </summary>
        /// <param name="Attacker"></param>
        /// <param name="Defender"></param>
        /// <returns></returns>
        public bool IsTargetInRange(PlayerInfoModel Attacker, PlayerInfoModel Defender)
        {
            var locationAttacker = GetLocationForPlayer(Attacker);
            var locationDefender = GetLocationForPlayer(Defender);

            if (locationAttacker == null)
            {
                return false;
            }

            if (locationDefender == null)
            {
                return false;
            }

            // Get X distance in absolute value
            var distance = Math.Abs(CalculateDistance(locationAttacker, locationDefender));

            var AttackerRange = Attacker.GetRange();

            // Can Reach on X?
            if (distance <= AttackerRange)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calculate distance between two map locations
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int CalculateDistance(MapModelLocation start, MapModelLocation end)
        {
            if (start == null)
            {
                return int.MaxValue;
            }

            if (end == null)
            {
                return int.MaxValue;
            }

            return Distance(start.Column, start.Row, end.Column, end.Row);
        }

        /// <summary>
        /// Calculate Distance between locations
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public int Distance(int x1, int y1, int x2, int y2)
        {
            return ((int)Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)));
        }
    }
}