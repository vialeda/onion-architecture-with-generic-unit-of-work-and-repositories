using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Viainternet.OnionArchitecture.Core.Interfaces.IRepositories;
using Viainternet.OnionArchitecture.Core.Interfaces.IServices;

namespace Viainternet.OnionArchitecture.Core.Interfaces
{
    public interface IUnitOfWorkAsync : IUnitOfWork, IDisposable
    {
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
