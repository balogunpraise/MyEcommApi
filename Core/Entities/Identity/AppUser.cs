using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DotnetEcommerce.Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public List<Address> Address { get; set; }
    }
}
