using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Interfaces.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class, IObjectState
    {
        void Delete(object id);
        void Delete(TEntity entity);
        TEntity Find(params object[] keyValues);
        IRepository<T> GetRepository<T>() where T : class, IObjectState;
        void Insert(TEntity entity);
        void InsertGraphRange(IEnumerable<TEntity> entities);
        void InsertOrUpdateGraph(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        IQueryFluent<TEntity> Query();
        IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query);
        IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject);
        IQueryable<TEntity> Queryable();
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);
        void Update(TEntity entity);
    }
}
