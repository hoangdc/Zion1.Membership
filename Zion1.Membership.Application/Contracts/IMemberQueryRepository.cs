﻿using Zion1.Common.Application.Contracts;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Application.Contracts
{
    public interface IMemberQueryRepository : IQueryRepository<Member>
    {
        Task<IReadOnlyList<Member>> GetMembersInGroup(int groupId);
    }
}
