using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WARDEN
{
    public class Class1 : Interface1
    {
        public void addbeacon(string x, string y, string comm, string neighbour)
        {


            try
            {
                MySqlConnection cn = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;password=1234");
                cn.Open();
                //adding unit
                MySqlCommand cmd = new MySqlCommand("INSERT INTO all_beacons( x, y, comments,neighbourID) VALUES (" + "'" + x + "'" + "," + "'" + y + "'" + "," + "'" + comm + "'" + "," + "'" + neighbour + "'" + ") ", cn);
                cmd.ExecuteNonQuery();
                long i = cmd.LastInsertedId;

                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO new_beacons(idnb) VALUES (" + i + ") ", cn);
                cmd1.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        
        public void Bind(GridView a, GridView b)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");
                MySqlCommand cmd1;
                MySqlCommand cmd2;

                con.Open();
                cmd1 = new MySqlCommand("select idn, idb, ninfo from notifications", con); //TODO: sort by dateTime when adding in list
                DataTable datatable1 = new DataTable();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
                adapter1.Fill(datatable1);
                a.DataSource = datatable1;
                a.DataBind();

                cmd2 = new MySqlCommand("select idn,idb, ninfo from history", con);
                DataTable datatable2 = new DataTable();
                MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
                adapter2.Fill(datatable2);
                b.DataSource = datatable2;
                b.DataBind();

                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        

        public void delete(string delete)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;password=1234");
                cn.Open();
                //adding unit
                MySqlCommand cmd = new MySqlCommand("DELETE from active_beacons where idcb=" + delete, cn);
                MySqlCommand cmd1 = new MySqlCommand("DELETE from new_beacons where idcb=" + delete, cn);
                MySqlCommand cmd2 = new MySqlCommand("DELETE from all_beacons where idcb=" + delete, cn);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        public void editData()
        {
          
        }

        public void showdata(GridView a)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");
                MySqlCommand cmd1;
                cmd1 = new MySqlCommand("Select idb,x,y,comments,last_seen from all_beacons ab join active_beacons cb where ab.idb = cb.idcb", cn); //TODO: sort by dateTime when adding in list
                DataTable datatable1 = new DataTable();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
                adapter1.Fill(datatable1);
                if (datatable1.Rows.Count > 0)
                {
                    a.DataSource = datatable1;
                    a.DataBind();
                }
                cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public void tick_timer(string a, string b)
        {

           a = "Panel refreshed at: " + DateTime.Now.ToLongTimeString();
           b = "Panel refreshed at: " + DateTime.Now.ToLongTimeString();
        }

        public void update(string x, string y, string com, string ls, string id, GridView a)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;password=1234");
                cn.Open();
                //updating the record  
                MySqlCommand cmd = new MySqlCommand("Update all_beacons set x='" + x + "',y='" + y + "',comments='" + com + "',last_seen='" + ls + "' where idb=" + id, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
                a.EditIndex = -1;
            }
            catch (Exception)
            {

                throw;
            }
         
        }
    }
}