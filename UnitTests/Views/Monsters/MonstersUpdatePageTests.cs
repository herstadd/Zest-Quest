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
    public class MonsterUpdatePageTests : MonsterUpdatePage
    {
        App app;
        MonsterUpdatePage page;

        public MonsterUpdatePageTests() : base(true) { }
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new MonsterUpdatePage(new GenericViewModel<MonsterModel>(new MonsterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void MonsterUpdatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterUpdatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void MonsterUpdatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        //[Test]
        //public void MonsterUpdatePage_Attack_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new MonsterModel();
        //    var ViewModel = new GenericViewModel<MonsterModel>(data);

        //    page = new MonsterUpdatePage(ViewModel);
        //    double oldValue = 0.0;
        //    double newValue = 1.0;

        //    var args = new ValueChangedEventArgs(oldValue, newValue);

        //    // Act
        //    page.Attack_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}
        
        //[Test]
        //public void MonsterUpdatePage_Defense_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new MonsterModel();
        //    var ViewModel = new GenericViewModel<MonsterModel>(data);

        //    page = new MonsterUpdatePage(ViewModel);
        //    double oldRange = 0.0;
        //    double newRange = 1.0;

        //    var args = new ValueChangedEventArgs(oldRange, newRange);

        //    // Act
        //    page.Defense_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void MonsterUpdatePage_Speed_OnStepperDamageChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new MonsterModel();
        //    var ViewModel = new GenericViewModel<MonsterModel>(data);

        //    page = new MonsterUpdatePage(ViewModel);
        //    double oldDamage = 0.0;
        //    double newDamage = 1.0;

        //    var args = new ValueChangedEventArgs(oldDamage, newDamage);

        //    // Act
        //    page.Speed_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void MonsterUpdatePage_RollDice_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.RollDice_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        [Test]
        public void MonsterUpdatePage_ClosePopup_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_ClosePopup_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_OnPopupItemSelected_Clicked_Default_Should_Pass()
        {
            // Arrange

            var data = new ItemModel();

            var selectedMonsterChangedEventArgs = new SelectedItemChangedEventArgs(data, 0);

            // Act
            page.OnPopupItemSelected(null, selectedMonsterChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_OnPopupItemSelected_Clicked_Null_Should_Fail()
        {
            // Arrange

            var selectedMonsterChangedEventArgs = new SelectedItemChangedEventArgs(null, 0);

            // Act
            page.OnPopupItemSelected(null, selectedMonsterChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_Item_ShowPopup_Default_Should_Pass()
        {
            // Arrange

            var item = page.GetItemToDisplay();

            // Act
            var itemButton = item.Children.FirstOrDefault(m => m.GetType().Name.Equals("Button"));

            page.ShowPopup(new ItemModel());

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var StackItem = page.GetItemToDisplay();
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        #region ButtonUpDown
        [Test]
        public void MonsterUpdatePage_AttackDownButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Attack = 1;

            // Act
            page.AttackDownButton_Clicked(null,null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_AttackUpButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Attack = 1;

            // Act
            page.AttackUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_DefenseDownButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Defense = 1;

            // Act
            page.DefenseDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_DefenseUpButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Defense = 1;

            // Act
            page.DefenseUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_SpeedDownButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Speed = 1;

            // Act
            page.SpeedDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_SpeedUpButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Speed = 1;

            // Act
            page.SpeedUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_AttackDownButton_Clicked_Invalid_0_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Attack = 0;

            // Act
            page.AttackDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_AttackUpButton_Clicked_Invalid_10_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Attack = 10;

            // Act
            page.AttackUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_DefenseDownButton_Clicked_Invalid_0_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Defense = 0;

            // Act
            page.DefenseDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_DefenseUpButton_Clicked_Invalid_10_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Defense = 10;

            // Act
            page.DefenseUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_SpeedDownButton_Clicked_Invalid_0_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Speed = 0;

            // Act
            page.SpeedDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_SpeedUpButton_Clicked_Invalid_10_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Speed = 10;

            // Act
            page.SpeedUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        #endregion ButtonUpDown

        #region RandomButton_Clicked
        [Test]
        public void MonsterUpdatePage_RandomButton_Clicked_Valid_Should_Pass()
        {
            // Arrange

            // Act
            page.RandomButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        #endregion RandomButton_Clicked

    }
}