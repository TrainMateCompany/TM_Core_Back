using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trainmate.Repositories.Entities;

namespace Trainmate.Domain.Interfaces
{
    public interface IDomainBase<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? page = null, int? itemsPerPage = null, params Expression<Func<T, object>>[] includes);

        Task<T> Find(int id);

        Task<T> FirstOfDefaultAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);

        Task<int> Create(T entity);

        Task<bool> Update(T entity);

        Task<int> Delete(T entity);
    }
}
