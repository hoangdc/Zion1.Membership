using AutoMapper;
using Zion1.Membership.Application.Commands.CreateUserProfile;
using Zion1.Membership.Application.Commands.UpdateUserProfile;
using Zion1.Membership.Domain.Entities;
using Zion1.Common.Application.Mapper;

namespace Zion1.Membership.Application.Mapper
{
    public class MemberhispMappingProfile : Profile
    {
        public MemberhispMappingProfile()
        {
            CreateMap<UserProfile, CreateUserProfileRequest>().ReverseMap();
            CreateMap<UserProfile, UpdateUserProfileRequest>().ReverseMap();
        }
    }

    public class MembershipMapper : CommonMapper<MemberhispMappingProfile>
    {

    }
}
