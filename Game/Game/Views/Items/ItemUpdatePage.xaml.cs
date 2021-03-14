using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// Item Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemUpdatePage : ContentPage
    {
        // View Model for Item
        public readonly GenericViewModel<ItemModel> ViewModel;

        // Hold a copy of the original data for Cancel to use
        public ItemModel DataCopy;

        // Empty Constructor for Tests
        public ItemUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public ItemUpdatePage(GenericViewModel<ItemModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            // Make a copy of the character for cancel to restore
            DataCopy = new ItemModel(data.Data);

            //Need to make the SelectedItem a string, so it can select the correct item.
            ItemTypeEntry.SelectedItem = ItemModelEnumExtensions.ToMessage(DataCopy.Type);
            LocationPicker.SelectedItem = ItemLocationEnumExtensions.ToMessage(DataCopy.Location);
            AttributePicker.SelectedItem = DataCopy.Attribute.ToString();
        }

        /// <summary>
        /// Change based on the Name of an Item that is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Type_Changed(object sender, EventArgs e)
        {
            // Change bellow according to our upcoming Item name Enum
            var selected = (String)ItemTypeEntry.SelectedItem;

            // change Description according to the selected Item type
            Description.Text = ItemIndexViewModel.Instance.GetDescription(selected);

            // change Item data Description value according to the selected Item type
            this.ViewModel.Data.Description = ItemIndexViewModel.Instance.GetDescription(selected);

            // change Item Picture source according to the selected Item type
            PictureSource.Source = ItemIndexViewModel.Instance.GetImage(selected);

            // change Item Image according to the selected Item type
            this.ViewModel.Data.ImageURI = ItemIndexViewModel.Instance.GetImage(selected);

            // change Item Type according to the selected Item type
            this.ViewModel.Data.Type = ItemIndexViewModel.Instance.GetType(selected);

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
        /// Save calls to Update
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
            //if (ItemTypeEntry.SelectedIndex == -1)
            //{
            //    // pop message appears when name box is empty
            //    await DisplayAlert("Alert", "Type is Empty!", "OK");
            //    return;
            //}

            // If the Name in the data box is empty changes the Entry background color
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                // pop message appears when name box is empty
                //await DisplayAlert("Alert", "Name is Empty!", "OK");
                return;
            }

            // If the Description in the data box is just white spaces changes the Entry background color
            //if (string.IsNullOrWhiteSpace(ViewModel.Data.Description))
            //{
            //    // pop message appears when name box is empty
            //    await DisplayAlert("Alert", "Description is Empty!", "OK");
            //    return;
            //}

            //Comment out bellow if condititions cause 
            //It is Not possible to leave Location and Attribute blank and save the update because
            // Description alart pop-up (needs to set type to get Description and type and Attribtuion)

            //If the Location in the data box is just white space then data won't save 
            //if (LocationPicker.SelectedIndex == -1)
            //{
            //    pop message appears when name box is just white spaces
            //   await DisplayAlert("Alert", "Location is Empty!", "OK");
            //    return;
            //}

            //If the Attribute in the data box is just white space then data won't save 
            //if (AttributePicker.SelectedIndex == -1)
            //{
            //    pop message appears when name box is just white spaces
            //   await DisplayAlert("Alert", "Attribute is Empty!", "OK");
            //    return;
            //}

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