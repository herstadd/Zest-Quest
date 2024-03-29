﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Helpers;

using Game.ViewModels;
using Game.Models;
using System.Collections.Generic;

namespace Game.Views
{
    /// <summary>
    /// Item Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterUpdatePage : ContentPage
    {
        // View Model for Item
        public readonly GenericViewModel<CharacterModel> ViewModel;

        // Hold a copy of the original data for Cancel to use
        public CharacterModel DataCopy;

        // Empty Constructor for Tests
        public CharacterUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public CharacterUpdatePage(GenericViewModel<CharacterModel> data)
        {
            List<string> locations = GetInitialLocations(data.Data);
            List<string> items = GetInitialItems(data.Data);

            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            // Make a copy of the character for cancel to restore
            DataCopy = new CharacterModel(data.Data);

            //Need to make the SelectedItem a string, so it can select the correct item.
            JobPicker.SelectedItem = ViewModel.Data.Job.ToMessage();

            ViewModel.Data.Update(DataCopy);

            // Restores previous max health instead of recalculating
            MaxHealthValue.Text = DataCopy.MaxHealth.ToString();

            RemoveAllItems();
            MakeAllItemsInvisible();

            NewItemPicker.SelectedItem = "Chef Hat";

            for (int i = 0; i < locations.Count; i++)
            {
                PopulateInitialItems(locations[i], items[i], ViewModel.Data);
            }
        }

        /// <summary>
        /// Gets the initial items for the character model passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<string> GetInitialItems(CharacterModel data)
        {
            List<string> locations = new List<string>();
            if (data.Head != null) locations.Add(data.Head);
            if (data.Necklass != null) locations.Add(data.Necklass);
            if (data.PrimaryHand != null) locations.Add(data.PrimaryHand);
            if (data.OffHand != null) locations.Add(data.OffHand);
            if (data.Feet != null) locations.Add(data.Feet);
            if (data.RightFinger != null) locations.Add(data.RightFinger);
            if (data.LeftFinger != null) locations.Add(data.LeftFinger);
            return locations;
        }

        /// <summary>
        /// Gets the initial item locations for the character model passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<string> GetInitialLocations(CharacterModel data)
        {
            List<string> locations = new List<string>();
            if (data.Head != null) locations.Add("Head");
            if (data.Necklass != null) locations.Add("Necklass");
            if (data.PrimaryHand != null) locations.Add("PrimaryHand");
            if (data.OffHand != null) locations.Add("OffHand");
            if (data.Feet != null) locations.Add("Feet");
            if (data.RightFinger != null) locations.Add("RightFinger");
            if (data.LeftFinger != null) locations.Add("LeftFinger");
            return locations;
        }

        /// <summary>
        /// Removes all items from the view model
        /// </summary>
        public void RemoveAllItems() 
        {
            ViewModel.Data.RemoveItem(ItemLocationEnum.Head);
            ViewModel.Data.RemoveItem(ItemLocationEnum.Necklass);
            ViewModel.Data.RemoveItem(ItemLocationEnum.PrimaryHand);
            ViewModel.Data.RemoveItem(ItemLocationEnum.OffHand);
            ViewModel.Data.RemoveItem(ItemLocationEnum.Feet);
            ViewModel.Data.RemoveItem(ItemLocationEnum.RightFinger);
            ViewModel.Data.RemoveItem(ItemLocationEnum.LeftFinger);
        }

        /// <summary>
        /// Makes all the items invisible on the UI
        /// </summary>
        public void MakeAllItemsInvisible()
        {
            headFrame.IsVisible = false;
            necklassFrame.IsVisible = false;
            primaryhandFrame.IsVisible = false;
            offhandFrame.IsVisible = false;
            rightfingerFrame.IsVisible = false;
            leftfingerFrame.IsVisible = false;
            feetFrame.IsVisible = false;
        }

        /// <summary>
        /// Populates the initial items and makes them visible to the UI
        /// </summary>
        /// <param name="location"></param>
        /// <param name="item"></param>
        /// <param name="data"></param>
        public void PopulateInitialItems(string location, string item, CharacterModel data)
        {
            switch (location)
            {
                case "Head":
                    ViewModel.Data.Head = item;
                    headFrame.IsVisible = true;
                    headFrame.WidthRequest = 120;
                    head.Source = ItemIndexViewModel.Instance.GetImage(item);
                    headName.Text = item;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "Necklass":
                    ViewModel.Data.Necklass = item;
                    necklassFrame.IsVisible = true;
                    necklassFrame.WidthRequest = 120;
                    necklass.Source = ItemIndexViewModel.Instance.GetImage(item);
                    necklassName.Text = item;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "PrimaryHand":
                    ViewModel.Data.PrimaryHand = item;
                    primaryhandFrame.IsVisible = true;
                    primaryhandFrame.WidthRequest = 120;
                    primaryhand.Source = ItemIndexViewModel.Instance.GetImage(item);
                    primaryhandName.Text = item;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "OffHand":
                    ViewModel.Data.OffHand = item;
                    offhandFrame.IsVisible = true;
                    offhandFrame.WidthRequest = 120;
                    offhand.Source = ItemIndexViewModel.Instance.GetImage(item);
                    offhandName.Text = item;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "RightFinger":
                    ViewModel.Data.RightFinger = item;
                    rightfingerFrame.IsVisible = true;
                    rightfingerFrame.WidthRequest = 120;
                    rightfinger.Source = ItemIndexViewModel.Instance.GetImage(item);
                    rightfingerName.Text = item;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "LeftFinger":
                    ViewModel.Data.LeftFinger = item;
                    leftfingerFrame.IsVisible = true;
                    leftfingerFrame.WidthRequest = 120;
                    leftfinger.Source = ItemIndexViewModel.Instance.GetImage(item);
                    leftfingerName.Text = item;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
                case "Feet":
                    ViewModel.Data.Feet = item;
                    feetFrame.IsVisible = true;
                    feetFrame.WidthRequest = 120;
                    feet.Source = ItemIndexViewModel.Instance.GetImage(item);
                    feetName.Text = item;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    break;
            }
        }

        /// <summary>
        /// Changes the name of the Character when updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NameChanged(object sender, EventArgs e)
        {
            ViewModel.Data.Name = CharacterName.Text;

            // Setting Name Entry Box background color
            CharacterName.BackgroundColor = Color.FromRgb(255, 179, 0);

            // If the Name in the data box is empty changes the Entry background color
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                CharacterName.BackgroundColor = Color.DarkRed;
            }

            // If the Name in the data box is just white spaces changes the Entry background color
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                CharacterName.BackgroundColor = Color.DarkRed;
            }
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Update_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

            // If the Name in the data box is just white space then data won't update 
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                return;
            }

            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            // Put the copy back
            ViewModel.Data.Update(DataCopy);

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
        /// Change the description of the character when the type dropdown is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TypeChanged(object sender, EventArgs e)
        {
            var selected = (string)((Picker)sender).SelectedItem;
            List<string> locations = ItemLocationEnumHelper.GetAllListItems;
            int AnyItems = 0;

            this.ViewModel.Data.Description = CharacterIndexViewModel.Instance.GetSpecialty(selected);
            Description.Text = CharacterIndexViewModel.Instance.GetSpecialty(selected);
            PictureSource.Source = CharacterIndexViewModel.Instance.GetImage(selected);
            ChangeImage.Text = CharacterIndexViewModel.Instance.GetImage(selected);
            LevelValue.Text = CharacterIndexViewModel.Instance.GetLevel(selected).ToString();
            MaxHealthValue.Text = CharacterIndexViewModel.Instance.GetMaxHealth(selected).ToString();

            foreach (string location in locations)
            {
                if (CallProperImages(selected, location))
                {
                    AnyItems++;
                }
            }
            if (AnyItems == 0)
            {
                NoItemLabel.HeightRequest = 0;
                ItemLabel.HeightRequest = 30;
            }
            else
            {
                ItemLabel.HeightRequest = 30;
            }
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
        /// Update Max Health value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MaxHealthValueChanged(object sender, EventArgs e)
        {
            int NewMaxHealthValue = Int32.Parse(MaxHealthValue.Text);
            MaxHealthValue.Text = ButtonClickedHelper.ValueChange((sender as Button).Text, NewMaxHealthValue, false).ToString();
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
            }
            return true;
        }

        /// <summary>
        /// Hooks up item removal confirmation equipping and front end
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickedOnItemSelection(object sender, EventArgs e)
        {
            if ((sender as Button).Text.Equals("Confirm"))
            {
                switch ((sender as Button).BindingContext)
                {
                    case "Head":
                        headFrame.IsVisible = false;
                        NoItemLabel.HeightRequest = 0;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.Head);
                        break;
                    case "Necklass":
                        necklassFrame.IsVisible = false;
                        NoItemLabel.HeightRequest = 0;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.Necklass);
                        break;
                    case "PrimaryHand":
                        primaryhandFrame.IsVisible = false;
                        NoItemLabel.HeightRequest = 0;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.PrimaryHand);
                        break;
                    case "OffHand":
                        offhandFrame.IsVisible = false;
                        NoItemLabel.HeightRequest = 0;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.OffHand);
                        break;
                    case "Feet":
                        feetFrame.IsVisible = false;
                        NoItemLabel.HeightRequest = 0;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.Feet);
                        break;
                    case "RightFinger":
                        rightfingerFrame.IsVisible = false;
                        NoItemLabel.HeightRequest = 0;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.RightFinger);
                        break;
                    case "LeftFinger":
                        leftfingerFrame.IsVisible = false;
                        NoItemLabel.HeightRequest = 0;
                        ViewModel.Data.RemoveItem(ItemLocationEnum.LeftFinger);
                        break;
                    default:
                        break;
                }
            }

            ItemConfirmBox.IsVisible = false;
        }

        /// <summary>
        /// Hooks the binding context up to the clicked on item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickedOnItem(object sender, EventArgs e)
        {
            ItemConfirmBox.IsVisible = true;

            switch ((sender as Button).BindingContext)
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

        /// <summary>
        /// Adds the clicked on item to the character and displays on UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddItemButtonClicked(object sender, EventArgs e)
        {
            if (!(((Button)sender).BindingContext is string))
            {
                return;
            }
            string selected = (string)((Button)sender).BindingContext;

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
                case "Primary Hand":
                    primaryhandFrame.IsVisible = true;
                    primaryhandFrame.WidthRequest = 120;
                    primaryhand.Source = ItemIndexViewModel.Instance.GetImage(selected);
                    primaryhandName.Text = selected;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.RemoveItem(ItemLocationEnum.PrimaryHand);
                    ViewModel.Data.AddItem(ItemLocationEnum.PrimaryHand, selected);
                    break;
                case "Off Hand":
                    offhandFrame.IsVisible = true;
                    offhandFrame.WidthRequest = 120;
                    offhand.Source = ItemIndexViewModel.Instance.GetImage(selected);
                    offhandName.Text = selected;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.RemoveItem(ItemLocationEnum.OffHand);
                    ViewModel.Data.AddItem(ItemLocationEnum.OffHand, selected);
                    break;
                case "Right Finger":
                    rightfingerFrame.IsVisible = true;
                    rightfingerFrame.WidthRequest = 120;
                    rightfinger.Source = ItemIndexViewModel.Instance.GetImage(selected);
                    rightfingerName.Text = selected;
                    ItemLabel.HeightRequest = 30;
                    NoItemLabel.HeightRequest = 0;
                    ViewModel.Data.RemoveItem(ItemLocationEnum.RightFinger);
                    ViewModel.Data.AddItem(ItemLocationEnum.RightFinger, selected);
                    break;
                case "Left Finger":
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
            }
        }

        /// <summary>
        /// Sets the picked item 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ItemSelected(object sender, EventArgs e)
        {
            string picked = ((ItemModel)((Picker)sender).SelectedItem).Name;
            AddItemButton.BindingContext = picked;
        }
    }
}