using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace WARDEN
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bind();
            }

            MySqlConnection con = new MySqlConnection("Server=localhost;Database=warden;User id=root;");
            MySqlCommand cmd;
            
            con.Open();
            cmd = new MySqlCommand("select idn,ninfo from history_table", con);
            DataTable datatable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(datatable);
            AcceptedRecordsGridview.DataSource = datatable;
            AcceptedRecordsGridview.DataBind();
            con.Close();
        }

        protected void bind()
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=warden;User id=root;");
            MySqlCommand cmd;

            con.Open();
            cmd = new MySqlCommand("select idn,ninfo from notifications_table", con);
            DataTable datatable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(datatable);
            PendingRecordsGridview.DataSource = datatable;
            PendingRecordsGridview.DataBind();
            con.Close();
        }
        protected void PendingRecordsGridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "seen")
            {
                Session["idn"] = e.CommandArgument.ToString();
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=warden;User id=root;");

                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO history_table (idn, ninfo) SELECT idn, ninfo FROM notifications_table where idn='" + Session["idn"].ToString() + "'", con);
                MySqlCommand cmd2 = new MySqlCommand("delete from notifications_table where idn='" + Session["idn"].ToString() + "'", con);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                bind();

            }
        }

    }
}