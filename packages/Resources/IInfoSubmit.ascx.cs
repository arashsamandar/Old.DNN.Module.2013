using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Modules.FaavanResume1.Components;
using System.Data.SqlClient;
using DotNetNuke.Modules.FaavanResume1.Data;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security;
using DotNetNuke.Common;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DotNetNuke.Modules.FaavanResume1
{
    public partial class IInfoSubmit : FaavanResume1ModuleBase
    {
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                Actions.Add(GetNextActionID(), Localization.GetString("EditModule", this.LocalResourceFile), "", "", "", EditUrl(), false, SecurityAccessLevel.Edit, true, false);
                return Actions;
            }
        }

        int num;
        protected void Page_Load(object sender, EventArgs e)
        {
            var mmn = this.Request.Url;
            string recordnum = mmn.ToString();
            string recparams = "meter=";
            int mahalstr = recordnum.IndexOf(recparams, 0, StringComparison.Ordinal);
            string mh1 = (recordnum[mahalstr + 6].ToString() + recordnum[mahalstr + 7].ToString()).ToString();
            string mh2 = recordnum[mahalstr + 6].ToString();
            
            bool ishnum = int.TryParse(mh1, out num);
            bool istnum = int.TryParse(mh2, out num);
            if (ishnum) { num = Convert.ToInt32(mh1); }
            else if (istnum) { num = Convert.ToInt32(mh2); }

            if(!string.IsNullOrEmpty(DataProvider.Instance().getnatijeh(num)) & DataProvider.Instance().getnatijeh(num) != ".")
            natije.Text = DataProvider.Instance().getnatijeh(num);


            DataTable pr = DataProvider.Instance().getpr(num);
            DataTable th = DataProvider.Instance().tahsilat(num);
            DataTable sabeghe = DataProvider.Instance().savabeghe_kaari(num);
            DataTable alaghe = DataProvider.Instance().getradds(num);
            DataTable maharatha = DataProvider.Instance().maharat_va_tavanayiha(num);


            GridView1.DataSource = pr;
            GridView1.DataBind();

            grid3.DataSource = alaghe;
            grid3.DataBind();


            for (int j = 0; j < th.Columns.Count; j++)
            {
                if (string.IsNullOrEmpty(th.Rows[0][j].ToString()) || th.Rows[0][j] == DBNull.Value)
                    th.Columns.Remove(th.Columns[j].ColumnName.ToString());

            }


            grid2.DataSource = th;
            grid2.DataBind();



            maharat.DataSource = maharatha;
            maharat.DataBind();




            for (int d = 0; d < sabeghe.Columns.Count; d++)
            {
                if (string.IsNullOrEmpty(sabeghe.Rows[0][d].ToString()) || sabeghe.Rows[0][d] == DBNull.Value)
                    sabeghe.Columns.Remove(sabeghe.Columns[d].ColumnName.ToString());

            }


            savabeghkari.DataSource = sabeghe;
            savabeghkari.DataBind();
            
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL(), true);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void grid3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid3.PageIndex = e.NewPageIndex;
            grid3.DataBind();
            
        }

    }
}