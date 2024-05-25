using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using CongestionTaxCalculator.Infrastructure;
using CongestionTaxCalculator.Infrastructure.Repositories;
using CongestionTaxCalculator.Domain.Interfaces.Repositories;



namespace CongestionTaxCalculator.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCongestionTaxDbContext(this IServiceCollection services/*, IConfiguration configuration*/)
        {
            services.AddDbContext<CongestionTaxContext>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddScoped<ITaxExemptionRepository, TaxExemptionRepository>();
            services.AddScoped<ITaxRuleRepository, TaxRuleRepository>();


            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<CongestionTaxCalculator>(options =>
            //    options.UseSqlServer(connectionString));
            return services;
        }
    }
}
