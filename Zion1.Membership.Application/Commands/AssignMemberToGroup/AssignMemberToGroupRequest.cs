using MediatR;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.AssignMemberToGroup
{
    public class AssignMemberToGroupRequest : IRequest<int>
    {
        public List<int> MemberIdList { get; set; } = new();
        public int GroupId { get; set; } = 0;
    }
}
