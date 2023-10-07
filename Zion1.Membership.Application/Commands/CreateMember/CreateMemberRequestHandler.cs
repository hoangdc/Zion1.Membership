using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.CreateMember
{
    public class CreateMemberRequestHandler : IRequestHandler<CreateMemberRequest, int>
    {
        private readonly IMemberCommandRepository _memberCommandRepository;
        public CreateMemberRequestHandler(IMemberCommandRepository memberRepository)
        {
            _memberCommandRepository = memberRepository;
        }

        public async Task<int> Handle(CreateMemberRequest request, CancellationToken cancellationToken)
        {
            var member = MembershipMapper.Mapper.Map<Member>(request);
            if (member is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newMember = await _memberCommandRepository.AddAsync(member);
            return newMember.Id;
        }
    }
}
