using MediatR;
using Zion1.Membership.Domain.Entities;
using Zion1.Membership.Application.Contracts;

namespace Zion1.Membership.Application.Queries
{
    public class GetGroupListQuery : IRequest<IReadOnlyList<Group>>
    {
        public class GetGroupListQueryHandler : IRequestHandler<GetGroupListQuery, IReadOnlyList<Group>>
        {
            private readonly IGroupQueryRepository _groupRepository;
            public GetGroupListQueryHandler(IGroupQueryRepository groupRepository)
            {
                _groupRepository = groupRepository;
            }
            

            public async Task<IReadOnlyList<Group>> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
            {
                return await _groupRepository.GetAllAsync();
            }
            
        }
    }
}
