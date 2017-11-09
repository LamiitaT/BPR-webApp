using System;
using System.Collections.Generic;
using System.Data.Common;
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
            if(Session["username"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You pressed seen')", true);

                Server.Transfer("Login.aspx");
            }

            if (!IsPostBack)
            {
                Bind();
            }

        }

        protected void Bind()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;");
            //DAN: MySqlConnection con = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;password=1234");
            MySqlCommand cmd1;
            MySqlCommand cmd2;

            con.Open();
            cmd1 = new MySqlCommand("select idn, idb, ninfo from notifications", con); //TODO: sort by dateTime when adding in list
            DataTable datatable1 = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
            adapter1.Fill(datatable1);
            PendingRecordsGridview.DataSource = datatable1;
            PendingRecordsGridview.DataBind();

            cmd2 = new MySqlCommand("select idn,idb, ninfo from history", con);
            DataTable datatable2 = new DataTable();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
            adapter2.Fill(datatable2);
            AcceptedRecordsGridview.DataSource = datatable2;
            AcceptedRecordsGridview.DataBind();

            con.Close();
            ShowData();

            //search_results.Text = PendingRecordsGridview.Rows.Count.ToString();
        }
        protected void PendingRecordsGridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You pressed seen')", true);

            if (e.CommandName == "seen")
            {
                Session["idn"] = e.CommandArgument.ToString();
                MySqlConnection con = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;");

                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO history (idn, idb, ntype, ninfo, time) SELECT idn, idb, ntype, ninfo, time FROM notifications where idn='" + Session["idn"].ToString() + "'", con);
                MySqlCommand cmd2 = new MySqlCommand("UPDATE history set status='Seen by " + Session["username"].ToString() + "', timeUpdated = NOW() where idn='" + Session["idn"].ToString() + "'", con);
                MySqlCommand cmd3 = new MySqlCommand("DELETE FROM notifications where idn='" + Session["idn"].ToString() + "'", con);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                Bind();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Bind();
            Label1.Text = "Panel refreshed at: " + DateTime.Now.ToLongTimeString();
            Label3.Text = "Panel refreshed at: " + DateTime.Now.ToLongTimeString();
        }

        protected void ShowData()  
    {

            MySqlConnection cn = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;");
            MySqlCommand cmd1;
            cmd1 = new MySqlCommand("Select idb,x,y,comments,last_seen from all_beacons ab join current_beacons cb where ab.idb = cb.idcb", cn); //TODO: sort by dateTime when adding in list
            DataTable datatable1 = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
            adapter1.Fill(datatable1);
            if(datatable1.Rows.Count>0)
            {
                GridView1.DataSource = datatable1;
                 GridView1.DataBind();
            }
          


         /*    DataTable dt = new DataTable();
            cn = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;");  
             cn.Open();
            cmd1 = new MySqlCommand("Select idcb,x,y,comments,lastseen from tbl_Employee", cn);
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1); 
              adapt.Fill(dt);  
              if(dt.Rows.Count>0)  
              {  
                  GridView1.DataSource = dt;  
                   GridView1.DataBind();  
              }  
              con.Close();  */
    }  
        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            GridView1.EditIndex = e.NewEditIndex;
            ShowData();
        }
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update  
            Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox x = GridView1.Rows[e.RowIndex].FindControl("txt_x") as TextBox;
            TextBox y = GridView1.Rows[e.RowIndex].FindControl("txt_y") as TextBox;
            TextBox comm = GridView1.Rows[e.RowIndex].FindControl("txt_comments") as TextBox;
            TextBox ls = GridView1.Rows[e.RowIndex].FindControl("txt_ls") as TextBox;

            MySqlConnection cn = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;");
            cn.Open();
            //updating the record  
            MySqlCommand cmd = new MySqlCommand("Update all_beacons set x='" +x.Text + "',y='" + y.Text + "',comments='"+comm.Text+"',last_seen='"+ls.Text + "' where idb=" + Convert.ToInt32(id.Text), cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            ShowData();
        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            ShowData();
        }

    }
}