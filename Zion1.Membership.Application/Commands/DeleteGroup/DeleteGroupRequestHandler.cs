using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.DeleteGroup
{
    public class DeleteGroupRequestHandler : IRequestHandler<DeleteGroupRequest, int>
    {
        private readonly IGroupCommandRepository _groupCommandRepository;
        public DeleteGroupRequestHandler(IGroupCommandRepository groupRepository)
        {
            _groupCommandRepository = groupRepository;
        }

        public async Task<int> Handle(DeleteGroupRequest request, CancellationToken cancellationToken)
        {
            var group = await _groupCommandRepository.GetByIdAsync(request.Id);
            if (group is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            await _groupCommandRepository.DeleteAsync(group);
            return group.Id;
        }
    }
}
