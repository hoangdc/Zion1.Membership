using MediatR;
using Zion1.Membership.Domain.Entities;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.DTOs;
using Zion1.Membership.Application.Mapper;

namespace Zion1.Membership.Application.Queries
{
    public class GetMemberListQuery : IRequest<IReadOnlyList<MemberDto>>
    {
        public class GetMemberListQueryHandler : IRequestHandler<GetMemberListQuery, IReadOnlyList<MemberDto>>
        {
            private readonly IMemberQueryRepository _memberRepository;
            public GetMemberListQueryHandler(IMemberQueryRepository memberRepository)
            {
                _memberRepository = memberRepository;
            }
            

            public async Task<IReadOnlyList<MemberDto>> Handle(GetMemberListQuery request, CancellationToken cancellationToken)
            {
                var memberList = await _memberRepository.GetAllAsync();
                return MembershipMapper.Mapper.Map<IReadOnlyList<MemberDto>>(memberList);
            }
            
        }
    }
}
