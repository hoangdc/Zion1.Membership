using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.CreateUserProfile
{
    public class CreateUserProfileRequestHandler : IRequestHandler<CreateUserProfileRequest, int>
    {
        private readonly IUserProfileCommandRepository _userProfileCommandRepository;
        public CreateUserProfileRequestHandler(IUserProfileCommandRepository clientRepository)
        {
            _userProfileCommandRepository = clientRepository;
        }

        public async Task<int> Handle(CreateUserProfileRequest request, CancellationToken cancellationToken)
        {
            var clientInfo = MembershipMapper.Mapper.Map<UserProfile>(request);
            if (clientInfo is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newClientInfo = await _userProfileCommandRepository.AddAsync(clientInfo);
            return newClientInfo.Id;
        }
    }
}
