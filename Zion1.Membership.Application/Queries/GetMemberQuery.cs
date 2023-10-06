using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Queries
{
    public class GetMemberQuery : IRequest<Member>
    {
        public int MemberId { get; set; } = 0;

        public GetMemberQuery(int memberId)
        {
            MemberId = memberId;
        }

        public class GetMemberListQueryHandler : IRequestHandler<GetMemberQuery, Member>
        {
            private readonly IMemberQueryRepository _memberRepository;
            public GetMemberListQueryHandler(IMemberQueryRepository clientRepository)
            {
                _memberRepository = clientRepository;
            }
            

            public async Task<Member> Handle(GetMemberQuery request, CancellationToken cancellationToken)
            {
                return await _memberRepository.GetByIdAsync(request.MemberId);
            }
            
        }
    }
}
