using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CommandCentre.Resources.Classes
{
    public class CommandUtils
    {
        protected string commandCon;

        public CommandUtils()
        {
            if (WebConfigurationManager.ConnectionStrings["CommandCon"] == null)
            {
                throw new ApplicationException("Cannot connect to application resource at this time. Please try again later");
            }
            else
            {
                commandCon = WebConfigurationManager.ConnectionStrings["CommandCon"].ConnectionString;
            }
        }
        

        public bool conTry(SqlCommand command)
        {
            int success;

            SqlConnection con = new SqlConnection(commandCon);

            command.Connection = con;

            try
            {
                con.Open();
                success = command.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            if (success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public DataSet commandData(SqlCommand command, string Tablename)
        {
            SqlConnection con = new SqlConnection(commandCon);

            command.Connection = con;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet ds = new DataSet();

            try
            {
                con.Open();
                adapter.Fill(ds, Tablename);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
    }
}