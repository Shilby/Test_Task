using Test_Task.Repository;

namespace Test_Task.DI
{
    public static class RepositoryInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICandidateRepository, CandidateRepository>();

        }
    }
}
