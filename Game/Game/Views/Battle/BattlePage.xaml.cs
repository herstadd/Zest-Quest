﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;
using System.Timers;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    public partial class BattlePage : ContentPage
    {
        // HTML Formatting for message output box
        public HtmlWebViewSource htmlSource = new HtmlWebViewSource();

        // Wait time before proceeding
        public int WaitTime = 1500;

        // Timer object for Auto attack
        public Timer aTimer = new Timer();

        // Hold the Map Objects, for easy access to update them
        public Dictionary<string, object> MapLocationObject = new Dictionary<string, object>();

        // Empty Constructor for UTs
        bool UnitTestSetting;
        public BattlePage(bool UnitTest) { UnitTestSetting = UnitTest; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BattlePage()
        {
            InitializeComponent();

            // Set initial State to Starting
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Starting;

            // Set up the UI to Defaults
            BindingContext = BattleEngineViewModel.Instance;

            // Create and Draw the Map
            InitializeMapGrid();

            SetCharacterList();

            // Start the Battle Engine
            BattleEngineViewModel.Instance.Engine.StartBattle(false);

            // Populate the UI Map
            DrawMapGridInitialState();

            // Ask the Game engine to select who goes first
            BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(null);

            // Add Players to Display
            DrawGameAttackerDefenderBoard();

            // Set the Battle Mode
            ShowBattleMode();
        }

        /// <summary>
        /// Dray the Player Boxes
        /// </summary>
        public void DrawPlayerBoxes()
        {
            var CharacterBoxList = CharacterBox.Children.ToList();
            foreach (var data in CharacterBoxList)
            {
                CharacterBox.Children.Remove(data);
            }

            // Draw the Characters
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Where(m => m.PlayerType == PlayerTypeEnum.Character).ToList())
            {
                CharacterBox.Children.Add(PlayerInfoDisplayBox(data));
            }

            var MonsterBoxList = MonsterBox.Children.ToList();
            foreach (var data in MonsterBoxList)
            {
                MonsterBox.Children.Remove(data);
            }

            // Draw the Monsters
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Where(m => m.PlayerType == PlayerTypeEnum.Monster).ToList())
            {
                MonsterBox.Children.Add(PlayerInfoDisplayBox(data));
            }

            // Add one black PlayerInfoDisplayBox to hold space in case the list is empty
            CharacterBox.Children.Add(PlayerInfoDisplayBox(null));

            // Add one black PlayerInfoDisplayBox to hold space incase the list is empty
            MonsterBox.Children.Add(PlayerInfoDisplayBox(null));

        }

        /// <summary>
        /// Put the Player into a Display Box
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout PlayerInfoDisplayBox(PlayerInfoModel data)
        {
            if (data == null)
            {
                data = new PlayerInfoModel
                {
                    ImageURI = ""
                };
            }

            // Hookup the image
            var PlayerImage = new Image
            {
                Style = (Style)Application.Current.Resources["PlayerBattleMediumStyle"],
                Source = data.ImageURI
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["PlayerBattleDisplayBox"],
                Children = {
                    PlayerImage,
                },
            };

            return PlayerStack;
        }

        #region BattleMapMode

        /// <summary>
        /// Create the Initial Map Grid
        /// 
        /// All lcoations are empty
        /// </summary>
        /// <returns></returns>
        public bool InitializeMapGrid()
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.ClearMapGrid();

            return true;
        }

        /// <summary>
        /// Draw the Map Grid
        /// Add the Players to the Map
        /// 
        /// Need to have Players in the Engine first, to then put on the Map
        /// 
        /// The Map Objects are all created with the map background image first
        /// 
        /// Then the actual characters are added to the map
        /// </summary>
        public void DrawMapGridInitialState()
        {
            // Create the Map in the Game Engine
            BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.PopulateMapModel(BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList);

            CreateMapGridObjects();

            //UpdateMapGrid();
        }

        /// <summary>
        /// Walk the current grid
        /// check each cell to see if it matches the engine map
        /// Update only those that need change
        /// </summary>
        /// <returns></returns>
        public bool UpdateMapGrid(bool SkipBorder = false, PlayerInfoModel NewPlayer = null)
        {
           
            // var test = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel;

            var Attacker = NewPlayer;

            if (Attacker == null)
            {
                SetAttackerAndDefender();
                Attacker = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker;
            }
            if (SkipBorder == false)
            {

                if (Attacker != null)
                {
                    if (Attacker.PlayerType == PlayerTypeEnum.Character)
                    {
                        var location = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.GetLocationForPlayer(Attacker);
                        if (location != null)
                        {
                            object MapObject1 = GetMapGridObject(GetDictionaryImageButtonName(location));
                            var x = (ImageButton)MapObject1;
                            x.BorderWidth = 3;
                            x.BorderColor = Color.FromHex("45806D");
                            x.BackgroundColor = Color.FromHex("C5EBDF");
                        }
                    }
                }
            }
            if (NewPlayer != null)
            {
                var location = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.GetLocationForPlayer(Attacker);
                if (location != null)
                {
                    object MapObject1 = GetMapGridObject(GetDictionaryImageButtonName(location));
                    var x = (ImageButton)MapObject1;
                    x.BorderWidth = 0;
                    x.BorderColor = Color.Cyan;
                    x.BackgroundColor = Color.Transparent;
                }
            }
            

            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.MapGridLocation)
            {
               
                // Use the ImageButton from the dictionary because that represents the player object
                object MapObject = GetMapGridObject(GetDictionaryImageButtonName(data));
                if (MapObject == null)
                {
                    return false;
                }

                var imageObject = (ImageButton)MapObject;

                // Check automation ID on the Image, That should match the Player, if not a match, the cell is now different need to update
                if (!imageObject.AutomationId.Equals(data.Player.Guid))
                {
                    // The Image is different, so need to re-create the Image Object and add it to the Stack
                    // That way the correct monster is in the box.

                    MapObject = GetMapGridObject(GetDictionaryStackName(data));
                    if (MapObject == null)
                    {
                        return false;
                    }

                    var stackObject = (StackLayout)MapObject;

                    // Remove the ImageButton
                    stackObject.Children.RemoveAt(0);

                    var PlayerImageButton = DetermineMapImageButton(data);

                    stackObject.Children.Add(PlayerImageButton);

                    // Update the Image in the Datastructure
                    MapGridObjectAddImage(PlayerImageButton, data);

                    stackObject.BackgroundColor = DetermineMapBackgroundColor(data);
                }

            }

            return true;
        }

        /// <summary>
        /// Convert the Stack to a name for the dictionary to lookup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetDictionaryFrameName(MapModelLocation data)
        {
            return string.Format("MapR{0}C{1}Frame", data.Row, data.Column);
        }

        /// <summary>
        /// Convert the Stack to a name for the dictionary to lookup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetDictionaryStackName(MapModelLocation data)
        {
            return string.Format("MapR{0}C{1}Stack", data.Row, data.Column);
        }

        /// <summary>
        /// Covert the player map location to a name for the dictionary to lookup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetDictionaryImageButtonName(MapModelLocation data)
        {
            // Look up the Frame in the Dictionary
            return string.Format("MapR{0}C{1}ImageButton", data.Row, data.Column);
        }

        /// <summary>
        /// Populate the Map
        /// 
        /// For each map position in the Engine
        /// Create a grid object to hold the Stack for that grid cell.
        /// </summary>
        /// <returns></returns>
        public bool CreateMapGridObjects()
        {
            // Make a frame for each location on the map
            // Populate it with a new Frame Object that is unique
            // Then updating will be easier

            foreach (var location in BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.MapGridLocation)
            {
                var data = MakeMapGridBox(location);

                // Add the Box to the UI

                MapGrid.Children.Add(data, location.Column, location.Row);
            }

            // Set the Height for the MapGrid based on the number of rows * the height of the BattleMapFrame

            var height = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.MapXAxiesCount * 60;

            BattleMapDisplay.MinimumHeightRequest = height;
            BattleMapDisplay.HeightRequest = height;

            return true;
        }

        /// <summary>
        /// Get the Frame from the Dictionary
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetMapGridObject(string name)
        {
            MapLocationObject.TryGetValue(name, out object data);
            return data;
        }

        /// <summary>
        /// Make the Game Map Frame 
        /// Place the Character or Monster on the frame
        /// If empty, place Empty
        /// </summary>
        /// <param name="mapLocationModel"></param>
        /// <returns></returns>
        public Frame MakeMapGridBox(MapModelLocation mapLocationModel)
        {
            if (mapLocationModel.Player == null)
            {
                mapLocationModel.Player = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.EmptySquare;
            }

            var PlayerImageButton = DetermineMapImageButton(mapLocationModel);

            var PlayerStack = new StackLayout
            {
                Padding = 0,
                Style = (Style)Application.Current.Resources["BattleMapImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = DetermineMapBackgroundColor(mapLocationModel),
                Children = {
                    PlayerImageButton
                },
            };

            MapGridObjectAddImage(PlayerImageButton, mapLocationModel);
            MapGridObjectAddStack(PlayerStack, mapLocationModel);

            var MapFrame = new Frame
            {
                Style = (Style)Application.Current.Resources["BattleMapFrame"],
                Content = PlayerStack,
                AutomationId = GetDictionaryFrameName(mapLocationModel)
            };

            return MapFrame;
        }

        /// <summary>
        /// This add the ImageButton to the stack to kep track of
        /// </summary>
        /// <param name="data"></param>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public bool MapGridObjectAddImage(ImageButton data, MapModelLocation MapModel)
        {
            var name = GetDictionaryImageButtonName(MapModel);

            // First check to see if it has data, if so update rather than add
            if (MapLocationObject.ContainsKey(name))
            {
                // Update it
                MapLocationObject[name] = data;
                return true;
            }

            MapLocationObject.Add(name, data);

            return true;
        }

        /// <summary>
        /// This adds the Stack into the Dictionary to keep track of
        /// </summary>
        /// <param name="data"></param>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public bool MapGridObjectAddStack(StackLayout data, MapModelLocation MapModel)
        {
            var name = GetDictionaryStackName(MapModel);

            // First check to see if it has data, if so update rather than add
            if (MapLocationObject.ContainsKey(name))
            {
                // Update it
                MapLocationObject[name] = data;
                return true;
            }

            MapLocationObject.Add(name, data);
            return true;
        }

        /// <summary>
        /// Set the Image onto the map
        /// The Image represents the player
        /// 
        /// So a charcter is the character Image for that character
        /// 
        /// The Automation ID equals the guid for the player
        /// This makes it easier to identify when checking the map to update thigns
        /// 
        /// The button action is set per the type, so Characters events are differnt than monster events
        /// </summary>
        /// <param name="MapLocationModel"></param>
        /// <returns></returns>
        public ImageButton DetermineMapImageButton(MapModelLocation MapLocationModel, ImageButton TestButton = null)
        {
            var data = new ImageButton
            {
                Style = (Style)Application.Current.Resources["BattleMapPlayerSmallStyle"],
                Source = MapLocationModel.Player.ImageURI,

                // Store the guid to identify this button
                AutomationId = MapLocationModel.Player.Guid
            };

            if (TestButton != null)
            {
                data = TestButton;
            }

            switch (MapLocationModel.Player.PlayerType)
            {
                case PlayerTypeEnum.Character:
                    data.Clicked += (sender, args) => SetSelectedCharacter(MapLocationModel);
                    break;
                case PlayerTypeEnum.Monster:
                    data.Clicked += (sender, args) => SetSelectedMonster(MapLocationModel);
                    break;
                case PlayerTypeEnum.Unknown:
                default:
                    data.Clicked += (sender, args) => SetSelectedEmpty(MapLocationModel);

                    // Use the blank cell
                    data.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.EmptySquare.ImageURI;
                    break;
            }

            return data;
        }

        /// <summary>
        /// Set the Background color for the tile.
        /// Monsters and Characters have different colors
        /// Empty cells are transparent
        /// </summary>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public Color DetermineMapBackgroundColor(MapModelLocation MapModel)
        {
            string BattleMapBackgroundColor;
            switch (MapModel.Player.PlayerType)
            {
                case PlayerTypeEnum.Character:
                    BattleMapBackgroundColor = "BattleMapCharacterColor";
                    break;
                case PlayerTypeEnum.Monster:
                    BattleMapBackgroundColor = "BattleMapMonsterColor";
                    break;
                case PlayerTypeEnum.Unknown:
                default:
                    BattleMapBackgroundColor = "BattleMapTransparentColor";
                    break;
            }

            var result = (Color)Application.Current.Resources[BattleMapBackgroundColor];
            return result;
        }


        /// <summary>
        /// Creates jumping animations for characters to move and attack
        /// </summary>
        /// <param name="Player">Player to move or attack</param>
        /// <param name="OldLocation">Initial location</param>
        /// <param name="NewLocation">Location or attack destination</param>
        /// <param name="Attack">true if attacking</param>
        public async void MoveAnimation(PlayerInfoModel Player, MapModelLocation OldLocation, MapModelLocation NewLocation, bool Attack = false)
        {
            var PlayerLocation = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.GetLocationForPlayer(Player);
            if (PlayerLocation == null)
            {
                return;
            }
            object MapObject = GetMapGridObject(GetDictionaryImageButtonName(PlayerLocation));
               
            var ImageOfPlayer = (ImageButton)MapObject;
            var distance = 1;// BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.CalculateDistance(NewLocation, OldLocation);
            var NumRotations = 1; // Math.Ceiling((double)distance/2);

            FlyingImage.IsVisible = true;
            ImageOfPlayer.IsVisible = false;
            FlyingImage.Source = ImageOfPlayer.Source;

            //Move image to initial location
            await Task.WhenAny<bool>
            (
                FlyingImage.TranslateTo(OldLocation.Column * 60, OldLocation.Row * 60, 0),
                FlyingImage.ScaleTo(0.833, 0)
            );

            //enlarge
            await Task.WhenAny<bool>
            (
                    FlyingImage.ScaleTo(1.1,30, Easing.SinInOut)
            );

            if (Attack)
            {
                //Spin to enemy to new location
                await Task.WhenAny<bool>
                (
                    FlyingImage.TranslateTo(NewLocation.Column * 60, NewLocation.Row * 60, (uint)(60 * distance), Easing.SinInOut),
                    //FlyingImage.RelRotateTo(360 * NumRotations, (uint)(60 * distance)),
                    FlyingImage.ScaleTo(2.0, (uint)(60 * distance), Easing.SinInOut)
                );

                //de-enlarge upon landing
                await Task.WhenAny<bool>
                (
                    FlyingImage.ScaleTo(0.5, 30, Easing.SinInOut)
                );

                //decrease size again
                await Task.WhenAny<bool>
                (
                    FlyingImage.ScaleTo(1.1, 30, Easing.SinInOut)
                );

                //return to old location
                await Task.WhenAny<bool>
                (
                    FlyingImage.TranslateTo(OldLocation.Column * 60, OldLocation.Row * 60, (uint)(50 * distance), Easing.SinInOut)
                );
            }
            else
            {
                //Move to new location
                await Task.WhenAny<bool>
                (
                    FlyingImage.TranslateTo(NewLocation.Column * 60, NewLocation.Row * 60, (uint)(50 * distance), Easing.SinInOut)
                );
            }

            //Decrease size again
            await Task.WhenAny<bool>
            (
                FlyingImage.ScaleTo(0.833, 30, Easing.SinInOut)
            );

            ////try to delay, doesn't work

            FlyingImage.IsVisible = false;
            ImageOfPlayer.IsVisible = true;
            
            return;
        }

        #region MapEvents
        /// <summary>
        /// Event when an empty location is clicked on
        /// </summary>
        /// <param name="CurrentMapLocation"></param>
        /// <returns></returns>
        public bool SetSelectedEmpty(MapModelLocation CurrentMapLocation, bool testing = false)
        {
            // TODO: Info

            /*
             * This gets called when the characters is clicked on
             * Usefull if you want to select the location to move to etc.
             * 
             * For Mike's simple battle grammar there is no selection of action so I just return true
             */
            
             // Empty space can be selected only during the game
             if(AttackButton.IsVisible == true || StartBattleButton.IsVisible == true || NextRoundButton.IsVisible == true)                  
             {
                return false;
             }                                              
    
            var Attacker = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker;
            var AttackerLocation = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.GetLocationForPlayer(Attacker);
            var AttackerJob = Attacker.Job;

            if(testing)
            {
                AttackerLocation = new MapModelLocation();
                AttackerLocation.Row = 0;
                AttackerLocation.Column = 1;
            }

            // Can Player reach this location?
            if (testing || BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.CanAttackerMoveHere(CurrentMapLocation, AttackerLocation, AttackerJob))
            {

                Debug.WriteLine(string.Format("{0} moves from {1},{2} to {3},{4}", AttackerLocation.Player.Name, AttackerLocation.Column, AttackerLocation.Row, CurrentMapLocation.Column, CurrentMapLocation.Row));

                if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender == null)
                {
                    return false;
                }

                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.SeattleSlip + BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.Name;
  
                BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.MovePlayerOnMap(AttackerLocation, CurrentMapLocation);

                UpdateMapGrid();
                TurnOff_AutoAttack();
                AttackButton_Clicked(new Button(), EventArgs.Empty);

                GameMessage();
                DrawGameBoardAttackerDefenderSection();

                //Do animation
                Device.BeginInvokeOnMainThread(() =>
                {
                    MoveAnimation(Attacker, AttackerLocation, CurrentMapLocation);
                });
                

                return true;
            }

            //Attacker can't move here, return without moving
            return false;
        }

        /// <summary>
        /// Event when a Monster is clicked on
        /// </summary>
        /// <param name="CurrentLocation"></param>
        /// <returns></returns>
        public bool SetSelectedMonster(MapModelLocation CurrentLocation, bool IsTesting = false, bool LateTest = false)
        {
            // TODO: Info

            /*
             * This gets called when the Monster is clicked on
             * Usefull if you want to select the monster to attack etc.
             * 
             * For Mike's simple battle grammar there is no selection of action so I just return true
             */


            // Empty space can be selected only during the game
            if (!IsTesting && !LateTest)
            {
                if (AttackButton.IsVisible == true || StartBattleButton.IsVisible == true || NextRoundButton.IsVisible == true)
                {
                    return false;
                }
            }

            var Attacker = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker;
            var AttackerLocation = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.GetLocationForPlayer(Attacker);
            var AttackerJob = Attacker.Job;
            var Defender = CurrentLocation.Player;
            
            if(IsTesting || LateTest)
            {
                AttackerLocation = new MapModelLocation
                {
                    Row = 0,
                    Column = 1,
                };
            }

            // Can Player reach this location?
            if ((IsTesting && LateTest)|| Math.Abs(BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.CalculateDistance(AttackerLocation, CurrentLocation)) > Attacker.GetRange())
            {
                return false;
            }

            //Do animation
            Device.BeginInvokeOnMainThread(() =>
            {
                MoveAnimation(Attacker, AttackerLocation, CurrentLocation, true);
            });

            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Attack;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = CurrentLocation.Player;
            //Attacker.border
                
            NextAttackExample();

            UpdateMapGrid(false, Attacker);
            
            if(LateTest)
            {
                AttackerName.Text = "Test";
            }


            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender == null)
            {

                UpdateMapGrid();

                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;

                AutoAttackButton_Clicked(new Button(), EventArgs.Empty);
                return true;
            }

            AttackButton_Clicked(new Button(), EventArgs.Empty);

            return true;
        }


        /// <summary>
        /// Event when a Character is clicked on
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SetSelectedCharacter(MapModelLocation data)
        {
            // TODO: Info

            /*
             * This gets called when the characters is clicked on
             * Usefull if you want to select the character and then set state or do something
             * 
             * For Mike's simple battle grammar there is no selection of action so I just return true
             */

            return true;
        }
        #endregion MapEvents

        #endregion BattleMapMode

        #region BasicBattleMode

        /// <summary>
        /// Draw the UI for
        ///
        /// Attacker vs Defender Mode
        /// 
        /// </summary>
        public void DrawGameAttackerDefenderBoard()
        {
            // Clear the current UI
            DrawGameBoardClear();

            // Show Characters across the Top
            DrawPlayerBoxes();

            // Draw the Map
            UpdateMapGrid();

            // Show the Attacker and Defender
            DrawGameBoardAttackerDefenderSection();
        }

        /// <summary>
        /// Draws the Game Board Attacker and Defender
        /// </summary>
        public void DrawGameBoardAttackerDefenderSection()
        {
            //BattlePlayerBoxVersus.Text = "";

            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker == null)
            {
                return;
            }

            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender == null)
            {
                return;
            }
        

            AttackerImage.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.ImageURI;
            AttackerName.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.Name;
            AttackerHealth.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.GetCurrentHealthTotal.ToString() + " / " + BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.GetMaxHealthTotal.ToString();

            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.Alive == false)
            {
                UpdateMapGrid();
            }
        }

        /// <summary>
        /// Draws the Game Board Attacker and Defender areas to be null
        /// </summary>
        public void DrawGameBoardClear()
        {
            AttackerImage.Source = string.Empty;
            AttackerName.Text = string.Empty;
            AttackerHealth.Text = string.Empty;
        }

        /// <summary>
        /// Attack Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AttackButton_Clicked(object sender, EventArgs e)
        {
            AttackButton.IsEnabled = false;
            AttackButton.IsVisible = false;
            AutoAttackButton.IsVisible = true;
            AutoAttackOffButton.IsVisible = false;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent3);
            aTimer.Interval = 100;
            aTimer.Start();
        }

        /// <summary>
        /// Auto Attack Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AutoAttackButton_Clicked(object sender, EventArgs e)
        {      
            AttackButton.IsEnabled = false;
            AttackButton.IsVisible = false;
            AutoAttackButton.IsVisible = false;
            AutoAttackOffButton.IsVisible = true;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 100;
            aTimer.Start();          
        }

        /// <summary>
        /// Auto Attack Off Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AutoAttackButtonOff_Clicked(object sender, EventArgs e)
        {
            TurnOff_AutoAttack();
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PlayerType == PlayerTypeEnum.Monster)
            {
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent3);
                aTimer.Interval = 100;
                aTimer.Start();
            }
        }

        /// <summary>
        /// Opearte this function when Timer starts
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if(BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum == BattleStateEnum.GameOver)
            {
                TurnOff_AutoAttack();
            }        
            Device.BeginInvokeOnMainThread(() =>
            {
                NextAttackExample();
            });
        }

        /// <summary>
        /// Opearte this function when Timer starts
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnTimedEvent2(object source, ElapsedEventArgs e)
        {
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum == BattleStateEnum.GameOver)
            {
                TurnOff_AutoAttack();
            }
            if(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PlayerType == PlayerTypeEnum.Monster)
            Device.BeginInvokeOnMainThread(() =>
            {
                NextAttackExample();
            });
        }

        /// <summary>
        /// Opearte this function when Timer starts
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnTimedEvent3(object source, ElapsedEventArgs e)
        {
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum == BattleStateEnum.GameOver)
            {
                TurnOff_AutoAttack();
            }
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PlayerType == PlayerTypeEnum.Character)
            {
                TurnOff_AutoAttack();
                return;
            }
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PlayerType == PlayerTypeEnum.Monster)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    NextAttackExample();
                });
                return;
            }
        }

        /// <summary>
        /// Settings Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Setttings_Clicked(object sender, EventArgs e)
        {
            TurnOff_AutoAttack();
            await ShowBattleSettingsPage();
        }

        /// <summary>
        /// Next Attack Example
        /// 
        /// This code example follows the rule of
        /// 
        /// Auto Select Attacker
        /// Auto Select Defender
        /// 
        /// Do the Attack and show the result
        /// 
        /// So the pattern is Click Next, Next, Next until game is over
        /// 
        /// </summary>
        public void NextAttackExample()
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;

            // Get the turn, set the current player and attacker to match
            var Attacker = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker;

            if(Attacker == null)
            {
                return;
            }

            var Defender = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender;
            BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(Defender);

            if ( Defender == null || Attacker.PlayerType == Defender.PlayerType)
            {
                BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(BattleEngineViewModel.Instance.Engine.Round.Turn.AttackChoice(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker));

            }

            if (Attacker != null)
            {
                var location = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.GetLocationForPlayer(Attacker);
                if (location != null)
                {
                    object MapObject1 = GetMapGridObject(GetDictionaryImageButtonName(location));
                    var x = (ImageButton)MapObject1;
                    x.BorderWidth = 0;
                    x.BackgroundColor = Color.Transparent;
                }
            }

            // Hold the current state
            var RoundCondition = BattleEngineViewModel.Instance.Engine.Round.RoundNextTurn();

            // Output the Message of what happened.
            GameMessage();

            // Show the outcome on the Board
            DrawGameAttackerDefenderBoard();

            if (RoundCondition == RoundEnum.NewRound)
            {
                TurnOff_AutoAttack();

                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.NewRound;

                // Pause
                Task.Delay(WaitTime);

                Debug.WriteLine("New Round");

                // Show the Round Over, after that is cleared, it will show the New Round Dialog
                ShowModalRoundOverPage();
                return;
            }

            // Check for Game Over
            if (RoundCondition == RoundEnum.GameOver)
            {
                TurnOff_AutoAttack();

                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;

                // Wrap up
                BattleEngineViewModel.Instance.Engine.EndBattle();

                // Pause
                Task.Delay(WaitTime);

                Debug.WriteLine("Game Over");

                GameOver();
                return;
            }
        }

        /// <summary>
        /// Decide The Turn and who to Attack
        /// </summary>
        public void SetAttackerAndDefender()
        {
            BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(BattleEngineViewModel.Instance.Engine.Round.GetNextPlayerTurn());
           
            switch (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PlayerType)
            {
                case PlayerTypeEnum.Character:
                   
                    // for now just auto selecting
                    BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(BattleEngineViewModel.Instance.Engine.Round.Turn.AttackChoice(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker));
                    break;

                case PlayerTypeEnum.Monster:
                    break;  
                    
                default:

                    // Monsters turn, so auto pick a Character to Attack
                    BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(BattleEngineViewModel.Instance.Engine.Round.Turn.AttackChoice(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker));
                    break;
            }
        }

        /// <summary>
        /// Game is over
        /// 
        /// Show Buttons
        /// 
        /// Clean up the Engine
        /// 
        /// Show the Score
        /// 
        /// Clear the Board
        /// 
        /// </summary>
        public void GameOver()
        {
            // Save the Score to the Score View Model, by sending a message to it.
            var Score = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore;

            List<PlayerInfoModel> deathListNotPet = new List<PlayerInfoModel>();

            foreach (var x in Score.CharacterModelDeathList)
            {
                if (x.Job != CharacterJobEnum.Pet)
                    deathListNotPet.Add(x);
            }

            Score.CharacterModelDeathList = deathListNotPet;

            GenericViewModel<ScoreModel> ViewModel = new GenericViewModel<ScoreModel>(Score);

            MessagingCenter.Send(new ScoreCreatePage(ViewModel), "Create", Score);

            ShowBattleMode();
        }


        #endregion BasicBattleMode

        #region MessageHandelers

        /// <summary>
        /// Builds up the output message
        /// </summary>
        /// <param name="message"></param>
        public void GameMessage()
        {
            // Output The Message that happened.
            BattleMessages.Text = string.Format("{0} \n{1}", BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.TurnMessage, BattleMessages.Text);

            Debug.WriteLine(BattleMessages.Text);

            if (!string.IsNullOrEmpty(BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.LevelUpMessage))
            {
                BattleMessages.Text = string.Format("{0} \n{1}", BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.LevelUpMessage, BattleMessages.Text);
            }
        }

        /// <summary>
        ///  Clears the messages on the UX
        /// </summary>
        public void ClearMessages()
        {
            BattleMessages.Text = "";
            htmlSource.Html = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.GetHTMLBlankMessage();
        }

        #endregion MessageHandelers

        #region PageHandelers

        /// <summary>
        /// Battle Over, so Exit Button
        /// Need to show this for the user to click on.
        /// The Quit does a prompt, exit just exits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ExitButton_Clicked(object sender, EventArgs e)
        {
            TurnOff_AutoAttack();
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Turn off Auto Attack
        /// </summary>
        public async void TurnOff_AutoAttack()
        {
            aTimer.Stop();
            aTimer = new Timer();
            Device.BeginInvokeOnMainThread(() =>
            {
                AttackButton.IsEnabled = true;
                AutoAttackButton.IsVisible = true;
                AutoAttackOffButton.IsVisible = false;
            });
        }

        /// <summary>
        /// Turn off Auto Attack
        /// </summary>
        public async void TurnOff_AutoAttack2()
        {

            aTimer.Stop();
            aTimer = new Timer();
            Device.BeginInvokeOnMainThread(() =>
            {
                AutoAttackButton.IsVisible = true;
                AutoAttackOffButton.IsVisible = false;
                //NextAttackExample();
                //SetAttackerAndDefender();


                var Attacker = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker;
                if (Attacker.PlayerType == PlayerTypeEnum.Character)
                {
                    var location = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.GetLocationForPlayer(Attacker);
                    if (location != null)
                    {
                        object MapObject1 = GetMapGridObject(GetDictionaryImageButtonName(location));
                        var x = (ImageButton)MapObject1;
                        if (x.BorderWidth < 1)
                        {
                            x.BorderColor = Color.FromHex("45806D");
                            x.BackgroundColor = Color.FromHex("C5EBDF");
                            x.BorderWidth = 3;
                            // ShowBattleMode();
                        }
                    }
                }
            });
         

        }

        /// <summary>
        /// The Next Round Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void NextRoundButton_Clicked(object sender, EventArgs e)
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;
            ShowBattleMode();
            await Navigation.PushModalAsync(new NewRoundPage());
        }

        /// <summary>
        /// The Start Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void StartButton_Clicked(object sender, EventArgs e)
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;

            ShowBattleMode();
            await Navigation.PushModalAsync(new NewRoundPage());
        }

        /// <summary>
        /// Show the Game Over Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void ShowScoreButton_Clicked(object sender, EventArgs args)
        {
            ShowBattleMode();
            await Navigation.PushModalAsync(new ScorePage());
        }

        /// <summary>
        /// Show the Round Over page
        /// 
        /// Round Over is where characters get items
        /// 
        /// </summary>
        public async void ShowModalRoundOverPage()
        {
            ShowBattleMode();
            await Navigation.PushModalAsync(new RoundOverPage());
        }

        /// <summary>
        /// Show Settings
        /// </summary>
        public async Task ShowBattleSettingsPage()
        {
            ShowBattleMode();
            await Navigation.PushModalAsync(new BattleSettingsPage());
        }
        #endregion PageHandelers

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ShowBattleMode();
        }

        /// <summary>
        /// 
        /// Hide the differnt button states
        /// 
        /// Hide the message display box
        /// 
        /// </summary>
        public void HideUIElements()
        {
            NextRoundButton.IsVisible = false;
            StartBattleButton.IsVisible = false;
            AttackButton.IsVisible = false;
            AutoAttackButton.IsVisible = false;
            AutoAttackOffButton.IsVisible = false;
            MessageDisplayBox.IsVisible = false;
            BattlePlayerInfomationBox.IsVisible = false;
        }

        /// <summary>
        /// Show the proper Battle Mode
        /// </summary>
        public void ShowBattleMode()
        {
            // If running in UT mode, 
            if (UnitTestSetting)
            {
                return;
            }

            HideUIElements();

            ClearMessages();

            DrawPlayerBoxes();

            // Update the Mode
            BattleModeValue.Text = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum.ToMessage();        

            ShowBattleModeDisplay();

            ShowBattleModeUIElements();
        }

        /// <summary>
        /// Set Character List for Game Over
        /// </summary>
        public void SetCharacterList() 
        {
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList)
            {
                CharacterListFrame.Children.Add(CreateCharacterDisplayBox(data));
            }
        }

        /// <summary>
        /// Return a stack layout for the Characters
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout CreateCharacterDisplayBox(PlayerInfoModel data)
        {
            if (data == null)
            {
                data = new PlayerInfoModel();
            }

            // Hookup the image
            var PlayerImage = new Image
            {
                Style = (Style)Application.Current.Resources["ImageBattleMediumStyle"],
                Source = data.ImageURI
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["ScoreCharacterInfoBox"],
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = 80,
                Padding = 0,
                Spacing = 0,
                Children = {
                    PlayerImage,
                },
            };

            return PlayerStack;
        }

        /// <summary>
        /// Control the UI Elements to display
        /// </summary>
        public void ShowBattleModeUIElements()
        {
            switch (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum)
            {
                case BattleStateEnum.Starting:
                    StartBattleButton.IsVisible = true;
                    break;

                case BattleStateEnum.NewRound:          
                    UpdateMapGrid(true);
                    NextRoundButton.IsVisible = true;
                    break;

                case BattleStateEnum.GameOver:
                    // Hide the Game Board
                    GameUIDisplay.IsVisible = false;
                    
                    // Show the Game Over Display
                    GameOverDisplay.IsVisible = true;
                    break;

                case BattleStateEnum.RoundOver:
                case BattleStateEnum.Battling:
                    GameUIDisplay.IsVisible = true;
                    BattlePlayerInfomationBox.IsVisible = true;
                    MessageDisplayBox.IsVisible = true;
                    AttackButton.IsVisible = true;
                    AutoAttackButton.IsVisible = true;
                    MessageDisplayOuterBox.IsVisible = true;
                    break;

                // Based on the State disable buttons
                case BattleStateEnum.Unknown:
                default:
                    break;
            }
        }

        /// <summary>
        /// Control the Map Mode or Simple
        /// </summary>
        public void ShowBattleModeDisplay()
        {
            switch (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum)
            {
                case BattleModeEnum.MapAbility:
                case BattleModeEnum.MapFull:
                case BattleModeEnum.MapNext:
                    GamePlayersTopDisplay.IsVisible = false;
                    BattleMapDisplay.IsVisible = true;
                    break;

                case BattleModeEnum.SimpleAbility:
                case BattleModeEnum.SimpleNext:
                case BattleModeEnum.Unknown:
                default:
                    GamePlayersTopDisplay.IsVisible = true;
                    BattleMapDisplay.IsVisible = false;
                    break;
            }
        }
    }
}