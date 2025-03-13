#region "Using Declare"

using System;

#endregion

namespace CommonDLL.Shared.SessionProvider
{
    /// <summary>
    /// </summary>
    public interface ISessionProvider
    {
        /// <summary>
        ///     Adds the specified serializable object to cache/session and returns a Guid key to access the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject">The serializable object.</param>
        /// <param name="storeApplicationWide">if set to <c>true</c> [store application wide].</param>
        /// <returns></returns>
        string Add<T>(T serializableObject, bool storeApplicationWide = false);

        /// <summary>
        ///     Adds the object using a specific key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="serializableObject">The serializable object.</param>
        /// <param name="storeApplicationWide">if set to <c>true</c> [store application wide].</param>
        void Add<T>(string key, T serializableObject, bool storeApplicationWide = false);

        /// <summary>
        ///     Return te object from session/cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="storeApplicationWide">if set to <c>true</c> [store application wide].</param>
        /// <returns></returns>
        T GetObject<T>(string key, bool storeApplicationWide = false);

        /// <summary>
        ///     Return te object from session/cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="storeApplicationWide">if set to <c>true</c> [store application wide].</param>
        /// <returns></returns>
        T GetCustomObject<T>(string key, bool storeApplicationWide = false);

        /// <summary>
        ///     Deletes from session.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="storeApplicationWide">if set to <c>true</c> [store application wide].</param>
        void DeleteFromSession(string key, bool storeApplicationWide = false);

        void IncreaseTimeout(TimeSpan timeSpan);

        void SetTimeout(TimeSpan timeSpan);
    }
}