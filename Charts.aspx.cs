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
    public partial class Charts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btndashbord2_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }


        protected void btnCharts2_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Charts.aspx");
        }

        protected void btnTables2_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Tables.aspx");
        }

        protected void btnCalcul_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Calculations.aspx");
        }

        [WebMethod]
        public static string BindChart(string name,string aParam,string aStart,string aStop,string aresolution)
        {
            string TODAY = DateTime.Now.AddHours(-6).ToString("dd/MM/yyyy HH:mm:ss");
            string PRESENTDATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string constring = ConfigurationManager.ConnectionStrings["ArqusDBConnstring"].ConnectionString;
            string st1 = string.Empty;
            string st2 = string.Empty;
            string data = string.Empty;
            string query = string.Empty;
            //select oDate, ISNULL(DD,'null') DD, ISNULL(FF,'null') FF, ISNULL(Tair,'no data') Tair, ISNULL(HR,'no data') HR, ISNULL(Td,'no data') Td, ISNULL(Pmer,'no data') Pmer, ISNULL(RR,'no data') RR, ISNULL(Di,'no data') Di, ISNULL(Rg,'no data') Rg from station60714 where oDate between '25/03/2020 00:00:00' and '25/03/2020 03:00:00' order by oDate desc
            if (aresolution == "0")
            {
                query = "SELECT oDate, ISNULL(" + aParam + ",'null')" + aParam + " FROM station" + name + " WHERE oDate BETWEEN " + "'" + aStart + ":00'" + " AND " + "'" + aStop + ":00'" + "ORDER BY oDate ASC";

            }
            else if (aresolution == "1")
            {
                if (aParam == "RR" || aParam == "Di" || aParam == "Rg")
                {
                    query = "SELECT oDate, ISNULL(" + aParam + ",'null')" + aParam + " FROM hourly" + name + " WHERE oDate BETWEEN " + "'" + aStart + ":00'" + " AND " + "'" + aStop + ":00'" + "ORDER BY oDate ASC";

                }
                else
                {
                    query = "SELECT oDate, ISNULL(" + aParam + ",'null')" + aParam + " FROM station" + name + " WHERE DATEPART(MINUTE, oDate) = '00' AND oDate BETWEEN " + "'" + aStart + ":00'" + " AND " + "'" + aStop + ":00'" + "ORDER BY oDate ASC";

                }
                

            }


            using (SqlConnection con = new SqlConnection(constring))
            {
               
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
                        st2 = "\"parameter\":[";
                        
                        while (sdr.Read())
                        {
                            st1 = st1 + (string.Format("\"{0}\",", sdr[0]));
                            st2 = st2 + (string.Format("{0},", sdr[1]));
                        }

                        st1 = st1.Remove(st1.Length - 1, 1);
                        st2 = st2.Remove(st2.Length - 1, 1);
                        
                        st1 = st1 + "],";
                        st2 = st2 + "]";
                       
                        data = data + st1 + st2;
                        data = data + "}";
                        con.Close();
                        return data;

                    }

                }

            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("~/Login.aspx");
        }

        
    }
}