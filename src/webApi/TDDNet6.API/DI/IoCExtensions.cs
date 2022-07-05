using TDDNet6.Services.User;

namespace TDDNet6.API.DI
{
    public static class IoCExtensions
    {
        internal static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
