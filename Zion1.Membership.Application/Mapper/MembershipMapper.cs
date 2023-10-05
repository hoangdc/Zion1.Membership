using AutoMapper;
using Zion1.Common.Application.Mapper;
using Zion1.Membership.Application.Commands.CreateMember;
using Zion1.Membership.Application.Commands.UpdateMember;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Mapper
{
    public class MembershipMappingProfile : Profile
    {
        public MembershipMappingProfile()
        {
            CreateMap<Member, CreateMemberRequest>().ReverseMap();
            CreateMap<Member, UpdateMemberRequest>().ReverseMap();
        }
    }

    public class MembershipMapper : CommonMapper<MembershipMappingProfile>
    {

    }
}
