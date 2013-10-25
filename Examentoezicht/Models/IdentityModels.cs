using Microsoft.AspNet.Identity.EntityFramework;

namespace Examentoezicht.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit  to learn more.
    public class ApplicationUser : User
    {  
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
    }
}