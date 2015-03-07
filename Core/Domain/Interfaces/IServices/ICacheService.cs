using System;

namespace Viainternet.OnionArchitecture.Core.Interfaces.IServices
{
    public interface ICacheService
    {
        T Get<T>(string cacheID) where T : class;
        T Get<T>(string cacheID, Func<T> getItemCallback) where T : class;
        void Set<T>(string cacheID, object result) where T : class;
    }
}
