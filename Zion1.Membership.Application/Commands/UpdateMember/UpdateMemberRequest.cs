﻿using MediatR;

namespace Zion1.Membership.Application.Commands.UpdateMember
{
    public class UpdateMemberRequest : IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //public Address Address { get; set; } = new Address();
        public string Address { get; set; } = string.Empty;
    }
}
