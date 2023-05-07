using System;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security;
using System.Data;
using DotNetNuke.Modules.FaavanResume1.Data;
using DotNetNuke.Modules.FaavanResume1.Components;
using System.Text.RegularExpressions;
using System.Globalization;
using DotNetNuke.Common;
using System.Collections.Generic;

namespace DotNetNuke.Modules.FaavanResume1
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The ViewFaavanResume1 class displays the content
    /// </summary>
    /// -----------------------------------------------------------------------------
    /// 
    public partial class View : FaavanResume1ModuleBase, IActionable
    {

        #region Event Handlers

        public static DataSet userlogin = DataProvider.Instance().getdataset(1);

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Page_Load runs when the control is loaded
        /// </summary>
        /// -----------------------------------------------------------------------------
        private void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                showstringcon.Text = DotNetNuke.Data.DataProvider.Instance().ConnectionString;
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
                
            }
        }

        #endregion

        #region Optional Interfaces

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

 

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //List<string> ar = new List<string>();
            //ar[0] = "ARASH";
            Resumepr pr = new Resumepr();
            pr.pid = DataProvider.Instance().setpr(pr);
            Resumema ma = new Resumema();

            DataProvider.Instance().setma(ma);
            //DataProvider.Instance().set_this_persone_radds(pr.pid, ar);

            Resumemk mk = new Resumemk();
            DataProvider.Instance().setmk(mk);

            tozihat ttabl = new tozihat();
            DataProvider.Instance().setttable(ttabl);
            
            
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "PageOne", "parameter=" + pr.pid.ToString(), "mid=" + ModuleId.ToString()));
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(ueamil.Text.Trim()))
            {
                DataSet userlogin = DataProvider.Instance().getalldata();
                string useremail = ueamil.Text.Trim();
                string datacheckemail = userlogin.Tables[0].Rows[0].ItemArray[8].ToString();
                
                    int rowcounter = userlogin.Tables[0].Rows.Count;
                    for (int k = 0; k <= (rowcounter - 1); k++)
                    {
                        if (
                        useremail == userlogin.Tables[0].Rows[k].ItemArray[8].ToString())
                        {
                            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "Info", "parameter=" + (k + 1).ToString(), "mid=" + ModuleId.ToString()));
                            break;
                        }
                        
                    }
                        
            }
            else { invalidemail.Visible = true;}

            checkusername.Text = "چنین ایمیلی ثبت نشده ، دوباره سعی کنید ، یا از ثبت نام رزومه جدید استفاده کنید";
            
        }




    }

}
        
