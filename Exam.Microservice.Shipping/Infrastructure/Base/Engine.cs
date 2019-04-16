using Exam.Mapper.Base;

namespace Exam.Microservice.Shipping.Infrastructure.Base
{
    public class Engine
    {
        public void Ignite()
        {
            MapperDependencyInjectorBootstrapper();
        }

        internal void MapperDependencyInjectorBootstrapper() => new MapperProfileBootstrapper().RegisterProfiles();
    }
}
