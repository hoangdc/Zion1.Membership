using Microsoft.AspNetCore.Mvc;
using Zion1.Common.API.Controller;
using Zion1.Membership.Application.Commands.CreateUserProfile;
using Zion1.Membership.Application.Commands.DeleteUserProfile;
using Zion1.Membership.Application.Commands.UpdateUserProfile;
using Zion1.Membership.Application.Queries;
using Zion1.Membership.Domain.Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zion1.Membership.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : CoreController
    {
        [HttpGet(Name = "GetUserProfileList")]
        public async Task<IReadOnlyList<UserProfile>> GetUserProfileList()
        {
            return await Mediator.Send(new GetUserProfileListQuery());
        }

        [HttpPost(Name = "CreateUserProfile")]
        public async Task<ActionResult<int>> CreateUserProfile(CreateUserProfileRequest userProfile)
        {
            var validator = new CreateUserProfileValidator();
            var result = validator.Validate(userProfile);

            if (result.IsValid)
            {
                return await Mediator.Send(userProfile);
            }
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }

        [HttpPut("{id}")]
        public async Task<int> UpdateUserProfile(int id, UpdateUserProfileRequest userProfile)
        {
            if (id != userProfile.Id)
            {
                return 0;
            }

            return await Mediator.Send(userProfile);
        }

        [HttpDelete("{UserId}")]
        public async Task<int> DeleteUserProfile(int id)
        {
            return await Mediator.Send(new DeleteUserProfileRequest(id));
        }
    }
}
