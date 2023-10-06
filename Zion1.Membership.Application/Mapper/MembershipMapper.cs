using AutoMapper;
using Zion1.Common.Application.Mapper;
using Zion1.Membership.Application.Commands.AssignMemberToGroup;
using Zion1.Membership.Application.Commands.CreateGroup;
using Zion1.Membership.Application.Commands.CreateMember;
using Zion1.Membership.Application.Commands.UpdateGroup;
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

            CreateMap<Group, CreateGroupRequest>().ReverseMap();
            CreateMap<Group, UpdateGroupRequest>().ReverseMap();

            CreateMap<MemberInGroup, AssignMemberToGroupRequest>().ReverseMap();
            
        }
    }

    public class MembershipMapper : CommonMapper<MembershipMappingProfile>
    {

    }
}
