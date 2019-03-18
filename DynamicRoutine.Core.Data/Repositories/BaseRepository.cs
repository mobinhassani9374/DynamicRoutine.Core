using DynamicRoutine.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DynamicRoutine.Core.Utility;
using System.Linq.Expressions;

namespace DynamicRoutine.Core.Data.Repositories
{
    public abstract class BaseRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public ServiceResult Create(TEntity entity)
        {
            _context.Add(entity);
            return _context.Save();
        }

        public ServiceResult Update(TEntity entity)
        {
            _context.Update(entity);
            return _context.Save();
        }
    }
}
