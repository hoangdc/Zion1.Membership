using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Queries
{
    public class GetGroupQuery : IRequest<Group>
    {
        public int GroupId { get; set; } = 0;

        public GetGroupQuery(int groupId)
        {
            GroupId = groupId;
        }

        public class GetGroupListQueryHandler : IRequestHandler<GetGroupQuery, Group>
        {
            private readonly IGroupQueryRepository _groupRepository;
            public GetGroupListQueryHandler(IGroupQueryRepository clientRepository)
            {
                _groupRepository = clientRepository;
            }
            

            public async Task<Group> Handle(GetGroupQuery request, CancellationToken cancellationToken)
            {
                return await _groupRepository.GetByIdAsync(request.GroupId);
            }
            
        }
    }
}
