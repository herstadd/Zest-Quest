using Game.Helpers;
using Game.Models;
using Game.ViewModels;
using System.Diagnostics;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace Game.Views
{
    /// <summary>
    /// Create Item
    /// </summary>
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterCreatePage : ContentPage
    {
        // The item to create
        public GenericViewModel<CharacterModel> ViewModel = new GenericViewModel<CharacterModel>();

        // Empty Constructor for UTs
        public CharacterCreatePage(bool UnitTest){}

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public CharacterCreatePage()
        {
            List<string> locations = ItemLocationEnumHelper.GetAllListItems;

            InitializeComponent();

            this.ViewModel.Data = new CharacterModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Create";

            //Need to make the SelectedItem a string, so it can select the correct item.
            JobPicker.SelectedItem = ViewModel.Data.Job.ToString();

            foreach (string location in locations)
            {
                CallProperImages(ViewModel.Data.Job.ToMessage(), location);
            }
        }

        /// <summary>
        /// Checks if the user enter empty Entry Box for the Name then changes the box color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckNullEntry(object sender, EventArgs e)
        {
            // Setting Name Entry Box background color
            NameEntry.BackgroundColor = Color.FromRgb(255, 179, 0);

            // If the Name in the data box is empty changes the Entry background color
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                NameEntry.BackgroundColor = Color.DarkRed;
            }

            // If the Name in the data box is just white spaces changes the Entry background color
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                NameEntry.BackgroundColor = Color.DarkRed;
            }
        }


        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

            // If the Name in the data box is empty then data won't save 
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                // pop message appears when name box is empty
                await DisplayAlert("Alert", "Name is Empty!", "OK");
                return;
            }

            // If the Name in the data box is just white space then data won't save 
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                // pop message appears when name box is just white spaces
                await DisplayAlert("Alert", "Name is Empty!", "OK");
                return;
            }

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Update Level value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LevelValueChanged(object sender, EventArgs e)
        {
            int NewLevelValue = Int32.Parse(LevelValue.Text);
            int MaxHealth = Int32.Parse(MaxHealthValue.Text);
            LevelValue.Text = ButtonClickedHelper.ValueChange((sender as Button).Text, NewLevelValue, false).ToString();
            MaxHealthValue.Text = ButtonClickedHelper.ValueChange((sender as Button).Text, NewLevelValue, true, MaxHealth).ToString();
        }

        /// <summary>
        /// Update Attack value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AttackValueChanged(object sender, EventArgs e)
        {
            int NewAttackValue = Int32.Parse(AttackValue.Text);
            AttackValue.Text = ButtonClickedHelper.ValueChange((sender as Button).Text, NewAttackValue, false).ToString();
        }

        /// <summary>
        /// Update Defense value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DefenseValueChanged(object sender, EventArgs e)
        {
            int NewDefenseValue = Int32.Parse(DefenseValue.Text);
            DefenseValue.Text = ButtonClickedHelper.ValueChange((sender as Button).Text, NewDefenseValue, false).ToString();
        }

        /// <summary>
        /// Update Speed value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SpeedValueChanged(object sender, EventArgs e)
        {
            int NewSpeedValue = Int32.Parse(SpeedValue.Text);
            SpeedValue.Text = ButtonClickedHelper.ValueChange((sender as Button).Text, NewSpeedValue, false).ToString();
        }

        /// <summary>
        /// Changes the description for a character based on the type that is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TypeChanged(object sender, EventArgs e)
        {
            var selected = (string)JobPicker.SelectedItem;
            List<string> locations = ItemLocationEnumHelper.GetAllListItems;
            int AnyItems = 0;

            Description.Text = CharacterIndexViewModel.Instance.GetSpecialty(selected);
            this.ViewModel.Data.Description = CharacterIndexViewModel.Instance.GetSpecialty(selected);
            PictureSource.Source = CharacterIndexViewModel.Instance.GetImage(selected); 
            ChangeImage.Text = CharacterIndexViewModel.Instance.GetImage(selected);
            LevelValue.Text = CharacterIndexViewModel.Instance.GetLevel(selected).ToString();
            MaxHealthValue.Text = CharacterIndexViewModel.Instance.GetMaxHealth(selected).ToString();
            
            foreach (string location in locations)
            {
                if(CallProperImages(selected, location))
                {
                    AnyItems++;
                }
            }
            if(AnyItems == 0)
            {
                NoItemLabel.HeightRequest = 30;
            }
        }

        /// <summary>
        /// Gets the images to populate the default items characters hold upon creation
        /// </summary>
        /// <param name="data"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool CallProperImages(string job, string location)
        {
            string ItemAtLocation = CharacterIndexViewModel.Instance.GetItemForLocation(job, location);
            ItemModel FoundItem = ItemIndexViewModel.Instance.GetItem(ItemAtLocation);

            if (FoundItem == null)
            {
                switch (location)
                {
                    case "Head":
                        headFrame.WidthRequest = 0;
                        ItemLabel.HeightRequest = 0;
                        break;
                    case "Necklass":
                        necklassFrame.WidthRequest = 0;
                        ItemLabel.HeightRequest = 0;
                        break;
                    case "PrimaryHand":
                        primaryhandFrame.WidthRequest = 0;
                        ItemLabel.HeightRequest = 0;
                        break;
                    case "OffHand":
                        offhandFrame.WidthRequest = 0;
                        ItemLabel.HeightRequest = 0;
                        break;
                    case "RightFinger":
                        rightfingerFrame.WidthRequest = 0;
                        ItemLabel.HeightRequest = 0;
                        break;
                    case "LeftFinger":
                        leftfingerFrame.WidthRequest = 0;
                        ItemLabel.HeightRequest = 0;
                        break;
                    case "Feet":
                        feetFrame.WidthRequest = 0;
                        ItemLabel.HeightRequest = 0;
                        break;
                    default:
                        break;
                }
                return false;
            }

            switch (location)
            {
                case "Head":
                    headFrame.WidthRequest = 120;
                    head.Source = FoundItem.ImageURI;
                    headName.Text = FoundItem.Type.ToMessage();
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "Necklass":
                    necklassFrame.WidthRequest = 120;
                    necklass.Source = FoundItem.ImageURI;
                    necklassName.Text = FoundItem.Type.ToMessage();
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "PrimaryHand":
                    primaryhandFrame.WidthRequest = 120;
                    primaryhand.Source = FoundItem.ImageURI;
                    primaryhandName.Text = FoundItem.Type.ToMessage();
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "OffHand":
                    offhandFrame.WidthRequest = 120;
                    offhand.Source = FoundItem.ImageURI;
                    offhandName.Text = FoundItem.Type.ToMessage();
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "RightFinger":
                    rightfingerFrame.WidthRequest = 120;
                    rightfinger.Source = FoundItem.ImageURI;
                    rightfingerName.Text = FoundItem.Type.ToMessage();
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "LeftFinger":
                    leftfingerFrame.WidthRequest = 120;
                    leftfinger.Source = FoundItem.ImageURI;
                    leftfingerName.Text = FoundItem.Type.ToMessage();
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "Feet":
                    feetFrame.WidthRequest = 120;
                    feet.Source = FoundItem.ImageURI;
                    feetName.Text = FoundItem.Type.ToMessage();
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}