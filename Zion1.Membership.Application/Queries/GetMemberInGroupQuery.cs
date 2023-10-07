using MediatR;
using Zion1.Membership.Domain.Entities;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.DTOs;
using Zion1.Membership.Application.Mapper;

namespace Zion1.Membership.Application.Queries
{
    public class GetMemberInGroupQuery : IRequest<IReadOnlyList<MemberDto>>
    {
        public int GroupId { get; set; }

        public GetMemberInGroupQuery(int groupId)
        {
            GroupId = groupId;
        }

        public class GetMemberListQueryHandler : IRequestHandler<GetMemberInGroupQuery, IReadOnlyList<MemberDto>>
        {
            private readonly IMemberQueryRepository _memberRepository;
            public GetMemberListQueryHandler(IMemberQueryRepository memberRepository)
            {
                _memberRepository = memberRepository;
            }
            

            public async Task<IReadOnlyList<MemberDto>> Handle(GetMemberInGroupQuery request, CancellationToken cancellationToken)
            {
                var memberList = await _memberRepository.GetMembersInGroup(request.GroupId);
                return MembershipMapper.Mapper.Map<IReadOnlyList<MemberDto>>(memberList);
            }
            
        }
    }
}
