using MediatR;
using Zion1.Membership.Application.Contracts;
using Zion1.Membership.Application.Mapper;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Commands.DeleteUserProfile
{
    public class DeleteUserProfileRequest : IRequest<int>
    {
        public int Id { get; set; } = 0;

        public DeleteUserProfileRequest()
        {

        }

        public DeleteUserProfileRequest(int userId)
        {
            Id = userId;
        }
    }
}
