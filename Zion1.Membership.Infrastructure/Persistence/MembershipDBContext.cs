﻿using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Members)
                .WithMany(m => m.Groups)
                .UsingEntity("MembersInGroups");
        }
    }


}