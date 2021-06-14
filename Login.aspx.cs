using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace PlotArqus
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] !=null)
            {
                Response.Redirect("~/Home.aspx");

            }


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["userconnectionstring"].ConnectionString);
            conn.Open();
            string query = "select count(*) from UserLog where Name='"+txtuser.Text+"' and Password='"+txtpassword.Text+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            string checkuser = cmd.ExecuteScalar().ToString();

            if(checkuser=="1")
            {
                Session["user"] = txtuser.Text;
                Response.Redirect("~/Home.aspx");
            }

            else
            {
                Response.Write("Votre nom d'utilisateur et/ou Votre mot de passe sont erronés !");
            }
        }
    }
}