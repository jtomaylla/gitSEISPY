using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSProyectos
{
    public partial class KeepSessionAlive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MetaRefresh.Attributes["content"] = Convert.ToString((Session.Timeout * 60) / 2) + ";url=KeepSessionAlive.aspx?q=" + DateTime.Now.Ticks;
        }
    }
}