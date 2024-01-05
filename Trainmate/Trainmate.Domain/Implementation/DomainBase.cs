using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trainmate.Domain.Interfaces;
using Trainmate.Repositories.Entities;
using Trainmate.Repositories.Infrastructure;

namespace Trainmate.Domain.Implementation
{
    public class DomainBase<TEntity> : IDomainBase<TEntity> where TEntity : EntityBase
    {
        protected readonly IGenericRepository<TEntity> Repository;

        public DomainBase(IGenericRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? page = null, int? itemsPerPage = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return await Repository.GetAll(filter, orderBy, page, itemsPerPage, includes);
        }

        public async Task<TEntity> Find(int id)
        {
            return await Repository.GetById(id);
        }

        public async Task<TEntity> FirstOfDefaultAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return await Repository.FirstOfDefaultAsync(filter, includes);
        }

        public async Task<int> Create(TEntity entity)
        {
            return await Repository.Create(entity);
        }

        public async Task<bool> Update(TEntity entity)
        {
            return await Repository.Update(entity);
        }

        public async Task<int> Delete(TEntity entity)
        {
            return await Repository.Delete(entity);
        }

        public async Task<int> SoftDelete(TEntity entity)
        {
            return await Repository.SoftDelete(entity);
        }
    }
}
