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

        using(var context = new BlackJackOnlineEntities())
        {
            var users = from u in context.Users
                        where u.UserId == x
                        select u;

            if (users.FirstOrDefault() != null)
            {
                var user = users.FirstOrDefault();
                user.Money += Convert.ToDecimal(funds.Text);
                context.SaveChanges();
                Label2.Text = "Funds Added to your Account !!!";
            }

        }

      
    }
}