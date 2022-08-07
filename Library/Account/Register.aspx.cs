using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.UI;
using Library.Identity;
using System;
using Microsoft.Practices.Unity;

public partial class Account_Register : Page
{
    [Dependency]
    public UserManager _userManager { get; set; }


    protected void CreateUser_Click(object sender, EventArgs e)
    {
        var user = new User()
        {
            UserName = UserName.Text
        };

        var result = _userManager.Create(user, Password.Text);
        if (result.Succeeded)
        {
            Response.Redirect("~/Account/Login/");
        }
        else
        {
            ErrorMessage.Text = result.Errors.FirstOrDefault();
        }
    }
}