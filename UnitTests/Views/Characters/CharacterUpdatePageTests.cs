using NUnit.Framework;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using System.Linq;

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
            picker.SelectedItem = "Refrigerator";

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
            button.BindingContext = "ChefHat";

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
            button.BindingContext = "OnionRing";

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
            button.BindingContext = "RingPop";

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
            button.BindingContext = "CuttingBoard";

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
            button.BindingContext = "WookieBoots";

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
        public void CharacterUpdatePage_PopulateInitialItems_Null_Head_Item_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.Head = null;

            // Act
            page.PopulateInitialItems("Head", data);

            // Reset 

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterUpdatePage_PopulateInitialItems_Valid_Head_Item_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.Head = "ChefHat";

            // Act
            page.PopulateInitialItems("Head", data);

            // Reset 

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterUpdatePage_PopulateInitialItems_Null_Necklass_Item_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.Necklass = null;

            // Act
            page.PopulateInitialItems("Necklass", data);

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
            page.PopulateInitialItems("Necklass", data);

            // Reset 

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterUpdatePage_PopulateInitialItems_Null_PrimaryHand_Item_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.PrimaryHand = null;

            // Act
            page.PopulateInitialItems("PrimaryHand", data);

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
            page.PopulateInitialItems("PrimaryHand", data);

            // Reset 

            // Assert
            Assert.IsTrue(true);
        }


        //[Test]
        //public void CharacterUpdatePage_RollDice_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.RollDice_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_ClosePopup_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ClosePopup();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_ClosePopup_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ClosePopup_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_OnPopupItemSelected_Clicked_Default_Should_Pass()
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
        //public void CharacterUpdatePage_OnPopupItemSelected_Clicked_Null_Should_Fail()
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
        //public void CharacterUpdatePage_Item_ShowPopup_Default_Should_Pass()
        //{
        //    // Arrange

        //    var item = page.GetItemToDisplay(ItemLocationEnum.Head);

        //    // Act
        //    var itemButton = item.Children.FirstOrDefault(m => m.GetType().Name.Equals("Button"));

        //    page.ShowPopup(ItemLocationEnum.Head);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        //{
        //    // Arrange
        //    var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Head);
        //    page.ViewModel.Data.Head = item.Id;
        //    var StackItem = page.GetItemToDisplay(ItemLocationEnum.Head);
        //    var dataImage = StackItem.Children[0];

        //    // Act
        //    ((ImageButton)dataImage).PropagateUpClicked();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}


        #region ButtonUpDown
        //[Test]
        //public void CharacterUpdatePage_AttackDownButton_Clicked_Valid_1_Should_Pass()
        //{
        //    // Arrange
        //    page.ViewModel.Data.Attack = 1;

        //    // Act
        //    page.AttackDownButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_AttackUpButton_Clicked_Valid_1_Should_Pass()
        //{
        //    // Arrange
        //    page.ViewModel.Data.Attack = 1;

        //    // Act
        //    page.AttackUpButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_DefenseDownButton_Clicked_Valid_1_Should_Pass()
        //{
        //    // Arrange
        //    page.ViewModel.Data.Defense = 1;

        //    // Act
        //    page.DefenseDownButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_DefenseUpButton_Clicked_Valid_1_Should_Pass()
        //{
        //    // Arrange
        //    page.ViewModel.Data.Defense = 1;

        //    // Act
        //    page.DefenseUpButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_SpeedDownButton_Clicked_Valid_1_Should_Pass()
        //{
        //    // Arrange
        //    page.ViewModel.Data.Speed = 1;

        //    // Act
        //    page.SpeedDownButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_SpeedUpButton_Clicked_Valid_1_Should_Pass()
        //{
        //    // Arrange
        //    page.ViewModel.Data.Speed = 1;

        //    // Act
        //    page.SpeedUpButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_AttackDownButton_Clicked_Invalid_0_Should_Fail()
        //{
        //    // Arrange
        //    page.ViewModel.Data.Attack = 0;

        //    // Act
        //    page.AttackDownButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_AttackUpButton_Clicked_Invalid_10_Should_Fail()
        //{
        //    // Arrange
        //    page.ViewModel.Data.Attack = 10;

        //    // Act
        //    page.AttackUpButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_DefenseDownButton_Clicked_Invalid_0_Should_Fail()
        //{
        //    // Arrange
        //    page.ViewModel.Data.Defense = 0;

        //    // Act
        //    page.DefenseDownButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_DefenseUpButton_Clicked_Invalid_10_Should_Fail()
        //{
        //    // Arrange
        //    page.ViewModel.Data.Defense = 10;

        //    // Act
        //    page.DefenseUpButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_SpeedDownButton_Clicked_Invalid_0_Should_Fail()
        //{
        //    // Arrange
        //    page.ViewModel.Data.Speed = 0;

        //    // Act
        //    page.SpeedDownButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_SpeedUpButton_Clicked_Invalid_10_Should_Fail()
        //{
        //    // Arrange
        //    page.ViewModel.Data.Speed = 10;

        //    // Act
        //    page.SpeedUpButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}
        #endregion ButtonUpDown

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

        #region RandomButton_Clicked
        //[Test]
        //public void CharacterUpdatePage_RandomButton_Clicked_Valid_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.RandomButton_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}
        #endregion RandomButton_Clicked

        #region LevelPicker_Changed
        //[Test]
        //public void CharacterUpdatePage_LevelPicker_SelectedIndex_Neg1_Should_Return_Level()
        //{
        //    // Arrange

        //    // Make a new Character to use for the Picker Tests
        //    page.ViewModel.Data = new CharacterModel()
        //    {
        //        Id = "test",
        //        Level = 10
        //    };

        //    var control = (Picker)page.FindByName("LevelPicker");
        //    control.SelectedIndex = -1;

        //    // Act
        //    page.LevelPicker_Changed(null, null);
        //    var result = control.SelectedIndex;

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(10, result+1); 
        //}

        //[Test]
        //public void CharacterUpdatePage_LevelPicker_SelectedIndex_No_Change_Should_Skip()
        //{
        //    // Arrange

        //    // Make a new Character to use for the Picker Tests
        //    page.ViewModel.Data = new CharacterModel()
        //    {
        //        Id = "test",
        //        Level = 10
        //    };

        //    var control = (Picker)page.FindByName("LevelPicker");
        //    control.SelectedIndex = 10-1;

        //    // Act
        //    page.LevelPicker_Changed(null, null);
        //    var result = control.SelectedIndex;

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(10, result + 1);
        //}


        //[Test]
        //public void CharacterUpdatePage_LevelPicker_SelectedIndex_Change_Should_Update_Picker_To_Level()
        //{
        //    // Arrange

        //    // Make a new Character to use for the Picker Tests
        //    page.ViewModel.Data = new CharacterModel()
        //    {
        //        Id = "test",
        //        Level = 1
        //    };

        //    var control = (Picker)page.FindByName("LevelPicker");
        //    control.SelectedIndex = 15;

        //    // Act
        //    page.LevelPicker_Changed(null, null);
        //    var result = control.SelectedIndex;

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(16, result + 1);
        //}
        #endregion LevelPicker_Changed
    }
}