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
    public class ItemCreatePageTests : ItemCreatePage
    {
        App app;
        ItemCreatePage page;

        public ItemCreatePageTests() : base(true) { }
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new ItemCreatePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void ItemCreatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemCreatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void ItemCreatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Type_Changed_Default_Should_Pass()
        {
            // Arrange
            Picker picker = new Picker();
            picker.SelectedItem = ItemModelEnum.Apron;

            // Act
            page.Type_Changed(picker, EventArgs.Empty);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Save_Clicked_Valid_Data_Should_Pass()
        {
            // Arrange
            var NewPage = new ItemCreatePage();
            

            // Act
            NewPage.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Save_Clicked_Null_Name_Should_Pass()
        {
            // Arrange          
            var NewPage = new ItemCreatePage();
            NewPage.ViewModel.Data.Name = null;


            // Act
            NewPage.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_RangeValueChanged_Valid_Data_Should_Pass()
        {
            // Arrange            
            var NewPage = new ItemCreatePage();

            Button button = new Button();
            button.Text = "+";

            // Act
            NewPage.RangeValueChanged(button, System.EventArgs.Empty);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_ValueValueChanged_Valid_Data_Should_Pass()
        {
            // Arrange         
            var NewPage = new ItemCreatePage();

            Button button = new Button();
            button.Text = "-";

            // Act
            NewPage.ValueValueChanged(button, System.EventArgs.Empty);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_DamageValueChanged_Valid_Data_Should_Pass()
        {
            // Arrange          
            var NewPage = new ItemCreatePage();

            Button button = new Button();
            button.Text = "-";

            // Act
            NewPage.DamageValueChanged(button, System.EventArgs.Empty);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_ValueChange_Attribute_Value_To_Less_Than_Zero_Should_Return_Zero()
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
        public void ItemCreatePage_ValueChange_Invalid_Attribute_Value_9_To_10_Should_Return_9()
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
        public void ItemCreatePage_ValueChange_Valid_Level_Value_8_To_7_Should_Return_7()
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
        public void ItemCreatePage_ValueChange_Invalid_Level_Value_1_To_0_Should_Return_1()
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
        public void ItemCreatePage_CheckNullEntry_Null_Name_Should_Pass()
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
        //public void ItemCreatePage_Value_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange

        //    page = new ItemCreatePage();
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
        //public void ItemCreatePage_Range_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange

        //    page = new ItemCreatePage();
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
        //public void ItemCreatePage_Damage_OnStepperDamageChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    page = new ItemCreatePage();
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