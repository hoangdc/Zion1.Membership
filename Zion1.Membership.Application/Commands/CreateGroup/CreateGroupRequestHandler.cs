using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.CreateGroup
{
    public class CreateGroupRequestHandler : IRequestHandler<CreateGroupRequest, int>
    {
        private readonly IGroupCommandRepository _groupCommandRepository;
        public CreateGroupRequestHandler(IGroupCommandRepository groupRepository)
        {
            _groupCommandRepository = groupRepository;
        }

        public async Task<int> Handle(CreateGroupRequest request, CancellationToken cancellationToken)
        {
            var group = MembershipMapper.Mapper.Map<Group>(request);
            if (group is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newGroup = await _groupCommandRepository.AddAsync(group);
            return newGroup.Id;
        }
    }
}
