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

using System.Data;
using System;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Framework.Providers;
using System.Data.SqlClient;
using DotNetNuke.Modules.FaavanResume1.Components;
using System.Xml;
using System.Collections.Generic;


namespace DotNetNuke.Modules.FaavanResume1.Data
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// An abstract class for the data access layer
    /// </summary>
    /// -----------------------------------------------------------------------------
    public abstract class DataProvider
    {

        #region Shared/Static Methods

        private static DataProvider provider;

        // return the provider
        public static DataProvider Instance()
        {
            if (provider == null)
            {
                const string assembly = "DotNetNuke.Modules.FaavanResume1.Data.SqlDataprovider,FaavanResume1";
                Type objectType = Type.GetType(assembly, true, true);

                provider = (DataProvider)Activator.CreateInstance(objectType);
                DataCache.SetCache(objectType.FullName, provider);
            }

            return provider;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Not returning class state information")]
        public static IDbConnection GetConnection()
        {
            const string providerType = "data";
            ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration(providerType);

            Provider objProvider = ((Provider)_providerConfiguration.Providers[_providerConfiguration.DefaultProvider]);
            string _connectionString;
            if (!String.IsNullOrEmpty(objProvider.Attributes["connectionStringName"]) && !String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings[objProvider.Attributes["connectionStringName"]]))
            {
                _connectionString = System.Configuration.ConfigurationManager.AppSettings[objProvider.Attributes["connectionStringName"]];
            }
            else
            {
                _connectionString = objProvider.Attributes["connectionString"];
            }

            IDbConnection newConnection = new System.Data.SqlClient.SqlConnection();
            newConnection.ConnectionString = _connectionString.ToString();
            newConnection.Open();
            return newConnection;
        }

        #endregion

        #region Abstract methods

        

        public abstract SqlConnection constringcapture();

        public abstract int setpr(Resumepr pr);

        public abstract void set_this_persone_radds(int identification, List<string> personradds);

        public abstract void set_this_persone_onvs(int personid, List<string> persononvs);

        public abstract int setmk(Resumemk mk);

        public abstract int setma(Resumema ma);

        public abstract int setttable(tozihat tt);

        public abstract DataSet getdataset(int indexnum);

        public abstract DataSet getalldata();

        public abstract DataTable getpr(int prpid);

        public abstract DataTable maharat_va_tavanayiha(int onvpid);

        public abstract DataTable savabeghe_kaari(int spid);

        public abstract DataTable getradds(int personid);

        public abstract DataTable tahsilat(int tpid);

        public abstract void setpic(SqlCommand picommand,int pid);

        public abstract int getpic(int picpid);

        public abstract int countpic();

        // tavabeyi ke bayad jadid ijaad konam

        public abstract void uppdatepr(Resumepr pr,int pid);

        public abstract void uppdatema(Resumema ma,int pid);

        public abstract void uppdatemk(Resumemk mk,int pid);

        public abstract int countradds(int pid);

        public abstract void drop_pics(int pid);

        public abstract void upptozihat(string toziha,int pid);

        public abstract string gettozihat(int pid);

        public abstract void uppnatijeh(string natije,int pid);

        public abstract string getnatijeh(int pid);

        public abstract void uppmkboth(string toz, string nat, int pid);

            
        #endregion

    }

}