#region Using Declare

using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.SessionState;

#endregion

namespace CommonDLL.Shared.SessionProvider
{
    /***************************************************************************************************************************************************
     * To Configure to run in SQL :
     * Web Config in <System.Web>:   <sessionState  mode="SQLServer" allowCustomSqlDatabase="true" sqlConnectionString="Data Source=<serverName>;Initial Catalog=<databaseName>;User ID=<userName>;Password=<password>" timeout="30"  cookieless="false"/>
     * Command Line :  aspnet_regsql.exe -S <servername> -U <username> -P <password> -ssadd -sstype c -d <databaseName>
     
     ***************************************************************************************************************************************************/

    [ExcludeFromCodeCoverage]
    public class SessionProvider : ISessionProvider
    {
        #region HttpState Methods

        private HttpSessionState LocalSession
        {
            get { return HttpContext.Current.Session; }
        }

        private HttpApplicationState ApplicationSession
        {
            get { return HttpContext.Current.Application; }
        }

        #endregion

        #region Add & Delete

        public string Add<T>(T serializableObject, bool storeApplicationWide = false)
        {
            var key = System.Guid.NewGuid().ToString("N");
            Add(key, serializableObject, storeApplicationWide);
            return key;
        }

        public void Add<T>(string key, T serializableObject, bool storeApplicationWide = false)
        {
            if (storeApplicationWide)
                ApplicationSession[key] = serializableObject;
            else
                LocalSession[key] = serializableObject;
        }

        public void DeleteFromSession(string key, bool storeApplicationWide = false)
        {
            if (storeApplicationWide)
                ApplicationSession.Remove(key);
            else
                LocalSession.Remove(key);
        }

        #endregion

        #region GetObject

        public T GetObject<T>(string key, bool storeApplicationWide = false)
        {
            var value = storeApplicationWide ? ApplicationSession[key] : LocalSession[key];
            return value == null ? default(T) : (T)value;
        }

        public T GetCustomObject<T>(string key, bool storeApplicationWide = false)
        {
            var value = storeApplicationWide ? ApplicationSession[key] : LocalSession[key];
            return value == null ? default(T) : (T)value;
        }

        #endregion

        #region Timeout Void

        public void IncreaseTimeout(TimeSpan timeSpan)
        {
            LocalSession.Timeout += (int)timeSpan.TotalMinutes;
        }

        public void SetTimeout(TimeSpan timeSpan)
        {
            LocalSession.Timeout = (int)timeSpan.TotalMinutes;
        }

        #endregion
    }
}