using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zion1.Common.Domain.Entities;

namespace Zion1.Membership.Domain.Entities
{
    public class Group : BaseEntity<int>
    {
        public string GroupName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<MemberInGroup> MembersInGroups { get; } = new();
    }
}
