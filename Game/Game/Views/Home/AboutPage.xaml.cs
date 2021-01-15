using Game.Helpers;
using Game.Models;
using Game.Services;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// About Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        // Constructor for UnitTests
        public AboutPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for About Page
        /// </summary>
        public AboutPage()
        {
            InitializeComponent();

            // Hide the Debug Settings
            DatabaseSettingsFrame.IsVisible = false;

            // Turn off the Settings Frame
            DebugSettingsFrame.IsVisible = false;

            // Set to the curent date and time
            CurrentDateTime.Text = DateTime.Now.ToString("MM/dd/yy hh:mm:ss");

            // Init the Server Item Value to 100 to get everything
            SetServerItemValue("100");
        }

        /// <summary>
        /// Show or hide the Database Frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DatabaseSettingsSwitch_OnToggled(object sender, ToggledEventArgs e)
        {
            // Show or hide the Database Section
            DatabaseSettingsFrame.IsVisible = (e.Value);
        }

        /// <summary>
        /// Sow or hide the Debug Settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DebugSettingsSwitch_OnToggled(object sender, ToggledEventArgs e)
        {
            // Show or hide the Debug Settings
            DebugSettingsFrame.IsVisible = (e.Value);
        }

        /// <summary>
        /// Data Source Toggle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DataSource_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (DataSourceValue.IsToggled == true)
            {
                MessagingCenter.Send(this, "SetDataSource", 1);
            }
            else
            {
                MessagingCenter.Send(this, "SetDataSource", 0);
            }
        }

        /// <summary>
        /// Button to delete the data store
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void WipeDataList_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Delete Data", "Are you sure you want to delete all data?", "Yes", "No");
            if (answer)
            {
                RunWipeData();
            }
        }

        public void RunWipeData()
        {
            Task.Run(async () => { await DataSetsHelper.WipeDataInSequence(); });
        }

        /// <summary>
        /// Example of how to call for Items using HttpGet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void GetItemsGet_Command(object sender, EventArgs e)
        {
            var result = await GetItemsGet();
            await DisplayServerResults(result);
        }

        /// <summary>
        /// Set the value for the Server Item
        /// </summary>
        /// <param name="value"></param>
        public void SetServerItemValue(string value)
        {
            ServerItemValue.Text = value;
        }

        /// <summary>
        /// Call the server call for Get Items using HTTP Get
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetItemsGet()
        {
            // Call to the ItemModel Service and have it Get the Items
            // The ServerItemValue Code stands for the batch of items to get
            // as the group to request.  1, 2, 3, 100 (All), or if not specified All

            var result = "No Results";

            var value = Convert.ToInt32(ServerItemValue.Text);
            var dataList = await ItemService.GetItemsFromServerGetAsync(value);

            if (dataList == null)
            {
                return result;
            }

            if (dataList.Count == 0)
            {
                return result;
            }

            // Reset the output
            result = "";

            foreach (var ItemModel in dataList)
            {
                // Add them line by one, use \n to force new line for output display.
                // Build up the output string by adding formatted ItemModel Output
                result += ItemModel.FormatOutput() + "\n";
            }

            return result;
        }

        /// <summary>
        /// Example of how to call for Items using Http Post
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void GetItemsPost_Command(object sender, EventArgs e)
        {
            var result = await GetItemsPost();
            await DisplayServerResults(result);
        }

        /// <summary>
        /// Show the Results of the server call
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task DisplayServerResults(string result)
        {
            await DisplayAlert("Returned List", result, "OK");
        }

        /// <summary>
        /// Get Items using the HTTP Post command
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetItemsPost()
        {
            var result = "No Results";
            var dataList = new List<ItemModel>();

            var number = Convert.ToInt32(ServerItemValue.Text);
            var level = 6;  // Max Value of 6
            var attribute = AttributeEnum.Unknown;  // Any Attribute
            var location = ItemLocationEnum.Unknown;    // Any Location
            var random = true;  // Random between 1 and Level
            var updateDataBase = true;  // Add them to the DB
            var category = 0;   // What category to filter down to, 0 is all

            // will return shoes value 10 of speed.
            // Example  result = await ItemsController.Instance.GetItemsFromGame(1, 10, AttributeEnum.Speed, ItemLocationEnum.Feet, false, true);
            dataList = await ItemService.GetItemsFromServerPostAsync(number, level, attribute, location, category, random, updateDataBase);

            // Null not possible, returns empty instead
            //if (dataList == null)
            //{
            //    return result;
            //}

            if (dataList.Count == 0)
            {
                return result;
            }

            // Reset the output
            result = "";

            foreach (var ItemModel in dataList)
            {
                // Add them line by one, use \n to force new line for output display.
                result += ItemModel.FormatOutput() + "\n";
            }

            return result;
        }
    }
}