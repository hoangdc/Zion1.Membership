using Zion1.Common.Infrastructure.Persistence.Repositories;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Infrastructure.Persistence.Repositories
{
    public class MemberCommandRepository : CommandRepository<Member>, IMemberCommandRepository
    {
        private MembershipDBContext _membershipDbContext;
        public MemberCommandRepository(MembershipDBContext membershipDbContext) : base(membershipDbContext)
        {
            _membershipDbContext = membershipDbContext;
        }
    }
}
