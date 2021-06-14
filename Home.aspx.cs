using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlotArqus
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Login.aspx");

            }

        }
        protected void btndashbord_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");

        }

        protected void btnTables_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Tables.aspx");

        }

        protected void btnCharts_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Charts.aspx");

        }
        
        protected void btnCalcul_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Calculations.aspx");

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("~/Login.aspx");
        }
        [WebMethod]
        public static string GetChartData(string name)
        {
            string TODAY = DateTime.Now.AddHours(-6).ToString("dd/MM/yyyy HH:mm:ss");
            string PRESENTDATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string constring = ConfigurationManager.ConnectionStrings["ArqusDBConnstring"].ConnectionString;
            string st1 = "";
            string st2 = "";
            string st3 = "";
            string st4 = "";
            string st5 = "";
            string st6 = "";
            string st7 = "";
            string st8 = "";
            string st9 = "";
            string st10 = "";
            string data = "";
                       
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT oDate, ISNULL(Tair,'null') Tair, ISNULL(Td,'null') Td, ISNULL(RR,'null') RR, ISNULL(HR,'null') HR, ISNULL(FF,'null') FF, ISNULL(DD,'null') DD, ISNULL(Pmer,'null') Pmer, ISNULL(Di,'null') Di, ISNULL(Rg,'null') Rg FROM station" + name +" WHERE oDate BETWEEN " + "'" + TODAY + "'" + " AND " + "'" + PRESENTDATE + "'" + "ORDER BY oDate ASC";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        data = "{";
                        st1 = "\"time\":[";
                        st2 = "\"temperature\":[";
                        st3 = "\"Td\":[";
                        st4 = "\"RR\":[";
                        st5 = "\"HR\":[";
                        st6 = "\"FF\":[";
                        st7 = "\"DD\":[";
                        st8 = "\"Pmer\":[";
                        st9 = "\"Di\":[";
                        st10 = "\"Rg\":[";
                        while (sdr.Read())
                        {
                            
                            st1 = st1 + (string.Format("\"{0}\",",sdr[0]));
                            st2 = st2 + (string.Format("{0},", sdr[1]));
                            st3 = st3 + (string.Format("{0},", sdr[2]));
                            st4 = st4 + (string.Format("{0},", sdr[3]));
                            st5 = st5 + (string.Format("{0},", sdr[4]));
                            st6 = st6 + (string.Format("{0},", sdr[5]));
                            st7 = st7 + (string.Format("{0},", sdr[6]));
                            st8 = st8 + (string.Format("{0},", sdr[7]));
                            st9 = st9 + (string.Format("{0},", sdr[8]));
                            st10 = st10 + (string.Format("{0},", sdr[9]));
                        }
                        
                        st1 = st1.Remove(st1.Length - 1, 1);
                        st2 = st2.Remove(st2.Length - 1, 1);
                        st3 = st3.Remove(st3.Length - 1, 1);
                        st4 = st4.Remove(st4.Length - 1, 1);
                        st5 = st5.Remove(st5.Length - 1, 1);
                        st6 = st6.Remove(st6.Length - 1, 1);
                        st7 = st7.Remove(st7.Length - 1, 1);
                        st8 = st8.Remove(st8.Length - 1, 1);
                        st9 = st9.Remove(st9.Length - 1, 1);
                        st10 = st10.Remove(st10.Length - 1, 1);
                        st1 = st1 + "],";
                        st2 = st2 + "],";
                        st3 = st3 + "],";
                        st4 = st4 + "],";
                        st5 = st5 + "],";
                        st6 = st6 + "],";
                        st7 = st7 + "],";
                        st8 = st8 + "],";
                        st9 = st9 + "],";
                        st10 = st10 + "]";
                        data = data + st1 + st2 + st3 + st4 + st5 + st6 + st7 + st8 + st9 + st10;
                        data = data + "}";
                        con.Close();
                        return data;

                    }

                }

            }
        }

        
    }

}
