using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.CreateMember
{
    public class CreateMemberRequestHandler : IRequestHandler<CreateMemberRequest, int>
    {
        private readonly IMemberCommandRepository _memberCommandRepository;
        public CreateMemberRequestHandler(IMemberCommandRepository clientRepository)
        {
            _memberCommandRepository = clientRepository;
        }

        public async Task<int> Handle(CreateMemberRequest request, CancellationToken cancellationToken)
        {
            var clientInfo = MembershipMapper.Mapper.Map<Member>(request);
            if (clientInfo is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newClientInfo = await _memberCommandRepository.AddAsync(clientInfo);
            return newClientInfo.Id;
        }
    }
}
