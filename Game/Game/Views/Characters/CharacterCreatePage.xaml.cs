using Game.Helpers;
using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            InitializeComponent();

            this.ViewModel.Data = new CharacterModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Create";

            //Need to make the SelectedItem a string, so it can select the correct item.
            JobPicker.SelectedItem = ViewModel.Data.Job.ToString();
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

            DescriptionEnum Type = DescriptionEnumExtensions.ToEnum(selected);

            Description.Text = DescriptionEnumExtensions.ToMessage(Type);

            PictureSource.Source = DescriptionEnumExtensions.GetPicture(Type);
            ChangeImage.Text = DescriptionEnumExtensions.GetPicture(Type);
            LevelValue.Text = DescriptionEnumExtensions.GetDefaultLevel(Type);

            MaxHealthValue.Text = DescriptionEnumExtensions.CalcMaxHealth(Type).ToString();
        }
    }
}