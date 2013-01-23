#region using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

#endregion using directives

namespace CommandCentre.Resources.Classes
{
    public class SessionUtils
    {
        private string sesID;
        private string browserName;
        private string browserVers;
        private string anonymousID;
        private string sesIP;
        private string sesUserID;
        private string sesMachUser;
        private string sesPag;
        private string loggedUser;
        private string sesDump;
        private string sesStart;

        CommandUtils commands = new CommandUtils();

        public SessionUtils()
        { }

        public void session(string Pag)
        {
            if (HttpContext.Current.Session.IsNewSession)
            {
                sesID       = HttpContext.Current.Session.SessionID.ToString();
                browserName = HttpContext.Current.Request.Browser.Browser;
                browserVers = HttpContext.Current.Request.Browser.Version;
                anonymousID = HttpContext.Current.Request.AnonymousID;
                sesIP       = HttpContext.Current.Request.UserHostAddress;
                sesUserID   = HttpContext.Current.Request.LogonUserIdentity.Name;
                sesMachUser = HttpContext.Current.Request.LogonUserIdentity.User.ToString();
                sesPag      = Pag;
                sesStart    = DateTime.Now.ToString();
            }
            else 
            {
                sesID       = HttpContext.Current.Session.SessionID.ToString();               
                sesUserID   = HttpContext.Current.Request.LogonUserIdentity.Name;
                browserName = HttpContext.Current.Request.Browser.Browser;
                browserVers = HttpContext.Current.Request.Browser.Version;
                sesPag      = Pag;

                if (Membership.GetNumberOfUsersOnline() > 0)
                {
                    loggedUser = Membership.GetUser().ProviderUserKey.ToString();
                }       
            }
        }

        public DataSet getSessions()
        {
            CommandUtils comUtils = new CommandUtils();

            string qry = "SELECT ";
            qry += "SS_SES_ID, SS_SES_STA, SS_SES_END, SS_CLI_ADD, SS_CLI_NAM, SS_BRW_NAM, SS_BRW_VER, SS_INI_PAG ";
            qry += "FROM ";
            qry += "ccentre_Sessions ";            

            SqlCommand command = new SqlCommand(qry);

            return commands.commandData(command, "ccentre_Sessions");
        }

    }
}