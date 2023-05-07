/*
' Copyright (c) 2011 DotNetNuke Corporation
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Framework.Providers;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using DotNetNuke.Modules.FaavanResume1.Components;
using System.Xml;
using System.Collections.Generic;

namespace DotNetNuke.Modules.FaavanResume1.Data
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// SQL Server implementation of the abstract DataProvider class
    /// </summary>
    /// -----------------------------------------------------------------------------
    public class SqlDataProvider : DataProvider
    {

        #region Private Members

        private const string ProviderType = "data";
        private const string ModuleQualifier = "FaavanResume1_";

        private readonly ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration(ProviderType);
        private readonly string _connectionString;
        private readonly string _providerPath;
        private readonly string _objectQualifier;
        private readonly string _databaseOwner;

        #endregion

        #region Constructors

        public SqlDataProvider()
        {

            // Read the configuration specific information for this provider
            Provider objProvider = (Provider)(_providerConfiguration.Providers[_providerConfiguration.DefaultProvider]);

            // Read the attributes for this provider

            //Get Connection string from web.config
            _connectionString = Config.GetConnectionString();

            if (string.IsNullOrEmpty(_connectionString))
            {
                // Use connection string specified in provider
                _connectionString = objProvider.Attributes["connectionString"];
            }

            _providerPath = objProvider.Attributes["providerPath"];

            _objectQualifier = objProvider.Attributes["objectQualifier"];
            if (!string.IsNullOrEmpty(_objectQualifier) && _objectQualifier.EndsWith("_", StringComparison.Ordinal) == false)
            {
                _objectQualifier += "_";
            }

            _databaseOwner = objProvider.Attributes["databaseOwner"];
            if (!string.IsNullOrEmpty(_databaseOwner) && _databaseOwner.EndsWith(".", StringComparison.Ordinal) == false)
            {
                _databaseOwner += ".";
            }

        }

        #endregion

        #region Properties

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        public string ProviderPath
        {
            get
            {
                return _providerPath;
            }
        }

        public string ObjectQualifier
        {
            get
            {
                return _objectQualifier;
            }
        }

        public string DatabaseOwner
        {
            get
            {
                return _databaseOwner;
            }
        }

        private string NamePrefix
        {
            get { return DatabaseOwner + ObjectQualifier + ModuleQualifier; }
        }



        #endregion

        #region Private Methods

        private static object GetNull(object Field)
        {
            return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value);
        }

        #endregion

        #region Public Methods

        public override int setpr(Resumepr pr)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, NamePrefix + "Addpr",
                new SqlParameter("@nms", pr.nms), new SqlParameter("@fml", pr.fml), new SqlParameter("@fname", pr.fname),
                new SqlParameter("@bday", pr.bday), new SqlParameter("@iid", pr.iid), new SqlParameter("@ms", pr.ms),
                new SqlParameter("@nv", pr.nv), new SqlParameter("@shotele", pr.shotele), new SqlParameter("@emails", pr.emails)
                , new SqlParameter("@address", pr.address)));
        }

        public override int setttable(tozihat tt)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, NamePrefix + "Addtt",
                new SqlParameter("@tozihat", tt.tozih), new SqlParameter("@natijeh", tt.natije)));
        }



        public override int setma(Resumema ma)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, NamePrefix + "Addma",

                new SqlParameter("@mth", ma.mth), new SqlParameter("@rth", ma.rth)
                , new SqlParameter("@grs", ma.grs), new SqlParameter("@mtl", ma.mtl),
                new SqlParameter("@sala", ma.sala),
                new SqlParameter("@mth2", ma.mth2), new SqlParameter("@rth2", ma.rth2), new SqlParameter("@grs2", ma.grs2)
                , new SqlParameter("@mtl2", ma.mtl2), new SqlParameter("@sala2", ma.sala2),
                new SqlParameter("@mth3", ma.mth3), new SqlParameter("@rth3", ma.rth3),
                new SqlParameter("@grs3", ma.grs3), new SqlParameter("@mtl3", ma.mtl3)
                , new SqlParameter("@sala3", ma.sala3)));
        }

        public override int setmk(Resumemk mk)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, NamePrefix + "Addmk"
                , new SqlParameter("@shoghl1", mk.shoghl1), new SqlParameter("@shoro1", mk.shoro1),
                new SqlParameter("@payan1", mk.payan1), new SqlParameter("@mahal1", mk.mahal1),
                new SqlParameter("@elat1", mk.elat1),
                new SqlParameter("@shoghl2", mk.shoghl2), new SqlParameter("@shoro2", mk.shoro2),
                new SqlParameter("@payan2", mk.payan2), new SqlParameter("@mahal2", mk.mahal2),
                new SqlParameter("@elat2", mk.elat2),
                new SqlParameter("@shoghl3", mk.shoghl3), new SqlParameter("@shoro3", mk.shoro3),
                new SqlParameter("@payan3", mk.payan3), new SqlParameter("@mahal3", mk.mahal3),
                new SqlParameter("@elat3", mk.elat3),
                new SqlParameter("@shoghl4", mk.shoghl4), new SqlParameter("@shoro4", mk.shoro4),
                new SqlParameter("@payan4", mk.payan4), new SqlParameter("@mahal4", mk.mahal4),
                new SqlParameter("@elat4", mk.elat4),
                new SqlParameter("@shoghl5", mk.shoghl5), new SqlParameter("@shoro5", mk.shoro5),
                new SqlParameter("@payan5", mk.payan5), new SqlParameter("@mahal5", mk.mahal5),
                new SqlParameter("@elat5", mk.elat5)));
        }

        public override SqlConnection constringcapture()
        {
            SqlConnection constring = (SqlConnection)DataProvider.GetConnection();
            return constring;
        }


        


/**********************************************************************************************/

        public override void set_this_persone_radds(int identification, List<string> personradds)
        {
            for ( int j=0 ; j < personradds.Count ; j++ )
            {
                SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure,NamePrefix+"Addradds",
                    new SqlParameter("@pid",identification),new SqlParameter("@al",personradds[j]));
            }
        }



        public override void set_this_persone_onvs(int personid, List<string> persononvs)
        {
            for (int j = 0; j < persononvs.Count; j++)
            {
                SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, NamePrefix + "Addonvs",
                    new SqlParameter("@pid", personid), new SqlParameter("@ol", persononvs[j]));
            }
        }

/**********************************************************************************************/

        #region getdata (ALL)


        public override DataSet getdataset(int indexnum)
        {
            var ds = new DataSet();

            SqlDataReader mysqlreader = (SqlDataReader)SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, NamePrefix + "getall", new SqlParameter("@pid", indexnum));

            DataTable tablewithindex = new DataTable();
            tablewithindex.Load(mysqlreader);
            ds.Tables.Add(tablewithindex);
            return ds;
        }

        public override DataSet getalldata()
        {
            var ds = new DataSet();
            SqlCommand commander = new SqlCommand();
            commander.CommandText = NamePrefix + "getallrows";
            commander.CommandType = CommandType.StoredProcedure;
            commander.Connection = (SqlConnection)DataProvider.GetConnection();
            var adaptor = new SqlDataAdapter(commander);
            adaptor.Fill(ds);

            return ds;
        }


        public override DataTable getpr(int prpid)
        {
            SqlDataReader mysqldatareader = (SqlDataReader)SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, NamePrefix + "getpr", new SqlParameter("@pid", prpid));
            DataTable prtable = new DataTable();
            prtable.Load(mysqldatareader);

            return prtable;
        }

        public override string getnatijeh(int pid)
        {
            SqlDataReader answer = SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, NamePrefix + "getnatijeh", new SqlParameter("@pid", pid));
            string javab = "";
            if (answer.Read())
                javab = answer.GetString(0) ;
            
            return javab;
        }


        


        public override string gettozihat(int pid)
        {
            SqlDataReader tanswer = SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, NamePrefix + "gettozihat", new SqlParameter("@pid", pid));
            string tozih = "";
            if (tanswer.Read())
                tozih = tanswer.GetString(0);

            return tozih;
        }




        public override DataTable tahsilat(int tpid)
        {
            SqlDataReader tahsilatreader = (SqlDataReader)SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, NamePrefix + "tahsilat", new SqlParameter("@pid", tpid));
            DataTable thtable = new DataTable();
            thtable.Load(tahsilatreader);

            return thtable;
        }

        public override DataTable getradds(int personid)
        {
            SqlDataReader radreader = (SqlDataReader)SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, NamePrefix + "gradds", new SqlParameter("@pid", personid));
            DataTable radtable = new DataTable();
            radtable.Load(radreader);

            return radtable;
        }


        public override DataTable maharat_va_tavanayiha(int onvpid)
        {
            SqlDataReader onvreader = (SqlDataReader)SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, NamePrefix + "gonvs", new SqlParameter("@pid", onvpid));
            DataTable onvtable = new DataTable();
            onvtable.Load(onvreader);

            return onvtable;
        }


        public override DataTable savabeghe_kaari(int spid)
        {
            SqlDataReader savabeghreader = (SqlDataReader)SqlHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, NamePrefix + "savabegh", new SqlParameter("@pid", spid));
            DataTable svtable = new DataTable();
            svtable.Load(savabeghreader);

            return svtable;
        }




        public override void setpic(SqlCommand picommand,int pid)
        {
            string commandstring = "INSERT INTO " + NamePrefix + "pic " + "(picpid,name,contenttype,data) VALUES (@picpid,@Name,@ContentType,@Data)";
            picommand.CommandText = commandstring;

            SqlConnection conn = new SqlConnection(ConnectionString);
            picommand.CommandType = CommandType.Text;
            picommand.Connection = conn;
            conn.Open();
            picommand.ExecuteNonQuery();

        }


        public override int getpic(int picpid)
        {
            int gotit = Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, NamePrefix + "getpic", new SqlParameter("@picpid", picpid)));
            return gotit;
        }



        public override int countpic()
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, NamePrefix + "countpic"));
        }

        public override int countradds(int pid)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, CommandType.StoredProcedure, NamePrefix + "countrad",new SqlParameter("@pid",pid)));
        }


            
        public override void  uppdatepr(Resumepr pr, int pid)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, NamePrefix + "upppr", new SqlParameter("@pid", pid),
                new SqlParameter("@nms", pr.nms), new SqlParameter("@fml", pr.fml), new SqlParameter("@fname", pr.fname),
                new SqlParameter("@bday", pr.bday), new SqlParameter("@iid", pr.iid), new SqlParameter("@ms", pr.ms),
                new SqlParameter("@nv", pr.nv), new SqlParameter("@shotele", pr.shotele), new SqlParameter("@emails", pr.emails)
                , new SqlParameter("@address", pr.address));
        }

        public override void uppmkboth(string toz, string nat, int pid)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, NamePrefix + "uppmkboth", new SqlParameter("@pid", pid),
                new SqlParameter("@tozihat", toz), new SqlParameter("@natijeh",nat));
        }
        

        public override void uppdatema(Resumema ma, int pid)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, NamePrefix + "uppma",new SqlParameter("@pid",pid),
                new SqlParameter("@mth", ma.mth), new SqlParameter("@rth", ma.rth)
                , new SqlParameter("@grs", ma.grs), new SqlParameter("@mtl", ma.mtl),
                new SqlParameter("@sala", ma.sala),
                new SqlParameter("@mth2", ma.mth2), new SqlParameter("@rth2", ma.rth2), new SqlParameter("@grs2", ma.grs2)
                , new SqlParameter("@mtl2", ma.mtl2), new SqlParameter("@sala2", ma.sala2),
                new SqlParameter("@mth3", ma.mth3), new SqlParameter("@rth3", ma.rth3),
                new SqlParameter("@grs3", ma.grs3), new SqlParameter("@mtl3", ma.mtl3)
                , new SqlParameter("@sala3", ma.sala3));
        }

       

        public override void uppdatemk(Resumemk mk, int pid)
        {
            string tozihat = "";
            string natije = "";
            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, NamePrefix + "uppmk",new SqlParameter("@pid",pid),
                new SqlParameter("@shoghl1", mk.shoghl1), new SqlParameter("@shoro1", mk.shoro1),
                new SqlParameter("@payan1", mk.payan1), new SqlParameter("@mahal1", mk.mahal1),
                new SqlParameter("@elat1", mk.elat1),
                new SqlParameter("@shoghl2", mk.shoghl2), new SqlParameter("@shoro2", mk.shoro2),
                new SqlParameter("@payan2", mk.payan2), new SqlParameter("@mahal2", mk.mahal2),
                new SqlParameter("@elat2", mk.elat2),
                new SqlParameter("@shoghl3", mk.shoghl3), new SqlParameter("@shoro3", mk.shoro3),
                new SqlParameter("@payan3", mk.payan3), new SqlParameter("@mahal3", mk.mahal3),
                new SqlParameter("@elat3", mk.elat3),
                new SqlParameter("@shoghl4", mk.shoghl4), new SqlParameter("@shoro4", mk.shoro4),
                new SqlParameter("@payan4", mk.payan4), new SqlParameter("@mahal4", mk.mahal4),
                new SqlParameter("@elat4", mk.elat4),
                new SqlParameter("@shoghl5", mk.shoghl5), new SqlParameter("@shoro5", mk.shoro5),
                new SqlParameter("@payan5", mk.payan5), new SqlParameter("@mahal5", mk.mahal5),
                new SqlParameter("@elat5", mk.elat5));
        }


        public override void uppnatijeh(string natije, int pid)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, NamePrefix + "uppmknatijeh",
                new SqlParameter("@pid", pid), new SqlParameter("@natijeh", natije));
        }



        public override void upptozihat(string toziha, int pid)
        {
            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, NamePrefix + "uppmktozihat",
                new SqlParameter("@pid", pid), new SqlParameter("@tozihat", toziha));
        }
        

        public override void drop_pics(int pid)
        {

            string dro = "drop from " + NamePrefix + "pic where pid=" + pid;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand dropic = new SqlCommand(dro, conn);
            dropic.ExecuteNonQuery();
            conn.Close();

        }


        #endregion



        #endregion ( PUBLIC METHODS )

    }

            

}

