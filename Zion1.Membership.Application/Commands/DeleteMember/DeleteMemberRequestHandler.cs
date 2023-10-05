using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.DeleteMember
{
    public class DeleteMemberRequestHandler : IRequestHandler<DeleteMemberRequest, int>
    {
        private readonly IMemberCommandRepository _memberCommandRepository;
        public DeleteMemberRequestHandler(IMemberCommandRepository clientRepository)
        {
            _memberCommandRepository = clientRepository;
        }

        public async Task<int> Handle(DeleteMemberRequest request, CancellationToken cancellationToken)
        {
            var clientInfo = await _memberCommandRepository.GetByIdAsync(request.Id);
            if (clientInfo is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newClientInfo = await _memberCommandRepository.DeleteAsync(clientInfo);
            return newClientInfo.Id;
        }
    }
}
