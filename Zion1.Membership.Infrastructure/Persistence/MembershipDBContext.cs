using Microsoft.EntityFrameworkCore;
using Zion1.Membership.Domain.Entities;

namespace Zion1.Membership.Infrastructure.Persistence
{
    public class MembershipDBContext : DbContext
    {
        public MembershipDBContext(DbContextOptions<MembershipDBContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<MemberInGroup> MembersInGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberInGroup>().HasKey(mg => new { mg.MemberId, mg.GroupId });

            //modelBuilder.Entity<MemberInGroup>()
            //    .HasOne<Member>(mg => mg.Member)
            //    .WithMany(m => m.MembersInGroups)
            //    .HasForeignKey(mg => mg.MemberId);

            //modelBuilder.Entity<MemberInGroup>()
            //    .HasOne<Group>(g => g.Group)
            //    .WithMany(g => g.MembersInGroups)
            //    .HasForeignKey(mg => mg.GroupId);
        }
    }


}