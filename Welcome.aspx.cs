using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login_Click(object sender, EventArgs e)
    {
        using (var context = new BlackJackOnlineEntities())
        {
            
            string userName = username.Text;
            string password = pwd.Text;
            var users = from u in context.Users
                        where u.UserName == userName && u.Password == password
                        select u;

            var user = users.FirstOrDefault();
            if (user == null)
            {
                Label3.Text = "UserName and Password didn't match. Try Again!";
            }
            else
            {
                //Label3.Text = "You are sucessfully logged in as " + user.UserName;
                Session["UserID"] = user.UserId;
                Response.Redirect("Home.aspx");                
            }
        }
    
    }
    protected void SignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }
}