using Zion1.Common.Application.Contracts;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Contracts
{
    public interface IMemberCommandRepository : ICommandRepository<Member>
    {
        Task<int> AssignMembersToGroup(List<int> memberIdList, int groupId);
    }
}
