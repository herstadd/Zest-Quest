using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;

namespace Game.Views
{
    /// <summary>
    /// Index Page
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreIndexPage : ContentPage
    {
        // The view model, used for data binding
        readonly ScoreIndexViewModel ViewModel = ScoreIndexViewModel.Instance;

        // Empty Constructor for UTs
        public ScoreIndexPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Index Page
        /// 
        /// Get the ScoreIndexView Model
        /// </summary>
        public ScoreIndexPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }

        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            ScoreModel data = args.SelectedItem as ScoreModel;
            if (data == null)
            {
                return;
            }

            // Open the Read Page
            await Navigation.PushAsync(new ScoreReadPage(new GenericViewModel<ScoreModel>(data)));

            // Manually deselect item.
            DataListView.SelectedItem = null;
        }

        /// <summary>
        /// Call to Add a new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AddScore_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ScoreCreatePage(new GenericViewModel<ScoreModel>())));
        }

        /// <summary>
        /// Refresh the list on page appearing
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = null;

            // If no data, then set it for needing refresh
            if (ViewModel.Dataset.Count == 0)
            {
                ViewModel.SetNeedsRefresh(true);
            }

            // If the needs Refresh flag is set update it
            if (ViewModel.NeedsRefresh())
            {
                ViewModel.LoadDatasetCommand.Execute(null);
            }

            BindingContext = ViewModel;
        }
    }
}