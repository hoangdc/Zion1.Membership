using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.UpdateUserProfile
{
    public class UpdateUserProfileRequestHandler : IRequestHandler<UpdateUserProfileRequest, int>
    {
        private readonly IUserProfileCommandRepository _userProfileCommandRepository;
        public UpdateUserProfileRequestHandler(IUserProfileCommandRepository clientRepository)
        {
            _userProfileCommandRepository = clientRepository;
        }

        public async Task<int> Handle(UpdateUserProfileRequest request, CancellationToken cancellationToken)
        {
            var clientInfo = MembershipMapper.Mapper.Map<UserProfile>(request);
            if (clientInfo is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newClientInfo = await _userProfileCommandRepository.UpdateAsync(clientInfo);
            return newClientInfo.Id;
        }
    }
}
