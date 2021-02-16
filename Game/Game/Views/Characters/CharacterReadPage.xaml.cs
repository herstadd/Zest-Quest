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

        /// <summary>
        /// Gets the images to populate the default items characters hold upon creation
        /// </summary>
        /// <param name="data"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool CallProperImages(GenericViewModel<CharacterModel> data, string location)
        {
            switch(location)
            {
                case "Head":
                    if(data.Data.Head is null)
                    {
                        break;
                    }
                    headFrame.WidthRequest = 120;
                    head.Source = ItemIndexViewModel.Instance.GetImage(data.Data.Head);
                    headName.Text = data.Data.Head;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "Necklass":
                    if (data.Data.Necklass is null)
                    {
                        break;
                    }
                    necklassFrame.WidthRequest = 120;
                    necklass.Source = ItemIndexViewModel.Instance.GetImage(data.Data.Necklass);
                    necklassName.Text = data.Data.Necklass;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "PrimaryHand":
                    if (data.Data.PrimaryHand is null)
                    {
                        break;
                    }
                    primaryhandFrame.WidthRequest = 120;
                    primaryhand.Source = ItemIndexViewModel.Instance.GetImage(data.Data.PrimaryHand);
                    primaryhandName.Text = data.Data.PrimaryHand;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "OffHand":
                    if (data.Data.OffHand is null)
                    {
                        break;
                    }
                    offhandFrame.WidthRequest = 120;
                    offhand.Source = ItemIndexViewModel.Instance.GetImage(data.Data.OffHand);
                    offhandName.Text = data.Data.OffHand;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "RightFinger":
                    if (data.Data.RightFinger is null)
                    {
                        break;
                    }
                    rightfingerFrame.WidthRequest = 120;
                    rightfinger.Source = ItemIndexViewModel.Instance.GetImage(data.Data.RightFinger);
                    rightfingerName.Text = data.Data.RightFinger;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "LeftFinger":
                    if (data.Data.LeftFinger is null)
                    {
                        break;
                    }
                    leftfingerFrame.WidthRequest = 120;
                    leftfinger.Source = ItemIndexViewModel.Instance.GetImage(data.Data.LeftFinger);
                    leftfingerName.Text = data.Data.LeftFinger;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "Feet":
                    if (data.Data.Feet is null)
                    {
                        break;
                    }
                    feetFrame.WidthRequest = 120;
                    feet.Source = ItemIndexViewModel.Instance.GetImage(data.Data.Feet);
                    feetName.Text = data.Data.Feet;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
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