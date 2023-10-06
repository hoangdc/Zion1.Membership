using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.DeleteGroup
{
    public class DeleteGroupRequest : IRequest<int>
    {
        public int Id { get; set; } = 0;

        public DeleteGroupRequest()
        {

        }

        public DeleteGroupRequest(int groupId)
        {
            Id = groupId;
        }
    }
}
