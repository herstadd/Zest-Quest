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
        Task<bool> CreateAsync(T Data);
        Task<T> ReadAsync(string id);
        Task<bool> UpdateAsync(T Data);
        Task<bool> DeleteAsync(string id);
        Task<List<T>> IndexAsync();

        Task<bool> WipeDataListAsync();
        Task<bool> GetNeedsInitializationAsync();
    }
}