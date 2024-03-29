﻿using NUnit.Framework;

using Game.Models;
using System.Collections.Generic;
using System.Linq;
using Game.ViewModels;
using Game.Helpers;

namespace UnitTests.Models
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
    [TestFixture]
    public class MapModelTests
    {
        [Test]
        public void MapModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new MapModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void MapModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new MapModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result.EmptySquare);
            Assert.IsNotNull(result.MapGridLocation);
        }

        [Test]
        public void MapModel_Set_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new MapModel();
            result.EmptySquare = new PlayerInfoModel { PlayerType = PlayerTypeEnum.Unknown };
            result.MapXAxiesCount = 1;
            result.MapYAxiesCount = 1;
            result.MapGridLocation = new MapModelLocation[result.MapXAxiesCount, result.MapYAxiesCount];

            // Reset

            // Assert 
            Assert.IsNotNull(result.EmptySquare);
            Assert.IsNotNull(result.MapGridLocation);
        }

        [Test]
        public void MapModel_ClearSelection_Should_Pass()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 1;
            map.MapYAxiesCount = 1;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];


            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.ClearSelection();

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MapModel_ClearMapGrid_Should_Pass()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 1;
            map.MapYAxiesCount = 1;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];


            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.ClearMapGrid();

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MapModel_MovePlayerOnMap_ToX_Neg_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            var MapLocationData = map.MapGridLocation[0, 0];

            // Act
            var result = map.MovePlayerOnMap(MapLocationData,new MapModelLocation { Column = -1, Row = 0 });

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_MovePlayerOnMap_ToY_Neg_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            var MapLocationData = map.MapGridLocation[0, 0];

            // Act
            var result = map.MovePlayerOnMap(MapLocationData, new MapModelLocation { Column = 0, Row = -1 });

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_MovePlayerOnMap_ToX_Over_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            var MapLocationData = map.MapGridLocation[0, 0];

            // Act
            var result = map.MovePlayerOnMap(MapLocationData, new MapModelLocation { Column = 100, Row = 0 });

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_MovePlayerOnMap_ToY_Over_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            var MapLocationData = map.MapGridLocation[0, 0];

            // Act
            var result = map.MovePlayerOnMap(MapLocationData, new MapModelLocation { Column = 0, Row = 100 });

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_MovePlayerOnMap_Move_Over_SamePlace_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            var MapLocationData = map.MapGridLocation[0, 0];

            // Act
            var result = map.MovePlayerOnMap(MapLocationData, new MapModelLocation { Column = 0, Row = 0 });

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_MovePlayerOnMap_Valid_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var Monster = new MonsterModel();

            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            var MapLocationData = map.MapGridLocation[0, 0];

            // Act
            var result = map.MovePlayerOnMap(MapLocationData, new MapModelLocation { Column = 1, Row = 1 });

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MapModel_GetEmptyLocations_InValid_Should_Return_Empty()
        {
            // Arrange

            var map = new MapModel();

            map.MapGridLocation = new MapModelLocation[0,0];

            // Act
            var result = map.GetEmptyLocations();

            // Reset

            // Assert 
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void MapModel_GetEmptyLocations_Full_Should_Return_Empty()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 2;
            map.MapYAxiesCount = 2;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.GetEmptyLocations();

            // Reset

            // Assert 
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void MapModel_GetEmptyLocations_Valid_Should_Return_Empty_Cells()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.GetEmptyLocations();

            // Reset

            // Assert 
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void MapModel_IsEmptySquare_Valid_Character_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.IsEmptySquare(0,0);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_IsEmptySquare_Valid_Monster_Should_Fail()
        {
            // Arrange

            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.IsEmptySquare(0, 2);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_IsEmptySquare_Valid_Empty_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.IsEmptySquare(0,1);

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MapModel_Distance_Valid_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            // Act
            var result = map.Distance(0, 1, 1,1);

            // Reset

            // Assert 
            Assert.AreEqual(1, result);
        }

        [Test]
        public void MapModel_CalculateDistance_InValid_Start_Null_Should_Fail()
        {
            // Arrange
            var map = new MapModel();

            // Act
            var result = map.CalculateDistance(null, new MapModelLocation());

            // Reset

            // Assert 
            Assert.AreEqual(int.MaxValue, result);
        }

        [Test]
        public void MapModel_CalculateDistance_InValid_End_Null_Should_Fail()
        {
            // Arrange
            var map = new MapModel();

            // Act
            var result = map.CalculateDistance(new MapModelLocation(), null);

            // Reset

            // Assert 
            Assert.AreEqual(int.MaxValue, result);
        }

        [Test]
        public void MapModel_CalculateDistance_Valid_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);
            var start = map.GetPlayerAtLocation(0, 0);
            var end = map.GetPlayerAtLocation(2, 2);

            // Act
            var result = map.CalculateDistance(map.GetLocationForPlayer(start), map.GetLocationForPlayer(end));

            // Reset

            // Assert 
            Assert.AreEqual(2, result);
        }

        [Test]
        public void MapModel_IsTargetInRange_Out_Should_Return_False()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);
            var start = map.GetPlayerAtLocation(0, 0);
            var end = map.GetPlayerAtLocation(2, 2);

            // Act
            var result = map.IsTargetInRange(start, end);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_IsTargetInRange_In_Should_Return_True()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);
            var start = map.GetPlayerAtLocation(0, 0);
            var end = map.GetPlayerAtLocation(1, 0); // Person next to them....

            // Act
            var result = map.IsTargetInRange(start, end);

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MapModel_IsTargetInRange_InValid_Attacker_Should_Fail()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);
            var start = map.GetPlayerAtLocation(0, 0);
            var end = map.GetPlayerAtLocation(1, 0); // Person next to them....

            var CharacterBogus = new CharacterModel();

            // Act
            var result = map.IsTargetInRange(new PlayerInfoModel(CharacterBogus), end);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_IsTargetInRange_InValid_Defender_Should_Fail()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);
            var start = map.GetPlayerAtLocation(0, 0);
            var end = map.GetPlayerAtLocation(1, 0); // Person next to them....

            var CharacterBogus = new CharacterModel();

            // Act
            var result = map.IsTargetInRange(start, new PlayerInfoModel(CharacterBogus));

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_ReturnClosestEmptyLocation_Valid_Target_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 3;
            map.MapYAxiesCount = 3;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.ReturnClosestEmptyLocation(map.MapGridLocation[0,0]);

            // Reset

            // Assert 
            Assert.AreEqual(0, result.Column);
            Assert.AreEqual(1, result.Row);
        }

        [Test]
        public void MapModel_ReturnClosestEmptyLocation_InValid_Should_Return_Null()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 2;
            map.MapYAxiesCount = 2;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.ReturnClosestEmptyLocation(map.MapGridLocation[0, 0]);

            // Reset

            // Assert 
            Assert.AreEqual(null, result);
        }

        [Test]
        public void MapModel_GetLocationForPlayer_InValid_Should_Return_Null()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 2;
            map.MapYAxiesCount = 2;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            PlayerList.Add(new PlayerInfoModel(Character));
            PlayerList.Add(new PlayerInfoModel(Character));

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.GetLocationForPlayer(null);

            // Reset

            // Assert 
            Assert.AreEqual(null, result);
        }

        [Test]
        public void MapModel_GetLocationForPlayer_Valid_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 2;
            map.MapYAxiesCount = 2;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.GetLocationForPlayer(CharacterPlayer);

            // Reset

            // Assert 
            Assert.AreEqual(0, result.Column);
            Assert.AreEqual(0, result.Row);
        }

        [Test]
        public void MapModel_GetEmptyLocationsSousChef_Pass_Right_Wall_Valid_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 6;
            map.MapYAxiesCount = 6;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(MonsterPlayer);

            map.PopulateMapModel(PlayerList);
            MapModelLocation playerNext = new MapModelLocation();
            playerNext.Row = 4;
            playerNext.Column = 5;

            MapModelLocation monsterNext = new MapModelLocation();
            monsterNext.Row = 1;
            monsterNext.Column = 1;

            var currPlayer = map.GetLocationForPlayer(CharacterPlayer);
            var currMonster = map.GetLocationForPlayer(MonsterPlayer);

            map.MovePlayerOnMap(currPlayer, playerNext);
            map.MovePlayerOnMap(currMonster, monsterNext);
            
            // Act
            var result = map.GetEmptyLocationsSousChef(monsterNext, playerNext);

            // Reset

            // Assert 
            Assert.AreEqual(4, result.Row);
            Assert.AreEqual(0, result.Column);
        }

        [Test]
        public void MapModel_GetEmptyLocationsSousChef_Move_Down_Valid_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 6;
            map.MapYAxiesCount = 6;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            PlayerList.Add(MonsterPlayer);

            map.PopulateMapModel(PlayerList);
            MapModelLocation playerNext = new MapModelLocation();
            playerNext.Row = 1;
            playerNext.Column = 1;

            MapModelLocation monsterNext = new MapModelLocation();
            monsterNext.Row = 4;
            monsterNext.Column = 4;

            var currPlayer = map.GetLocationForPlayer(CharacterPlayer);
            var currMonster = map.GetLocationForPlayer(MonsterPlayer);

            map.MovePlayerOnMap(currPlayer, playerNext);
            map.MovePlayerOnMap(currMonster, monsterNext);

            // Act
            var result = map.GetEmptyLocationsSousChef(monsterNext, playerNext);

            // Reset

            // Assert 
            Assert.AreEqual(2, result.Row);
            Assert.AreEqual(1, result.Column);
        }

        [Test]
        public void MapModel_GetEmptyLocationsSousChef_Pass_Left_Wall_Valid_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 6;
            map.MapYAxiesCount = 6;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            PlayerList.Add(MonsterPlayer);

            map.PopulateMapModel(PlayerList);
            MapModelLocation playerNext = new MapModelLocation();
            playerNext.Row = 0;
            playerNext.Column = 0;

            MapModelLocation monsterNext = new MapModelLocation();
            monsterNext.Row = 0;
            monsterNext.Column = 4;

            var currPlayer = map.GetLocationForPlayer(CharacterPlayer);
            var currMonster = map.GetLocationForPlayer(MonsterPlayer);

            map.MovePlayerOnMap(currPlayer, playerNext);
            map.MovePlayerOnMap(currMonster, monsterNext);

            // Act
            var result = map.GetEmptyLocationsSousChef(monsterNext, playerNext);

            // Reset

            // Assert 
            Assert.AreEqual(0, result.Row);
            Assert.AreEqual(5, result.Column);
        }

        [Test]
        public void MapModel_GetEmptyLocationsSousChef_Pass_Pass_Upper_Wall_Valid_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 6;
            map.MapYAxiesCount = 6;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            PlayerList.Add(MonsterPlayer);

            map.PopulateMapModel(PlayerList);
            MapModelLocation playerNext = new MapModelLocation();
            playerNext.Row = 0;
            playerNext.Column = 0;

            MapModelLocation monsterNext = new MapModelLocation();
            monsterNext.Row = 4;
            monsterNext.Column = 0;

            var currPlayer = map.GetLocationForPlayer(CharacterPlayer);
            var currMonster = map.GetLocationForPlayer(MonsterPlayer);

            map.MovePlayerOnMap(currPlayer, playerNext);
            map.MovePlayerOnMap(currMonster, monsterNext);

            // Act
            var result = map.GetEmptyLocationsSousChef(monsterNext, playerNext);

            // Reset

            // Assert 
            Assert.AreEqual(5, result.Row);
            Assert.AreEqual(0, result.Column);
        }

        [Test]
        public void MapModel_GetEmptyLocationsSousChef_Row_Move_Up_Valid_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 6;
            map.MapYAxiesCount = 6;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            PlayerList.Add(MonsterPlayer);

            map.PopulateMapModel(PlayerList);
            MapModelLocation playerNext = new MapModelLocation();
            playerNext.Row = 0;
            playerNext.Column = 1;

            MapModelLocation monsterNext = new MapModelLocation();
            monsterNext.Row = 5;
            monsterNext.Column = 1;

            var currPlayer = map.GetLocationForPlayer(CharacterPlayer);
            var currMonster = map.GetLocationForPlayer(MonsterPlayer);

            map.MovePlayerOnMap(currPlayer, playerNext);
            map.MovePlayerOnMap(currMonster, monsterNext);

            // Act
            var result = map.GetEmptyLocationsSousChef(monsterNext, playerNext);

            // Reset

            // Assert 
            Assert.AreEqual(1, result.Row);
            Assert.AreEqual(1, result.Column);
        }

        [Test]
        public void MapModel_GetEmptyLocationsSousChef_Move_Left_Valid_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 6;
            map.MapYAxiesCount = 6;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            PlayerList.Add(MonsterPlayer);

            map.PopulateMapModel(PlayerList);
            MapModelLocation playerNext = new MapModelLocation();
            playerNext.Row = 5;
            playerNext.Column = 3;

            MapModelLocation monsterNext = new MapModelLocation();
            monsterNext.Row = 5;
            monsterNext.Column = 1;

            var currPlayer = map.GetLocationForPlayer(CharacterPlayer);
            var currMonster = map.GetLocationForPlayer(MonsterPlayer);

            map.MovePlayerOnMap(currPlayer, playerNext);
            map.MovePlayerOnMap(currMonster, monsterNext);

            // Act
            var result = map.GetEmptyLocationsSousChef(monsterNext, playerNext);

            // Reset

            // Assert 
            Assert.AreEqual(5, result.Row);
            Assert.AreEqual(2, result.Column);
        }

        [Test]
        public void MapModel_RemovePlayerFromMap_Valid_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 2;
            map.MapYAxiesCount = 2;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.RemovePlayerFromMap(CharacterPlayer);

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MapModel_RemovePlayerFromMap_InValid_Bogus_Should_Fail()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 2;
            map.MapYAxiesCount = 2;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);

            // Act
            var result = map.RemovePlayerFromMap(null);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_RemovePlayerFromMap_InValid_Missing_Should_Fail()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 2;
            map.MapYAxiesCount = 2;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);


            var Character2 = new CharacterModel();
            var Character2Player = new PlayerInfoModel(Character2);

            // Act
            var result = map.RemovePlayerFromMap(Character2Player);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_ReturnNextEmptyLocation_Character_Slip_Seattle_Winter_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 6;
            map.MapYAxiesCount = 6;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);
            MapModelLocation playerNext = new MapModelLocation();
            playerNext.Row = 0;
            playerNext.Column = 0;

            MapModelLocation monsterNext = new MapModelLocation();
            monsterNext.Row = 0;
            monsterNext.Column = 5;

            var currPlayer = map.GetLocationForPlayer(CharacterPlayer);
            var currMonster = map.GetLocationForPlayer(CharacterPlayer);

            map.MovePlayerOnMap(currPlayer, playerNext);
            map.MovePlayerOnMap(currMonster, monsterNext);

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.EnableSeattleWinter = true;
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(10);

            // Act
            var result = map.ReturnNextEmptyLocation(monsterNext, playerNext, CharacterJobEnum.HeadChef);

            // Reset

            DiceHelper.DisableForcedRolls();
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.EnableSeattleWinter = false;

            // Assert 
            Assert.AreEqual(1, result.Column);
            Assert.AreEqual(5, result.Row);
        }

        [Test]
        public void MapModel_ReturnNextEmptyLocation_Character_MoveOnlyOne_Valid_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 6;
            map.MapYAxiesCount = 6;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);
            MapModelLocation playerNext = new MapModelLocation();
            playerNext.Row = 0;
            playerNext.Column = 0;

            MapModelLocation monsterNext = new MapModelLocation();
            monsterNext.Row = 0;
            monsterNext.Column = 5;

            var currPlayer = map.GetLocationForPlayer(CharacterPlayer);
            var currMonster = map.GetLocationForPlayer(CharacterPlayer);

            map.MovePlayerOnMap(currPlayer, playerNext);
            map.MovePlayerOnMap(currMonster, monsterNext);

            // Act
            var result = map.ReturnNextEmptyLocation(monsterNext, playerNext, CharacterJobEnum.HeadChef);

            // Reset

            // Assert 
            Assert.AreEqual(1, result.Column);
            Assert.AreEqual(0, result.Row);
        }

        [Test]
        public void MapModel_ReturnNextEmptyLocation_Monster_MoveOnlyOne_Valid_Should_Pass()
        {
            // Arrange
            var map = new MapModel();

            map.MapXAxiesCount = 6;
            map.MapYAxiesCount = 6;
            map.MapGridLocation = new MapModelLocation[map.MapXAxiesCount, map.MapYAxiesCount];

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            PlayerList.Add(new PlayerInfoModel(Monster));

            map.PopulateMapModel(PlayerList);
            MapModelLocation playerNext = new MapModelLocation();
            playerNext.Row = 0;
            playerNext.Column = 0;

            MapModelLocation monsterNext = new MapModelLocation();
            monsterNext.Row = 0;
            monsterNext.Column = 5;

            var currPlayer = map.GetLocationForPlayer(CharacterPlayer);
            var currMonster = map.GetLocationForPlayer(CharacterPlayer);

            map.MovePlayerOnMap(currPlayer, playerNext);
            map.MovePlayerOnMap(currMonster, monsterNext);

            // Act
            var result = map.ReturnNextEmptyLocation(playerNext, monsterNext, CharacterJobEnum.Unknown);

            // Reset

            // Assert 
            Assert.AreEqual(4, result.Column);
            Assert.AreEqual(0, result.Row);
        }

        [Test]
        public void MapModel_ReturnNextEmptyLocation_SousChef_Should_Return_0()
        {
            // Arrange
            var map = new MapModel();

            var MapGridLocationOriginal = new MapModelLocation();

            var MapGridLocationTarget = new MapModelLocation();

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            // Act
            var result = map.ReturnNextEmptyLocation(MapGridLocationTarget, MapGridLocationOriginal, CharacterJobEnum.SousChef);

            // Reset

            // Assert 
            Assert.AreEqual(0, result.Row);
            Assert.AreEqual(0, result.Column);
        }

        [Test]
        public void MapModel_GetEmptyLocationsSousChef_SousChef_Should_Return_0()
        {
            // Arrange
            var map = new MapModel();

            var MapGridLocationOriginal = new MapModelLocation();
            MapGridLocationOriginal.Row = 5;

            var MapGridLocationTarget = new MapModelLocation();

            var PlayerList = new List<PlayerInfoModel>();

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            PlayerList.Add(CharacterPlayer);

            // Act
            var result = map.GetEmptyLocationsSousChef(MapGridLocationTarget, MapGridLocationOriginal);

            // Reset

            // Assert 
            Assert.AreEqual(0, result.Row);
            Assert.AreEqual(0, result.Column);
        }

        [Test]
        public void MapModel_GetAllValidMoveLocationsForPlayer_Default_Not_SousChef_Should_Return_4()
        {
            // Arrange
            var map = new MapModel();

            var MapGridLocationOriginal = new MapModelLocation();
            MapGridLocationOriginal.Row = 5;

            // Act
            var result = map.GetAllValidMoveLocationsForPlayer(MapGridLocationOriginal, CharacterJobEnum.CatChef);

            // Reset

            // Assert 
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void MapModel_GetAllValidMoveLocationsForPlayer_Seattle_Winter_Not_SousChef_Should_Return_4()
        {
            // Arrange
            var map = new MapModel();

            var MapGridLocationOriginal = new MapModelLocation();
            MapGridLocationOriginal.Row = 5;

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.EnableSeattleWinter = true;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.SeattleWinterSlippingPercent = 50;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(10);

            // Act
            var result = map.GetAllValidMoveLocationsForPlayer(MapGridLocationOriginal, CharacterJobEnum.CatChef);

            // Reset
            DiceHelper.DisableForcedRolls();
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.EnableSeattleWinter = false;

            // Assert 
            Assert.AreEqual(36, result.Count);
        }

        [Test]
        public void MapModel_GetAllValidMoveLocationsForPlayer_SousChef_Should_Return_4()
        {
            // Arrange
            var map = new MapModel();
            map.MapXAxiesCount = 6;
            map.MapYAxiesCount = 6;

            var MapGridLocationOriginal = new MapModelLocation();
            MapGridLocationOriginal.Row = 0;
            MapGridLocationOriginal.Column = 0;

            // Act
            var result = map.GetAllValidMoveLocationsForPlayer(MapGridLocationOriginal, CharacterJobEnum.SousChef);

            // Reset

            // Assert 
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void MapModel_CanAttackerMoveHere_HeadChef_Invalid_Move_Should_Return_False()
        {
            // Arrange
            var map = new MapModel();

            var MapGridLocationOriginal = new MapModelLocation();
            MapGridLocationOriginal.Row = 0;
            MapGridLocationOriginal.Column = 0;

            var MapGridLocationTarget = new MapModelLocation();
            MapGridLocationTarget.Row = 5;
            MapGridLocationTarget.Column = 5;

            // Act
            var result = map.CanAttackerMoveHere(MapGridLocationTarget, MapGridLocationOriginal, CharacterJobEnum.HeadChef);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MapModel_CanAttackerMoveHere_HeadChef_Valid_Move_Should_Return_True()
        {
            // Arrange
            var map = new MapModel();

            var MapGridLocationOriginal = new MapModelLocation();
            MapGridLocationOriginal.Row = 0;
            MapGridLocationOriginal.Column = 0;

            var MapGridLocationTarget = new MapModelLocation();
            MapGridLocationTarget.Row = 0;
            MapGridLocationTarget.Column = 1;

            // Act
            var result = map.CanAttackerMoveHere(MapGridLocationTarget, MapGridLocationOriginal, CharacterJobEnum.HeadChef);

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
        }
    }
}