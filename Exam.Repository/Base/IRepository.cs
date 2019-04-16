using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using Exam.Context.Base;
using Exam.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repository.Base
{
    public interface IRepository<T> where T : Domain.Base.Aggregate
    {
        FrameworkDatabaseContext _context { get; set; }
        IEnumerable<T> GetAll();
        T Get(Guid id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
