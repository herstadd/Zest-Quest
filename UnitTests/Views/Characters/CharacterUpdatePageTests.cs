﻿using NUnit.Framework;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace UnitTests.Views
{
    [TestFixture]
    public class CharacterUpdatePageTests : CharacterUpdatePage
    {
        App app;
        CharacterUpdatePage page;

        public CharacterUpdatePageTests() : base(true) { }
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new CharacterUpdatePage(new GenericViewModel<CharacterModel>(new CharacterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void CharacterUpdatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterUpdatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Update_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Save_Clicked_Null_Name_Should_Pass()
        {
            // Arrange
            var ViewModel = new GenericViewModel<CharacterModel>(new CharacterModel());
            ViewModel.Data.Name = null;
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.Update_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Save_Clicked_Null_Image_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.ImageURI = null;

            // Act
            page.Update_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_NameChanged_Null_Name_Should_Pass()
        {
            // Arrange
            var ViewModel = new GenericViewModel<CharacterModel>(new CharacterModel());
            ViewModel.Data.Name = null;
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.NameChanged(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Attack_OnStepperValueChanged_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            var NewButton = new Button();
            NewButton.Text = "5";
            
            // Act
            NewPage.AttackValueChanged(NewButton, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Defense_OnStepperValueChanged_Default_Should_Pass()
        {
            // Arrange
            var NewButton = new Button();
            NewButton.Text = "5";

            // Act
            page.DefenseValueChanged(NewButton, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Speed_OnStepperDamageChanged_Default_Should_Pass()
        {
            // Arrange
            var NewButton = new Button();
            NewButton.Text = "5";

            // Act
            page.SpeedValueChanged(NewButton, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Level_Changed_Default_Should_Pass()
        {
            // Arrange
            var NewButton = new Button();
            NewButton.Text = "5";

            // Act
            page.LevelValueChanged(NewButton, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Type_TypeChanged_Default_Should_Pass()
        {
            // Arrange
            Picker picker = new Picker();
            picker.SelectedItem = "SousChef";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.TypeChanged(picker, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ItemSelected_Item_Should_Pass()
        {
            // Arrange
            Picker picker = new Picker();
            var item = new ItemModel();
            item.Name = "Refrigerator";
            picker.SelectedItem = item;

         
            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ItemSelected(picker, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItemSelection_Head_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "Head";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItemSelection(button, null);
            
            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItemSelection_Necklass_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "Necklass";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItemSelection_PrimaryHand_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "PrimaryHand";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItemSelection_OffHand_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "OffHand";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItemSelection_Feet_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "Feet";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItemSelection_RightFinger_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "RightFinger";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItemSelection_LeftFinger_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "LeftFinger";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItemSelection_default_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItem_Head_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Head";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItem_Necklass_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Necklass";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItem_PrimaryHand_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "PrimaryHand";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItem_OffHand_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "OffHand";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItem_Feet_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Feet";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItem_RightFinger_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "RightFinger";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItem_LeftFinger_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "LeftFinger";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClickedOnItem_Default_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AddItemButtonClicked_Selected_ChefHat_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Chef Hat";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AddItemButtonClicked_Selected_OnionRing_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Onion Ring";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AddItemButtonClicked_Selected_RingPop_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Ring Pop";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AddItemButtonClicked_Selected_Timer_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Timer";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AddItemButtonClicked_Selected_Null_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = null;

            var NewPage = new CharacterUpdatePage(true);


            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AddItemButtonClicked_Selected_Refrigerator_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Refrigerator";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AddItemButtonClicked_Selected_CuttingBoard_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Cutting Board";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AddItemButtonClicked_Selected_WookieBoots_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Wookie Boots";

            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            var NewPage = new CharacterUpdatePage(ViewModel);

            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_PopulateInitialItems_Valid_Head_Item_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.Head = "ChefHat";

            // Act
            page.PopulateInitialItems("Head", "Chef Hat", data);

            // Reset 

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterUpdatePage_PopulateInitialItems_Valid_Necklass_Item_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.Necklass = "ButcherKnifeNecklace";

            // Act
            page.PopulateInitialItems("Necklass", "Butcher Knife Necklace", data);

            // Reset 

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterUpdatePage_PopulateInitialItems_Valid_PrimaryHand_Item_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.PrimaryHand = "Refrigerator";

            // Act
            page.PopulateInitialItems("PrimaryHand", "Refrigerator", data);

            // Reset 

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterUpdatePage_PopulateInitialItems_Valid_OffHand_Item_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.OffHand = "Knife";

            // Act
            page.PopulateInitialItems("OffHand", "Knife", data);

            // Reset 

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterUpdatePage_PopulateInitialItems_Valid_RightFinger_Item_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.RightFinger = "ScreamRing";

            // Act
            page.PopulateInitialItems("RightFinger", "Scream Ring", data);

            // Reset 

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterUpdatePage_PopulateInitialItems_Valid_LeftFinger_Item_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.LeftFinger = "RingPop";

            // Act
            page.PopulateInitialItems("LeftFinger", "Ring Pop", data);

            // Reset 

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterUpdatePage_PopulateInitialItems_Valid_Feet_Item_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.Feet = "Crocs";

            // Act
            page.PopulateInitialItems("Feet", "Crocs", data);

            // Reset 

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterUpdatePage_GetInitialItems_Valid_Should_Return_Locations()
        {
            // Arrange
            var data = new CharacterModel
            {
                Head = "Chef Hat",
                Necklass = "Butcher Knife Necklace",
                PrimaryHand = "Refrigerator",
                OffHand = "Knife",
                Feet = "Crocs",
                RightFinger = "Scream Ring",
                LeftFinger = "Ring Pop",
            };

            // Act
            var result = page.GetInitialItems(data);

            // Reset 

            // Assert
            Assert.AreEqual(7, result.Count);
        }

        [Test]
        public void CharacterUpdatePage_GetInitialLocations_Valid_Should_Return_Locations()
        {
            // Arrange
            var data = new CharacterModel
            {
                Head = "Chef Hat",
                Necklass = "Butcher Knife Necklace",
                PrimaryHand = "Refrigerator",
                OffHand = "Knife",
                Feet = "Crocs",
                RightFinger = "Scream Ring",
                LeftFinger = "Ring Pop",
            };

            // Act
            var result = page.GetInitialLocations(data);

            // Reset 

            // Assert
            Assert.AreEqual(7, result.Count);
        }

        [Test]
        public void CharacterUpdatePage_Not_Default_Constructor_Should_Pass()
        {
            // Arrange
            var CharData = new CharacterModel
            {
                Head = "Chef Hat",
                Necklass = "Butcher Knife Necklace",
                PrimaryHand = "Refrigerator",
                OffHand = "Knife",
                Feet = "Crocs",
                RightFinger = "Scream Ring",
                LeftFinger = "Ring Pop",
            };

            GenericViewModel<CharacterModel> data = new GenericViewModel<CharacterModel>();
            data.Data = CharData;

            // Act
            CharacterUpdatePage NewPage = new CharacterUpdatePage(data);

            // Reset 

            // Assert
            Assert.IsNotNull(NewPage);
        }

        #region UpdateHealth
        [Test]
        public void CharacterUpdatePage_UpdateHealthValue_Valid_Default_Should_Pass()
        {
            // Arrange
            var NewButton = new Button();
            NewButton.Text = "5";

            // Act
            page.MaxHealthValueChanged(NewButton, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        #endregion UpdateHealth
    }
}