
using FluentValidation;
using System.Text.RegularExpressions;

namespace Zion1.Membership.Application.Commands.CreateGroup;

public class CreateGroupValidator : AbstractValidator<CreateGroupRequest>
{
    public CreateGroupValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.GroupName).NotEmpty();
    }

}