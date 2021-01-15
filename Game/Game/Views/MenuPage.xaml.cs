using Game.Models;

using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Menu Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        // List of Menu Items
        readonly List<HomeMenuItemModel> menuItems;

        /// <summary>
        /// Constructor
        /// Load the Menu Items
        /// Setup Item Selected call
        /// </summary>
        public MenuPage()
        {
            InitializeComponent();

            // Establish the Menu List
            menuItems = new List<HomeMenuItemModel>
            {
                new HomeMenuItemModel {Id = MenuItemEnum.Game, Title="Game" },
                new HomeMenuItemModel {Id = MenuItemEnum.About, Title="About" },
                new HomeMenuItemModel {Id = MenuItemEnum.Village, Title="Village" },
                new HomeMenuItemModel {Id = MenuItemEnum.Battle, Title="Battle" }
            };

            // Register the ListView for the Menu and the Item Selected call back
            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                // Menu choice was selected, evaluate it
                if (e.SelectedItem == null)
                {
                    return;
                }

                var id = (int)((HomeMenuItemModel)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}