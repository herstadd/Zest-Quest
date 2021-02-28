using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;
using System.Linq;
using Game.GameRules;
using System.Collections.Generic;

namespace Game.Views
{
    /// <summary>
    /// Index Page
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickMonstersPage : ContentPage
    {
      

        // Empty Constructor for UTs
        public PickMonstersPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Index Page
        /// 
        /// Get the ItemIndexView Model
        /// </summary>
        public PickMonstersPage()
        {
            InitializeComponent();

            BindingContext = BattleEngineViewModel.Instance.PartyCharacterList;
        }

        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            CharacterModel data = args.SelectedItem as CharacterModel;
            if (data == null)
            {
                return;
            }

            // Open the Read Page
            await Navigation.PushAsync(new CharacterReadPage(new GenericViewModel<CharacterModel>(data)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        /// <summary>
        /// Call to Add a new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterCreatePage()));
        }

        /// <summary>
        /// Refresh the list on page appearing
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Create a list of 6 Monsters and add to item source in listview
            var monsterList = DefaultData.LoadData(new MonsterModel());

            List<MonsterModel> monsters = new List<MonsterModel>();

            int counter = 1;
            foreach(var monster in monsterList )
            {
                if (counter > 6)
                {
                    break;
                }
                counter++;
                monsters.Add(monster);
            }


            // Create a list of 6 chefs and add to item source in listview
            var ChefList = DefaultData.LoadData(new CharacterModel());

            List<CharacterModel> chefs = new List<CharacterModel>();

            counter = 1;
            foreach (var chef in ChefList)
            {
                if (counter > 6)
                {
                    break;
                }
                counter++;
                chefs.Add(chef);
            }

            ItemsListView.ItemsSource = chefs;
            ItemsListView2.ItemsSource = monsters;
            
        }

        /// <summary>
        /// Jump to the Pick Characters Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickCharactersPage());
        }

        /// <summary>
		/// Jump to the Battle game Page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void RoundStartBUtton_CLicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new BattlePage()));
            await Navigation.PopAsync();
        }
    }
}