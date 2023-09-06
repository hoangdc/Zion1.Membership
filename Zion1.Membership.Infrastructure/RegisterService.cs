using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Infrastructure.Persistence;
using Zion1.Membership.Infrastructure.Persistence.Repositories;
using Zion1.Membership.Application.Queries;
using Zion1.Membership.Application.Commands.CreateUserProfile;
using Zion1.Membership.Application.Commands.UpdateUserProfile;
using Zion1.Membership.Application.Commands.DeleteUserProfile;

namespace Zion1.Membership.Infrastructure
{
    public static class RegisterService
    {
        public static IServiceCollection AddMemberhispService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MembershipDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("Zion1.Membership"), b => b.MigrationsAssembly(typeof(MembershipDBContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserProfileListQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserProfileRequestHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateUserProfileRequestHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteUserProfileRequestHandler).Assembly));

            services.AddScoped<IUserProfileCommandRepository, UserProfileCommandRepository>();
            services.AddScoped<IUserProfileQueryRepository, UserProfileQueryRepositoty>();


            return services;
        }
    }
}
