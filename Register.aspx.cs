using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlotArqus
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtfirstName.Text) || string.IsNullOrEmpty(txtlastName.Text) || string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirmPssWrd.Text)))
            {
                string pswd = txtPassword.Text;
                string confpswd = txtConfirmPssWrd.Text;
                bool compare = pswd.Equals(confpswd);
                if (compare == true)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["userconnectionstring"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("user_Insert", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UName", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@UPassword", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@UFirstName", txtfirstName.Text);
                    cmd.Parameters.AddWithValue("@ULastName", txtlastName.Text);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Utilisateur enregistré ! Bienvenue, veillez vou connecter via la page Login.')", true);
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Confirmation de mot de passe: erronée!')", true);

                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Erreur d'enregistrement,Remplir tout les champs !')", true);
            }
        }
    }
}