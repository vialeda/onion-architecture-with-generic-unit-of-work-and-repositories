using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Interfaces
{
    public interface IQueryFluent<TEntity> where TEntity : IObjectState
    {
        IQueryFluent<TEntity> Include(Expression<Func<TEntity, object>> expression);
        IQueryFluent<TEntity> OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        IEnumerable<TEntity> Select();
        IEnumerable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector = null);
        Task<IEnumerable<TEntity>> SelectAsync();
        IEnumerable<TEntity> SelectPage(int page, int pageSize, out int totalCount);
        IQueryable<TEntity> SqlQuery(string query, params object[] parameters);
    }
}
