using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using Exam.Context.Base;
using Exam.Domain.Base;
using Exam.Exception.Core;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : Domain.Base.Aggregate
    {
        public FrameworkDatabaseContext _context { get; set; }
        private readonly DbSet<T> _entities;
        string _errorMessage = string.Empty;
        public Repository(FrameworkDatabaseContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }
        public T Get(Guid id)
        {
            return _entities.SingleOrDefault(x => x.Id == id);
        }
        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(T));
            }
            _entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(T));
            }

            var databaseObject = _entities.Find(entity.Id);
            if (databaseObject is null)
                throw new ObjectNotFoundException("Item Not Found");
            if (!entity.RowVersion.SequenceEqual(databaseObject.RowVersion))
            {
                throw new UpdateLostException("Rpw Version Mismatch");
            }
            _context.Entry(databaseObject).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(T));
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

    }
}
