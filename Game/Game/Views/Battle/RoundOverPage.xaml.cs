using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoundOverPage: ContentPage
	{

        public PlayerInfoModel SelectedCharacter = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public RoundOverPage()
        {
            InitializeComponent();

            // Update the Round Count
            TotalRound.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.RoundCount.ToString();

            // Update the Found Number
            TotalFound.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Count().ToString();

            // Update the Selected Number, this gets updated later when selected refresh happens
            TotalSelected.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Count().ToString();

            DrawCharacterList();

            DrawItemLists();
        }

        /// <summary>
        /// Clear and Add the Characters that survived
        /// </summary>
        public void DrawCharacterList()
        {
            // Clear and Populate the Characters Remaining
            var FlexList = CharacterListFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                CharacterListFrame.Children.Remove(data);
            }

            // Draw the Characters
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList)
            {
                CharacterListFrame.Children.Add(CreatePlayerDisplayBox(data));
            }

        }

        /// <summary>
        /// Draw the List of Items
        /// 
        /// The Ones Dropped
        /// 
        /// The Ones Selected
        /// 
        /// </summary>
        public void DrawItemLists()
        {
            DrawDroppedItems();
            DrawSelectedItems();

            // Only need to update the selected, the Dropped is set in the constructor
            TotalSelected.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Count().ToString();
        }

        /// <summary>
        /// Add the Dropped Items to the Display
        /// </summary>
        public void DrawDroppedItems()
        {
            // Clear and Populate the Dropped Items
            var FlexList = ItemListFoundFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemListFoundFrame.Children.Remove(data);
            }

            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Distinct())
            {
                ItemListFoundFrame.Children.Add(GetItemToDisplay(data));
            }
        }

        /// <summary>
        /// Add the Dropped Items to the Display
        /// </summary>
        public void DrawSelectedItems()
        {
            // Clear and Populate the Dropped Items
            var FlexList = ItemListSelectedFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemListSelectedFrame.Children.Remove(data);
            }

            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList)
            {
                ItemListSelectedFrame.Children.Add(GetItemToDisplay(data));
            }
        }

        /// <summary>
        /// Look up the Item to Display
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetItemToDisplay(ItemModel item)
        {
            if (item == null)
            {
                return new StackLayout();
            }

            if (string.IsNullOrEmpty(item.Id))
            {
                return new StackLayout();
            }

            // Defualt Image is the Plus
            var ClickableButton = true;

            var data = ItemIndexViewModel.Instance.GetItem(item.Id);
            if (data == null)
            {
                // Show the Default Icon for the Location
                data = new ItemModel { Name="Unknown", ImageURI = "icon_cancel.png" };

                // Turn off click action
                ClickableButton = false;
            }

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageMediumStyle"],
                Source = data.ImageURI
            };

            if (ClickableButton)
            {
                // Add a event to the user can click the item and see more
                ItemButton.Clicked += (sender, args) => ShowPopup(data);
            }

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 3,
                Style = (Style)Application.Current.Resources["ItemImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    ItemButton,
                },
            };

            return ItemStack;
        }

        /// <summary>
        /// Return a stack layout with the Player information inside
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout CreatePlayerDisplayBox(PlayerInfoModel data)
        {
            if (data == null)
            {
                data = new PlayerInfoModel();
            }

            // Hookup the image
            var PlayerImage = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageBattleLargeStyle"],
                Source = data.ImageURI
            };

            // Add the Level
            var PlayerLevelLabel = new Label
            {
                Text = "Level : " + data.Level,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Add the HP
            var PlayerHPLabel = new Label
            {
                Text = "HP : " + data.GetCurrentHealthTotal,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            var PlayerNameLabel = new Label()
            {
                Text = data.Name,
                Style = (Style)Application.Current.Resources["ValueStyle"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["PlayerInfoBox"],
                HorizontalOptions = LayoutOptions.Center,
                Padding = 0,
                Spacing = 0,
                Children = {
                    PlayerImage,
                    PlayerNameLabel,
                    PlayerLevelLabel,
                    PlayerHPLabel,
                },
            };

            PlayerImage.Clicked += (sender, args) => ClickedCharacter(PlayerStack, data);

            return PlayerStack;
        }

        /// <summary>
        /// Saves the selected character to class data
        /// </summary>
        /// <param name="player"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool ClickedCharacter(StackLayout player, PlayerInfoModel character)
        {
            var FlexList = CharacterListFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                data.BackgroundColor = Color.Transparent;
            }

            if (character == SelectedCharacter)
            {
                SelectedCharacter = null;
                player.BackgroundColor = Color.Transparent;
                return true;
            }
            SelectedCharacter = character;
            player.BackgroundColor = Color.LightGoldenrodYellow;
            return true;
        }

        /// <summary>
        /// Show the Popup for the Item
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ShowPopup(ItemModel data)
        {
            if(SelectedCharacter == null)
            {
                return false;
            }

            ItemModel item;
            
            switch (data.Location)
            {
                case ItemLocationEnum.Head:
                    item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.Head, true);
                    if(item == null)
                    {
                        item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.Head);
                    }
                    break;
                case ItemLocationEnum.Necklass:
                    item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.Necklass, true);
                    if (item == null)
                    {
                        item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.Necklass);
                    }
                    break;
                case ItemLocationEnum.PrimaryHand:
                    item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.PrimaryHand, true);
                    if (item == null)
                    {
                        item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.PrimaryHand);
                    }
                    break;
                case ItemLocationEnum.OffHand:
                    item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.OffHand, true);
                    if (item == null)
                    {
                        item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.OffHand);
                    }
                    break;
                case ItemLocationEnum.RightFinger:
                    item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.RightFinger, true);
                    if (item == null)
                    {
                        item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.RightFinger);
                    }
                    break;
                case ItemLocationEnum.LeftFinger:
                    item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.LeftFinger, true);
                    if (item == null)
                    {
                        item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.LeftFinger);
                    }
                    break;
                case ItemLocationEnum.Feet:
                    item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.Feet, true);
                    if (item == null)
                    {
                        item = ItemIndexViewModel.Instance.GetItem(SelectedCharacter.Feet);
                    }
                    break;
                default:
                    item = null;
                    break;
            }

            PopupLoadingView.IsVisible = true;

            PossibleItemImage.Source = data.ImageURI;
            PossibleItemName.Text = data.Name;
            PossibleItemDescription.Text = data.Description;
            PossibleItemLocation.Text = data.Location.ToMessage();
            PossibleItemAttribute.Text = data.Attribute.ToMessage();
            PossibleItemValue.Text = " + " + data.Value.ToString();

            if (item == null)
            {
                CurrentItemImage.Source = "";
                CurrentItemDescription.Text = "";
                CurrentItemLocation.Text = "";
                CurrentItemAttribute.Text = "";
                CurrentItemValue.Text = "";
                CurrentItemName.Text = "No item in this spot";
                return false;
            }

            CurrentItemImage.Source = item.ImageURI;
            CurrentItemName.Text = item.Name;
            CurrentItemDescription.Text = item.Description;
            CurrentItemLocation.Text = "Location : " + item.Location.ToMessage();
            CurrentItemAttribute.Text = item.Attribute.ToMessage();
            CurrentItemValue.Text = " + " + item.Value.ToString();

            return true;
        }

        /// <summary>
        /// Close the popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClosePopup_Clicked(object sender, EventArgs e)
		{
			PopupLoadingView.IsVisible = false;
		}

        /// <summary>
        /// Equip the selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EquipItem_Clicked(object sender, EventArgs e)
        {
            ItemModel CurrentItem = null;

            if (!CurrentItemName.Text.Equals("No item in this spot"))
            {
                CurrentItem = ItemIndexViewModel.Instance.GetItem(CurrentItemName.Text, true);
            }

            CurrentItemImage.Source = PossibleItemImage.Source;
            CurrentItemName.Text = PossibleItemName.Text;
            CurrentItemDescription.Text = PossibleItemDescription.Text;
            CurrentItemLocation.Text = "Location : " + PossibleItemLocation.Text;
            CurrentItemAttribute.Text = PossibleItemAttribute.Text;
            CurrentItemValue.Text = PossibleItemValue.Text;

            ItemModel PossibleItem = ItemIndexViewModel.Instance.GetItem(PossibleItemName.Text, true);

            switch (PossibleItemLocation.Text)
            {
                case "Head":
                    SelectedCharacter.RemoveItem(ItemLocationEnum.Head);
                    SelectedCharacter.AddItem(ItemLocationEnum.Head, PossibleItem.Id);
                    break;
                case "Necklass":
                    SelectedCharacter.RemoveItem(ItemLocationEnum.Necklass);
                    SelectedCharacter.AddItem(ItemLocationEnum.Necklass, PossibleItem.Id);
                    break;
                case "Primary Hand":
                    SelectedCharacter.RemoveItem(ItemLocationEnum.PrimaryHand);
                    SelectedCharacter.AddItem(ItemLocationEnum.PrimaryHand, PossibleItem.Id);
                    break;
                case "Off Hand":
                    SelectedCharacter.RemoveItem(ItemLocationEnum.OffHand);
                    SelectedCharacter.AddItem(ItemLocationEnum.OffHand, PossibleItem.Id);
                    break;
                case "Right Finger":
                    SelectedCharacter.RemoveItem(ItemLocationEnum.RightFinger);
                    SelectedCharacter.AddItem(ItemLocationEnum.RightFinger, PossibleItem.Id);
                    break;
                case "Left Finger":
                    SelectedCharacter.RemoveItem(ItemLocationEnum.LeftFinger);
                    SelectedCharacter.AddItem(ItemLocationEnum.LeftFinger, PossibleItem.Id);
                    break;
                case "Feet":
                    SelectedCharacter.RemoveItem(ItemLocationEnum.Feet);
                    SelectedCharacter.AddItem(ItemLocationEnum.Feet, PossibleItem.Id);
                    break;
                default:
                    break;
            }

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Remove(PossibleItem);
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(PossibleItem);

            if (CurrentItem != null)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(CurrentItem);
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Remove(CurrentItem);
            }

            DrawItemLists();

            PopupLoadingView.IsVisible = false;
        }
		
		/// <summary>
		/// Closes the Round Over Popup
        /// 
        /// Launches the Next Round Popup
        /// 
        /// Resets the Game Round
        /// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void CloseButton_Clicked(object sender, EventArgs e)
		{
            // Reset to a new Round
            BattleEngineViewModel.Instance.Engine.Round.NewRound();

            // Show the New Round Screen
            ShowModalNewRoundPage();
		}

		/// <summary>
		/// Start next Round, returning to the battle screen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void AutoAssignButton_Clicked(object sender, EventArgs e)
		{
			// Distribute the Items
			BattleEngineViewModel.Instance.Engine.Round.PickupItemsForAllCharacters();

            // Show what was picked up
            DrawItemLists();
        }

        /// <summary>
        /// Show the Page for New Round
        /// 
        /// Upcomming Monsters
        /// 
        /// </summary>
        public async void ShowModalNewRoundPage()
        {
            await Navigation.PopModalAsync();
        }

    }
}