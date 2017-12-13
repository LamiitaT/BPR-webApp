using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WARDEN
{
    public class Controller : Controller_View
    {
        private DataAdaptor model;
        public Controller()
        {
            model = new MySqlData();
        }

        public void addbeacon(string x, string y, string comm, string neighbour)
        {
             model.addbeacon( x,  y,  comm,  neighbour);
        }

        public int countNotifications()
        {
            try{

                return model.countNotifications();
            }
            catch (Exception ex)
            {
                throw new AdapterException();
            }
        }

        public DataTable getBeacons()
        {
            try
            {
                return model.getBeacons();
            }
            catch (Exception ex)
            {
                throw new AdapterException();
            }
        }

        

        public DataTable getNotifications()
        {
            try
            {
                return model.getNotifications();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string login(string username, string password)
        {
            try
            {
                return model.login(username, password);
            }
            catch (Exception ex)
            {
                throw new AdapterException();
            }
        }

        public bool moveToHistory(string sesionid, string sessionUser)
        {
            try
            {
                return model.moveToHistory(sesionid, sessionUser);
            }
            catch (Exception ex)
            {
                throw new AdapterException();
            }
        }

        public void update(string x, string y, string com, string ls, string id)
        {
            model.update(x, y, com, ls, id);
        }
        public DataTable getCordinates()
        {
            try
            {
                return model.getNotifications();
            }
            catch (Exception ex)
            {
                throw new AdapterException();
            }
        }
        public void BindStatusList(DropDownList ddlStatus, string ViewState)
        {
            try
            {
                model.BindStatusList(ddlStatus, ViewState);
            }
            catch (Exception ex)
            {

                throw new AdapterException(); 
            }
             
        
        }

        public DataTable getHistory(string viewstate)
        {
            try
            {

                return model.getHistory(viewstate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }

    class AdapterException : Exception
    {
        public AdapterException() : base()
        { 
        }
    }
}
