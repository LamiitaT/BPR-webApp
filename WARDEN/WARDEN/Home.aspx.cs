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

namespace WARDEN
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=warden;User id=root;");
            MySqlCommand cmd;
            
            con.Open();
            cmd = new MySqlCommand("select idn,ntype,ninfo from notifications_table", con);
            DataTable datatable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(datatable);
            GridView2.DataSource = datatable;
            GridView2.DataBind();
            con.Close();
        }

    }
}