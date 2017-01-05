using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // if(IsPostBack)
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        
        using (var context =new BlackJackOnlineEntities())
        {
            
            string userName = TextBox1.Text;
            string password1 = TextBox2.Text;
            string password2= TextBox3.Text;

            if(password1!=password2 || userName==null||password1==""||password2=="" || context.Users.Any(user=>user.UserName==userName)) //username should not be existing username;username shouldn't be null
            {
                Label4.Text="Bad username or password";
                return;
            }

            //create object
            var newuser = new Users();
            //newuser.UserName = TextBox1.Text;
            newuser.UserName = userName;
            newuser.Password = password2;
           
            context.Users.Add(newuser);

            context.SaveChanges();

            Label4.Text = "User added successfully!";
        }
    }
}