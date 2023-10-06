using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.AssignMemberToGroup
{
    public class AssignMemberToGroupRequestHandler : IRequestHandler<AssignMemberToGroupRequest, bool>
    {
        private readonly IMemberInGroupCommandRepository _memberInGroupCommandRepository;
        public AssignMemberToGroupRequestHandler(IMemberInGroupCommandRepository memberInGroupRepository)
        {
            _memberInGroupCommandRepository = memberInGroupRepository;
        }

        public async Task<bool> Handle(AssignMemberToGroupRequest request, CancellationToken cancellationToken)
        {
            var memberInGroup = MembershipMapper.Mapper.Map<MemberInGroup>(request);

            //check GroupId and MemberId existed in Groups and Members

            if (memberInGroup is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            await _memberInGroupCommandRepository.AddAsync(memberInGroup);

            return true;
        }
    }
}
