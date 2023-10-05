using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.UpdateMember
{
    public class UpdateMemberRequestHandler : IRequestHandler<UpdateMemberRequest, int>
    {
        private readonly IMemberCommandRepository _memberCommandRepository;
        public UpdateMemberRequestHandler(IMemberCommandRepository clientRepository)
        {
            _memberCommandRepository = clientRepository;
        }

        public async Task<int> Handle(UpdateMemberRequest request, CancellationToken cancellationToken)
        {
            var clientInfo = MembershipMapper.Mapper.Map<Member>(request);
            if (clientInfo is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newClientInfo = await _memberCommandRepository.UpdateAsync(clientInfo);
            return newClientInfo.Id;
        }
    }
}
