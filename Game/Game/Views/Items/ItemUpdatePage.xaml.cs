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

            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = data.Data.Location.ToString();
            AttributePicker.SelectedItem = data.Data.Attribute.ToString();
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