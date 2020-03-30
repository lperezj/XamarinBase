using System;
using System.Threading.Tasks;

namespace Cognizant.AppServices.Contracts
{
    public interface ISecureStorageService
    {
        /// <summary>
        ///     Gets a value from Secure Storage by its key
        /// </summary>
        /// <returns>The auth info.</returns>
        Task<T> Get<T>(string key);

        /// <summary>
        ///     Remove all values in the Secure Storage
        /// </summary>
        /// <returns>Task.</returns>
        Task RemoveAll();

        /// <summary>
        ///     Saves a value by key in the Secure Storage
        /// </summary>
        /// <returns>Task.</returns>
        /// <param name="key">Identifier</param>
        /// <param name="value">Value to save</param>
        Task Set<T>(string key, T value);

        /// <summary>
        ///     Remove a value by key in the Secure Storage
        /// </summary>
        /// <returns>
        /// True if removed, otherwise false
        /// </returns>
        /// <param name="key">Identifier</param>
        bool Remove(string key);
    }
}
