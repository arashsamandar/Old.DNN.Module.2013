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
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Modules.FaavanResume1.Data;
using System.Data.SqlClient;
using DotNetNuke.Modules.FaavanResume1.Components;
using System.Data;
using System.Xml;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace DotNetNuke.Modules.FaavanResume1
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The EditFaavanResume1 class is used to manage content
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Edit : FaavanResume1ModuleBase
    {

        class variables
        {
            public static int ii;
            
        }
        int counter = 0;
        #region Event Handlers

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
        ///

        private void Page_Load(object sender, System.EventArgs e)
        {
            
            try
            {

                //in kaar ro kardam , ke faghat ye baar page load anjaam beshe va betoonam indexChange haam ro bebinam
                if (!IsPostBack)
                {
                    DataSet aras = DataProvider.Instance().getalldata();
                    aras.Tables[0].Columns.Add("nameandfamily", typeof(string), "' ' + nms + ' ' + fml + ' ' + ' | ' + nv + ' '");
                    ddl.DataSource = aras.Tables[0].DefaultView;
                    ddl.DataTextField = "nameandfamily";
                    ddl.DataBind();
                    ListItem item = new ListItem("یک نام را انتخاب کنید", "-1");
                    ddl.Items.Insert(0, item);
                    natijeh.Visible = false;
                    nnatijeh.Visible = false;
                    tozihhat.Visible = false;
                    imgPreview.Visible = false;
                } 

            }

            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }

        }

        

        #endregion
        
        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            natijeh.Visible = true;
            nnatijeh.Visible = true;
            imgPreview.Visible = true;
            imgPreview.ImageUrl = "AHandler.ashx?imgID=99" ;
            ddl.AutoPostBack = true;
            DataSet aras = DataProvider.Instance().getalldata();
            counter = ddl.SelectedIndex;
            number.Text = counter.ToString();

            if (!string.IsNullOrEmpty(DataProvider.Instance().getnatijeh(counter)))
                natijeh.Text = DataProvider.Instance().getnatijeh(counter);
            else natijeh.Text = "";

            if (!string.IsNullOrEmpty(DataProvider.Instance().gettozihat(counter)))
            {tozihhat.Visible = true;tozihhat.Text = DataProvider.Instance().gettozihat(counter);}
            else {tozihhat.Text="";tozihhat.Visible=false;}

            GridView1.DataSource = DataProvider.Instance().getpr(counter);
            GridView1.DataBind();

            if (DataProvider.Instance().getpic(counter) != 0)
            {
                imgPreview.ImageUrl = "AHandler.ashx?imgID=" + DataProvider.Instance().getpic(counter).ToString();
            }

            DataTable th = DataProvider.Instance().tahsilat(counter);

            for (int j = 0; j < th.Columns.Count; j++)
            {
                if (string.IsNullOrEmpty(th.Rows[0][j].ToString()) || th.Rows[0][j] == DBNull.Value)
                    th.Columns.Remove(th.Columns[j].ColumnName.ToString());

            }


            grid2.DataSource = th;
            grid2.DataBind();

            grid3.DataSource = DataProvider.Instance().getradds(counter);
            grid3.DataBind();


            maharat.DataSource = DataProvider.Instance().maharat_va_tavanayiha(counter);
            maharat.DataBind();


            DataTable savabeghe = DataProvider.Instance().savabeghe_kaari(counter);

            for (int k = 0; k < savabeghe.Columns.Count; k++)
            {
                if (string.IsNullOrEmpty(savabeghe.Rows[0][k].ToString()) || savabeghe.Rows[0][k] == DBNull.Value)
                    savabeghe.Columns.Remove(savabeghe.Columns[k].ColumnName.ToString());

            }

            savabeghkari.DataSource = savabeghe;
            savabeghkari.DataBind();

             
        }

        protected void grid3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid3.PageIndex = e.NewPageIndex;
            grid3.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void nnatijeh_Click(object sender, EventArgs e)
        {
            string nm = number.Text.Trim();
            int pidnum = Convert.ToInt32(nm);
            string natijjeh = natijeh.Text.ToString();
            DataProvider.Instance().uppnatijeh(natijjeh,pidnum);
        }


    }

}