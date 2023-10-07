using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion1.Membership.Domain.Entities
{
    public class MemberInGroup
    {
        public int MemberId { get; set; } = 0;
        public int GroupId { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Member Member { get; set; } = new();
        public Group Group { get; set; } = new();
    }
}
