﻿using Zion1.Common.Infrastructure.Persistence.Repositories;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Infrastructure.Persistence.Repositories
{
    public class GroupCommandRepository : CommandRepository<Group>, IGroupCommandRepository
    {
        private MembershipDBContext _membershipDbContext;
        public GroupCommandRepository(MembershipDBContext membershipDbContext) : base(membershipDbContext)
        {
            _membershipDbContext = membershipDbContext;
        }
    }
}
