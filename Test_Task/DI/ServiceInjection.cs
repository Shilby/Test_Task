using Test_Task.Services;

namespace Test_Task.DI
{
    public static class ServiceInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICandidateService, CandidateService>();
        }
    }
}
