﻿using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Create Item
    /// </summary>
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemCreatePage : ContentPage
    {
        // The item to create
        public GenericViewModel<ItemModel> ViewModel = new GenericViewModel<ItemModel>();

        // Empty Constructor for UTs
        public ItemCreatePage(bool UnitTest){}

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public ItemCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new ItemModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Create Gadget";

            //Need to make the SelectedItem a string, so it can select the correct item.
            ItemTypeEntry.SelectedItem = ItemModelEnum.RingPop.ToMessage();
        }

        /// <summary>
        /// Change based on the Name of an Item that is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Type_Changed(object sender, EventArgs e)
        {
            // Change bellow according to our upcoming Item name Enum

            //var selected = (String) ItemTypeEntry.SelectedItem;
            var selected = (sender as Picker).SelectedItem.ToString();

            // change Description according to the selected Item type
            Description.Text = ItemIndexViewModel.Instance.GetDescription(selected);

            // change Item data Description value according to the selected Item type
            this.ViewModel.Data.Description = ItemIndexViewModel.Instance.GetDescription(selected);

            // change Item Picture source according to the selected Item type
            PictureSource.Source = ItemIndexViewModel.Instance.GetImage(selected);

            // change Item Image according to the selected Item type
            this.ViewModel.Data.ImageURI = ItemIndexViewModel.Instance.GetImage(selected);

            // change Item Type according to the selected Item type
            ItemTypeEntry.SelectedItem = ItemIndexViewModel.Instance.GetType(selected).ToMessage();

            // Location
            LocationPicker.SelectedItem = ItemIndexViewModel.Instance.GetLocation(selected).ToMessage();
            
            // Attribute
            AttributePicker.SelectedItem = ItemIndexViewModel.Instance.GetAttribute(selected).ToMessage();

            // change Item Range value text according to the selected Item type in the Create Page
            RangeValue.Text = ItemIndexViewModel.Instance.GetValues(selected, "Range").ToString();

            // change Item Damage value text according to the selected Item type in the Create Page
            DamageValue.Text = ItemIndexViewModel.Instance.GetValues(selected, "Damage").ToString();

            // change Item value text according to the selected Item type in the Create Page
            ValueValue.Text = ItemIndexViewModel.Instance.GetValues(selected, "Value").ToString();
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
            
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
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
        /// Update Range value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RangeValueChanged(object sender, EventArgs e)
        {
            int NewAttackValue = Int32.Parse(RangeValue.Text);
            RangeValue.Text = ValueChange((sender as Button).Text, NewAttackValue, false).ToString();
        }

        /// <summary>
        /// Update Value value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ValueValueChanged(object sender, EventArgs e)
        {
            int NewAttackValue = Int32.Parse(ValueValue.Text);
            ValueValue.Text = ValueChange((sender as Button).Text, NewAttackValue, false).ToString();
        }

        /// <summary>
        /// Update Damge value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DamageValueChanged(object sender, EventArgs e)
        {
            int NewAttackValue = Int32.Parse(DamageValue.Text);
            DamageValue.Text = ValueChange((sender as Button).Text, NewAttackValue, false).ToString();
        }

        /// <summary>
        /// Change Stat value
        /// </summary>
        /// <param name="ButtonText"></param>
        /// <param name="num"></param>
        /// <param name="IsLevel"></param>
        /// <returns></returns>
        public int ValueChange(String ButtonText, int num, bool IsLevel)
        {
            if (ButtonText.Equals("-"))
            {
                num--;
                if (IsLevel)
                {
                    return num < 1 ? 1 : num;
                }
                else
                {
                    return num < 0 ? 0 : num;
                }
            }
            else
            {
                num++;
                return num > 9 ? 9 : num;
            }
        }

        /// <summary>
        /// Checks if the user enter empty Entry Box for the Name then changes the box color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckNullEntry(object sender, EventArgs e)
        {
            ItemNameEntry.BackgroundColor = Color.FromRgb(255, 179, 0);

            // If the Name in the data box is empty changes the Entry background color
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                ItemNameEntry.BackgroundColor = Color.DarkRed;
            }

            // If the Name in the data box is just white spaces changes the Entry background color
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                ItemNameEntry.BackgroundColor = Color.DarkRed;
            }
        }
    }
}