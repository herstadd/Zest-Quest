using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

using Game.Models;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Engine.EngineBase;

namespace Game.ViewModels
{
    /// <summary>
    /// Index View Model
    /// Manages the list of data records
    /// </summary>
    public class BattleEngineViewModel
    {
        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile BattleEngineViewModel instance;
        private static readonly object syncRoot = new Object();

        public static BattleEngineViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new BattleEngineViewModel();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        #region BattleEngineSelection
        // The Battle Engine
        public IBattleEngineInterface EngineKoenig = new Engine.EngineKoenig.BattleEngine();

        // Auto Battle Engine (used for scneario testing)
        public IAutoBattleInterface AutoBattleEngineKoenig = new Engine.EngineKoenig.AutoBattleEngine();

        // The Battle Engine
        public IBattleEngineInterface EngineGame = new Engine.EngineGame.BattleEngine();

        // Auto Battle Engine (used for scneario testing)
        public IAutoBattleInterface AutoBattleEngineGame = new Engine.EngineGame.AutoBattleEngine();

        // Set the Battle Engine
        public IBattleEngineInterface Engine;

        // Auto Battle Engine (used for scneario testing)
        public IAutoBattleInterface AutoBattleEngine;

        #endregion BattleEngineSelection

        // Hold the Proposed List of Characters for the Battle to Use
        public ObservableCollection<CharacterModel> PartyCharacterList { get; set; } = new ObservableCollection<CharacterModel>();

        //// Hold the View Model to the CharacterIndexViewModel
        //public CharacterIndexViewModel DatabaseCharacterViewModel = CharacterIndexViewModel.Instance;

        //// Have the Database Character List point to the Character View Model List
        //public ObservableCollection<CharacterModel> DatabaseCharacterList { get; set; } = CharacterIndexViewModel.Instance.Dataset;

     
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BattleEngineViewModel()
        {
            SetBattleEngineToGame();
        }

        /// <summary>
        /// Set the Battle Engine to the Game Version for actual use
        /// </summary>
        /// <returns></returns>
        public bool SetBattleEngineToGame()
        {
            Engine = EngineGame;
            AutoBattleEngine = AutoBattleEngineGame;
            return true;
        }

        /// <summary>
        /// Set the Battle Engine to the Koenig Version for Testing
        /// </summary>
        /// <returns></returns>
        public bool SetBattleEngineToKoenig()
        {
            Engine = EngineKoenig;
            AutoBattleEngine = AutoBattleEngineKoenig;
            return true;
        }

        #endregion Constructor
    }
}