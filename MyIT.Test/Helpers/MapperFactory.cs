using AutoMapper;
using MyIT.BusinessLogic.AutoMapperProfiles;

namespace MyIT.Test.Helpers;

internal class MapperFactory
{
    public static IMapper GetMapper()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddMaps(new [] {
            typeof(MappingProfile)
        }));

        return new Mapper(configuration);
    }
}