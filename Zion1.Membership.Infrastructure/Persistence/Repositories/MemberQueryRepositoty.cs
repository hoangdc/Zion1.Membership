using Microsoft.EntityFrameworkCore;
using Zion1.Common.Infrastructure.Persistence.Repositories;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Infrastructure.Persistence.Repositories
{
    public class MemberQueryRepositoty : QueryRepository<Member>, IMemberQueryRepository
    {
        private MembershipDBContext _membershipDbContext;
        public MemberQueryRepositoty(MembershipDBContext membershipDbContext) : base(membershipDbContext)
        {
            _membershipDbContext = membershipDbContext;
        }

        public async Task<IReadOnlyList<Member>> GetMembersInGroup(int groupId) 
        {
            var membersInGroup = _membershipDbContext.Groups
                .Where(group => group.Id == groupId)
                .SelectMany(group => group.Members);
            await Task.Delay(1);
            return membersInGroup.ToList();
        }
    }
}
