using MediatR;

namespace Zion1.Membership.Application.Commands.AssignMemberToGroup
{
    public class AssignMemberToGroupRequest : IRequest<bool>
    {
        public int MemberId { get; set; } = 0;
        public int GroupId { get; set; } = 0;
    }
}
