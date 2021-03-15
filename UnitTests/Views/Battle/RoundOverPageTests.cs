using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Game.Models;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.ViewModels;

namespace UnitTests.Views
{
    [TestFixture]
    public class RoundOverPageTests
    {
        App app;
        RoundOverPage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            // For now, set the engine to the Koenig Engine, change when ready 
            BattleEngineViewModel.Instance.SetBattleEngineToKoenig();

            page = new RoundOverPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void RoundOverPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void RoundOverPage_NextButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.CloseButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_AutoAssignButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.AutoAssignButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_ClosePopup_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.ClosePopup_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_ShowPopup_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.ShowPopup(new ItemModel());

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_CreatePlayerDisplayBox_Null_Should_Pass()
        {
            // Arrange
            // Act
            page.CreatePlayerDisplayBox(null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetItemToDisplay_Null_Should_Pass()
        {
            // Arrange
            // Act
            page.GetItemToDisplay(null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetItemToDisplay_InValid_Id_Should_Pass()
        {
            // Arrange
            // Act
            page.GetItemToDisplay(new ItemModel { Id = "" });

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public async Task RoundOverPage_GetItemToDisplay_Valid_Should_Pass()
        {
            // Arrange
            var data = new ItemModel { Name = "Mike" };
            await ItemIndexViewModel.Instance.CreateAsync(data);

            // Act
            page.GetItemToDisplay(data);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_DrawCharacterList_Valid_Should_Pass()
        {
            // Arrange

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.CharacterModelDeathList.Add(new PlayerInfoModel(new CharacterModel()));

            // Draw the Monsters
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.MonsterModelDeathList.Add(new PlayerInfoModel(new CharacterModel()));

            // Do it two times
            page.DrawCharacterList();

            // Act
            page.DrawCharacterList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_DrawDroppedItems_Valid_Should_Pass()
        {
            // Arrange

            // Draw the Items
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel());

            // Draw two times
            page.DrawDroppedItems();

            // Act
            page.DrawDroppedItems();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_DrawItemLists_Valid_Should_Pass()
        {
            // Arrange

            // Draw the Items
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(new ItemModel());

            // Draw two times
            page.DrawItemLists();

            // Act  BattleEngineViewModel.Instance.Engine.EngineSettings.
            page.DrawItemLists();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_DrawSelectedItems_Valid_Should_Pass()
        {
            // Arrange

            // Draw the Items
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(new ItemModel());

            // Draw two times
            page.DrawSelectedItems();

            // Act
            page.DrawSelectedItems();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.PrimaryHand);
            var StackItem = page.GetItemToDisplay(item);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_ClickedCharacter_Same_Character_Should_Return_True()
        {
            // Arrange
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["PlayerInfoBox"],
                HorizontalOptions = LayoutOptions.Center,
                Padding = 0,
                Spacing = 0,
            };

            // Act
            var result = page.ClickedCharacter(PlayerStack, null);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundOverPage_ClickedCharacter_Different_Character_Should_Return_True()
        {
            // Arrange
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["PlayerInfoBox"],
                HorizontalOptions = LayoutOptions.Center,
                Padding = 0,
                Spacing = 0,
            };

            // Act
            var result = page.ClickedCharacter(PlayerStack, new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Valid_Head_Item_Should_Return_True()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                Head = "Chef Hat",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.Head,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Null_Head_Item_Should_Return_False()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                Head = "Null",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.Head,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Valid_Necklass_Item_Should_Return_True()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                Necklass = "Timer",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.Necklass,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Null_Necklass_Item_Should_Return_False()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                Necklass = "Null",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.Necklass,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Valid_PrimaryHand_Item_Should_Return_True()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                PrimaryHand = "Refrigerator",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.PrimaryHand,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Null_PrimaryHand_Item_Should_Return_False()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                PrimaryHand = "Null",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.PrimaryHand,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Valid_OffHand_Item_Should_Return_True()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                OffHand = "Knife",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.OffHand,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Null_OffHand_Item_Should_Return_False()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                OffHand = "Null",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.OffHand,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Valid_RightFinger_Item_Should_Return_True()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                RightFinger = "Scream Ring",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.RightFinger,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Null_RightFinger_Item_Should_Return_False()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                RightFinger = "Null",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.RightFinger,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Valid_LeftFinger_Item_Should_Return_True()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                LeftFinger = "Ring Pop",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.LeftFinger,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Null_LeftFinger_Item_Should_Return_False()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                LeftFinger = "Null",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.LeftFinger,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Valid_Feet_Item_Should_Return_True()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                Feet = "Crocs",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.Feet,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Null_Feet_Item_Should_Return_False()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                Feet = "Null",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.Feet,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoundOverPage_ShowPopup_Null_Unknown_Item_Should_Return_False()
        {
            // Arrange
            page.SelectedCharacter = new PlayerInfoModel
            {
                Feet = "Null",
            };

            ItemModel TestItem = new ItemModel
            {
                Location = ItemLocationEnum.Unknown,
            };

            // Act
            var result = page.ShowPopup(TestItem);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoundOverPage_EquipItem_Clicked_CurrentItem_Null_Should_Pass()
        {
            // Arrange
            var CurrentItem = (Label)page.FindByName("CurrentItemName");
            CurrentItem.Text = "No item in this spot";

            // Act
            page.EquipItem_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_EquipItem_Clicked_CurrentItem_Valid_Should_Pass()
        {
            // Arrange
            var CurrentItem = (Label)page.FindByName("CurrentItemName");
            CurrentItem.Text = "Chef Hat";

            // Act
            page.EquipItem_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_EquipItem_Clicked_PossibleItem_Head_Should_Pass()
        {
            // Arrange
            var CurrentItem = (Label)page.FindByName("CurrentItemName");
            CurrentItem.Text = "Chef Hat";

            var PossibleItem = (Label)page.FindByName("PossibleItemName");
            PossibleItem.Text = "Chef Hat";

            var PossibleItemLocation = (Label)page.FindByName("PossibleItemLocation");
            PossibleItemLocation.Text = "Head";

            page.SelectedCharacter = new PlayerInfoModel
            {
                Head = null,
            };

            // Act
            page.EquipItem_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_EquipItem_Clicked_PossibleItem_Necklass_Should_Pass()
        {
            // Arrange
            var CurrentItem = (Label)page.FindByName("CurrentItemName");
            CurrentItem.Text = "Timer";

            var PossibleItem = (Label)page.FindByName("PossibleItemName");
            PossibleItem.Text = "Timer";

            var PossibleItemLocation = (Label)page.FindByName("PossibleItemLocation");
            PossibleItemLocation.Text = "Necklass";

            page.SelectedCharacter = new PlayerInfoModel
            {
                Necklass = null,
            };

            // Act
            page.EquipItem_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_EquipItem_Clicked_PossibleItem_PrimaryHand_Should_Pass()
        {
            // Arrange
            var CurrentItem = (Label)page.FindByName("CurrentItemName");
            CurrentItem.Text = "Refrigerator";

            var PossibleItem = (Label)page.FindByName("PossibleItemName");
            PossibleItem.Text = "Refrigerator";

            var PossibleItemLocation = (Label)page.FindByName("PossibleItemLocation");
            PossibleItemLocation.Text = "Primary Hand";

            page.SelectedCharacter = new PlayerInfoModel
            {
                PrimaryHand = null,
            };

            // Act
            page.EquipItem_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}