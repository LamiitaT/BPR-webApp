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
using System.Web.UI.HtmlControls;

namespace WARDEN
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
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
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=warden;User id=root;");
            MySqlCommand cmd1;
            MySqlCommand cmd2;
            MySqlCommand cmd3;

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

            cmd3 = new MySqlCommand("SELECT COUNT(*) FROM notifications", con);
            int countRows;
            countRows = Convert.ToInt32(cmd3.ExecuteScalar());
            //System.Diagnostics.Debug.WriteLine(countRows.ToString());
            //System.Diagnostics.Debug.WriteLine(count.InnerHtml);
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


            con.Close();

        }

        protected void PendingRecordsGridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You pressed seen')", true);

            if (e.CommandName == "seen")
            {
                Session["idn"] = e.CommandArgument.ToString();
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=warden;User id=root;");

                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO history (idn, idb, ntype, ninfo, time) SELECT idn, idb, ntype, ninfo, time FROM notifications where idn='" + Session["idn"].ToString() + "'", con);
                MySqlCommand cmd2 = new MySqlCommand("UPDATE history set status='Seen by " + Session["username"].ToString() + "', timeUpdated = NOW() where idn='" + Session["idn"].ToString() + "'", con);
                MySqlCommand cmd3 = new MySqlCommand("DELETE FROM notifications where idn='" + Session["idn"].ToString() + "'", con);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                con.Close();

                Bind();
                UpdatePanel3.Update();


            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Bind();
            Label1.Text = "Panel refreshed at: " + DateTime.Now.ToLongTimeString();
            Label3.Text = "Panel refreshed at: " + DateTime.Now.ToLongTimeString();
            UpdatePanel3.Update();
        }

        /*
        protected void nbutton_Click(object sender, EventArgs e)
        {
            if (nlist.Visible)
            {
                nlist.Visible = false;
            }
            else
            {
                nlist.Visible = true;
            }
        }
        */
    }
}