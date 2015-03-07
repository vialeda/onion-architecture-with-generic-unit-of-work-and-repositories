using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Web.Mvc;

namespace Infrastructure.Caching
{
    /// <summary>
    /// Cache action types.
    /// </summary>
    public enum CachingAction
    {
        /// <summary>
        /// Add a new item to cache.
        /// </summary>
        Add = 1,
        /// <summary>
        /// Remove all associated items from cache for the given domain model.
        /// </summary>
        Remove = 2
    }
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// MemoryCache is a simple in-memory caching sample which does not support a distributed caching scenario in case of web farm deployments.
    /// For distributed scenarios it may be replaced by any solution that supports this like "AppFabric Caching API" (http://msdn.microsoft.com/en-us/library/hh334209.aspx)
    /// The server bits for AppFabric 1.1 can be downloaded from here: http://www.microsoft.com/en-US/download/details.aspx?id=27115 
    /// This can be implemented by adding a reference to the package "ServerAppFabric.Client" (https://nuget.org/packages/ServerAppFabric.Client)
    /// and include a DataCache wrapper class that implemetns ObjectCache or simply replace all "cache" usage with changes like:
    /// "cache.Add(expenseId.ToString(), expense, GetExpiration())" may be replaced by "cache.Add(expenseId.ToString(), expense, this.expiration)"
    /// where cache is now defined as "private DataCache cache".
    /// </remarks>
    [Serializable]
    public class CachingInterceptorAttribute : FilterAttribute, IInterceptionBehavior
    {
        private ObjectCache _cache;
        private TimeSpan _expiration;
        private CachingAction _action;
        /// <summary>
        /// Caching for 15 minutes.
        /// </summary>
        /// <param name="action">Add/Remove caching action.</param>
        public CachingInterceptorAttribute(CachingAction action)
        {
            this.Initialize();
            _action = CachingAction.Add;
            _expiration = new TimeSpan(0, 15, 0);
        }
        /// <summary>
        /// Caching constructor
        /// </summary>
        /// <param name="action">Add/Remove caching action.</param>
        /// <param name="expiration">Expiration of caching value.</param>
        public CachingInterceptorAttribute(CachingAction action, TimeSpan expiration)
        {
            this.Initialize();
            _action = CachingAction.Add;
            _expiration = expiration;
        }

        public IMethodReturn Invoke(IMethodInvocation input,
        GetNextInterceptionBehaviorDelegate getNext)
        {
            var cacheKey = BuildCacheKey(input);
            if (_action == CachingAction.Add)
            {
                // If cache is empty, execute the target method, retrieve the return value and cache it.
                if (!_cache.Any(k => k.Key == cacheKey))
                {
                    // Execute the target method
                    IMethodReturn returnVal = getNext()(input, getNext);
                    // Cache the return value
                    _cache.Add(cacheKey, returnVal.ReturnValue, GetExpiration());

                    return returnVal;
                }

                // Otherwise, return the cache result
                return input.CreateMethodReturn(_cache.Get(cacheKey), input.Arguments);
            }
            else
            {
                _cache.Remove(cacheKey);

                IMethodReturn returnVal = getNext()(input, getNext);
                return returnVal;
            }
        }
        /// <summary>
        /// Build the cache key using the type name, method name and parameter argument values.
        /// </summary>
        /// <param name="input">Aspect arguments.</param>
        /// <returns>Cache key.</returns>
        private string BuildCacheKey(IMethodInvocation input)
        {
            const string divider = "_";

            var typeName = GetTypeName(input.GetType());

            var cacheKey = new StringBuilder();
            cacheKey.Append(typeName);
            cacheKey.Append(divider);
            cacheKey.Append(input.MethodBase.Name);

            foreach (var argument in input.Arguments)
                cacheKey.Append(argument == null ? divider : argument.ToString());

            return cacheKey.ToString();
        }

        /// <summary>
        /// Use reflection to get the object's type name. 
        /// </summary>
        /// <param name="type">The object's type.</param>
        /// <returns>Type name.</returns>
        /// <remarks>
        /// If we're supporting non-generic repositories we need to identify the correct type name.
        /// </remarks>
        private string GetTypeName(Type type)
        {
            return ((type.UnderlyingSystemType).GenericTypeArguments.Any())
                ? ((type.UnderlyingSystemType).GenericTypeArguments[0]).Name
                : type.Name;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private void Initialize(TimeSpan? cacheExpiration = null)
        {
            
            if (ConfigurationManager.AppSettings["CachedExpiration"] == null)
            {
                const string noCachedExpiration = @"Their is no cache expiration value in web.config. You have to add <add key=""CachedExpiration"" value=""00:05:00""/>";
                throw new ArgumentNullException(noCachedExpiration);
            }

            this._cache = MemoryCache.Default;
            this._expiration = cacheExpiration ?? (TimeSpan)new InfiniteTimeSpanConverter().ConvertFromString(ConfigurationManager.AppSettings["CachedExpiration"]);
        }

        private CacheItemPolicy GetExpiration()
        {
            var policy = new CacheItemPolicy();

            if (this._expiration > TimeSpan.Zero &&
                this._expiration < TimeSpan.MaxValue)
            {
                policy.AbsoluteExpiration = DateTimeOffset.UtcNow.Add(this._expiration);
            }

            return policy;
        }
    }
}