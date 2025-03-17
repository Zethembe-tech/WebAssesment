#region Using Declare

using CommonDLL.DTO;
using CommonDLL.Object;
using System;

#endregion

namespace WebAssessment.Controllers.Cache
{
    public interface ICacheProvider
    {
        void SetTimeoutSession(TimeSpan timeSpan);

        void IncreaseTimeoutSession(TimeSpan timeSpan);


        void CacheUserDetail(Users model);

        Users GetUserDetail();

        void CacheObject(CacheObject cacheObject);

        void CacheCustomObject(CacheObject cacheObject);

        CacheObject GetObjectByKey(string key);

        CacheObject GetCustomObjectByValue(string value);

        string[] GetStringArrayByKey(string key);

        void CacheStringArray(string key, string[] strArr);
    }
}