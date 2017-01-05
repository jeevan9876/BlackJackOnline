using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("Welcome.aspx");
        }
        else
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int x = Convert.ToInt32(Session["UserID"]);

        using(var context=new BlackJackOnlineEntities()){
            var users = from u in context.Users
                        where u.UserId == x
                        select u;
            var currentuser=users.FirstOrDefault();
            if (currentuser != null && currentuser.UserId == x && currentuser.Password != changepwd.Text)
            {
                if (changepwd.Text == changepwd2.Text)
                {
                    currentuser.Password = changepwd.Text;
                    context.SaveChanges();
                    ErrorMessage.Text = "Password changed Successfully";
                }else
                {
                    ErrorMessage.Text = "Please give same password";
                }
            }

        }
    }
    }
