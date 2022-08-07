using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;

namespace Library.Identity
{
    public static class IdentityHelper
    {
        public static void SignIn(UserManager manager, User user, bool isPersistent)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
    }
}