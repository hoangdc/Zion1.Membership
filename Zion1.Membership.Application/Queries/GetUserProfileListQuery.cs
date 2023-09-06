using MediatR;
using Zion1.Membership.Domain.Entities;
using Zion1.Membership.Application.Contracts;

namespace Zion1.Membership.Application.Queries
{
    public class GetUserProfileListQuery : IRequest<IReadOnlyList<UserProfile>>
    {
        public class GetClientListQueryHandler : IRequestHandler<GetUserProfileListQuery, IReadOnlyList<UserProfile>>
        {
            private readonly IUserProfileQueryRepository _userProfileRepository;
            public GetClientListQueryHandler(IUserProfileQueryRepository userProfileRepository)
            {
                _userProfileRepository = userProfileRepository;
            }
            

            public async Task<IReadOnlyList<UserProfile>> Handle(GetUserProfileListQuery request, CancellationToken cancellationToken)
            {
                return await _userProfileRepository.GetAllAsync();
            }
            
        }
    }
}
