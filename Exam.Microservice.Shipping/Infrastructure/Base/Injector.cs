using Exam.Business.Core;
using Exam.Context.Base;
using Exam.Context.Boundary;
using Exam.Repository.Aggregate;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Exam.Microservice.Shipping.Infrastructure.Base
{
    public static class Injector
    {
        public static void Inject(this IServiceCollection services)
        {
            services.AddSingleton<Engine>();
            services.AddTransient<IShippingBusiness, ShippingBusiness>();
            services.AddTransient<ProductRepository>();
            services.AddTransient<FrameworkDatabaseContext, ShippingBoundedContext>();

        }
        private static string GetXmlCommentsPath()
        {
            var app = System.AppContext.BaseDirectory;
            return System.IO.Path.Combine(app, "Exam.Microservice.Shipping.xml");
        }
    }
}
