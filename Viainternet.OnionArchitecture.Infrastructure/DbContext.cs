using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viainternet.OnionArchitecture.Core.Interfaces;

namespace Viainternet.OnionArchitecture.Infrastructure
{
    public class CodeFirst : DbContext, IDataContextAsync
    {
        public void SyncObjectsStatePostCommit()
        {
            throw new NotImplementedException();
        }

        public void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState
        {
            throw new NotImplementedException();
        }
    }
}
