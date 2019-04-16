using System;
using System.Collections.Generic;
using System.Text;
using Exam.Context.Base;
using Exam.Domain.Model;
using Exam.Repository.Base;

namespace Exam.Repository.Aggregate
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(FrameworkDatabaseContext context) : base(context)
        {
        }
    }
}
