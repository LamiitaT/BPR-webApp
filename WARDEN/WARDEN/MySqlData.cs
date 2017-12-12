using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WARDEN
{
    public class MySqlData : DataAdaptor
    {
        public int countNotifications()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM notifications", con);
                int countRows;
                countRows = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return countRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                try
                {
                    con.Close();
                }
                catch
                {

                }
            }
        }

        public DataTable getBeacons()
        {
            MySqlConnection cn = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");    
            try
            {
              
                MySqlCommand cmd1;
                cmd1 = new MySqlCommand("Select idb,x,y,comments,last_seen from all_beacons ab join active_beacons cb where ab.idb = cb.idcb", cn); //TODO: sort by dateTime when adding in list
                DataTable datatable = new DataTable();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
                adapter1.Fill(datatable);
                cn.Close();
                return datatable;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                try
                {
                    cn.Close();
                }
                catch
                {

                }
            }

        }

        public DataTable getNotifications()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select idn, idb, ninfo, time from notifications", con); //TODO: sort by dateTime when adding in list
                DataTable datatable = new DataTable();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd);
                adapter1.Fill(datatable);
                con.Close();
                return datatable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                try
                {
                    con.Close();
                }
                catch
                {

                }
            }
        }
        public void addbeacon(string x, string y, string comm, string neighbour)
        {

            MySqlConnection cn = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;password=1234");
            try
            {
                cn.Open();
                //adding unit
                MySqlCommand cmd = new MySqlCommand("INSERT INTO all_beacons( x, y, comments,neighbourID) VALUES (" + "'" + x + "'" + "," + "'" + y + "'" + "," + "'" + comm + "'" + "," + "'" + neighbour + "'" + ") ", cn);
                cmd.ExecuteNonQuery();
                long i = cmd.LastInsertedId;

                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO new_beacons(idnb) VALUES (" + i + ") ", cn);
                cmd1.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                try
                {
                    cn.Close();
                }
                catch
                {

                }
            }

        }
        public void update(string x, string y, string com, string ls, string id)
        {

            MySqlConnection cn = new MySqlConnection("server=localhost;persistsecurityinfo=True;user id=root;database=warden;password=1234");
            try
            {
                cn.Open();
                //updating the record  
                MySqlCommand cmd = new MySqlCommand("Update all_beacons set x='" + x + "',y='" + y + "',comments='" + com + "',last_seen='" + ls + "' where idb=" + id, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                try
                {
                    cn.Close();
                }
                catch
                {

                }
            }

        }
        public string login(string username, string password)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");
            try
            {
                con.Open();
                MySqlCommand cmd1;
                DataTable table = new DataTable();
                cmd1 = new MySqlCommand("select * from login where username = '" + username + "' and password = '" + password + "'", con);

                MySqlDataAdapter adapter1 = new MySqlDataAdapter(cmd1);
                adapter1.Fill(table);
                String returnusername = "";
                foreach (DataRow dr in table.Rows)
                {

                    returnusername = dr["username"].ToString();

                }
                con.Close();

                return returnusername;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                try
                {
                    con.Close();
                }
                catch
                {

                }
            }


        }

        public bool moveToHistory(string sesionid, string sessionUser)
        {
            bool result = false;
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");
            try
            {

                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO history (idn, idb, ntype, ninfo, time) SELECT idn, idb, ntype, ninfo, time FROM notifications where idn='" + sesionid + "'", con);
                MySqlCommand cmd2 = new MySqlCommand("UPDATE history set status='Seen by " + sessionUser + "', timeUpdated = NOW() where idn='" + sesionid + "'", con);
                MySqlCommand cmd3 = new MySqlCommand("DELETE FROM notifications where idn='" + sesionid + "'", con);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();

                con.Close();
                result = true;

            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                try
                {

                    con.Close();
                }
                catch
                {

                }

            }

            return result;


        }

        public DataTable getCordinates()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");
            try
            {
               
                MySqlCommand cmd = new MySqlCommand("Select idb,x,y,comments,last_seen from all_beacons ab join active_beacons cb where ab.idb = cb.idcb");
                using (con)
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
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                try
                {

                    con.Close();
                }
                catch
                {

                }

            }

        }

        public void BindStatusList(DropDownList ddlStatus, string ViewState)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");
            try
            {
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
                ddlStatus.Items.FindByValue(ViewState).Selected = true;
            }
            catch (Exception ex )
            {

                throw ex;
            }
            finally
            {
                try
                {

                    con.Close();
                }
                catch
                {

                }

            }

        }

        public DataTable getHistory(string viewstate)
        {

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=warden;password=1234");
            try
            {
                MySqlCommand cmd2;
                con.Open();
                string sqlp = "status_by";
                cmd2 = new MySqlCommand(sqlp, con);
                DataTable datatable = new DataTable();
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@con", viewstate);
                cmd2.Connection = con;
                MySqlDataAdapter adapter2 = new MySqlDataAdapter();
                adapter2.SelectCommand = cmd2;
                adapter2.Fill(datatable);

                /* foreach(DataRow r in datatable.Rows)
                {
                    long time= (long)r["time"];
                    System.Diagnostics.Debug.WriteLine(time +"this is the time");
                    DateTime dtDateTime = new DateTime(time);
                    System.Diagnostics.Debug.WriteLine(dtDateTime+"this is after convertion");
                    DateTime timenow = DateTime.Now;
                    long t = dtDateTime.Ticks;
                    System.Diagnostics.Debug.WriteLine(t + "this is the time in tiks");
                    r["time"] = dtDateTime.Ticks;
                    r["timeUpdated"] = long.Parse(timenow.ToString("yyyyMMddHHmmss")); 
                }*/

                con.Close();
                return datatable;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                try
                {

                    con.Close();
                }
                catch
                {

                }

            }
        }
    }
}