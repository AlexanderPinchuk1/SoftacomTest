using System;
using System.Web.UI;
using Library.Identity;
using Microsoft.Practices.Unity;

public partial class Account_Login : Page
{
    [Dependency]
    public UserManager _userManager { get; set; }


    protected async void LogIn(object sender, EventArgs e)
    {
        if (!IsValid)
        {
            return;
        }

        var user = await _userManager.FindAsync(UserName.Text, Password.Text);
        if (user != null)
        {
            IdentityHelper.SignIn(_userManager, user, false);
            Response.Redirect("~/Books/");
        }
        else
        {
            FailureText.Text = "Invalid username or password.";
            ErrorMessage.Visible = true;
        }
    }
}