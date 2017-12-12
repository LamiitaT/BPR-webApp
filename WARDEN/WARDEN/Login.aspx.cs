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
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");
        Controller_View c = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            /*  con.Open();
              MySqlCommand cmd1;
              cmd1 = new MySqlCommand("select * from login where username = '" + user.Text + "' and password = '" + pass.Text + "'", con);
              DataTable datatable1 = new DataTable();
              MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
              adapter1.Fill(datatable1);
              */
           if( c.login(user.Text, pass.Text)!="")
            {
                Session["username"] = c.login(user.Text, pass.Text);
                Response.Redirect("Home.aspx");
            }
           
          /*  
            foreach (DataRow dr in datatable1.Rows)
            {
                System.Diagnostics.Debug.WriteLine(dr["username"].ToString());

                Session["username"] = dr["username"].ToString();
                Response.Redirect("Home.aspx");
            }*/

         //   con.Close();

            //System.Diagnostics.Debug.WriteLine("helooo");

            feedback.Text = "Invalid username or password";

        }
    }
}