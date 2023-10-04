using Zion1.Common.Domain.Entities;
using Zion1.Membership.Domain.Enums;

namespace Zion1.Membership.Domain.Entities
{
    public  class UserProfile : BaseEntity<int>
    {
        /// <summary>
        /// This userId is foreign key of Identity database. 
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        public string FisrtName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set;} = string.Empty;
        public string Email { get; set; } = string.Empty;
        //public Address Address { get; set; } = new Address();
        public string Address { get; set; } = string.Empty;
        public string Others { get; set; } = string.Empty;
        public UserStatus Status { get; set; } = UserStatus.Active;
    }
}
