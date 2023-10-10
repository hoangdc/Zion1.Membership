using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.AssignMemberToGroup
{
    public class AssignMemberToGroupRequestHandler : IRequestHandler<AssignMemberToGroupRequest, bool>
    {
        private readonly IMemberCommandRepository _memberCommandRepository;
        public AssignMemberToGroupRequestHandler(IMemberCommandRepository memberInGroupRepository)
        {
            _memberCommandRepository = memberInGroupRepository;
        }

        public async Task<bool> Handle(AssignMemberToGroupRequest request, CancellationToken cancellationToken)
        {
            return await _memberCommandRepository.AssignMemberToGroup(request.MemberId, request.GroupId);
        }
    }
}
