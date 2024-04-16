using CleanArch.Application.Mapping;

namespace CleanArch.MVC.MappingConfig;

public static class AutoMapperConfig 
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
    }
}