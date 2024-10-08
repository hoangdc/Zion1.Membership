﻿namespace Zion1.Membership.Web.UI.Models
{
    public class Member
    {
        public int Id { get; set; } = 0;
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
