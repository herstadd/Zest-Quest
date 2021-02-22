using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace UnitTests.Views
{
    [TestFixture]
    public class CharacterCreatePageTests : CharacterCreatePage
    {
        App app;
        CharacterCreatePage page;

        public CharacterCreatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            //page = new CharacterCreatePage(new GenericViewModel<CharacterModel>(new CharacterModel()));
            page = new CharacterCreatePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void CharacterCreatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterCreatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Save_Clicked_Null_Image_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.ImageURI = null;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Attack_OnStepperAttackChanged_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);

            page = new CharacterCreatePage();
            double oldAttack = 0.0;
            double newAttack = 1.0;

            var args = new ValueChangedEventArgs(oldAttack, newAttack);

            Button button = new Button();
            button.Text = "+";

            // Act
            page.AttackValueChanged(button, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Speed_OnStepperValueChanged_Default_Should_Pass()
        {
            // ArSpeed
            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);

            page = new CharacterCreatePage();
            double oldSpeed = 0.0;
            double newSpeed = 1.0;

            var args = new ValueChangedEventArgs(oldSpeed, newSpeed);

            Button button = new Button();
            button.Text = "+";

            // Act
            page.SpeedValueChanged(button, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Defense_OnStepperDefenseChanged_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);

            page = new CharacterCreatePage();
            double oldDefense = 0.0;
            double newDefense = 1.0;

            var args = new ValueChangedEventArgs(oldDefense, newDefense);

            Button button = new Button();
            button.Text = "+";

            // Act
            page.DefenseValueChanged(button, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Level_OnStepperDefenseChanged_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);

            page = new CharacterCreatePage();
            int oldLevel = 1;
            int newLevel = 2;

            var args = new ValueChangedEventArgs(oldLevel, newLevel);

            Button button = new Button();
            button.Text = "+";

            // Act
            page.LevelValueChanged(button, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_CheckNullEntry_Null_Name_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Name = null;

            // Act
            page.CheckNullEntry(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Save_Clicked_Null_Name_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);
            ViewModel.Data.Name = null;
            var NewPage = new CharacterCreatePage();
            NewPage.ViewModel = ViewModel;

            // Act
            NewPage.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_TypeChanged_No_Items_Should_Pass()
        {
            // Arrange
            Picker picker = new Picker();
            picker.SelectedItem = "SousChef"; 
            
            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.TypeChanged(picker, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItemSelection_Head_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "Head";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItemSelection_Necklass_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "Necklass";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItemSelection_PrimaryHand_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "PrimaryHand";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItemSelection_OffHand_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "OffHand";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItemSelection_Feet_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "Feet";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItemSelection_RightFinger_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "RightFinger";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItemSelection_LeftFinger_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "LeftFinger";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItemSelection_Default_Case_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.Text = "Confirm";
            button.BindingContext = "Nonexistent";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItemSelection(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItem_Head_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Head";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItem_Necklass_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Necklass";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItem_PrimaryHand_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "PrimaryHand";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItem_OffHand_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "OffHand";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItem_Feet_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Feet";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItem_RightFinger_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "RightFinger";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItem_LeftFinger_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "LeftFinger";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClickedOnItem_Default_Case_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Nonexistent";

            var NewPage = new CharacterCreatePage();

            // Act
            NewPage.ClickedOnItem(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_AddItemButtonClicked_Selected_Null_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = null;

            var NewPage = new CharacterCreatePage();


            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_AddItemButtonClicked_Selected_ChefHat_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "ChefHat";

            var NewPage = new CharacterCreatePage();


            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_AddItemButtonClicked_Selected_Apron_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Apron";

            var NewPage = new CharacterCreatePage();


            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_AddItemButtonClicked_Selected_Pan_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Pan";

            var NewPage = new CharacterCreatePage();


            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_AddItemButtonClicked_Selected_Knife_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "Knife";

            var NewPage = new CharacterCreatePage();


            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_AddItemButtonClicked_Selected_ScreamRing_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "ScreamRing";

            var NewPage = new CharacterCreatePage();


            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_AddItemButtonClicked_Selected_RingPop_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "RingPop";

            var NewPage = new CharacterCreatePage();


            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_AddItemButtonClicked_Selected_FlipFlop_Should_Pass()
        {
            // Arrange
            Button button = new Button();
            button.BindingContext = "FlipFlop";

            var NewPage = new CharacterCreatePage();


            // Act
            NewPage.AddItemButtonClicked(button, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        //[Test]
        //public void CharacterCreatePage_RollDice_Clicked_Default_Should_Pass()
        //{
        //    // Arrange
        //    page.ViewModel.Data = new CharacterModel();

        //    // Act
        //    page.RollDice_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCreatePage_ClosePopup_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ClosePopup();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCreatePage_ClosePopup_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ClosePopup_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCreatePage_ShowPopup_Default_Should_Pass()
        //{
        //    // Arrange
        //    page.ViewModel.Data = new CharacterModel();

        //    // Act
        //    page.ShowPopup(ItemLocationEnum.PrimaryHand);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCreatePage_OnPopupItemSelected_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    var data = new ItemModel();

        //    var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(data, 0);

        //    // Act
        //    page.OnPopupItemSelected(null, selectedCharacterChangedEventArgs);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCreatePage_OnPopupItemSelected_Clicked_Null_Should_Fail()
        //{
        //    // Arrange

        //    var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(null, 0);

        //    // Act
        //    page.OnPopupItemSelected(null, selectedCharacterChangedEventArgs);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCreatePage_Item_ShowPopup_Default_Should_Pass()
        //{
        //    // Arrange

        //    var item = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);

        //    // Act
        //    var itemButton = item.Children.FirstOrDefault(m => m.GetType().Name.Equals("Button"));

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCratePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        //{
        //    // Arrange
        //    var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.PrimaryHand);
        //    page.ViewModel.Data.Head = item.Id;
        //    var StackItem = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);
        //    var dataImage = StackItem.Children[0];

        //    // Act
        //    ((ImageButton)dataImage).PropagateUpClicked();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCreatePage_RandomButton_Clicked_Vaid_Should_Pass()
        //{
        //    // Arrange
        //    page.ViewModel.Data.ImageURI = null;

        //    // Act
        //    page.RandomButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

    }
}