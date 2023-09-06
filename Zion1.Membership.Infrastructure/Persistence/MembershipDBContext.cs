using Microsoft.EntityFrameworkCore;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Infrastructure.Persistence
{
    public class MembershipDBContext : DbContext
    {
        public MembershipDBContext(DbContextOptions<MembershipDBContext> options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }


}