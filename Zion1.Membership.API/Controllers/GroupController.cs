using Microsoft.AspNetCore.Mvc;
using Zion1.Common.API.Controller;
using Zion1.Membership.Application.Commands.CreateGroup;
using Zion1.Membership.Application.Commands.DeleteGroup;
using Zion1.Membership.Application.Commands.UpdateGroup;
using Zion1.Membership.Application.Queries;
using Zion1.Membership.Domain.Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zion1.Membership.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : CoreController
    {
        [HttpGet]
        public async Task<IReadOnlyList<Group>> GetGroupList()
        {
            return await Mediator.Send(new GetGroupListQuery());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Group> GetGroup(int id)
        {
            var group = await Mediator.Send(new GetGroupQuery(id));
            return group;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateGroup(CreateGroupRequest group)
        {
            var validator = new CreateGroupValidator();
            var result = validator.Validate(group);

            if (result.IsValid)
            {
                return await Mediator.Send(group);
            }
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        [HttpPut]
        public async Task<int> UpdateGroup(UpdateGroupRequest group)
        {
            return await Mediator.Send(group);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteGroup(int id)
        {
            return await Mediator.Send(new DeleteGroupRequest(id));
        }
    }
}
