using AcconAPI.Domain.Auth;
using Microsoft.EntityFrameworkCore;

namespace AcconAPI.Persistence.Seeds;

public static class ContextSeed
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        CreateBasicUsers(modelBuilder);
    }


    private static void CreateBasicUsers(ModelBuilder modelBuilder)
    {
        List<AppUser> users = DefaultUser.IdentityUserList();
        modelBuilder.Entity<AppUser>().HasData(users);
    }
}