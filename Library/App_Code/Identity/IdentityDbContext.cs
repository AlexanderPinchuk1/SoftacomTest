using Microsoft.AspNet.Identity.EntityFramework;

namespace Library.Identity
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        public IdentityDbContext()
            : base("DefaultConnection")
        {
        }
    }

}