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

        Interface1 controler = new Class1();
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
        //Bind
        protected void Bind()
        {
            controler.Bind(PendingRecordsGridview, AcceptedRecordsGridview);
          

            con.Close();*/
            ShowData();

            //search_results.Text = PendingRecordsGridview.Rows.Count.ToString();
        }
        //editData
        protected void PendingRecordsGridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You pressed seen')", true);

            if (e.CommandName == "seen")
            {
                Session["idn"] = e.CommandArgument.ToString();
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");

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
        //timer
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Bind();
            Label1.Text = "Panel refreshed at: " + DateTime.Now.ToLongTimeString();
            Label3.Text = "Panel refreshed at: " + DateTime.Now.ToLongTimeString();
        }
        //showdata
        protected void ShowData()  
    {
           controler.showdata(GridView1);
     
    }  
        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            GridView1.EditIndex = e.NewEditIndex;
            ShowData();
        }
        //update
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update  
            Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox x = GridView1.Rows[e.RowIndex].FindControl("txt_x") as TextBox;
            TextBox y = GridView1.Rows[e.RowIndex].FindControl("txt_y") as TextBox;
            TextBox comm = GridView1.Rows[e.RowIndex].FindControl("txt_comments") as TextBox;
            TextBox ls = GridView1.Rows[e.RowIndex].FindControl("txt_ls") as TextBox;
          
            ShowData();
        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            ShowData();
        }
        //addbeacon
        protected  void Addbeacon_click(object sender,EventArgs e)
        {
            controler.addbeacon(xcords.Text, ycords.Text, comments.Text, neighbourid.Text);
         /*   string x = xcords.Text;
            string y = ycords.Text;
            string comm = comments.Text;
            string neighbour = neighbourid.Text;
          
            MySqlConnection cn = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;password=1234");
            cn.Open();
            //adding unit
            MySqlCommand cmd = new MySqlCommand("INSERT INTO all_beacons( x, y, comments,neighbourID) VALUES (" + "'"+ xcords.Text + "'" + "," + "'"+ ycords.Text+ "'" + "," + "'"+ comments.Text+ "'" + "," + "'"+ neighbourid.Text+ "'" + ") ", cn);
           cmd.ExecuteNonQuery();
           long i = cmd.LastInsertedId;

            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO new_beacons(idnb) VALUES (" + i + ") ", cn);
            cmd1.ExecuteNonQuery();
            cn.Close();*/
        }
        //addunit
        protected void btn_Edit_Click1(object sender, EventArgs e)
        {
            controler.delete(delete.Text);
          /*  MySqlConnection cn = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;password=1234");
            cn.Open();
            //adding unit
            MySqlCommand cmd = new MySqlCommand("DELETE from active_beacons where idcb="+delete.Text, cn);
            MySqlCommand cmd1 = new MySqlCommand("DELETE from new_beacons where idcb=" + delete.Text, cn);
            MySqlCommand cmd2 = new MySqlCommand("DELETE from all_beacons where idcb=" + delete.Text, cn);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cn.Close();*/
        }
    }
}