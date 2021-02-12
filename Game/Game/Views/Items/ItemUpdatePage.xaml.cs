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
            LocationPicker.SelectedItem = data.Data.Location.ToString();
            AttributePicker.SelectedItem = data.Data.Attribute.ToString();
            ItemTypeEntry.SelectedItem = ViewModel.Data.Type.ToString();
        }

        /// <summary>
        /// Change based on the Name of an Item that is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Type_Changed(object sender, EventArgs e)
        {
            // Change bellow according to our upcoming Item name Enum
            var selected = ItemModelEnumHelper.ConvertStringToEnum((String)ItemTypeEntry.SelectedItem);
            ViewModel.Data.Type = selected;
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

            // If the Description in the data box is empty changes the Entry background color
            if (string.IsNullOrEmpty(ViewModel.Data.Description))
            {
                // pop message appears when name box is empty
                await DisplayAlert("Alert", "Description is Empty!", "OK");
                return;
            }

            // If the Description in the data box is just white spaces changes the Entry background color
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Description))
            {
                // pop message appears when name box is empty
                await DisplayAlert("Alert", "Description is Empty!", "OK");
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
        private int ValueChange(String ButtonText, int num, bool IsLevel)
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
    }
}