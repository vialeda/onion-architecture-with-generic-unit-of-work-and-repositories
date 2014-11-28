using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Interfaces
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        void SyncObjectsStatePostCommit();
        void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState;
    }
}
