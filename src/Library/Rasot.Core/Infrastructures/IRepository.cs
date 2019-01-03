using Rasot.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rasot.Core.Infrastructures
{
    public interface IRepository<T> where T:BaseEntity
    {
        void Insert(T item);
        void InsertRange(IEnumerable<T> items);
        void Update(T item);
        void UpdateRange(IEnumerable<T> items);

        T Find(int Id);
        void Delete(int Id);
        void Delete(T item);
        void DeleteRange(IEnumerable<T> items);
        IQueryable<T> Table { get; }
        IQueryable<T> TableAsNoTraking { get; }
    }
}
