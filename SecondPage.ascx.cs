using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security;
using DotNetNuke.Modules.FaavanResume1.Components;
using DotNetNuke.Modules.FaavanResume1.Data;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;

namespace DotNetNuke.Modules.FaavanResume1
{

    

    public partial class SecondPage : FaavanResume1ModuleBase
    {


        #region OnInit(eventartgs e)

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        #endregion


        #region initializecomponent()

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }

        #endregion


        #region moduleactioncollection

        public ModuleActionCollection ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                Actions.Add(GetNextActionID(), Localization.GetString("EditModule", this.LocalResourceFile), "", "", "", EditUrl(), false, SecurityAccessLevel.Edit, true, false);
                return Actions;
            }
        }

        #endregion


        #region Page_Load

        int num = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
  
            
            var mmn = this.Request.Url;
            string recordnum = mmn.ToString();
            string recparams = "meter=";
            int mahalstr = recordnum.IndexOf(recparams, 0, StringComparison.Ordinal);
            string mh1 = (recordnum[mahalstr + 6].ToString() + recordnum[mahalstr + 7].ToString()).ToString();
            string mh2 = recordnum[mahalstr + 6].ToString();
            bool ishnum = int.TryParse(mh1,out num);
            bool istnum = int.TryParse(mh2, out num);
            if (ishnum) { num = Convert.ToInt32(mh1); }
            else if (istnum) { num = Convert.ToInt32(mh2); }
            

        }

        #endregion


        #region تایید


        protected void stepproof_Click(object sender, EventArgs e)
        {
                

                if ( mth.Text != "" & mtl.Text != "" & sala.Text != "" & grs.Text != "" & rth.Text != "")
                {
                    UpdateDataSource(false);
                    List<string> datas = GetDataSource();
                    datas.Insert(0, rad1.Text.Trim());

                    UpdateDataSource2(false);
                    List<string> onvss = GetDataSource2();
                    onvss.Insert(0, onv1.Text.Trim());

                    Resumema mm = new Resumema
                    {
                        
                        mth = mth.Text.Trim(),
                        mtl = mtl.Text.Trim(),
                        rth = rth.Text.Trim(),
                        rth2 = rth2.Text.Trim(),
                        rth3 = rth3.Text.Trim(),
                        grs = grs.Text.Trim(),
                        sala = sala.Text.Trim(),
                        mth2 = mth2.Text.Trim(),
                        mtl2 = mtl2.Text.Trim(),
                        grs2 = grs2.Text.Trim(),
                        sala2 = sala2.Text.Trim(),
                        mth3 = mth3.Text.Trim(),
                        mtl3 = mtl3.Text.Trim(),
                        grs3 = grs3.Text.Trim(),
                        sala3 = sala3.Text.Trim()

                    };



                    

                    DataProvider.Instance().uppdatema(mm, num);

                    DataProvider.Instance().set_this_persone_radds(num, datas);

                    DataProvider.Instance().set_this_persone_onvs(num, onvss);



                Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "ThirdPage", "parameter=" + num.ToString(), "mid=" + ModuleId.ToString()));

            }

            else if ( string.IsNullOrEmpty(rad1.Text.Trim()) )
            {
                radware.Visible = true;
                lrad.Visible = true;
                tware.Visible = false;
            }
            else if ( string.IsNullOrEmpty(onv1.Text.Trim()))
             {
                 Label2.Visible = true;
                 lonv.Visible = true;
                 tware.Visible = false;
             }
            else
            {
                
                tware.Visible = true;
            }

        
        }
            
        #endregion

       
        private void BindListView()
        {
            List<string> dataSource = this.GetDataSource();

            this.lvDynamicTextboxes.DataSource = dataSource;
            this.lvDynamicTextboxes.DataBind();
        }
/****************************************************************************************/

        private List<string> GetDataSource()
        {
            List<string> dataSource = null;

            if (ViewState["DataSource"] != null) // baraye inke etela'aat ro Page-PostBack az beyn nabare bayad estefade konam ( mohem )
                dataSource = (List<string>)ViewState["DataSource"];
            else
            {
                dataSource = new List<string>();
                dataSource.Add(string.Empty);
                ViewState["DataSource"] = dataSource;
            }
            

            return dataSource;
        }

/****************************************************************************************/
        private void IncrementTextboxCount()
        {
            List<string> dataSource = this.GetDataSource();

            dataSource.Add(string.Empty);
            this.SetDataSource(dataSource);
        }

/****************************************************************************************/

        private void UpdateDataSource(bool delete)
        {
            List<string> dataSource = new List<string>();

            foreach (ListViewItem item in this.lvDynamicTextboxes.Items)
                if (item is ListViewDataItem)
                {
                    TextBox txt = (TextBox)item.FindControl("txtStep");
                    dataSource.Add(txt.Text);
                }
            
            // do khate zir fellan nadide gerefte mishavad . a bug is in the referenced code .

            if (delete)
                dataSource.RemoveRange(dataSource.Count - 1, 1);

            this.SetDataSource(dataSource);
        }

/****************************************************************************************/
        protected void lvDynamicTextboxes_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item is ListViewDataItem)
            {
                TextBox txt = (TextBox)e.Item.FindControl("txtStep");
                txt.Text = ((ListViewDataItem)e.Item).DataItem.ToString();
            }
        }

/****************************************************************************************/
        private void SetDataSource(List<string> dataSource)
        {
            ViewState["DataSource"] = dataSource;
        }

/****************************************************************************************/

        protected void good_Click(object sender, EventArgs e)
        {
            this.UpdateDataSource(false);
            this.IncrementTextboxCount();
            this.BindListView();
        }

/****************************************************************************************/

        /*            ********  MAHARAT HA , MAHARAT HA *********                 */

/****************************************************************************************/


        private void BindListView2()
        {
            List<string> dataSource2 = this.GetDataSource2();
            this.lvdynamictbox.DataSource = dataSource2;
            this.lvdynamictbox.DataBind();
        }
        /****************************************************************************************/

        private List<string> GetDataSource2()
        {
            List<string> dataSource2 = null;

            if (ViewState["DataSource"] != null) // baraye inke etela'aat ro Page-PostBack az beyn nabare bayad estefade konam ( mohem )
                dataSource2 = (List<string>)ViewState["DataSource"];
            else
            {
                dataSource2 = new List<string>();
                dataSource2.Add(string.Empty);
                ViewState["DataSource"] = dataSource2;
            }


            return dataSource2;
        }

        /****************************************************************************************/
        private void IncrementTextboxCount2()
        {
            List<string> dataSource2 = this.GetDataSource2();

            dataSource2.Add(string.Empty);
            this.SetDataSource2(dataSource2);
        }

        /****************************************************************************************/

        private void UpdateDataSource2(bool delete2)
        {
            List<string> dataSource2 = new List<string>();

            foreach (ListViewItem item in this.lvdynamictbox.Items)
                if (item is ListViewDataItem)
                {
                    TextBox txt2 = (TextBox)item.FindControl("txtStep2");
                    dataSource2.Add(txt2.Text);
                }

            // do khate zir fellan nadide gerefte mishavad . a bug is in the referenced code .

            if (delete2)
                dataSource2.RemoveRange(dataSource2.Count - 1, 1);

            this.SetDataSource2(dataSource2);
        }

        /****************************************************************************************/
        protected void lvdynamictbox_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item is ListViewDataItem)
            {
                TextBox txt2 = (TextBox)e.Item.FindControl("txtStep2");
                txt2.Text = ((ListViewDataItem)e.Item).DataItem.ToString();
            }
        }

        /****************************************************************************************/
        private void SetDataSource2(List<string> dataSource)
        {
            ViewState["DataSource"] = dataSource;
        }

        /****************************************************************************************/

        protected void linkbutton2_Click(object sender, EventArgs e)
        {
            this.UpdateDataSource2(false);
            this.IncrementTextboxCount2();
            this.BindListView2();
        }


        
    }
        
}