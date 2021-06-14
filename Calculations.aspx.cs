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
    public partial class Calculations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Login.aspx");

            }

        }

        protected void btnCharts3_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Charts.aspx");

        }

        protected void btnTables3_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Tables.aspx");

        }

        protected void btnCalcul3_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Calculations.aspx");

        }

        protected void btndashbord3_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("~/Login.aspx");
        }

        protected void btnTair_Click(object sender, EventArgs e)
        {
            string TODAY = DateTime.Now.AddHours(-6).ToString("dd/MM/yyyy HH:mm:ss");
            string PRESENTDATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string dummydate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string dateA = txtdate1.Text;
            string dateB = txtdate2.Text;
            string DATE1 = txtdate1.Text + ":00";
            string DATE2 = txtdate2.Text + ":00";
            string ID = ddlStation.SelectedValue;
            
            string quTmax = string.Empty;
            string quTmin = string.Empty;
            string quTmoy = string.Empty;
            string dateMaxT = string.Empty;
            string date2MxT = string.Empty;
            string dateMinT = string.Empty;
            string date2MnT = string.Empty;
            int mintTmin;
            int mintTmax;
            string Tmxvalue = string.Empty;
            string Tmnvalue = string.Empty;
            string Tmoy = string.Empty;
            string mntMxT = string.Empty;
            string mntMnT = string.Empty;
            string stMxT = string.Empty;
            string stMnT = string.Empty;
            string stDateMxT = string.Empty;
            string stDateMnT = string.Empty;
            
            string ltrTemp = string.Empty;

            if (!(string.IsNullOrEmpty(dateA) || string.IsNullOrEmpty(dateB) || string.IsNullOrEmpty(ID)))
            {
                try
                {
                    string constring = ConfigurationManager.ConnectionStrings["ArqusDBConnstring"].ConnectionString;

                    quTmoy = "SELECT ROUND(AVG(CAST(Tair AS float)),2) AS moyTair FROM station" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "'";
                    quTmax = "SELECT oDate, MaxTair, MnMaxTair FROM hourly" + ID + " WHERE MaxTair = (SELECT MAX(MaxTair ) FROM hourly" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "') ORDER BY oDate DESC;";
                    quTmin = "SELECT oDate, MinTair, MnMinTair FROM hourly" + ID + " WHERE MinTair = (SELECT MIN(MinTair ) FROM hourly" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "') ORDER BY oDate DESC;";
                   
                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();
                                                
                            using (SqlCommand cmdTmax = new SqlCommand(quTmax, con))
                            {
                                SqlDataReader rdTmax = cmdTmax.ExecuteReader();
                                while (rdTmax.Read())
                                {
                                    dateMaxT = rdTmax["oDate"].ToString();
                                    DateTime iDateTmx = Convert.ToDateTime(dateMaxT);
                                    DateTime iDate2Tmx = iDateTmx.AddHours(-1);
                                    string date2Tmax = iDate2Tmx.ToString();
                                    mntMxT = rdTmax["MnMaxTair"].ToString();
                                    if (int.TryParse(mntMxT, out mintTmax))
                                        stMxT = mintTmax.ToString("00");
                                    else
                                        stMxT = "//";

                                    date2MxT = date2Tmax.Substring(0, 14);
                                    stDateMxT = date2MxT + stMxT;
                                    Tmxvalue = rdTmax["MaxTair"].ToString();
                                    break;
                                }
                            }
                        
                        con.Close();

                    }

                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmdTmin = new SqlCommand(quTmin, con))
                        {
                            SqlDataReader rdTmin = cmdTmin.ExecuteReader();
                            while (rdTmin.Read())
                            {
                                dateMinT = rdTmin["oDate"].ToString();
                                DateTime iDateTmn = Convert.ToDateTime(dateMinT);
                                DateTime iDate2Tmn = iDateTmn.AddHours(-1);
                                string date2Tmin = iDate2Tmn.ToString();
                                mntMnT = rdTmin["MnMinTair"].ToString();
                                if (int.TryParse(mntMnT, out mintTmin))
                                    stMnT = mintTmin.ToString("00");
                                else
                                    stMnT = "//";

                                date2MnT = date2Tmin.Substring(0, 14);
                                stDateMnT = date2MnT + stMnT;
                                Tmnvalue = rdTmin["MinTair"].ToString();
                                break;
                            }
                        }

                        con.Close();

                    }

                    double Tmax;
                    double Tmin;
                    double Moy;
                    string stMoy = string.Empty; 
                    if(double.TryParse(Tmxvalue, out Tmax) && double.TryParse(Tmnvalue, out Tmin))
                    {
                        Moy = (Tmax + Tmin) / 2;
                        stMoy = Moy.ToString();

                    }
                    else
                    {
                        stMoy = "N/A";
                    }

                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmdTmoy = new SqlCommand(quTmoy, con))
                        {
                            SqlDataReader rdTmoy = cmdTmoy.ExecuteReader();
                            while (rdTmoy.Read())
                            {
                                Tmoy = rdTmoy["moyTair"].ToString();
                               
                            }
                        }

                        con.Close();

                    }
                    
                    string TempLtr = "<div class=\"card m-2\"> <div class=\"card-header\"> <i class=\"fas fa-temperature-high\"></i> Températures</div><table class=\"table\"><thead><tr><th scope =\"col\"> Pramètre </th > <th scope=\"col\">Valeur</th> <th scope =\"col\">Date / Heure</th > </tr > </thead > <tbody > <tr > <th scope=\"row\">T°Max</th> <td>" + Tmxvalue + "°C </td> <td>" + stDateMxT + "</td> </tr> <tr> <th scope =\"row\">T°Min</th> <td>" + Tmnvalue + "°C</td> <td>" + stDateMnT + "</td> </tr> <tr> <th scope =\"row\">(Tn + Tx) / 2</th > <td colspan=\"2\">" + stMoy + "°C</td> </tr> <tr> <th scope =\"row\">Moy T° 6min</th> <td colspan =\"2\">" + Tmoy + "°C</td> </tr></tbody> </table> <div class=\"card-footer small text-muted\">Station " + ID + "</div> </div>";
                    LtrT.Text = TempLtr;


                }
                catch (Exception)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Un erreur est survenus, contactez le WebMaster!')", true);
                }


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Remplir les champs correctement !')", true);
            }


        }

        protected void btnWnd_Click(object sender, EventArgs e)
        {
            string TODAY = DateTime.Now.AddHours(-6).ToString("dd/MM/yyyy HH:mm:ss");
            string PRESENTDATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string dummydate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string dateA = txtdate1.Text;
            string dateB = txtdate2.Text;
            string DATE1 = txtdate1.Text + ":00";
            string DATE2 = txtdate2.Text + ":00";
            string ID = ddlStation.SelectedValue;

            string quVmax = string.Empty;
           
            string quVmoy = string.Empty;
            string dateMaxFF = string.Empty;
            string date2MxFF = string.Empty;
            string dateMaxDD = string.Empty;
            string date2MxDD = string.Empty;
            int mintFFmax;
            
            string FFmxvalue = string.Empty;
            string DDmxvalue = string.Empty;
            string FFmoy = string.Empty;
            string mntMxFF = string.Empty;
            string mntMxDD = string.Empty;
            string stMxFF = string.Empty;
            string stMxDD = string.Empty;
            string stDateMxFF = string.Empty;
            string stDateMnT = string.Empty;
                      

            if (!(string.IsNullOrEmpty(dateA) || string.IsNullOrEmpty(dateB) || string.IsNullOrEmpty(ID)))
            {
                try
                {
                    string constring = ConfigurationManager.ConnectionStrings["ArqusDBConnstring"].ConnectionString;

                    quVmoy = "SELECT ROUND(AVG(CAST(FF AS float)),2) AS moyFF FROM station" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "'";
                    quVmax = "SELECT oDate, MaxFFinst, MaxDDinst ,MnMaxVent FROM hourly" + ID + " WHERE MaxFFinst = (SELECT MAX(MaxFFinst ) FROM hourly" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "') ORDER BY oDate DESC;";
                   
                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand(quVmax, con))
                        {
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                dateMaxFF = rdr["oDate"].ToString();
                                DateTime iDateFFmx = Convert.ToDateTime(dateMaxFF);
                                DateTime iDate2FFmx = iDateFFmx.AddHours(-1);
                                string date2maxFF = iDate2FFmx.ToString();
                                mntMxFF = rdr["MnMaxVent"].ToString();
                                if (int.TryParse(mntMxFF, out mintFFmax))
                                    stMxFF = mintFFmax.ToString("00");
                                else
                                    stMxFF = "//";

                                date2MxFF = date2maxFF.Substring(0, 14);
                                stDateMxFF = date2MxFF + stMxFF;
                                FFmxvalue = rdr["MaxFFinst"].ToString();
                                stMxDD = rdr["MaxDDinst"].ToString();
                                break;

                            }

                        }

                        con.Close();

                    }
                    
                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmdVmoy = new SqlCommand(quVmoy, con))
                        {
                            SqlDataReader rdVmoy = cmdVmoy.ExecuteReader();
                            while (rdVmoy.Read())
                            {
                                FFmoy = rdVmoy["moyFF"].ToString();

                            }
                        }

                        con.Close();

                    }
                                       
                    string WindLtr = "<div class=\"card m-2\"> <div class=\"card-header\"> <i class=\"fas fa-wind\"></i> Vent</div> <table class=\"table table-bordered\"> <thead> <tr> <th scope=\"col\">FF Max Inst</th> <th scope=\"col\">DD Max Inst</th> <th scope=\"col\">Date/Heure</th> <th scope=\"col\">FF moy 6 min</th> </tr> </thead> <tbody> <tr> <td>" + FFmxvalue + " m/s</td> <td>" + stMxDD + "°</td> <td>" + stDateMxFF + "</td> <td>" + FFmoy + " m/s</td> </tr> </tbody> </table> <div class=\"card-footer small text-muted\"> Station " + ID + " </div> </div>";
                    LtrWnd.Text = WindLtr;


                }
                catch (Exception)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Un erreur est survenus, contactez le WebMaster!')", true);
                }


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Remplir les champs correctement !')", true);
            }

        }

        protected void btnHR_Click(object sender, EventArgs e)
        {
            string TODAY = DateTime.Now.AddHours(-6).ToString("dd/MM/yyyy HH:mm:ss");
            string PRESENTDATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string dummydate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string dateA = txtdate1.Text;
            string dateB = txtdate2.Text;
            string DATE1 = txtdate1.Text + ":00";
            string DATE2 = txtdate2.Text + ":00";
            string ID = ddlStation.SelectedValue;

            string quHRmax = string.Empty;
            string quHRmin = string.Empty;
            string quHRmoy = string.Empty;
            string dateMaxHR = string.Empty;
            string date2MxHR = string.Empty;
            string dateMinHR = string.Empty;
            string date2MnHR = string.Empty;
            int mintHRmin;
            int mintHRmax;
            string HRmxvalue = string.Empty;
            string HRmnvalue = string.Empty;
            string HRmoy = string.Empty;
            string mntMxHR = string.Empty;
            string mntMnHR = string.Empty;
            string stMxHR = string.Empty;
            string stMnHR = string.Empty;
            string stDateMxHR = string.Empty;
            string stDateMnHR = string.Empty;
                       

            if (!(string.IsNullOrEmpty(dateA) || string.IsNullOrEmpty(dateB) || string.IsNullOrEmpty(ID)))
            {
                try
                {
                    string constring = ConfigurationManager.ConnectionStrings["ArqusDBConnstring"].ConnectionString;

                    quHRmoy = "SELECT ROUND(AVG(CAST(HR AS float)),2) AS moyHR FROM station" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "'";
                    quHRmax = "SELECT oDate, MaxHR, MnMaxHR FROM hourly" + ID + " WHERE MaxHR = (SELECT MAX(MaxHR ) FROM hourly" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "') ORDER BY oDate DESC;";
                    quHRmin = "SELECT oDate, MinHR, MnMinHR FROM hourly" + ID + " WHERE MinHR = (SELECT MIN(MinHR ) FROM hourly" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "') ORDER BY oDate DESC;";

                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmdHRmax = new SqlCommand(quHRmax, con))
                        {
                            SqlDataReader rdHRmax = cmdHRmax.ExecuteReader();
                            while (rdHRmax.Read())
                            {
                                dateMaxHR = rdHRmax["oDate"].ToString();
                                DateTime iDateHRmx = Convert.ToDateTime(dateMaxHR);
                                DateTime iDate2HRmx = iDateHRmx.AddHours(-1);
                                string date2maxHR = iDate2HRmx.ToString();
                                mntMxHR = rdHRmax["MnMaxHR"].ToString();
                                if (int.TryParse(mntMxHR, out mintHRmax))
                                    stMxHR = mintHRmax.ToString("00");
                                else
                                    stMxHR = "//";

                                date2MxHR = date2maxHR.Substring(0, 14);
                                stDateMxHR = date2MxHR + stMxHR;
                                HRmxvalue = rdHRmax["MaxHR"].ToString();
                                break;
                            }
                        }

                        con.Close();

                    }

                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmdHRmin = new SqlCommand(quHRmin, con))
                        {
                            SqlDataReader rdHRmin = cmdHRmin.ExecuteReader();
                            while (rdHRmin.Read())
                            {
                                dateMinHR = rdHRmin["oDate"].ToString();
                                DateTime iDateHRmn = Convert.ToDateTime(dateMinHR);
                                DateTime iDate2HRmn = iDateHRmn.AddHours(-1);
                                string date2minHR = iDate2HRmn.ToString();
                                mntMnHR = rdHRmin["MnMinHR"].ToString();
                                if (int.TryParse(mntMnHR, out mintHRmin))
                                    stMnHR = mintHRmin.ToString("00");
                                else
                                    stMnHR = "//";

                                date2MnHR = date2minHR.Substring(0, 14);
                                stDateMnHR = date2MnHR + stMnHR;
                                HRmnvalue = rdHRmin["MinHR"].ToString();
                                break;
                            }
                        }

                        con.Close();

                    }

                    double HRmax;
                    double HRmin;
                    double Moy;
                    string stHrMoy = string.Empty;
                    if (double.TryParse(HRmxvalue, out HRmax) && double.TryParse(HRmnvalue, out HRmin))
                    {
                        Moy = (HRmax + HRmin) / 2;
                        stHrMoy = Moy.ToString();

                    }
                    else
                    {
                        stHrMoy = "No Data";
                    }

                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmdHRmoy = new SqlCommand(quHRmoy, con))
                        {
                            SqlDataReader rdHRmoy = cmdHRmoy.ExecuteReader();
                            while (rdHRmoy.Read())
                            {
                                HRmoy = rdHRmoy["moyHR"].ToString();

                            }
                        }

                        con.Close();

                    }
                    
                    string HRLtr = "<div class=\"card m-2\"> <div class=\"card-header\"> <i class=\"fas fa-tint\"></i> Humidité</div><table class=\"table\"><thead><tr><th scope =\"col\"> Pramètre </th > <th scope=\"col\">Valeur</th> <th scope =\"col\">Date / Heure</th > </tr > </thead > <tbody > <tr > <th scope=\"row\">HR Max</th> <td>" + HRmxvalue + "% </td> <td>" + stDateMxHR + "</td> </tr> <tr> <th scope =\"row\">HR Min</th> <td>" + HRmnvalue + "%</td> <td>" + stDateMnHR + "</td> </tr> <tr> <th scope =\"row\">(HRn + HRx) / 2</th > <td colspan=\"2\">" + stHrMoy + "%</td> </tr> <tr> <th scope =\"row\">Moy HR 6min</th> <td colspan =\"2\">" + HRmoy + "%</td> </tr></tbody> </table> <div class=\"card-footer small text-muted\">Station " + ID + "</div> </div>";
                    LtrHR.Text = HRLtr;


                }
                catch (Exception)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Un erreur est survenus, contactez le WebMaster!')", true);
                }


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Remplir les champs correctement !')", true);
            }

        }

        protected void btnRR_Click(object sender, EventArgs e)
        {
            string TODAY = DateTime.Now.AddHours(-6).ToString("dd/MM/yyyy HH:mm:ss");
            string PRESENTDATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string dummydate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string dateA = txtdate1.Text;
            string dateB = txtdate2.Text;
            string DATE1 = txtdate1.Text + ":00";
            string DATE2 = txtdate2.Text + ":00";
            string ID = ddlStation.SelectedValue;

            string quRRmaxH = string.Empty;
            string quRRmax6 = string.Empty;
            string quCumRR6 = string.Empty;
            string quCumRRH = string.Empty;

            string dateMaxRRH = string.Empty;
            string dateMaxRR6 = string.Empty;
            string stDateMxH = string.Empty;
            string stDateMxS = string.Empty;
            string stCumS = string.Empty;
            string stCumH = string.Empty;
            string stMxSix = string.Empty;
            string stMxHor = string.Empty;
                      
            if (!(string.IsNullOrEmpty(dateA) || string.IsNullOrEmpty(dateB) || string.IsNullOrEmpty(ID)))
            {
                try
                {
                    string constring = ConfigurationManager.ConnectionStrings["ArqusDBConnstring"].ConnectionString;

                    quCumRR6 = "SELECT ROUND(SUM(CAST(RR AS float)),1) AS CumulS FROM station" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "'";
                    quCumRRH = "SELECT ROUND(SUM(CAST(RR AS float)),1) AS CumulH FROM hourly" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "'";
                    quRRmax6 = "SELECT oDate, RR FROM station" + ID + " WHERE RR = (SELECT MAX(RR) FROM station" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "') ORDER BY oDate DESC;";
                    quRRmaxH = "SELECT oDate, RR FROM hourly60714 WHERE RR = (SELECT MAX(RR) FROM hourly60714 WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "') ORDER BY oDate DESC;";
                    
                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmdClS = new SqlCommand(quCumRR6, con))
                        {
                            SqlDataReader rdCuS = cmdClS.ExecuteReader();
                            while (rdCuS.Read())
                            {                                
                                stCumS = rdCuS["CumulS"].ToString();
                                
                            }

                        }

                        con.Close();

                    }

                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmdClH = new SqlCommand(quCumRRH, con))
                        {
                            SqlDataReader rdrCumH = cmdClH.ExecuteReader();
                            while (rdrCumH.Read())
                            {
                                stCumH = rdrCumH["CumulH"].ToString();

                            }
                        }

                        con.Close();

                    }

                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmdMxS = new SqlCommand(quRRmax6, con))
                        {
                            SqlDataReader rdrMxS = cmdMxS.ExecuteReader();
                            while (rdrMxS.Read())
                            {
                                dateMaxRR6 = rdrMxS["oDate"].ToString();
                                stDateMxS = dateMaxRR6.Substring(0, 16);
                                stMxSix = rdrMxS["RR"].ToString();
                                break;
                                
                            }
                        }

                        con.Close();

                    }

                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmdMxH = new SqlCommand(quRRmaxH, con))
                        {
                            SqlDataReader rdrMxH = cmdMxH.ExecuteReader();
                            while (rdrMxH.Read())
                            {
                                dateMaxRRH = rdrMxH["oDate"].ToString();
                                stDateMxH = dateMaxRRH.Substring(0, 16);
                                stMxHor = rdrMxH["RR"].ToString();
                                break;

                            }
                        }

                        con.Close();

                    }
                    
                    string RRLtr = "<div class=\"card m-2\"> <div class=\"card-header\"> <i class=\"fas fa-cloud-rain\"></i> Pluie</div><table class=\"table\"><thead><tr><th scope =\"col\"> Pramètre </th > <th scope=\"col\">Valeur</th> <th scope =\"col\">Date / Heure</th > </tr > </thead > <tbody > <tr > <th scope=\"row\">RR Max Hor</th> <td>" + stMxHor + "</td> <td>" + stDateMxH + "</td> </tr> <tr> <th scope =\"row\">RR Max 6min</th> <td>" + stMxSix + "</td> <td>" + stDateMxS + "</td> </tr> <tr> <th scope =\"row\">Cumul Horaire</th > <td colspan=\"2\">" +stCumH + "</td> </tr> <tr> <th scope =\"row\">Cumul 6 Min</th> <td colspan =\"2\">" + stCumS + "</td> </tr></tbody> </table> <div class=\"card-footer small text-muted\">Station " + ID + "</div> </div>";
                    LtrRR.Text = RRLtr;                    


                }
                catch (Exception)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Un erreur est survenus, contactez le WebMaster!')", true);
                }


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Remplir les champs correctement !')", true);
            }

        }

        protected void btnRGDI_Click(object sender, EventArgs e)
        {
            string TODAY = DateTime.Now.AddHours(-6).ToString("dd/MM/yyyy HH:mm:ss");
            string PRESENTDATE = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string dummydate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            string dateA = txtdate1.Text;
            string dateB = txtdate2.Text;
            string DATE1 = txtdate1.Text + ":00";
            string DATE2 = txtdate2.Text + ":00";
            string ID = ddlStation.SelectedValue;
            string quCumDI = string.Empty;
            string stCumDI = string.Empty;
            double TotDImnt;
            string stDIHrs;
            double TotDIHrs;

            if (!(string.IsNullOrEmpty(dateA) || string.IsNullOrEmpty(dateB) || string.IsNullOrEmpty(ID)))
            {
                try
                {
                    string constring = ConfigurationManager.ConnectionStrings["ArqusDBConnstring"].ConnectionString;
                    quCumDI = "SELECT ROUND(SUM(CAST(Di AS float)),2) AS CumulDI FROM station" + ID + " WHERE oDate BETWEEN " + "'" + DATE1 + "'" + " AND " + "'" + DATE2 + "'";
                    
                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();

                        using (SqlCommand cmdCuDI = new SqlCommand(quCumDI, con))
                        {
                            SqlDataReader rdrCumDI = cmdCuDI.ExecuteReader();
                            while (rdrCumDI.Read())
                            {
                                stCumDI = rdrCumDI["CumulDI"].ToString();

                            }
                        }

                        con.Close();

                    }
                   

                    if (double.TryParse(stCumDI, out TotDImnt))
                    {
                        TotDIHrs = TotDImnt / 60;
                        stDIHrs = string.Format("{0:0.0}", TotDIHrs);

                    }
                    else
                    {
                        stDIHrs = "N/A";
                    }
                     
                    string RGDILtr = "<div class=\"card m-2\"> <div class=\"card-header\"> <i class=\"fas fa-sun\"></i> Durée Totale d'Insolation </div> <table class=\"table table-bordered\"> <thead> <tr> <th scope=\"col\">Durée Totale en Minutes</th> <th scope=\"col\">Durée Totale en Heures</th> </tr> </thead> <tbody> <tr> <td>" + stCumDI + "</td> <td>" + stDIHrs + "</td> </tr> </tbody> </table> <div class=\"card-footer small text-muted\">Station " + ID + "</div> </div>";
                    LtrRGDI.Text = RGDILtr;


                }
                catch (Exception)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Un erreur est survenus, contactez le WebMaster!')", true);
                }


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Remplir les champs correctement !')", true);
            }
        }
    }
}