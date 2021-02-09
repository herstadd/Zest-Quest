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
    public partial class MonsterCreatePage : ContentPage
    {
        // The Monster to create
        public GenericViewModel<MonsterModel> ViewModel = new GenericViewModel<MonsterModel>();

        // Empty Constructor for UTs
        public MonsterCreatePage(bool UnitTest){}

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public MonsterCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new MonsterModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Monster Create";

            //Need to make the SelectedItem a string, so it can select the correct item.
            JobPicker.SelectedItem = ViewModel.Data.MonsterType.ToString();
        }

        /// <summary>
        /// Checks if the user enter empty Entry Box for the Name then changes the box color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckNullEntry(object sender, EventArgs e)
        {
            MonsterNameEntry.BackgroundColor = Color.FromRgb(255, 179, 0);

            // If the Name in the data box is empty changes the Entry background color
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                MonsterNameEntry.BackgroundColor = Color.DarkRed;
            }

            // If the Name in the data box is just white spaces changes the Entry background color
            if (string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                MonsterNameEntry.BackgroundColor = Color.DarkRed;
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
        /// Change based on the type of a monster that is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TypeChanged(object sender, EventArgs e)
        {
            var selected = MonsterJobEnumHelper.ConvertStringToEnum((String)JobPicker.SelectedItem);
            UniqueDrop.Text  = MonsterJobEnumExtensions.GetSpecialDrop(selected);
            ViewModel.Data.SpecialDrop = SpecialDropEnumHelper.ConvertStringToEnum(UniqueDrop.Text);
            PictureSource.Source = MonsterJobEnumExtensions.GetPicture(selected);
            ChangeImage.Text = MonsterJobEnumExtensions.GetPicture(selected);
            MonsterClass.Text = MonsterJobEnumExtensions.GetMonsterClass(selected);
        }
    }
}