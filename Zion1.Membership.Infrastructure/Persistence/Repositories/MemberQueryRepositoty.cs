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
            var group = _membershipDbContext.Groups.Where(g => g.Id == groupId).FirstOrDefault();
            var memberList = _membershipDbContext.Members.Where(m => m.Groups.Equals(group));
            await Task.Delay(1);
            return memberList.ToList();
        }
    }
}
