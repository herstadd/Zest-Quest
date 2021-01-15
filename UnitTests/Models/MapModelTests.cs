using NUnit.Framework;

using Game.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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
    }
}