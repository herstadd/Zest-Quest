using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

using Game.Models;
using Game.Views;
using Game.GameRules;
using Game.Helpers;

namespace Game.ViewModels
{
    /// <summary>
    /// Index View Model
    /// Manages the list of data records
    /// </summary>
    public class CharacterIndexViewModel : BaseViewModel<CharacterModel>
    {
        private static CharacterModel DefaultCharacter = null;

        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile CharacterIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        public static CharacterIndexViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new CharacterIndexViewModel();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        #region Constructor

        /// <summary>
        /// Constructor
        /// 
        /// The constructor subscribes message listeners for crudi operations
        /// </summary>
        public CharacterIndexViewModel()
        {
            Title = "Characters";

            #region Messages

            // Register the Create Message
            MessagingCenter.Subscribe<CharacterCreatePage, CharacterModel>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as CharacterModel);
            });

            // Register the Update Message
            MessagingCenter.Subscribe<CharacterUpdatePage, CharacterModel>(this, "Update", async (obj, data) =>
            {
                // Have the item update itself
                data.Update(data);

                await UpdateAsync(data as CharacterModel);
            });

            // Register the Delete Message
            MessagingCenter.Subscribe<CharacterDeletePage, CharacterModel>(this, "Delete", async (obj, data) =>
            {
                await DeleteAsync(data as CharacterModel);
            });

            // Register the Set Data Source Message
            MessagingCenter.Subscribe<AboutPage, int>(this, "SetDataSource", async (obj, data) =>
            {
                await SetDataSource(data);
            });

            // Register the Wipe Data List Message
            MessagingCenter.Subscribe<AboutPage, bool>(this, "WipeDataList", async (obj, data) =>
            {
                await WipeDataListAsync();
            });

            #endregion Messages
        }

        #endregion Constructor
        
        #region DataOperations_CRUDi

        /// <summary>
        /// Returns the item passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override CharacterModel CheckIfExists(CharacterModel data)
        {
            if (data == null)
            {
                return null;
            }

            // This will walk the items and find if there is one that is the same.
            // If so, it returns the item...

            var myList = Dataset.Where(a =>
                                        a.Name == data.Name &&
                                        a.Description == data.Description
                                        )
                                        .FirstOrDefault();

            if (myList == null)
            {
                // it's not a match, return false;
                return null;
            }

            return myList;
        }

        /// <summary>
        /// Load the Default Data
        /// </summary>
        /// <returns></returns>
        public override List<CharacterModel> GetDefaultData() 
        {
            return DefaultData.LoadData(new CharacterModel());
        }

        #endregion DataOperations_CRUDi

        #region SortDataSet

        /// <summary>
        /// The Sort Order for the CharacterModel
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public override List<CharacterModel> SortDataset(List<CharacterModel> dataset)
        {
            return dataset
                    .OrderBy(a => a.Name)
                    .ThenBy(a => a.Description)
                    .ToList();
        }

        #endregion SortDataSet

        #region GetFromDefaultData
        private void InitializeDefaultCharacter(string target)
        {
            CharacterJobEnum character = CharacterJobEnumHelper.ConvertStringToEnum(target);

            if (DefaultCharacter == null)
            {
                DefaultCharacter = DefaultDataHelper.GetCharacter(character);
            }
            else
            {
                if (character != DefaultCharacter.Job)
                {
                    DefaultCharacter = DefaultDataHelper.GetCharacter(character);
                }
            }
        }

        public string GetSpecialty(string target)
        {
            InitializeDefaultCharacter(target);

            if (DefaultCharacter == null)
            {
                return "";
            }

            return DefaultCharacter.Description;
        }

        public string GetImage(string target)
        {
            InitializeDefaultCharacter(target);

            if (DefaultCharacter == null)
            {
                return "item.png";
            }

            return DefaultCharacter.ImageURI;
        }

        public int GetLevel(string target)
        {
            InitializeDefaultCharacter(target);

            if (DefaultCharacter == null)
            {
                return 1;
            }

            return DefaultCharacter.Level;
        }

        public string GetItemForLocation(string target, string ItemLocation)
        {
            InitializeDefaultCharacter(target);

            if (DefaultCharacter == null)
            {
                return "No Item";
            }
            switch(ItemLocation)
            {
                case "Head":
                    return DefaultCharacter.Head; // ""
                case "Feet":
                    return DefaultCharacter.Feet;
                case "Necklass":
                    return DefaultCharacter.Necklass;
                case "PrimaryHand":
                    return DefaultCharacter.PrimaryHand;
                case "OffHand":
                    return DefaultCharacter.OffHand;
                case "RightFinger":
                    return DefaultCharacter.RightFinger;
                case "LeftFinger":
                    return DefaultCharacter.LeftFinger;
                default:
                    return "No Item";
            }
        }

        /// <summary>
        /// Calculates a new max health value based on which chef type was selected
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetMaxHealth(string target)
        {
            CharacterJobEnum character = CharacterJobEnumHelper.ConvertStringToEnum(target);

            int DefaultHealth = 0;

            switch (character)
            {
                case CharacterJobEnum.HeadChef:
                case CharacterJobEnum.HomeCook:
                    DefaultHealth = DiceHelper.RollDice(10, 10);
                    break;

                case CharacterJobEnum.SchoolChef:
                    DefaultHealth = DiceHelper.RollDice(5, 10);
                    break;

                case CharacterJobEnum.SousChef:
                case CharacterJobEnum.SushiChef:
                case CharacterJobEnum.CatChef:
                    DefaultHealth = DiceHelper.RollDice(1, 10);
                    break;

                case CharacterJobEnum.Unknown:
                default:
                    break;
            }

            return DefaultHealth;
        }
        #endregion GetFromDefaultData
    }
}