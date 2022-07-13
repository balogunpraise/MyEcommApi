using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetEcommerce.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace DotnetEcommerce.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUser(UserManager<AppUser> userManager, ILoggerFactory logger)
        {
            try
            {
                if (!userManager.Users.Any())
                {
                    var user = new AppUser()
                    {
                        DisplayName = "Praise",
                        Email = "balogunpraise2@gmail.com",
                        UserName = "balogunpraise2@gmail.com",
                        PhoneNumber = "07034947651",
                        Address = new List<Address>()
                        {
                            new Address()
                            {
                                FirstName = "Praise",
                                LastName = "Balogun",
                                City = "Ikeja",
                                State = "Lagos",
                                Street = "1st Ajorin, AIT road",
                                ZipCode = "100001"
                            }
                        }
                    };
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            catch (Exception ex)
            {
                var log = logger.CreateLogger<AppIdentityDbContextSeed>();
                log.LogError(ex.Message);
            }
        }
    }
}
