using Microsoft.EntityFrameworkCore;
using Rasot.Core.Domain;
using Rasot.Core.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rasot.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly IDbContext _DbContext;
        private DbSet<T> _entities;

        protected virtual DbSet<T> Entities
        {
            get {

                    if(_entities==null)
                    {
                        _entities = _DbContext.Set<T>();
                    }

                    return _entities;
               }
            
        }
        public Repository(IDbContext rasotDbContext)
        {
            this._DbContext = rasotDbContext;
        }
        public virtual IQueryable<T> Table => Entities;

        public virtual IQueryable<T> TableAsNoTraking => Entities.AsNoTracking();

        public virtual void Delete(int Id)
        {
            if(Id==0)
            {
                throw new ArgumentOutOfRangeException($"Id parameter not available Zero");
            }

            var item = Find(Id);
            Delete(item);
        }

        public virtual void Delete(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException($"Entity not null");
            }

            Entities.Remove(item);
            _DbContext.SaveChanges();
        }

        public virtual T Find(int Id)
        {
            return Entities.Find(Id);
        }

        public virtual void Insert(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException($"Entity not null");
            }

            Entities.Add(item);
            _DbContext.SaveChanges();
        }

        public virtual void Update(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException($"Entity not null");
            }

            Entities.Update(item);
            _DbContext.SaveChanges();
        }

        public virtual void InsertRange(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException($"Entity List not null");
            }
            Entities.AddRange(items);
            _DbContext.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException($"Entity List not null");
            }

            Entities.UpdateRange(items);
            _DbContext.SaveChanges();
        }

        public virtual void DeleteRange(IEnumerable<T> items)
        {
            if(items == null)
            {
                throw new ArgumentNullException($"Entity List not null");
            }
            Entities.RemoveRange(items);
            _DbContext.SaveChanges();
        }
    }
}
