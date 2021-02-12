using Game.Models;
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

            this.ViewModel.Title = "Create";

            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = ViewModel.Data.Location.ToString();
            AttributePicker.SelectedItem = ViewModel.Data.Attribute.ToString();
        }

        /// <summary>
        /// Change based on the Name of an Item that is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Name_Changed(object sender, EventArgs e)
        {
            // Change bellow according to our upcoming Item name Enum
            var selected = MonsterJobEnumHelper.ConvertStringToEnum((String)ItemNameEntry.SelectedItem);
            ViewModel.Data.Name = MonsterJobEnumExtensions.ToMessage(selected);
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
            if (ItemNameEntry.SelectedIndex == -1)
            {
                // pop message appears when name box is empty
                await DisplayAlert("Alert", "Name is Empty!", "OK");
                return;
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

            // If the Location in the data box is just white space then data won't save 
            if (LocationPicker.SelectedIndex == -1)
            {
                // pop message appears when name box is just white spaces
                await DisplayAlert("Alert", "Location is Empty!", "OK");
                return;
            }

            // If the Attribute in the data box is just white space then data won't save 
            if (AttributePicker.SelectedIndex == -1)
            {
                // pop message appears when name box is just white spaces
                await DisplayAlert("Alert", "Attribute is Empty!", "OK");
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