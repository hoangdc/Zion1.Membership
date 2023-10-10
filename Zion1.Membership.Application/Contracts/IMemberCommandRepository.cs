﻿using Zion1.Common.Application.Contracts;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Contracts
{
    public interface IMemberCommandRepository : ICommandRepository<Member>
    {
        Task<bool> AssignMemberToGroup(int memberId, int groupId);
    }
}
