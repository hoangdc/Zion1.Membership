﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Infrastructure.Persistence;
using Zion1.Membership.Infrastructure.Persistence.Repositories;
using Zion1.Membership.Application.Queries;
using Zion1.Membership.Application.Commands.CreateMember;
using Zion1.Membership.Application.Commands.UpdateMember;
using Zion1.Membership.Application.Commands.DeleteMember;
using Zion1.Membership.Application.Commands.CreateGroup;
using Zion1.Membership.Application.Commands.UpdateGroup;
using Zion1.Membership.Application.Commands.DeleteGroup;

namespace Zion1.Membership.Infrastructure
{
    public static class RegisterService
    {
        public static IServiceCollection AddMemberhispService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MembershipDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("Zion1.Membership"), b => b.MigrationsAssembly(typeof(MembershipDBContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetMemberListQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateMemberRequestHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateMemberRequestHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteMemberRequestHandler).Assembly));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetGroupListQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateGroupRequestHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateGroupRequestHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteGroupRequestHandler).Assembly));

            services.AddScoped<IMemberCommandRepository, MemberCommandRepository>();
            services.AddScoped<IMemberQueryRepository, MemberQueryRepositoty>();

            services.AddScoped<IGroupCommandRepository, GroupCommandRepository>();
            services.AddScoped<IGroupQueryRepository, GroupQueryRepositoty>();

            services.AddScoped<IMemberInGroupCommandRepository, MemberInGroupCommandRepositoty>();


            return services;
        }
    }
}
