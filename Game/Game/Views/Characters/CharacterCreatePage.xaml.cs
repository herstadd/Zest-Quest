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
                ItemLabel.HeightRequest = 0;
            } else
            {
                ItemLabel.HeightRequest = 30;
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

            if (ItemAtLocation == null)
            {
                switch (location)
                {
                    case "Head":
                        headFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.Head);
                        break;
                    case "Necklass":
                        necklassFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.Necklass);
                        break;
                    case "PrimaryHand":
                        primaryhandFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.PrimaryHand);
                        break;
                    case "OffHand":
                        offhandFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.OffHand);
                        break;
                    case "RightFinger":
                        rightfingerFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.RightFinger);
                        break;
                    case "LeftFinger":
                        leftfingerFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.LeftFinger);
                        break;
                    case "Feet":
                        feetFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.Feet);
                        break;
                    default:
                        break;
                }
                return false;
            }

            switch (location)
            {
                case "Head":
                    headFrame.IsVisible = true;
                    headFrame.WidthRequest = 120;
                    head.Source = ItemIndexViewModel.Instance.GetImage(ItemAtLocation);
                    headName.Text = ItemAtLocation;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.AddItem(ItemLocationEnum.Head, ItemAtLocation);
                    break;
                case "Necklass":
                    necklassFrame.IsVisible = true;
                    necklassFrame.WidthRequest = 120;
                    necklass.Source = ItemIndexViewModel.Instance.GetImage(ItemAtLocation);
                    necklassName.Text = ItemAtLocation;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.AddItem(ItemLocationEnum.Necklass, ItemAtLocation);
                    break;
                case "PrimaryHand":
                    primaryhandFrame.IsVisible = true;
                    primaryhandFrame.WidthRequest = 120;
                    primaryhand.Source = ItemIndexViewModel.Instance.GetImage(ItemAtLocation);
                    primaryhandName.Text = ItemAtLocation;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.AddItem(ItemLocationEnum.PrimaryHand, ItemAtLocation);
                    break;
                case "OffHand":
                    offhandFrame.IsVisible = true;
                    offhandFrame.WidthRequest = 120;
                    offhand.Source = ItemIndexViewModel.Instance.GetImage(ItemAtLocation);
                    offhandName.Text = ItemAtLocation;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.AddItem(ItemLocationEnum.OffHand, ItemAtLocation);
                    break;
                case "RightFinger":
                    rightfingerFrame.IsVisible = true;
                    rightfingerFrame.WidthRequest = 120;
                    rightfinger.Source = ItemIndexViewModel.Instance.GetImage(ItemAtLocation);
                    rightfingerName.Text = ItemAtLocation;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.AddItem(ItemLocationEnum.RightFinger, ItemAtLocation);
                    break;
                case "LeftFinger":
                    leftfingerFrame.IsVisible = true;
                    leftfingerFrame.WidthRequest = 120;
                    leftfinger.Source = ItemIndexViewModel.Instance.GetImage(ItemAtLocation);
                    leftfingerName.Text = ItemAtLocation;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.AddItem(ItemLocationEnum.LeftFinger, ItemAtLocation);
                    break;
                case "Feet":
                    feetFrame.IsVisible = true;
                    feetFrame.WidthRequest = 120;
                    feet.Source = ItemIndexViewModel.Instance.GetImage(ItemAtLocation);
                    feetName.Text = ItemAtLocation;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.AddItem(ItemLocationEnum.Feet, ItemAtLocation);
                    break;
                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickedOnItemSelection(object sender, EventArgs e)
        {
            if((sender as Button).Text.Equals("Confirm"))
            {
                switch((sender as Button).BindingContext)
                {
                    case "Head":
                        headFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.Head);
                        break;
                    case "Necklass":
                        necklassFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.Necklass);
                        break;
                    case "PrimaryHand":
                        primaryhandFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.PrimaryHand);
                        break;
                    case "OffHand":
                        offhandFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.OffHand);
                        break;
                    case "Feet":
                        feetFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.Feet);
                        break;
                    case "RightFinger":
                        rightfingerFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.RightFinger);
                        break;
                    case "LeftFinger":
                        leftfingerFrame.IsVisible = false;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.LeftFinger);
                        break;
                    default:
                        break;
                }
            }
            
            ItemConfirmBox.IsVisible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickedOnItem(object sender, EventArgs e)
        {
            ItemConfirmBox.IsVisible = true;

            switch((sender as Button).BindingContext)
            {
                case "Head":
                    ConfirmButton.BindingContext = "Head";
                    break;
                case "Necklass":
                    ConfirmButton.BindingContext = "Necklass";
                    break;
                case "PrimaryHand":
                    ConfirmButton.BindingContext = "PrimaryHand";
                    break;
                case "OffHand":
                    ConfirmButton.BindingContext = "OffHand";
                    break;
                case "Feet":
                    ConfirmButton.BindingContext = "Feet";
                    break;
                case "RightFinger":
                    ConfirmButton.BindingContext = "RightFinger";
                    break;
                case "LeftFinger":
                    ConfirmButton.BindingContext = "LeftFinger";
                    break;
                default:
                    break;
            }
        }

        private void AddItemButtonClicked(object sender, EventArgs e)
        {
            string selected = (string)NewItemPicker.SelectedItem;
            if (selected is null)
            {
                return;
            }
            //Debug.Print(selected);
            ItemModel FoundItem = ItemIndexViewModel.Instance.GetItem(selected, true);
            switch (FoundItem.Location.ToMessage())
            {
                case "Head":
                    headFrame.IsVisible = true;
                    headFrame.WidthRequest = 120;
                    head.Source = ItemIndexViewModel.Instance.GetImage(selected);
                    headName.Text = selected;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.RemoveItem(ItemLocationEnum.Head);
                    ViewModel.Data.AddItem(ItemLocationEnum.Head, selected);
                    break;
                case "Necklass":
                    necklassFrame.IsVisible = true;
                    necklassFrame.WidthRequest = 120;
                    necklass.Source = ItemIndexViewModel.Instance.GetImage(selected);
                    necklassName.Text = selected;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.RemoveItem(ItemLocationEnum.Necklass);
                    ViewModel.Data.AddItem(ItemLocationEnum.Necklass, selected);
                    break;
                case "PrimaryHand":
                    primaryhandFrame.IsVisible = true;
                    primaryhandFrame.WidthRequest = 120;
                    primaryhand.Source = ItemIndexViewModel.Instance.GetImage(selected);
                    primaryhandName.Text = selected;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.RemoveItem(ItemLocationEnum.PrimaryHand);
                    ViewModel.Data.AddItem(ItemLocationEnum.PrimaryHand, selected);
                    break;
                case "OffHand":
                    offhandFrame.IsVisible = true;
                    offhandFrame.WidthRequest = 120;
                    offhand.Source = ItemIndexViewModel.Instance.GetImage(selected);
                    offhandName.Text = selected;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.RemoveItem(ItemLocationEnum.OffHand);
                    ViewModel.Data.AddItem(ItemLocationEnum.OffHand, selected);
                    break;
                case "RightFinger":
                    rightfingerFrame.IsVisible = true;
                    rightfingerFrame.WidthRequest = 120;
                    rightfinger.Source = ItemIndexViewModel.Instance.GetImage(selected);
                    rightfingerName.Text = selected;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.RemoveItem(ItemLocationEnum.RightFinger);
                    ViewModel.Data.AddItem(ItemLocationEnum.RightFinger, selected);
                    break;
                case "LeftFinger":
                    leftfingerFrame.IsVisible = true;
                    leftfingerFrame.WidthRequest = 120;
                    leftfinger.Source = ItemIndexViewModel.Instance.GetImage(selected);
                    leftfingerName.Text = selected;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.RemoveItem(ItemLocationEnum.LeftFinger);
                    ViewModel.Data.AddItem(ItemLocationEnum.LeftFinger, selected);
                    break;
                case "Feet":
                    feetFrame.IsVisible = true;
                    feetFrame.WidthRequest = 120;
                    feet.Source = ItemIndexViewModel.Instance.GetImage(selected);
                    feetName.Text = selected;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.RemoveItem(ItemLocationEnum.Feet);
                    ViewModel.Data.AddItem(ItemLocationEnum.Feet, selected);
                    break;
                default:
                    break;
            }
        }
    }
}