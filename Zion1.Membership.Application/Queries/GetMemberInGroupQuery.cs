using MediatR;
using Zion1.Membership.Domain.Entities;
using Zion1.Membership.Application.Contracts;

namespace Zion1.Membership.Application.Queries
{
    public class GetMemberInGroupQuery : IRequest<IReadOnlyList<Member>>
    {
        public int GroupId { get; set; }

        public GetMemberInGroupQuery(int groupId)
        {
            GroupId = groupId;
        }

        public class GetMemberListQueryHandler : IRequestHandler<GetMemberInGroupQuery, IReadOnlyList<Member>>
        {
            private readonly IMemberQueryRepository _memberRepository;
            public GetMemberListQueryHandler(IMemberQueryRepository memberRepository)
            {
                _memberRepository = memberRepository;
            }
            

            public Task<IReadOnlyList<Member>> Handle(GetMemberInGroupQuery request, CancellationToken cancellationToken)
            {
                return _memberRepository.GetMembersInGroup(request.GroupId);
            }
            
        }
    }
}
