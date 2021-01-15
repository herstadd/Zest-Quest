using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Game.Models;

namespace Game.Services
{
    public class MockDataStore<T> : IDataStore<T> where T: new()
    {
        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile MockDataStore<T> instance;
        private static readonly object syncRoot = new Object();

        public static MockDataStore<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MockDataStore<T>();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        /// <summary>
        /// The Data List
        /// This is where the items are stored
        /// </summary>
        public List<T> datalist = new List<T>();

        // Set Needs Init to False, so toggles to true 
        public bool NeedsInitialization = true;

        /// <summary>
        /// First time toggled, returns true.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> GetNeedsInitializationAsync()
        {
            if (NeedsInitialization == true)
            {
                // Toggle State
                NeedsInitialization = false;
                return await Task.FromResult(true);
            }

            return await Task.FromResult(NeedsInitialization);
        }

        /// <summary>
        /// Clear the Dataset
        /// </summary>
        public async Task<bool> WipeDataListAsync()
        {
            NeedsInitialization = true;

            datalist.Clear();
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Add the data to the list
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for pass, else fail</returns>
        public async Task<bool> CreateAsync(T data)
        {
            if (data == null)
            {
                return await Task.FromResult(false);
            }

            datalist.Add(data);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Takes the ID and finds it in the data set
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Record if found else null</returns>
        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<T> ReadAsync(string id)
        #pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (string.IsNullOrEmpty(id))
            {
                return default(T);
            }

            if (!datalist.Any())
            {
                return default(T);
            }

            T oldData = datalist.Where((T arg) => ((BaseModel<T>)(object)arg).Id.Equals(id)).FirstOrDefault();
            return oldData;
        }

        /// <summary>
        /// Update the data with the information passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for pass, else fail</returns>
        public async Task<bool> UpdateAsync(T data)
        {
            if (data == null)
            {
                return await Task.FromResult(false);
            }

            T oldData = await ReadAsync(((BaseModel<T>)(object)data).Id);
            if (oldData == null)
            {
                return await Task.FromResult(false);
            }

            datalist.Remove(oldData);
            datalist.Add(data);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Deletes the Data passed in by
        /// Removing it from the list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True for pass, else fail</returns>
        public async Task<bool> DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return await Task.FromResult(false);
            }

            T oldData = await ReadAsync(id);
            if (oldData == null)
            {
                return await Task.FromResult(false);
            }

            datalist.Remove(oldData);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Get the full list of data
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<List<T>> IndexAsync()
        {
            return await Task.FromResult(datalist);
        }
    }
}