using AcconAPI.Domain.Auth;

namespace AcconAPI.Persistence.Seeds;

public class DefaultUser
{
    public static List<AppUser> IdentityUserList()
    {
        return new List<AppUser>()
        {
            new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                // Password@123
                PasswordHash =
                    "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                NormalizedUserName = "ADMIN@GMAIL.COM"
            },
        };
    }
}