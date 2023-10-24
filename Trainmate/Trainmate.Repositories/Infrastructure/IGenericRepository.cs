using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trainmate.Repositories.Entities;

namespace Trainmate.Repositories.Infrastructure
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? page = null, int? itemsPerPage = null, params Expression<Func<T, object>>[] includes);

        Task<IQueryable<T>> GetAllQuery(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes);

        Task<T> GetById(int id);

        Task<T> FirstOfDefaultAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);

        Task<int> Create(T entity);

        Task<int> CreateBulk(List<T> entityList);

        Task<bool> Update(T entity);

        Task<int> Delete(T entity);

        Task<int> SoftDelete(T entity);

        int GetTotalDtoRecords(IQueryable<object> query);

        Task<IList<object>> GetDtoList(IQueryable<object> query, int pageSize, int currentPage);
        Task<int> DeleteBulk(List<T> entityList);
    }
}
