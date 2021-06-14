using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlotArqus
{
    public partial class Tables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Login.aspx");

            }

        }

        protected void btnCharts1_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Charts.aspx");

        }

        protected void btnTables1_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Tables.aspx");
        }

        protected void btndshbord1_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }


        protected void btnCalcul_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Calculations.aspx");

        }

        protected void btnBindTable_Click(object sender, EventArgs e)
        {
            string TODAY = DateTime.Now.AddHours(-6).ToString("dd/MM/yyyy HH:mm:ss");
            string PRESENTDATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string dummydate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string dateA = txtdate1.Text;
            string dateB = txtdate2.Text;
            string DATE1 = txtdate1.Text + ":00";
            string DATE2 = txtdate2.Text + ":00";
            string ID = ddlStation.SelectedValue;
            string query = string.Empty;
            if (rdbResolution.SelectedValue == "1")
            {
                query = "SELECT oDate, ISNULL(DD, 'No Data') DD, ISNULL(FF, 'No Data') FF, ISNULL(Tair, 'No Data') Tair, ISNULL(HR, 'No Data') HR, ISNULL(Td, 'No Data') Td, ISNULL(Pmer, 'No Data') Pmer, ISNULL(RR, 'No Data') RR, ISNULL(Di, 'No Data') Di, ISNULL(Rg, 'No Data') Rg FROM station" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "'" + "ORDER BY oDate ASC";
               
            }
            else if (rdbResolution.SelectedValue == "0")
            {
                query = "SELECT station" + ID + ".oDate, ISNULL(station" + ID + ".DD,'No Data') DD, ISNULL(station" + ID + ".FF,'No Data') FF , ISNULL(station" + ID + ".Tair,'No Data') Tair, ISNULL(station" + ID + ".HR,'No Data') HR, ISNULL(station" + ID + ".Td,'No Data') Td, ISNULL(station" + ID + ".Pmer,'No Data') Pmer, ISNULL(hourly" + ID + ".RR,'No Data') RR, ISNULL(hourly" + ID + ".Di,'No Data') Di,ISNULL(hourly" + ID + ".Rg,'No Data') Rg FROM station" + ID + " INNER JOIN hourly" + ID + " ON hourly" + ID + ".oDate = station" + ID + ".oDate and hourly" + ID + ".oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "'" + "ORDER BY oDate ASC";
                
                //query = "SELECT station" + ID + ".oDate,station" + ID + ".DD,station" + ID + ".FF,station" + ID + ".Tair,station" + ID + ".HR,station" + ID + ".Td,station" + ID + ".Pmer,hourly" + ID + ".RR,hourly" + ID + ".Di,hourly" + ID + ".Rg FROM station" + ID + " INNER JOIN hourly" + ID + " ON hourly" + ID + ".oDate = station" + ID + ".oDate and hourly" + ID + ".oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "'" + "ORDER BY oDate ASC";
            }


            if (!(string.IsNullOrEmpty(dateA) || string.IsNullOrEmpty(dateB) || string.IsNullOrEmpty(ID)))
            {                
                try
                {
                    string constring = ConfigurationManager.ConnectionStrings["ArqusDBConnstring"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(constring))
                    {
                       
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable DtData = new DataTable();
                                sda.Fill(DtData);
                                DataTblRptr.DataSource = DtData;
                                DataTblRptr.DataBind();
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Ltrexption.Text = " <div>" + ex.Message + "///" + ex.StackTrace + "</div>";
                }
                

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Remplir les champs correctement !')", true);
            }
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("~/Login.aspx");
        }

    }
}
