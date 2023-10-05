using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.DeleteMember
{
    public class DeleteMemberRequest : IRequest<int>
    {
        public int Id { get; set; } = 0;

        public DeleteMemberRequest()
        {

        }

        public DeleteMemberRequest(int userId)
        {
            Id = userId;
        }
    }
}
