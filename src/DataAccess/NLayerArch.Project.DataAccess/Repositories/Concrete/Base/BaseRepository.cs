using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.DataAccess.Repositories.Abstract.Base;
using NLayerArch.Project.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NLayerArch.Project.Bussines.Base.PagingStructure;

namespace NLayerArch.Project.DataAccess.Repositories.Concrete.Base
{
    public class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity, new()
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private DbSet<T> __table { get => _dbContext.Set<T>(); }
        public async Task AddAsync(T entity)
        {
            await __table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await __table.AddRangeAsync(entities);

        }
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => { __table.Update(entity); });
            return entity;
        }

        public async Task<IList<T>> UpdateRangeAsync(IList<T> entity)
        {
            await Task.Run(() =>
            {
                __table.UpdateRange(entity);
            });
            return entity;
        }


        public async Task HardDeleteRangeAsync(IList<T> entity)
        {
            await Task.Run(() => { __table.RemoveRange(entity); });
        }
        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => { __table.Remove(entity); });
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = __table;
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);

            return await queryable.FirstOrDefaultAsync(predicate);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            __table.AsNoTracking();
            if (predicate is not null) __table.Where(predicate);
            return await __table.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking)
        {
            if (!enableTracking) __table.AsNoTracking();
            return __table.Where(predicate);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = __table;
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();

            return await queryable.ToListAsync();
        }

        public async Task<IPaginate<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 10)
        {
            IQueryable<T> queryable = __table;
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
            {
                var x = orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize);
                return x.ToPaginate<T>(index: currentPage, size: pageSize);

            }
            var result = queryable.Skip((currentPage - 1) * pageSize).Take(pageSize);
            return result.ToPaginate<T>(index: currentPage, size: pageSize);
        }

        public async Task<IList<T>> GetWithFiltersAsync(Expression<Func<T, bool>>? predicate = null,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                 bool enableTracking = false,
                                                 Dictionary<string, object>? filters = null)
        {
            IQueryable<T> queryable = __table;

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include is not null)
                queryable = include(queryable);

            if (predicate is not null)
                queryable = queryable.Where(predicate);

            if (filters != null)
            {
                // {{"isbestseller","true"}{"CategoryId","1"}} gibi gelecek.
                foreach (var filter in filters)
                {
                    var parameter = Expression.Parameter(typeof(T), "x");
                    var property = Expression.Property(parameter, filter.Key);
                    var constant = Expression.Constant(filter.Value);
                    var equal = Expression.Equal(property, constant);
                    var lambda = Expression.Lambda<Func<T, bool>>(equal, parameter);
                    queryable = queryable.Where(lambda);
                }
            }

            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();

            return await queryable.ToListAsync();
        }

        public async Task<IList<T>> GetWithFiltersByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, Dictionary<string, object>? filters = null, int currentPage = 1, int pageSize = 10)
        {
            IQueryable<T> queryable = __table;

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include is not null)
                queryable = include(queryable);

            if (predicate is not null)
                queryable = queryable.Where(predicate);

            if (filters != null)
            {
                // {{"isbestseller","true"}{"CategoryId","1"}} gibi gelecek.
                foreach (var filter in filters)
                {
                    var parameter = Expression.Parameter(typeof(T), "x");
                    var property = Expression.Property(parameter, filter.Key);
                    var constant = Expression.Constant(filter.Value);
                    var equal = Expression.Equal(property, constant);
                    var lambda = Expression.Lambda<Func<T, bool>>(equal, parameter);
                    queryable = queryable.Where(lambda);
                }
            }

            if (orderBy is not null)
            {
                return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            }

            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync(); ;
        }

    }
}
