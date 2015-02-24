//using System;
//using System.Web;
//using Viainternet.OnionArchitecture.Core.Interfaces.IServices;

//namespace Viainternet.OnionArchitecture.Core.Services
//{
//    public class CacheService : ICacheService
//    {
//        public T Get<T>(string cacheID) where T : class
//        {
//            T item = HttpRuntime.Cache.Get(cacheID) as T;
//            if(item != null)
//                HttpContext.Current.Cache.Insert(cacheID, item);
            
//            return item;
//        }

//        public void Set<T>(string cacheID, object result) where T : class
//        {
//            T item = HttpRuntime.Cache.Get(cacheID) as T;
//            if (item == null)
//                HttpContext.Current.Cache.Insert(cacheID, result);
//        }

//        public T Get<T>(string cacheID, Func<T> getItemCallback) where T : class
//        {
//            T item = HttpRuntime.Cache.Get(cacheID) as T;
//            if (item == null)
//            {
//                item = getItemCallback();
//                HttpContext.Current.Cache.Insert(cacheID, item);
//            }
//            return item;
//        }
//    }
//}
