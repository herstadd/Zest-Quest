using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// Item Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterUpdatePage : ContentPage
    {
        // View Model for Item
        public readonly GenericViewModel<MonsterModel> ViewModel;

        // Current Monster Name
        public String CurrentName { set; get; }

        // Current Monster Type
        public MonsterTypeEnum CurrentType { set; get; }

        // Current Monster Description
        public String CurrentDescription { set; get; }

        // Current Mosnter Unique Drop
        public SpecialDropEnum CurrentUiqueDrop { set; get; }

        // Current Monster Class (Boss or Standard)
        public String CurrentClass { set; get; }

        // Current Monster Image
        public String CurrentImage { set; get; }

        // Current Monster PictureSource
        public ImageSource CurrentPictureSource { set; get; }


        // Empty Constructor for Tests
        public MonsterUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            //Need to make the SelectedItem a string, so it can select the correct item.
            JobPicker.SelectedItem = ViewModel.Data.MonsterType.ToString();

            // Storing all current values to use them if user decide to cancel
            CurrentName = ViewModel.Data.Name;
            CurrentType = ViewModel.Data.MonsterType;
            CurrentDescription = ViewModel.Data.Description;
            CurrentUiqueDrop = ViewModel.Data.SpecialDrop;
            CurrentPictureSource = PictureSource.Source;
            CurrentImage = ViewModel.Data.ImageURI;
        }


        /// <summary>
        /// Changes the item for a Monster based on the type that is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TypeChanged(object sender, EventArgs e)
        {
            var selected = MonsterJobEnumHelper.ConvertStringToEnum((String)JobPicker.SelectedItem);
            UniqueDrop.Text = MonsterJobEnumExtensions.GetSpecialDrop(selected);
            ViewModel.Data.SpecialDrop = SpecialDropEnumHelper.ConvertStringToEnum(UniqueDrop.Text);
            MonsterClass.Text = MonsterJobEnumExtensions.GetMonsterClass(selected);
            PictureSource.Source = MonsterJobEnumExtensions.GetPicture(selected);
            ChangeImage.Text = MonsterJobEnumExtensions.GetPicture(selected);
        }

        /// <summary>
        /// Changes the name for the Monster when updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NameChanged(object sender, EventArgs e)
        {
            ViewModel.Data.Name = MonsterName.Text;
        }


        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Update_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

            // If the Name in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                ViewModel.Data.Name = "New Monster";
            }

            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            // Restore all values to what they were 
            ViewModel.Data.Name = CurrentName;
            ViewModel.Data.MonsterType = CurrentType;
            ViewModel.Data.Description = CurrentDescription;
            ViewModel.Data.SpecialDrop = CurrentUiqueDrop;
            PictureSource.Source = CurrentPictureSource;
            ViewModel.Data.ImageURI = CurrentImage;

            await Navigation.PopModalAsync();
        }
    }
}