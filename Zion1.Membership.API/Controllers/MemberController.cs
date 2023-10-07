using Microsoft.AspNetCore.Mvc;
using Zion1.Common.API.Controller;
using Zion1.Membership.Application.Commands.AssignMemberToGroup;
using Zion1.Membership.Application.Commands.CreateMember;
using Zion1.Membership.Application.Commands.DeleteMember;
using Zion1.Membership.Application.Commands.UpdateMember;
using Zion1.Membership.Application.DTOs;
using Zion1.Membership.Application.Queries;
using Zion1.Membership.Domain.Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zion1.Membership.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : CoreController
    {
        [HttpGet]
        public async Task<IReadOnlyList<MemberDto>> GetMemberList()
        {
            return await Mediator.Send(new GetMemberListQuery());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<MemberDto> GetMember(int id)
        {
            return await Mediator.Send(new GetMemberQuery(id));
        }

        [HttpGet]
        [Route("group/{groupId}")]
        public async Task<IReadOnlyList<MemberDto>> GetMemberListByGroup(int groupId)
        {
            return await Mediator.Send(new GetMemberInGroupQuery(groupId));
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateMember(CreateMemberRequest member)
        {
            var validator = new CreateMemberValidator();
            var result = validator.Validate(member);

            if (result.IsValid)
            {
                return await Mediator.Send(member);
            }
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        [HttpPost]
        [Route("group/")]
        public async Task<ActionResult<bool>> AssignMemberToGroup(AssignMemberToGroupRequest memberGroup)
        {
            return await Mediator.Send(memberGroup);
        }

        [HttpPut]
        public async Task<int> UpdateMember(UpdateMemberRequest member)
        {
            var hasMember = GetMember(member.Id);
            if (hasMember != null)
                return await Mediator.Send(member);
            return 0;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteMember(int id)
        {
            return await Mediator.Send(new DeleteMemberRequest(id));
        }
    }
}
