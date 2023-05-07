using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Modules.FaavanResume1.Components;
using DotNetNuke.Modules.FaavanResume1.Data;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security;

namespace DotNetNuke.Modules.FaavanResume1
{
    public partial class ThirdPage : FaavanResume1ModuleBase
    {
        int num = 0;

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
            if (ishnum) { bool green = true; }
            else if (istnum) { bool green = false; }
          
        }

        protected void thproof_Click(object sender, EventArgs e)
        {
            var r = new Resumemk
            {
               shoghl1 = shoghl1.Text.Trim(),
               shoghl2 = shoghl2.Text.Trim(),
               shoghl3 = shoghl3.Text.Trim(),
               shoghl4 = shoghl4.Text.Trim(),
               shoghl5 = shoghl5.Text.Trim(),
               shoro1 = shoro1.Text.Trim(),
               shoro2 = shoro2.Text.Trim(),
               shoro3 = shoro3.Text.Trim(),
               shoro4 = shoro4.Text.Trim(),
               shoro5 = shoro5.Text.Trim(),
               payan1 = payan1.Text.Trim(),
               payan2 = payan2.Text.Trim(),
               payan3 = payan3.Text.Trim(),
               payan4 = payan4.Text.Trim(),
               payan5 = payan5.Text.Trim(),
               mahal1 = mahal1.Text.Trim(),
               mahal2 = mahal2.Text.Trim(),
               mahal3 = mahal3.Text.Trim(),
               mahal4 = mahal4.Text.Trim(),
               mahal5 = mahal5.Text.Trim(),
               elat1 = elat1.Text.Trim(),
               elat2 = elat2.Text.Trim(),
               elat3 = elat3.Text.Trim(),
               elat4 = elat4.Text.Trim(),
               elat5 = elat5.Text.Trim()

            };

            DataProvider.Instance().uppdatemk(r, num);
            string fort = tozihattt.Text.Trim();
            if (fort != "در صورتی که توضیحات اضافه ای دارید . در این قسمت وارد کنید" & fort != "")
            {
                DataProvider.Instance().uppmkboth(fort, ".", num);
            }
            else
            {
                DataProvider.Instance().uppmkboth("کاربر توضیحات اضافه ای ننوشته", ".", num);
            }

            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "Info", "parameter=" + num.ToString(), "mid=" + ModuleId.ToString()));
        }
    }
}