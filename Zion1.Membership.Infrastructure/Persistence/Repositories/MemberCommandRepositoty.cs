using Azure.Core;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> AssignMembersToGroup(List<int> memberIdList, int groupId)
        {
            //Delete all MembersInGroups of this group
            await _membershipDbContext.Database.ExecuteSqlAsync($"DELETE [MembersInGroups] WHERE GroupsId={groupId}");

            //Insert all members to this group
            var memberList = _membershipDbContext.Members.Where(m => memberIdList.Contains(m.Id));
            var group = _membershipDbContext.Groups.FirstOrDefault(group => group.Id == groupId);

            if (memberList != null && group != null)
            {
                group.Members.AddRange(memberList);
                return await _membershipDbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
