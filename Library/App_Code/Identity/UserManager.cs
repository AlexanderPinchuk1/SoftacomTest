using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Library.Identity
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IdentityDbContext identityDbContext)
            : base(new UserStore<User>(identityDbContext))
        {
        }
    }
}