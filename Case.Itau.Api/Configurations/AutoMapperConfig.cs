using v1 = Case.Itau.Business.AutoMapper.V1;

namespace Case.Itau.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(v1.FundosMappingProfile));
        }
    }
}
