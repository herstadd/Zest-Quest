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
    public class ItemUpdatePageTests : ItemUpdatePage
    {
        App app;
        ItemUpdatePage page;

        public ItemUpdatePageTests() : base(true) { }
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new ItemUpdatePage(new GenericViewModel<ItemModel>(new ItemModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void ItemUpdatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemUpdatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_Type_Changed_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Type_Changed(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_Save_Clicked_Valid_Data_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            var ViewModel = new GenericViewModel<ItemModel>(data);
            ViewModel.Data.Type = ItemModelEnum.Bandana;
            var NewPage = new ItemUpdatePage(ViewModel);


            // Act
            NewPage.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void ItemUpdatePage_Save_Clicked_Null_Name_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            var ViewModel = new GenericViewModel<ItemModel>(data);
            ViewModel.Data.Type = ItemModelEnum.Bandana;
            ViewModel.Data.Name = null;
            var NewPage = new ItemUpdatePage(ViewModel);


            // Act
            NewPage.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_Save_Clicked_Null_Description_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            var ViewModel = new GenericViewModel<ItemModel>(data);
            ViewModel.Data.Type = ItemModelEnum.Bandana;
            var NewPage = new ItemUpdatePage(ViewModel);
            NewPage.ViewModel.Data.Description = null ;


            // Act
            NewPage.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_RangeValueChanged_Valid_Data_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            var ViewModel = new GenericViewModel<ItemModel>(data);
            ViewModel.Data.Type = ItemModelEnum.Knife;
            var NewPage = new ItemUpdatePage(ViewModel);

            Button button = new Button();
            button.Text = "+";

            // Act
            NewPage.RangeValueChanged(button, System.EventArgs.Empty);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_ValueValueChanged_Valid_Data_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            var ViewModel = new GenericViewModel<ItemModel>(data);
            ViewModel.Data.Type = ItemModelEnum.Knife;
            var NewPage = new ItemUpdatePage(ViewModel);

            Button button = new Button();
            button.Text = "-";

            // Act
            NewPage.ValueValueChanged(button, System.EventArgs.Empty);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_DamageValueChanged_Valid_Data_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();
            var ViewModel = new GenericViewModel<ItemModel>(data);
            ViewModel.Data.Type = ItemModelEnum.Knife;
            var NewPage = new ItemUpdatePage(ViewModel);

            Button button = new Button();
            button.Text = "-";

            // Act
            NewPage.DamageValueChanged(button, System.EventArgs.Empty);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_ValueChange_Attribute_Value_To_Less_Than_Zero_Should_Return_Zero()
        {
            // Arrange
            var NewAttributeValue = -1;

            // Act
            var Result = page.ValueChange("-", NewAttributeValue, false);

            // Reset

            // Assert
            Assert.AreEqual(0, Result); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_ValueChange_Attribute_Value_Greater_Than_Zero_Should_Return_4()
        {
            // Arrange
            var NewAttributeValue = 5;

            // Act
            var Result = page.ValueChange("-", NewAttributeValue, false);

            // Reset

            // Assert
            Assert.AreEqual(4, Result); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_ValueChange_Invalid_Attribute_Value_9_To_10_Should_Return_9()
        {
            // Arrange
            var CurrentLevelValue = 9;

            // Act
            var Result = page.ValueChange("+", CurrentLevelValue, true);

            // Reset

            // Assert
            Assert.AreEqual(9, Result); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_ValueChange_Valid_Level_Value_8_To_7_Should_Return_7()
        {
            // Arrange
            var CurrentLevelValue = 8;

            // Act
            var Result = page.ValueChange("-", CurrentLevelValue, true);

            // Reset

            // Assert
            Assert.AreEqual(7, Result); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_ValueChange_Invalid_Level_Value_1_To_0_Should_Return_1()
        {
            // Arrange
            var CurrentLevelValue = 1;

            // Act
            var Result = page.ValueChange("-", CurrentLevelValue, true);

            // Reset

            // Assert
            Assert.AreEqual(1, Result); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemUpdatePage_CheckNullEntry_Null_Name_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Name = null;

            // Act
            page.CheckNullEntry(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        

        //[Test]
        //public void ItemUpdatePage_Value_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new ItemModel();
        //    var ViewModel = new GenericViewModel<ItemModel>(data);

        //    page = new ItemUpdatePage(ViewModel);
        //    double oldValue = 0.0;
        //    double newValue = 1.0;

        //    var args = new ValueChangedEventArgs(oldValue, newValue);

        //    // Act
        //    page.Value_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void ItemUpdatePage_Range_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new ItemModel();
        //    var ViewModel = new GenericViewModel<ItemModel>(data);

        //    page = new ItemUpdatePage(ViewModel);
        //    double oldRange = 0.0;
        //    double newRange = 1.0;

        //    var args = new ValueChangedEventArgs(oldRange, newRange);

        //    // Act
        //    page.Range_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void ItemUpdatePage_Damage_OnStepperDamageChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new ItemModel();
        //    var ViewModel = new GenericViewModel<ItemModel>(data);

        //    page = new ItemUpdatePage(ViewModel);
        //    double oldDamage = 0.0;
        //    double newDamage = 1.0;

        //    var args = new ValueChangedEventArgs(oldDamage, newDamage);

        //    // Act
        //    page.Damage_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}
    }
}