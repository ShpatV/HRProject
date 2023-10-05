using HRProject.Domain.Interfaces;
using HRProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("HRProject"));
            });

            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAffiliateRepository, AffiliateRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
        }
    }
}
