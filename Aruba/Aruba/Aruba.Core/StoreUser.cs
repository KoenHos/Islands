using Microsoft.AspNetCore.Identity;

namespace Aruba.Core
{
    public class StoreUser : IdentityUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
