using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Modules;
using System.Data.SqlClient;
using DotNetNuke.Data;
using DotNetNuke.Modules.FaavanResume1.Data;
using DotNetNuke.Modules.FaavanResume1.Components;
using System.Data;

namespace DotNetNuke.Modules.FaavanResume1
{
    /// <summary>
    /// Summary description for AHandler
    /// </summary>
    public class AHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           
            SqlDataReader rdr = null;
            string ModuleQualifier = "FaavanResume1_";
            string objectQualifier = DotNetNuke.Data.DataProvider.Instance().ObjectQualifier;
            string databaseOwner = DotNetNuke.Data.DataProvider.Instance().DatabaseOwner;
            string connectionstring = DotNetNuke.Data.DataProvider.Instance().ConnectionString;
            string nameprefix = "ddn.dbo.FaavanResume1_";
            int pictureid;
            
                SqlConnection conn = new SqlConnection (DotNetNuke.Data.DataProvider.Instance().ConnectionString);

                SqlCommand selcmd = new SqlCommand("select data from dbo.favanDNN_FaavanResume1_pic where pid=" + context.Request.QueryString["imgID"], conn);

                conn.Open();

                rdr = selcmd.ExecuteReader();
            

            


            while (rdr.Read())

                {

                    context.Response.ContentType = "image/jpg";

                    context.Response.BinaryWrite((byte[])rdr["data"]);

                }

            rdr.Close();

            conn.Close();

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}