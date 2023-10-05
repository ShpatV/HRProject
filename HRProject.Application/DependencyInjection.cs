using HRProject.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HRProject.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<IAffiliateService, AffiliateService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IContractService, ContractService>();
        }
    }
}
