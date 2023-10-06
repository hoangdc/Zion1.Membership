using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.UpdateMember
{
    public class UpdateMemberRequestHandler : IRequestHandler<UpdateMemberRequest, int>
    {
        private readonly IMemberCommandRepository _memberCommandRepository;
        public UpdateMemberRequestHandler(IMemberCommandRepository memberRepository)
        {
            _memberCommandRepository = memberRepository;
        }

        public async Task<int> Handle(UpdateMemberRequest request, CancellationToken cancellationToken)
        {
            var member = MembershipMapper.Mapper.Map<Member>(request);
            if (member is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            await _memberCommandRepository.UpdateAsync(member);
            return member.Id;
        }
    }
}
