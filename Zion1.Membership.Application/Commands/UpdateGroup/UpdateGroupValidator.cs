
using FluentValidation;
using System.Text.RegularExpressions;

namespace Zion1.Membership.Application.Commands.UpdateGroup;

public class UpdateGroupValidator : AbstractValidator<UpdateGroupRequest>
{
    public UpdateGroupValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.GroupName).NotEmpty();
    }

}