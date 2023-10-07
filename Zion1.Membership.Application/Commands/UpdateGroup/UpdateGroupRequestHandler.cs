using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.UpdateGroup
{
    public class UpdateGroupRequestHandler : IRequestHandler<UpdateGroupRequest, int>
    {
        private readonly IGroupCommandRepository _groupCommandRepository;
        public UpdateGroupRequestHandler(IGroupCommandRepository groupRepository)
        {
            _groupCommandRepository = groupRepository;
        }

        public async Task<int> Handle(UpdateGroupRequest request, CancellationToken cancellationToken)
        {
            //var groupExisted = await _groupCommandRepository.GetByIdAsync(request.Id);
            //if (groupExisted is null)
            //{
            //    throw new ApplicationException("The group is not existed in database.");
            //}
            var group = MembershipMapper.Mapper.Map<Group>(request);
            await _groupCommandRepository.UpdateAsync(group);
            return request.Id;
        }
    }
}
