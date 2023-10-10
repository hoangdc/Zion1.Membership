using Azure.Core;
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

        public async Task<bool> AssignMemberToGroup(int memberId,int groupId)
        {
            var member = _membershipDbContext.Members.FirstOrDefault(member => member.Id == memberId);
            var group = _membershipDbContext.Groups.FirstOrDefault(group => group.Id == groupId);
            if (member != null && group != null)
            {
                group.Members.Add(member);
                await _membershipDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
