using MediatR;

namespace Zion1.Membership.Application.Commands.UpdateGroup
{
    public class UpdateGroupRequest : IRequest<int>
    {
        public int Id { get; set; } = 0;
        public string GroupName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
