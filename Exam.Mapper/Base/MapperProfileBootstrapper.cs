using System.Linq;
using System.Reflection;

namespace Exam.Mapper.Base
{
    public class MapperProfileBootstrapper
    {
        public void RegisterProfiles()
        {
            var mapperAssembly = Assembly.Load("Exam.Mapper");
            var autoMapperProfiles = mapperAssembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(AutoMapper.Profile)));
            AutoMapper.Mapper.Initialize(config => autoMapperProfiles.ToList().ForEach(config.AddProfile));
        }
    }
}
