using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.AssignMemberToGroup
{
    public class AssignMemberToGroupRequestHandler : IRequestHandler<AssignMemberToGroupRequest, int>
    {
        private readonly IMemberCommandRepository _memberCommandRepository;
        public AssignMemberToGroupRequestHandler(IMemberCommandRepository memberInGroupRepository)
        {
            _memberCommandRepository = memberInGroupRepository;
        }

        public async Task<int> Handle(AssignMemberToGroupRequest request, CancellationToken cancellationToken)
        {
            return await _memberCommandRepository.AssignMembersToGroup(request.MemberIdList, request.GroupId);
        }
    }
}
