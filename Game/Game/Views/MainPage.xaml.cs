using Game.Models;

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Main Page
    /// </summary>
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        // Collection of Navigation Pages
        public readonly Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        /// <summary>
        /// Constructor setups the behavior and menu pages
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;
        }

        /// <summary>
        /// Process the Menu Selected item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task NavigateFromMenu(int id)
        {
            // See if the Page is in memory, if not load it
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemEnum.Village:
                        MenuPages.Add(id, new NavigationPage(new VillagePage()));
                        break;

                    case (int)MenuItemEnum.Battle:
                        MenuPages.Add(id, new NavigationPage(new PickCharactersPage()));
                        break;

                    case (int)MenuItemEnum.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;

                    case (int)MenuItemEnum.Game:
                        MenuPages.Add(id, new NavigationPage(new GamePage()));
                        break;
                }
            }

            // Switch to the Page
            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                // Android needs a deal, iOS and UWP does not
                if (Device.RuntimePlatform == Device.Android)
                {
                    await Task.Delay(100);
                }

                IsPresented = false;
            }
        }
    }
}