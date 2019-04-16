using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Exam.Context.Base
{
    public class FrameworkDatabaseContext : DbContext
    {
        public static readonly LoggerFactory ConsoleLoggerFactory
            = new LoggerFactory(new[] {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true) });
        public FrameworkDatabaseContext(DbContextOptions<FrameworkDatabaseContext> options) : base(options) 
        {
            
            // Database.Log = s => Debug.Write(s);
            //Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Exam;User Id=sa;password=110!!)ali;Trusted_Connection=False;MultipleActiveResultSets=true;" ,x => x.MigrationsAssembly("Exam.Context"));
            optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFactory)
                .EnableSensitiveDataLogging(true);
        }
        public void EnableLog()
        {
            //  this. = message => Debug.Write($"{message}");
        }


    }
}
