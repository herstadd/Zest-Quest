using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// Score Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreUpdatePage : ContentPage
    {
        // View Model for Score
        public readonly GenericViewModel<ScoreModel> ViewModel;

        // Hold a copy of the original data for Cancel to use
        public ScoreModel DataCopy;

        // Constructor for Unit Testing
        public ScoreUpdatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor that takes and existing data Score
        /// </summary>
        public ScoreUpdatePage(GenericViewModel<ScoreModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            // Make a copy of the Score for cancel to restore
            DataCopy = new ScoreModel(data.Data);
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the Name in the data box is empty then data won't save 
            //if (string.IsNullOrEmpty(ViewModel.Data.Name))
            //{
            //    // pop message appears when name box is empty
            //    await DisplayAlert("Alert", "Name is Empty!", "OK");
            //    return;
            //}

            // If the Name in the data box is just white space then data won't save 
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                // pop message appears when name box is just white spaces
                //await DisplayAlert("Alert", "Name is Empty!", "OK");
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
        /// Checks if the user enter empty Entry Box for the Name then changes the box color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckNullEntry(object sender, EventArgs e)
        {
            NameEntry.BackgroundColor = Color.FromRgb(255, 179, 0);

            // If the Name in the data box is empty changes the Entry background color
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                NameEntry.BackgroundColor = Color.DarkRed;
            }
        }
    }
}