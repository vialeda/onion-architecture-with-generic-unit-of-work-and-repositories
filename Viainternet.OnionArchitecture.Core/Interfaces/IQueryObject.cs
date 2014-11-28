using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Interfaces
{
    public interface IQueryObject<TEntity>
    {
        Expression<System.Func<TEntity, bool>> And(Expression<System.Func<TEntity, bool>> query);
        Expression<System.Func<TEntity, bool>> And(IQueryObject<TEntity> queryObject);
        Expression<System.Func<TEntity, bool>> Or(Expression<System.Func<TEntity, bool>> query);
        Expression<System.Func<TEntity, bool>> Or(IQueryObject<TEntity> queryObject);
        Expression<System.Func<TEntity, bool>> Query();
    }
}
