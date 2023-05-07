using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DotNetNuke.Modules.FaavanResume1.Data;

namespace DotNetNuke.Modules.FaavanResume1.Components
{
    public class constring
    {
        public static SqlConnection AddString()
        {
            SqlConnection con = DataProvider.Instance().constringcapture();
            return con;
        }
    }
}