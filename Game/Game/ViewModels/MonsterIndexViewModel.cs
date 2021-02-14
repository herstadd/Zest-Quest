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
    public class MonsterIndexViewModel : BaseViewModel<MonsterModel>
    {
        private static MonsterModel DefaultMonster = null;

        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile MonsterIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        public static MonsterIndexViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MonsterIndexViewModel();
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
        public MonsterIndexViewModel()
        {
            Title = "Monsters";

            #region Messages

            // Register the Create Message
            MessagingCenter.Subscribe<MonsterCreatePage, MonsterModel>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as MonsterModel);
            });

            // Register the Update Message
            MessagingCenter.Subscribe<MonsterUpdatePage, MonsterModel>(this, "Update", async (obj, data) =>
            {
                // Have the item update itself
                data.Update(data);

                await UpdateAsync(data as MonsterModel);
            });

            // Register the Delete Message
            MessagingCenter.Subscribe<MonsterDeletePage, MonsterModel>(this, "Delete", async (obj, data) =>
            {
                await DeleteAsync(data as MonsterModel);
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
        public override MonsterModel CheckIfExists(MonsterModel data)
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
        public override List<MonsterModel> GetDefaultData() 
        {
            return DefaultData.LoadData(new MonsterModel());
        }

        #endregion DataOperations_CRUDi

        #region SortDataSet

        /// <summary>
        /// The Sort Order for the MonsterModel
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public override List<MonsterModel> SortDataset(List<MonsterModel> dataset)
        {
            return dataset
                    .OrderBy(a => a.Name)
                    .ThenBy(a => a.Description)
                    .ToList();
        }

        #endregion SortDataSet

        #region GetFromDefaultData
        /// <summary>
        /// Initializes the default monster based on the target passed in
        /// </summary>
        /// <param name="target"></param>
        private void InitializeDefaultMonster(string target)
        {
            MonsterTypeEnum monster = MonsterJobEnumHelper.ConvertStringToEnum(target);

            if (DefaultMonster == null)
            {
                DefaultMonster = DefaultDataHelper.GetMonster(monster);
            }
            else
            {
                if (monster != DefaultMonster.MonsterType)
                {
                    DefaultMonster = DefaultDataHelper.GetMonster(monster);
                }
            }
        }

        /// <summary>
        /// Gets the description for a specific monster type
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string GetDescription(string monster)
        {
            InitializeDefaultMonster(monster);

            if (DefaultMonster == null)
            {
                return "";
            }

            return DefaultMonster.Description;
        }

        /// <summary>
        /// Gets the image URI for a specific character type
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string GetImage(string monster)
        {
            InitializeDefaultMonster(monster);

            if (DefaultMonster == null)
            {
                return "item.png";
            }

            return DefaultMonster.ImageURI;
        }

        /// <summary>
        /// Gets the unique drop for a specific monster type
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public ItemModelEnum GetUniqueDrop(string monster)
        {
            InitializeDefaultMonster(monster);

            if (DefaultMonster == null)
            {
                return ItemModelEnum.Unknown;
            }

            return DefaultMonster.UniqueDrop;
        }

        /// <summary>
        /// Gets the class (standard/boss) for a specific monster type
        /// </summary>
        /// <param name="monster"></param>
        /// <returns></returns>
        public string GetMonsterClass(string monster)
        {
            InitializeDefaultMonster(monster);

            if (DefaultMonster == null)
            {
                return "Standard";
            }

            return DefaultMonster.MonsterClass;
        }
        #endregion GetFromDefaultData
    }
}