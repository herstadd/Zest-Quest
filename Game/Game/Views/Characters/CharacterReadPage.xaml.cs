using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;
using System.Diagnostics;
using System.Collections.Generic;

namespace Game.Views
{
    /// <summary>
    /// The Read Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterReadPage : ContentPage
    {
        // View Model for Item
        public readonly GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for UTs
        public CharacterReadPage(bool UnitTest) { }

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        /// <param name="viewModel"></param>
        public CharacterReadPage(GenericViewModel<CharacterModel> data)
        {

            List<string> locations = ItemLocationEnumHelper.GetAllListItems;

            InitializeComponent();

            BindingContext = this.ViewModel = data;

            foreach(string location in locations)
            {
                CallProperImages(data, location);
            }
        }

        public bool CallProperImages(GenericViewModel<CharacterModel> data, string location)
        {
            if(data == null)
            {
                return false;
            }
            
            string ItemAtLocation = CharacterIndexViewModel.Instance.GetItemForLocation(data.Data.Job.ToString(), location);
            ItemModel FoundItem = ItemIndexViewModel.Instance.GetItem(ItemAtLocation);
            
            if(FoundItem == null)
            {
                return false;
            }

            switch(location)
            {
                case "Head":
                    headFrame.WidthRequest = 120;
                    head.Source = FoundItem.ImageURI;
                    headName.Text = FoundItem.Name;
                    break;
                case "Necklass":
                    necklassFrame.WidthRequest = 120;
                    necklass.Source = FoundItem.ImageURI;
                    necklassName.Text = FoundItem.Name;
                    break;
                case "PrimaryHand":
                    primaryhandFrame.WidthRequest = 120;
                    primaryhand.Source = FoundItem.ImageURI;
                    primaryhandName.Text = FoundItem.Name;
                    break;
                case "OffHand":
                    offhandFrame.WidthRequest = 120;
                    offhand.Source = FoundItem.ImageURI;
                    offhandName.Text = FoundItem.Name;
                    break;
                case "RightFinger":
                    rightfingerFrame.WidthRequest = 120;
                    rightfinger.Source = FoundItem.ImageURI;
                    rightfingerName.Text = FoundItem.Name;
                    break;
                case "LeftFinger":
                    leftfingerFrame.WidthRequest = 120;
                    leftfinger.Source = FoundItem.ImageURI;
                    leftfingerName.Text = FoundItem.Name;
                    break;
                case "Feet":
                    feetFrame.WidthRequest = 120;
                    feet.Source = FoundItem.ImageURI;
                    feetName.Text = FoundItem.Name;
                    break;
                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterUpdatePage(ViewModel)));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Calls for Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterDeletePage(ViewModel)));
            await Navigation.PopAsync();
        }
    }
}