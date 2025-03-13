#region Using Declare

using CommonDLL.DTO;
using CommonDLL.Object;
using CommonDLL.Shared.SessionProvider;
using System;

#endregion

namespace AspireClient.Controllers.Cache
{
    public class CacheProvider : ICacheProvider
    {
        private ISessionProvider SessionProvider { get; set; }

        #region Ctor

        public CacheProvider(ISessionProvider sessionProvider)
        {
            SessionProvider = sessionProvider;
        }

        public CacheProvider()
            : this(new SessionProvider())
        {
        }

        #endregion

        #region Logged in User

        private const string CachedUser = "CACHED_USER";

        public void SetTimeoutSession(TimeSpan timeSpan)
        {
            SessionProvider.SetTimeout(timeSpan);
        }

        public void IncreaseTimeoutSession(TimeSpan timeSpan)
        {
            SessionProvider.IncreaseTimeout(timeSpan);
        }

        public void CacheUserDetail(Users model)
        {
            SessionProvider.Add(CachedUser, model);
        }

        public Users GetUserDetail()
        {
            try
            {
                return SessionProvider.GetObject<Users>(CachedUser);
            }
            catch (Exception)
            {
                return SessionProvider.GetObject<Users>(string.Empty);
            }
        }

        #endregion

        #region Object Store

        public void CacheObject(CacheObject cacheObject)
        {
            SessionProvider.Add(cacheObject.Key, cacheObject);
        }

        public void CacheStringArray(string key, string[] strArr)
        {
            SessionProvider.Add(key, strArr);
        }

        public void CacheCustomObject(CacheObject cacheObject)
        {
            if (cacheObject.Value == null)
            {
                cacheObject.Value = "0";
            }
            SessionProvider.Add(cacheObject.Key, cacheObject);
        }

        public CacheObject GetObjectByKey(string key)
        {
            if (SessionProvider.GetObject<CacheObject>(key) != null)
                return SessionProvider.GetObject<CacheObject>(key);

            else return new CacheObject();
        }

        public CacheObject GetCustomObjectByValue(string value)
        {
            if (SessionProvider.GetCustomObject<CacheObject>(value) != null)
                return SessionProvider.GetCustomObject<CacheObject>(value);

            else return new CacheObject();
        }

        public string[] GetStringArrayByKey(string key)
        {
            if (SessionProvider.GetObject<string[]>(key) != null)
                return SessionProvider.GetObject<string[]>(key);

            else return new string[0];
        }

        #endregion
    }
}