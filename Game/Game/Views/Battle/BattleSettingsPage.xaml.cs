using Game.Helpers;
using Game.Models;
using Game.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BattleSettingsPage : ContentPage
    {
        // Empty Constructor for UTs
       // public BattleSettingsPage(bool UnitTest) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public BattleSettingsPage()
        {
            InitializeComponent();

            #region BattleMode
            // Load the values for the Diffculty into the Picker
            foreach (var item in BattleModeEnumHelper.GetListMessageAll)
            {
                BattleModePicker.Items.Add(item);
            }

            // Set Values to current State
            BattleModePicker.SelectedItem = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum.ToMessage();
            BattleModePicker.SelectedIndex = BattleModePicker.Items.IndexOf(BattleModePicker.SelectedItem.ToString());
            #endregion BattleMode

            #region HitPickers
            // Load the values for the Diffculty into the Picker
            foreach (var item in HitStatusEnumHelper.GetListAll)
            {
                MonsterHitPicker.Items.Add(item);
                CharacterHitPicker.Items.Add(item);
            }

            // Set Values to current State
            MonsterHitPicker.SelectedItem = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum.ToString();
            MonsterHitPicker.SelectedIndex = MonsterHitPicker.Items.IndexOf(MonsterHitPicker.SelectedItem.ToString());

            CharacterHitPicker.SelectedItem = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum.ToString();
            CharacterHitPicker.SelectedIndex = CharacterHitPicker.Items.IndexOf(CharacterHitPicker.SelectedItem.ToString());
            #endregion HitPickers

            #region HitToggles
            AllowCriticalHitSwitch.IsToggled = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit;
            AllowCriticalMissSwitch.IsToggled = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss;
            #endregion HitToggles

            #region MonsterToggles
            AllowMonsterItemsSwitch.IsToggled = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowMonsterItems;
            #endregion
        }

        /// <summary>
        /// Set the Character Hit Enum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void BattleModePicker_Changed(object sender, EventArgs args)
        {
            // Check for null, SelectedItem is not set when the control is created
            if (BattleModePicker.SelectedItem == null)
            {
                return;
            }

            // Change the Difficulty
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnumHelper.ConvertMessageStringToEnum(BattleModePicker.SelectedItem.ToString());
        }

        /// <summary>
        /// Set the Monster Hit Enum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void MonsterHitPicker_Changed(object sender, EventArgs args)
        {
            // Check for null, SelectedItem is not set when the control is created
            if (MonsterHitPicker.SelectedItem == null)
            {
                return;
            }

            // Change the Difficulty
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnumHelper.ConvertStringToEnum(MonsterHitPicker.SelectedItem.ToString());
        }

        /// <summary>
        /// Set the Character Hit Enum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void CharacterHitPicker_Changed(object sender, EventArgs args)
        {
            // Check for null, SelectedItem is not set when the control is created
            if (CharacterHitPicker.SelectedItem == null)
            {
                return;
            }

            // Change the Difficulty
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnumHelper.ConvertStringToEnum(CharacterHitPicker.SelectedItem.ToString());
        }

        /// <summary>
        /// Close The Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Toggle Critical Miss
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AllowCriticalMiss_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (AllowCriticalMissSwitch.IsToggled == true)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss = true;
                return;
            }

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss = false;
        }

        /// <summary>
        /// Toggle Critical Hit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AllowCriticalHit_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (AllowCriticalHitSwitch.IsToggled == true)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = true;
                return;
            }

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = false;
        }

        /// <summary>
        /// Toggle Monster Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AllowMonsterItems_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (AllowMonsterItemsSwitch.IsToggled == true)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowMonsterItems = true;
                return;
            }

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowMonsterItems = false;
        }

    }
}