using System.Collections.Generic;

namespace Domain.EF_Models
{
    public class User /*: IdentityUser*/
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        //public int? IdentityUserId { get; set; }
        //public IdentityUser IdentityUser { get; set; }
    }
}