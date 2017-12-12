using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WARDEN
{
    interface DataAdaptor
    {
        string login(string username, string password);
        DataTable getNotifications();
        int countNotifications();
        bool moveToHistory(string sesionid,string sessionUser);
        DataTable getBeacons();
        void addbeacon(string x, string y, string comm, string neighbour);
        void update(string x, string y, string com, string ls, string id);
        DataTable getCordinates();
        void BindStatusList(DropDownList ddlStatus,string ViewState);
        DataTable getHistory(string viewstate);
    }
}
