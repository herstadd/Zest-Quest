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
            LevelValue.Text = ValueChange((sender as Button).Text, NewLevelValue, true).ToString();
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
        /// Update Max Health value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MaxHealthValueChanged(object sender, EventArgs e)
        {
            int NewMaxHealthValue = Int32.Parse(MaxHealthValue.Text);
            MaxHealthValue.Text = ValueChange((sender as Button).Text, NewMaxHealthValue, false).ToString();
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
                return num + 1;
            }
        }

        public void TypeChanged(object sender, EventArgs e)
        {
            var selected = JobPicker.SelectedItem;
            if(selected.Equals("HeadChef"))
            {
                Description.Text = "Each item grants this character double the normal stat modifier";
            } 
            else if(selected.Equals("SousChef"))
            {
                Description.Text = "This character's attack attribute will be 3 times stronger than usual for the first attack in every round";
            }
            else if (selected.Equals("SchoolChef"))
            {
                Description.Text = "Provide a 20% attack buff to the rest of team if the school chef dies in a battle";
            }
            else if (selected.Equals("SushiChef"))
            {
                Description.Text = "Has the ability to attack from anywhere on the map with any item";
            }
            else if (selected.Equals("CatChef"))
            {
                Description.Text = "Has nine lives (so if character dies, comes back to life 8 more times,) but cannot hold more than one item at a time";
            }
            else if (selected.Equals("HomeCook"))
            {
                Description.Text = "After winning a battle their current health will be recovered by 10% of original max health up to max health";
            }

        }
    }
}