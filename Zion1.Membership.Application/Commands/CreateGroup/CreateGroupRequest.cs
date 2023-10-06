using MediatR;

namespace Zion1.Membership.Application.Commands.CreateGroup
{
    public class CreateGroupRequest : IRequest<int>
    {
        public string GroupName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
