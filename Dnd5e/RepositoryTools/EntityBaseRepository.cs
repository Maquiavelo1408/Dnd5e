using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Media.Animation;

namespace Dnd5e.RepositoryTools
{
    public class EntityBaseRepository
    {
        protected DbContext _context;
        public EntityBaseRepository(CharacterContext characterContext)
        {
            _context = characterContext;
        }

        public virtual IEnumerable<T> GetAll<T>(Expression<Func<T, T>> select = null) where T : class, new()
        {
            IQueryable<T> query = _context.Set<T>();
            if (select != null)
            {
                query = query.Select(select);
            }
            return query.AsEnumerable();
        }

        public virtual IEnumerable<T> GetAllIncluding<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public virtual IEnumerable<T> GetAllWhere<T>(List<Expression<Func<T, bool>>> whereExpressions, Expression<Func<T, T>> select = null, params Expression<Func<T, object>>[] includeProperties) where T : class, new()
        {
            return GetAllQueryable(whereExpressions, select, includeProperties).AsEnumerable();
        }

        public virtual int Count<T>() where T : class, new()
        {
            return _context.Set<T>().Count();
        }

        public T GetSingle<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) where T : class, new()
        {
            IQueryable<T> query = _context.Set<T>();
            foreach(var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            var entity = query.FirstOrDefault(predicate);
            return entity;
        }

        public T GetSingle<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> select) where T : class, new()
        {
            IQueryable<T> query = _context.Set<T>();
            if(select != null)
            {
                query = query.Where(predicate).Select(select);
            }
            else
            {
                query = query.Where(predicate);
            }
            return query.FirstOrDefault();
        }

        public virtual void Add<T>(T entity) where T : class, new()
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Add(entity);
        }

        public virtual void Add<T>(object entityObject) where T : class, new()
        {
            T entity = (T)entityObject;
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<object> entityList)
        {
            _context.AddRange(entityList);
        }

        public virtual void Update<T>(T entity) where T : class, new()
        {
            EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<object> entityList)
        {
            _context.UpdateRange(entityList);
        }

        public virtual void Delete<T>(T entity) where T : class, new()
        {
            EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere<T>(Expression<Func<T, bool>> predicate) where T : class, new()
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            _context.RemoveRange(entities);
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }

        private IQueryable<T> GetAllQueryable<T>(List<Expression<Func<T, bool>>> whereExpressions, Expression<Func<T, T>> select = null, params Expression<Func<T, object>>[] includeProperties) where T:class, new()
        {
            IQueryable<T> query = _context.Set<T>();
            if(select != null)
            {
                if(whereExpressions != null)
                {
                    foreach(var item in whereExpressions)
                    {
                        query = query.Where(item);
                    }
                }
                query = query.Select(select);
                return query;
            }
            else
            {
                foreach(var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                if(whereExpressions != null)
                {
                    foreach(var item in whereExpressions)
                    {
                        query = query.Where(item);
                    }
                }
                return query;
            }
        }
    }
    public class DndRepository : EntityBaseRepository
    {
        public DndRepository(CharacterContext context) : base(context) { }
    }
}
