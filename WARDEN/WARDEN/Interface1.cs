using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WARDEN
{
    interface Interface1
    {
          void Bind( GridView a, GridView b);

        void tick_timer(string a, string b);
        void showdata(GridView a);
        void editData();
        void update(string x,string y,string com,string ls,string id,GridView a);
        void addbeacon(string x, string y, string comm, string neighbour);
        void delete(string delete);

    }
}
