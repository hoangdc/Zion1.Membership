using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.DeleteUserProfile
{
    public class DeleteUserProfileRequestHandler : IRequestHandler<DeleteUserProfileRequest, int>
    {
        private readonly IUserProfileCommandRepository _userProfileCommandRepository;
        public DeleteUserProfileRequestHandler(IUserProfileCommandRepository clientRepository)
        {
            _userProfileCommandRepository = clientRepository;
        }

        public async Task<int> Handle(DeleteUserProfileRequest request, CancellationToken cancellationToken)
        {
            var clientInfo = await _userProfileCommandRepository.GetByIdAsync(request.Id);
            if (clientInfo is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newClientInfo = await _userProfileCommandRepository.DeleteAsync(clientInfo);
            return newClientInfo.Id;
        }
    }
}
