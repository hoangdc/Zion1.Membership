using MediatR;
using Zion1.Membership.Domain.Entities;
using Zion1.Membership.Application.Contracts;

namespace Zion1.Membership.Application.Queries
{
    public class GetMemberListQuery : IRequest<IReadOnlyList<Member>>
    {
        public class GetMemberListQueryHandler : IRequestHandler<GetMemberListQuery, IReadOnlyList<Member>>
        {
            private readonly IMemberQueryRepository _memberRepository;
            public GetMemberListQueryHandler(IMemberQueryRepository memberRepository)
            {
                _memberRepository = memberRepository;
            }
            

            public async Task<IReadOnlyList<Member>> Handle(GetMemberListQuery request, CancellationToken cancellationToken)
            {
                return await _memberRepository.GetAllAsync();
            }
            
        }
    }
}
