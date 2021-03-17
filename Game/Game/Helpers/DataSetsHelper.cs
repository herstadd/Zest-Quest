using System;
using System.Threading.Tasks;

using Game.ViewModels;

namespace Game.Helpers
{
    static public class DataSetsHelper
    {
        /// <summary>
        /// To warm up Dataset for Score and Item
        /// </summary>
        /// <returns></returns>
        static public bool WarmUp()
        {
            ScoreIndexViewModel.Instance.GetCurrentDataSource();
            ItemIndexViewModel.Instance.GetCurrentDataSource();

            return true;
        }

        // Lock for wiping
        private static readonly object WipeLock = new object();

        /// <summary>
        /// Call the Wipe routines in order one by one
        /// </summary>
        /// <returns></returns>
        static public async Task<bool> WipeDataInSequence()
        {
            lock (WipeLock)
            {
                var runSyncScore = Task.Factory.StartNew(new Func<Task>(async () =>
                {
                    await ScoreIndexViewModel.Instance.DataStoreWipeDataListAsync();
                    await Task.Delay(100);
                })).Unwrap();
                runSyncScore.Wait();
                

                var runSyncItem = Task.Factory.StartNew(new Func<Task>(async () =>
                {
                    await ItemIndexViewModel.Instance.DataStoreWipeDataListAsync();
                    await Task.Delay(100);
                })).Unwrap();
                runSyncItem.Wait();
            }

            return await Task.FromResult(true);
        }
    }
}