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
            int x = Convert.ToInt32(Session["UserID"]);

            using (var context = new BlackJackOnlineEntities())
            {
                var users = (from u in context.Users
                            //where u.UserId == x
                            select u).ToList();

                GridView1.DataSource = users;
                GridView1.DataBind();
            }

        }
    }
}