using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace WARDEN
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Controller_View c = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You pressed seen')", true);

                Server.Transfer("Login.aspx");
            }

            if (!IsPostBack)
            {

                ViewState["Filter"] = "ALL";
                Bind();
            }

        }

        protected void Bind()
        {
            foreach(GridViewRow row in AcceptedRecordsGridview.Rows)
            PendingRecordsGridview.DataSource = c.getNotifications();
            PendingRecordsGridview.DataBind();
             AcceptedRecordsGridview.DataSource = c.getHistory(ViewState["Filter"].ToString());
            AcceptedRecordsGridview.DataBind();
            DropDownList ddlStatus = (DropDownList)AcceptedRecordsGridview.HeaderRow.FindControl("ddlStatus");
            c.BindStatusList(ddlStatus, ViewState["Filter"].ToString());

            // DropDownList ddlStatus = (DropDownList)AcceptedRecordsGridview.HeaderRow.FindControl("ddlStatus");
            // c.BindStatusList(ddlStatus, ViewState["Filter"].ToString());
            // this.BindStatusList(ddlStatus);
            
            int countRows;
            countRows = Convert.ToInt32(c.countNotifications());
            if (countRows > 0)
            {
                count.Visible = true;
                count.InnerHtml = countRows.ToString();
                System.Diagnostics.Debug.WriteLine(count.InnerHtml);
                count.Style.Add("padding", "1px 5px 1px 5px");
            }
            else
            {
                count.Visible = false;
            }
            DataTable dt = this.GetData();
           // DataTable dt = c.getCordinates();
            rptMarkers.DataSource = dt;
            rptMarkers.DataBind();
            ShowData();

        }

        protected void PendingRecordsGridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You pressed seen')", true);
               
                System.Diagnostics.Debug.WriteLine("un ungur apasa chestii");
                if (e.CommandName == "seen")
                {
                    System.Diagnostics.Debug.WriteLine("ungurul a apasat pe seen");
                    Session["idn"] = e.CommandArgument.ToString();

                    if (c.moveToHistory(Session["idn"].ToString(), Session["username"].ToString()) == true)
                    {
                        System.Diagnostics.Debug.WriteLine("works");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("fail");
                    }


                    Bind();
                    UpdatePanel3.Update();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            Bind();
            refreshnotif.Text = "panel refreshed at: " + DateTime.Now.ToLongTimeString();
            refreshhist.Text = "panel refreshed at: " + DateTime.Now.ToLongTimeString();

            UpdatePanel3.Update();
        }
        protected string getTime( string time)
        {

            System.Diagnostics.Debug.WriteLine(time + "this is before convertion");
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(Int64.Parse(time));
         
            System.Diagnostics.Debug.WriteLine(dtDateTime + "this is after convertion");
            // DateTime timenow = DateTime.Now;
            return dtDateTime.ToString() ;
        }

        private void BindStatusList(DropDownList ddlStatus)
        {/*
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("select distinct status" +
                            " from history");
            cmd.Connection = con;
            con.Open();
            ddlStatus.DataSource = cmd.ExecuteReader();
            ddlStatus.DataTextField = "status";
            ddlStatus.DataValueField = "status";
            ddlStatus.DataBind();
            con.Close();
            ddlStatus.Items.FindByValue(ViewState["Filter"].ToString()).Selected = true;
            */
        }

        protected void StatusChanged(object sender, EventArgs e)
        {
            DropDownList ddlStatus = (DropDownList)sender;
            ViewState["Filter"] = ddlStatus.SelectedValue;
            this.Bind();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            AcceptedRecordsGridview.PageIndex = e.NewPageIndex;
            this.Bind();
        }

        //timer

        //showdata
        protected void ShowData()
        {
            GridView1.DataSource = c.getBeacons();
            GridView1.DataBind();

        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
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
            c.update(x.Text, y.Text, comm.Text, ls.Text, id.Text);
            GridView1.EditIndex = -1;
            ShowData();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            ShowData();
        }
        //addbeacon
        protected void Addbeacon_click(object sender, EventArgs e)
        {
            c.addbeacon(xcords.Text, ycords.Text, comments.Text, neighbourid.Text);
        }
        //addunit
        protected void btn_Edit_Click1(object sender, EventArgs e)
        {
            //controler.delete(delete.Text);
          
        }
        private DataTable GetData()
        {
            string conString = "server=localhost;user id=root;database=warden;password=1234";
            MySqlCommand cmd = new MySqlCommand("Select idb,x,y,comments,last_seen from all_beacons ab join active_beacons cb where ab.idb = cb.idcb");
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}