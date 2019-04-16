using Exam.Context.Base;
using Exam.Domain.Map;
using Exam.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Exam.Context.Boundary
{
    public class ShippingBoundedContext : FrameworkDatabaseContext
    {

        public ShippingBoundedContext() : base(new DbContextOptions<FrameworkDatabaseContext>())
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductMap());
        }

 
    }
}

