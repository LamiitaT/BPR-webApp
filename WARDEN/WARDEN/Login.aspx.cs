using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace WARDEN
{
    public partial class Login : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=warden;User id=root;");

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd1;
            cmd1 = new MySqlCommand("select * from login where username = '" + user.Text + "' and password =password('" + pass.Text + "')", con);
            DataTable datatable1 = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
            adapter1.Fill(datatable1);
            foreach (DataRow dr in datatable1.Rows)
            {
                Session["username"] = dr["username"].ToString();
                Server.Transfer("Home.aspx");
            }


            con.Close();

            feedback.Text = "Invalid username or password";

        }
    }
}