using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Interfaces.IServices
{
    public interface IEntitiesContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : IEntity;
        void SetAsAdded<TEntity>(TEntity entity) where TEntity : IEntity;
        void SetAsModified<TEntity>(TEntity entity) where TEntity : IEntity;
        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : IEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void BeginTransaction();
        int Commit();
        void Rollback();
        Task<int> CommitAsync();
    }
}
