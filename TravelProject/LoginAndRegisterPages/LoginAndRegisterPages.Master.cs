﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TravelProject.LoginAndRegisterPages
{
    public partial class LoginAndRegisterPages : System.Web.UI.MasterPage
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-IOITRQL;Initial Catalog=Travel;Integrated Security=True");
            if (Request.QueryString["d"] == "T")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "mode", "colorMode();", true);
            }
            else if (Session["d"] != null)
            {
                if (Session["d"].ToString() == "T")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "mode", "colorMode();", true);
                }
            }
        }
        protected void mode_Click(object sender, EventArgs e)
        {
            if (Session["d"] != null)
            {
                if (Session["d"].ToString() == "T")
                {
                    Session["d"] = "F";
                    string[] cur = Request.RawUrl.Split('?');
                    if (cur.Length > 1) Response.Redirect(cur[0] + "?d=F");
                    else Response.Redirect(Request.RawUrl + "?d=F");
                }
                else
                {
                    Session["d"] = "T";
                    string[] cur = Request.RawUrl.Split('?');
                    if (cur.Length > 1) Response.Redirect(cur[0] + "?d=T");
                    else Response.Redirect(Request.RawUrl + "?d=T");
                }
            }
            else
            {
                Session["d"] = "T";
                string[] cur = Request.RawUrl.Split('?');
                if (cur.Length > 1) Response.Redirect(cur[0] + "?d=T");
                else Response.Redirect(Request.RawUrl + "?d=T");
            }
        }
    }
}