using Application.Countries.Commands.CreateCountry;
using Infrastructure;
using Microsoft.Extensions.Options;
using Presentation.Utils.ApiClient;
using Presentation.Utils.Services.Contries;
using Presentation.Utils.Services.DeviceTypes;
using Presentation.Utils.Services.Manufacturer;
using Presentation.Utils.Services.NomenclatureService;
using Presentation.Utils.Services.S3Service;

namespace Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new Exception("Connection string not found.");

            services.InjectInfrastructure(connectionString);

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateCountryCommand).Assembly);
            });

            services.AddHttpClient("", client =>
            {
                var address = configuration["ApiSettings:BaseAddress"] ?? throw new Exception();
                client.BaseAddress = new Uri(address);
            });

            services.Configure<S3Settings>(configuration.GetSection("S3"));
            services.AddScoped(sp => sp.GetRequiredService<IOptions<S3Settings>>().Value);
            services.AddScoped<IS3Service, S3Service>();

            services.AddScoped<IApiClient, ApiClient>();

            services.AddScoped<IDeviceTypeService, DeviceTypeService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<INomenclatureService, NomenclatureService>();

            return services;
        }
    }
}
