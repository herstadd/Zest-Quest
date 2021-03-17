using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// The Begin Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BeginGamePage : ContentPage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BeginGamePage()
        {
            InitializeComponent();
        }

        /// <summary>
		/// Jump to the Pick Characters Page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void LunchRushButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickCharactersPage());
        }
    }
}