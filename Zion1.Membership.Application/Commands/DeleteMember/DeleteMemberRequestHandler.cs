using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.DeleteMember
{
    public class DeleteMemberRequestHandler : IRequestHandler<DeleteMemberRequest, int>
    {
        private readonly IMemberCommandRepository _memberCommandRepository;
        public DeleteMemberRequestHandler(IMemberCommandRepository memberRepository)
        {
            _memberCommandRepository = memberRepository;
        }

        public async Task<int> Handle(DeleteMemberRequest request, CancellationToken cancellationToken)
        {
            var member = await _memberCommandRepository.GetByIdAsync(request.Id);
            if (member is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            await _memberCommandRepository.DeleteAsync(member);
            return member.Id;
        }
    }
}
