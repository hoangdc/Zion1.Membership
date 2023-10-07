using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.DTOs;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Queries
{
    public class GetMemberQuery : IRequest<MemberDto>
    {
        public int MemberId { get; set; } = 0;

        public GetMemberQuery(int memberId)
        {
            MemberId = memberId;
        }

        public class GetMemberListQueryHandler : IRequestHandler<GetMemberQuery, MemberDto>
        {
            private readonly IMemberQueryRepository _memberRepository;
            public GetMemberListQueryHandler(IMemberQueryRepository clientRepository)
            {
                _memberRepository = clientRepository;
            }
            

            public async Task<MemberDto> Handle(GetMemberQuery request, CancellationToken cancellationToken)
            {
                var member = await _memberRepository.GetByIdAsync(request.MemberId);
                return MembershipMapper.Mapper.Map<MemberDto>(member);
            }
            
        }
    }
}
