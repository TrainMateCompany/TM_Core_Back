using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trainmate.Repositories.Context;
using Trainmate.Repositories.Entities;

namespace Trainmate.Repositories.Infrastructure
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : EntityBase
    {
        protected readonly AppDbContext Context;
        private readonly DbSet<T> _dbSet;
        private bool _disposed;

        public GenericRepository(AppDbContext context)
        {
            Context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? page = null, int? itemsPerPage = null, params Expression<Func<T, object>>[] includes)
        {
            var query = await GetAllQuery(filter, orderBy, includes);

            if (page.HasValue && itemsPerPage.HasValue && page.Value > 0 && itemsPerPage.Value > 0)
            {
                query = query.Skip((page.Value - 1) * itemsPerPage.Value).Take(itemsPerPage.Value);
            }

            return query.ToList();
        }

        public Task<IQueryable<T>> GetAllQuery(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            // Siempre filtrar por Deleted = false
            query = query.Where(x => !x.Deleted);

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return Task.FromResult(query);
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(e => e.Id == id && !e.Deleted);
        }

        public async Task<T> FirstOfDefaultAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.Where(e => !e.Deleted).Where(filter);

            if (includes.Any())
            {
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> Create(T entity)
        {
            try
            {
                entity.CreationDate = DateTime.Now;

                await _dbSet.AddAsync(entity);
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> CreateBulk(List<T> entityList)
        {
            try
            {
                entityList.ForEach(entity =>
                {
                    entity.CreationDate = DateTime.Now;
                });

                await _dbSet.AddRangeAsync(entityList);
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<int> Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> DeleteBulk(List<T> entityList)
        {
            try
            {
                _dbSet.RemoveRange(entityList);
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> SoftDelete(T entity)
        {
            try
            {
                entity.Deleted = true;
                Context.Entry(entity).State = EntityState.Modified;
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetTotalDtoRecords(IQueryable<object> query)
        {
            return query.Count();
        }

        public async Task<IList<object>> GetDtoList(IQueryable<object> query, int pageSize, int currentPage)
        {
            if (pageSize > 0 && currentPage > 0)
            {
                query = query.Skip(pageSize * (currentPage - 1)).Take(pageSize);
            }

            return await query.ToListAsync();

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                Context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
