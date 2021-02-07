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

            // If the Name in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                ViewModel.Data.Name = "New Character";
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
            LevelValue.Text = ValueChange((sender as Button).Text, NewLevelValue, false).ToString();
            MaxHealthValue.Text = ValueChange((sender as Button).Text, NewLevelValue, true, MaxHealth).ToString();
        }

        /// <summary>
        /// Update Attack value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AttackValueChanged(object sender, EventArgs e)
        {
            int NewAttackValue = Int32.Parse(AttackValue.Text);
            AttackValue.Text = ValueChange((sender as Button).Text, NewAttackValue, false).ToString();
        }

        /// <summary>
        /// Update Defense value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DefenseValueChanged(object sender, EventArgs e)
        {
            int NewDefenseValue = Int32.Parse(DefenseValue.Text);
            DefenseValue.Text = ValueChange((sender as Button).Text, NewDefenseValue, false).ToString();
        }

        /// <summary>
        /// Update Speed value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SpeedValueChanged(object sender, EventArgs e)
        {
            int NewSpeedValue = Int32.Parse(SpeedValue.Text);
            SpeedValue.Text = ValueChange((sender as Button).Text, NewSpeedValue, false).ToString();
        }

        /// <summary>
        /// Change Stat value
        /// </summary>
        /// <param name="ButtonText"></param>
        /// <param name="num"></param>
        /// <param name="IsMaxHealth"></param>
        /// <param name="maxHealth"></param>
        /// <returns></returns>
        private int ValueChange(String ButtonText, int num, bool IsMaxHealth, int maxHealth=0) 
        {
            if (ButtonText.Equals("-"))
            {
                if (IsMaxHealth)
                {
                    num--;
                    return num < 1 ? maxHealth : DiceHelper.RollDice(num, 10);
                }
                num--;
                return num < 1 ? 1 : num;
            }
            else 
            {
                if (IsMaxHealth)
                {
                    return DiceHelper.RollDice(num + 1, 10);
                }
                return num + 1;
            }
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