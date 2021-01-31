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
            switch ((sender as Button).Text)
            {
                case "-":
                    NewLevelValue--;
                    NewLevelValue = NewLevelValue < 1 ? 1 : NewLevelValue;
                    break;
                case "+":
                    NewLevelValue++;
                    break;
            }
            LevelValue.Text = NewLevelValue.ToString();
        }

        /// <summary>
        /// Update Attack value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AttackValueChanged(object sender, EventArgs e)
        {
            int NewAttackValue = Int32.Parse(AttackValue.Text);
            switch ((sender as Button).Text)
            {
                case "-":
                    NewAttackValue--;
                    NewAttackValue = NewAttackValue < 0 ? 0 : NewAttackValue ;
                    break;
                case "+":
                    NewAttackValue++;
                    break;
            }
            AttackValue.Text = NewAttackValue.ToString();
        }

        /// <summary>
        /// Update Defense value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DefenseValueChanged(object sender, EventArgs e)
        {
            int NewDefenseValue = Int32.Parse(DefenseValue.Text);
            switch ((sender as Button).Text)
            {
                case "-":
                    NewDefenseValue--;
                    NewDefenseValue = NewDefenseValue < 0 ? 0 : NewDefenseValue;
                    break;
                case "+":
                    NewDefenseValue++;
                    break;
            }
            DefenseValue.Text = NewDefenseValue.ToString();
        }

        /// <summary>
        /// Update Speed value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SpeedValueChanged(object sender, EventArgs e)
        {
            int NewSpeedValue = Int32.Parse(SpeedValue.Text);
            switch ((sender as Button).Text)
            {
                case "-":
                    NewSpeedValue--;
                    NewSpeedValue = NewSpeedValue < 0 ? 0 : NewSpeedValue;
                    break;
                case "+":
                    NewSpeedValue++;
                    break;
            }
            SpeedValue.Text = NewSpeedValue.ToString();
        }

        /// <summary>
        /// Update Max Health value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MaxHealthValueChanged(object sender, EventArgs e)
        {

            int NewMaxHealthValue = Int32.Parse(MaxHealthValue.Text);
            switch ((sender as Button).Text)
            {
                case "-":
                    NewMaxHealthValue--;
                    NewMaxHealthValue = NewMaxHealthValue < 0 ? 0 : NewMaxHealthValue;
                    break;
                case "+":
                    NewMaxHealthValue++;
                    break;
            }
            MaxHealthValue.Text = NewMaxHealthValue.ToString();
        }
    }
}