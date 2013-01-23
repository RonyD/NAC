using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommandCentre.Resources.Classes;

namespace CommandCentre
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                SessionUtils defSes = new SessionUtils();
                CommandUtils com = new CommandUtils();

                string Page = Form.Page.ToString();

                defSes.session(Page);

                defSes.getSessions();
            
        }
    }
}
