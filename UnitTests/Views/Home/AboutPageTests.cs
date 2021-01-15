using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.Models;

namespace UnitTests.Views
{
    [TestFixture]
    public class AboutPageTests : AboutPage
    {
        App app;
        AboutPage page;

        // Base Constructor
        public AboutPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new AboutPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void AboutPage_Elements_Get_Set_Should_Pass()
        {
            // Arrange

            // Act
            ((StackLayout)page.FindByName("DatabaseSettingsFrame")).IsVisible = true;
            ((StackLayout)page.FindByName("DebugSettingsFrame")).IsVisible = true;

            ((Switch)page.FindByName("DatabaseSettingsSwitch")).IsVisible = true;
            ((Switch)page.FindByName("DatabaseSettingsSwitch")).IsToggled = true;
            ((Switch)page.FindByName("DatabaseSettingsSwitch")).IsToggled = false;

            ((Switch)page.FindByName("DebugSettingsSwitch")).IsVisible = true;
            ((Switch)page.FindByName("DebugSettingsSwitch")).IsToggled = true;
            ((Switch)page.FindByName("DebugSettingsSwitch")).IsToggled = false;

            ((Switch)page.FindByName("DataSourceValue")).IsVisible = true;
            ((Switch)page.FindByName("DataSourceValue")).IsToggled = true;
            ((Switch)page.FindByName("DataSourceValue")).IsToggled = false;

            ((Label)page.FindByName("CurrentDateTime")).Text = "test";

            ((StackLayout)page.FindByName("DatabaseSettingsFrame")).IsVisible = false;
            ((StackLayout)page.FindByName("DebugSettingsFrame")).IsVisible = false;

            // Reset

            // Assert
            Assert.IsNotNull((StackLayout)page.FindByName("DebugSettingsFrame"));
            Assert.IsNotNull(((StackLayout)page.FindByName("DatabaseSettingsFrame")));

            Assert.IsNotNull((Label)page.FindByName("CurrentDateTime"));

            Assert.IsNotNull((Switch)page.FindByName("DatabaseSettingsSwitch"));
            Assert.IsNotNull((Switch)page.FindByName("DataSourceValue"));
            Assert.IsNotNull((Switch)page.FindByName("DebugSettingsSwitch"));
        }

        [Test]
        public void AboutPage_DatabaseSettingsSwitch_OnToggled_Default_Should_Pass()
        {
            // Arrange

            StackLayout frame = (StackLayout)page.FindByName("DatabaseSettingsFrame");
            var current = frame.IsVisible;

            ToggledEventArgs args = new ToggledEventArgs(current);


            // Act
            page.DatabaseSettingsSwitch_OnToggled(null, args);

            // Reset

            // Assert
            Assert.IsTrue(!current); // Got to here, so it happened...
        }

        [Test]
        public void AboutPage_DebugSettingsSwitch_OnToggled_Default_Should_Pass()
        {
            // Arrange

            StackLayout frame = (StackLayout)page.FindByName("DebugSettingsFrame");
            var current = frame.IsVisible;

            ToggledEventArgs args = new ToggledEventArgs(current);


            // Act
            page.DebugSettingsSwitch_OnToggled(null, args);

            // Reset

            // Assert
            Assert.IsTrue(!current); // Got to here, so it happened...
        }

        [Test]
        public void AboutPage_DataSource_Toggled_Default_Should_Pass()
        {
            // Arrange

            var control = (Switch)page.FindByName("DataSourceValue");
            var current = control.IsToggled;

            ToggledEventArgs args = new ToggledEventArgs(current);

            // Act
            page.DataSource_Toggled(null, args);

            // Reset

            // Assert
            Assert.IsTrue(!current); // Got to here, so it happened...
        }

        [Test]
        public void AboutPage_DataSource_Toggled_False_Should_Pass()
        {
            // Arrange

            var control = (Switch)page.FindByName("DataSourceValue");
            var current = control.IsToggled = false;

            // Act
            control.IsToggled = true;

            var result = control.IsToggled;

            // Reset

            // Assert
            Assert.AreEqual(!current,result); 
        }

        [Test]
        public void AboutPage_DataSource_Toggled_True_Should_Pass()
        {
            // Arrange

            var control = (Switch)page.FindByName("DataSourceValue");
            var current = control.IsToggled = true;

            // Act
            control.IsToggled = false;

            var result = control.IsToggled;

            // Reset

            // Assert
            Assert.AreEqual(!current, result); 
        }

        [Test]
        public void AboutPage_WipeDataList_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.WipeDataList_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public async Task AboutPage_GetItemsGet_Default_Should_Pass()
        {
            // Arrange
            // Act
            var result = await page.GetItemsGet();

            // Reset

            // Assert
            Assert.AreNotEqual("No Results", result); // Got to here, so it happened...
        }

        //[Test]
        //public async Task AboutPage_GetItemsPost_Default_Should_Pass()
        //{
        //    // Arrange
        //    // Act
        //    var result = await page.GetItemsPost();

        //    // Reset

        //    // Assert
        //    Assert.AreNotEqual("No Results", result); // Got to here, so it happened...
        //}

        [Test]
        public void AboutPage_GetItemsGet_Clicked_Default_Should_Pass()
        {
            // Arrange
            
            // Act
            page.GetItemsGet_Command(null,null);

            // Reset

            // Assert
            Assert.AreEqual(true,true); // Got to here, so it happened...
        }

        [Test]
        public void AboutPage_GetItemsPost_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.GetItemsPost_Command(null, null);

            // Reset

            // Assert
            Assert.AreEqual(true, true); // Got to here, so it happened...
        }

        [Test]
        public void AboutPage_RunWipeData_Should_Pass()
        {
            // Arrange

            // Act
            page.RunWipeData();

            // Reset

            // Assert
            Assert.AreEqual(true, true); // Got to here, so it happened...
        }

        [Test]
        public async Task AboutPage_GetItemsGet_BadURL_Should_Fail()
        {
            // Arrange
            var hold = WebGlobalsModel.WebSiteAPIURL;
            WebGlobalsModel.WebSiteAPIURL = "https://bogusurl";

            // Act
            var result = await page.GetItemsGet();

            // Reset
            WebGlobalsModel.WebSiteAPIURL = hold;

            // Assert
            Assert.AreEqual("No Results", result); // Got to here, so it happened...
        }

        [Test]
        public async Task AboutPage_GetItemsGet_Neg_Should_Fail()
        {
            // Arrange

            page.SetServerItemValue("-100");

            // Act
            var result = await page.GetItemsGet();

            // Reset

            // Assert
            Assert.AreEqual("No Results", result); // Got to here, so it happened...
        }

        [Test]
        public async Task AboutPage_GetItemsPost_BadURL_Should_Fail()
        {
            // Arrange
            var hold = WebGlobalsModel.WebSiteAPIURL;
            WebGlobalsModel.WebSiteAPIURL = "https://bogusurl";

            // Act
            var result = await page.GetItemsPost();

            // Reset
            WebGlobalsModel.WebSiteAPIURL = hold;

            // Assert
            Assert.AreEqual("No Results", result); // Got to here, so it happened...
        }

        [Test]
        public async Task AboutPage_GetItemsPost_Neg_Should_Fail()
        {
            // Arrange

            page.SetServerItemValue("-100");

            // Act
            var result = await page.GetItemsPost();

            // Reset

            // Assert
            Assert.AreEqual("No Results", result); // Got to here, so it happened...
        }
    }
}