using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Services
{
    /// <summary>
    /// Interface for data intreactions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataStore<T>
    {
        // Create data
        Task<bool> CreateAsync(T Data);
        
        // Read data
        Task<T> ReadAsync(string id);
        
        // Update data
        Task<bool> UpdateAsync(T Data);
        
        //  Delete data
        Task<bool> DeleteAsync(string id);
        
        // List of data
        Task<List<T>> IndexAsync();

        // Wipe all data
        Task<bool> WipeDataListAsync();

        // Initialize data
        Task<bool> GetNeedsInitializationAsync();
    }
}