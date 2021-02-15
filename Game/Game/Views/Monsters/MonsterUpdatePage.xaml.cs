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
    public partial class MonsterUpdatePage : ContentPage
    {
        // View Model for Monster
        public readonly GenericViewModel<MonsterModel> ViewModel;

        // Hold a copy of the original data for Cancel to use
        public MonsterModel DataCopy;

        // Empty Constructor for Tests
        public MonsterUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            //Need to make the SelectedItem a string, so it can select the correct item.
            JobPicker.SelectedItem = ViewModel.Data.MonsterType.ToString();

            // Initialize the Monster Class Box Picker according to the default Monster type 
            MonsterClassPicker.SelectedItem = MonsterIndexViewModel.Instance.GetMonsterClass(ViewModel.Data.MonsterType.ToString());
            UniqueDrop.SelectedItem = data.Data.UniqueDrop.ToMessage();

            // Make a copy of the Monster for cancel to restore
            DataCopy = new MonsterModel(data.Data);         
        }


        /// <summary>
        /// Changes the items for a Monster based on the type that is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TypeChanged(object sender, EventArgs e)
        {
            var selected = (String)JobPicker.SelectedItem;

            //this.ViewModel.Data.Description = MonsterIndexViewModel.Instance.GetDescription(selected);
            Description.Text = MonsterIndexViewModel.Instance.GetDescription(selected);
            //ViewModel.Data.UniqueDrop = MonsterIndexViewModel.Instance.GetUniqueDrop(selected); 
            PictureSource.Source = MonsterIndexViewModel.Instance.GetImage(selected);
            ChangeImage.Text = MonsterIndexViewModel.Instance.GetImage(selected);
        }

        /// <summary>
        /// Changes the name of the Monster when updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NameChanged(object sender, EventArgs e)
        {
            ViewModel.Data.Name = MonsterName.Text;

            // setting Name Entry Box background color
            MonsterName.BackgroundColor = Color.FromRgb(255, 179, 0);

            // If the Name in the data box is empty changes the Entry background color
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                MonsterName.BackgroundColor = Color.DarkRed;
            }

            // If the Name in the data box is just white spaces changes the Entry background color
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                MonsterName.BackgroundColor = Color.DarkRed;
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

            // If the Name in the data box is empty then data won't update 
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                // pop message appears when name box is empty
                await DisplayAlert("Alert", "Name is Empty!", "OK");
                return;
            }

            // If the Name in the data box is just white space then data won't update 
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                // pop message appears when name box is just white spaces
                await DisplayAlert("Alert", "Name is Empty!", "OK");
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
    }
}