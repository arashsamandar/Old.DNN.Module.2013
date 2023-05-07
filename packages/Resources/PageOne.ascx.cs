using System;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Modules.FaavanResume1.Data;
using System.Data.SqlClient;
using DotNetNuke.Modules.FaavanResume1.Components;
using System.Data;
using System.Xml;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.IO;
using DotNetNuke.Modules.FaavanResume1;

namespace DotNetNuke.Modules.FaavanResume1
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The EditFaavanResume1 class is used to manage content
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class LoginSignIn : FaavanResume1ModuleBase
    {

        
        #region versatile VARIABLES
        
        
        //public static DataSet userlogin = DataProvider.Instance().getdataset();
        int num = 0;
        Resumepr r = new Resumepr();
        
        #endregion


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

        private void Page_Load(object sender, System.EventArgs e)
        {
            
            try
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
                r.nv = "خانم";
            }

            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void btget_Click(object sender, EventArgs e)
        {

                r.nms = nms.Text.Trim();
                r.fml = fml.Text.Trim();
                r.fname = fname.Text.Trim();
                r.bday = bday.Text.Trim();
                r.iid = iid.Text.Trim();
                r.ms = ms.Text.Trim();
                r.shotele = shotele.Text.Trim();
                r.emails = emails.Text.Trim();
                r.address = address.Text.Trim();

                bool flag = false;

                if (IsValidEmail(emails.Text.Trim()))
                {
                    DataSet userlogin = DataProvider.Instance().getalldata();
                    string useremail = emails.Text.Trim();
                    string datacheckemail = userlogin.Tables[0].Rows[0].ItemArray[8].ToString();

                    int rowcounter = userlogin.Tables[0].Rows.Count;
                    for (int k = 0; k <= (rowcounter - 1); k++)
                    {
                        if (useremail == userlogin.Tables[0].Rows[k].ItemArray[8].ToString())
                        {
                            flag = true;
                            break;
                        }

                    }

                }


                if (flag)
                {
                    emails.ForeColor = System.Drawing.Color.Red;
                    emails.Text = "این ایمیل قبلا ثبت شده . اگر قبلا رزومه فرستاده اید برای مشاهده ی نتیجه از صفحه ی اول و تایپ ایمیل و سپس زدن کلیک ورود نتیجه ی رزومه ی خود را ببینید";
                }



            


            if (IsValidEmail(emails.Text.Trim()) & flag==false & (nms.Text.Trim() != "" & fml.Text.Trim() != "" & fname.Text.Trim() != "" & bday.Text.Trim() != ""
                 & ms.Text.Trim() != "" & nv.Text.Trim() != "" & shotele.Text.Trim() != ""
                & address.Text.Trim() != ""))
            {

                DataProvider.Instance().uppdatepr(r,num);
                Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "SecondPage", "parameter=" + num.ToString() , "mid=" + ModuleId.ToString()));
            }
            else
            {
                
                if (IsValidEmail(emails.Text.Trim()) == false)
                {
                    emailscontrol.Visible = true;
                    emailsbuttom.Visible = true;
                    
                }
                else { emailsbuttom.Visible = false; emailscontrol.Visible = false; }
                if (nms.Text.Trim() == "" || fml.Text.Trim() == "" || fname.Text.Trim() == "" || bday.Text.Trim() == ""
                    || iid.Text.Trim() == "" || ms.Text.Trim() == "" || nv.Text.Trim() == "")
                {
                    warecontrol.Visible = true;
                
                }
                else { warecontrol.Visible = false; }

                





            }



           }//end of btget_click

        









        protected void bpictup_Click(object sender, EventArgs e)
        {
            
            // Read the file and convert it to Byte Array

            string filePath = picup.PostedFile.FileName;

            string filename = Path.GetFileName(filePath);

            string ext = Path.GetExtension(filename);

            string contenttype = String.Empty;

            int sizeofpic = picup.PostedFile.ContentLength;


            //Set the contenttype based on File Extension

            switch (ext)
            {
                case ".bmp":

                    contenttype = "image/bmp";

                    break;

                case ".jpg":

                    contenttype = "image/jpg";

                    break;

                case ".png":

                    contenttype = "image/png";

                    break;

                

            }// End Of Switch Command


            if (contenttype != String.Empty && sizeofpic <= 716800)
            {

                Stream fs = picup.PostedFile.InputStream;

                BinaryReader br = new BinaryReader(fs);

                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                //vaared kardne tasvir dar SQL DATABASE

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;

                cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype;

                cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;

                if (DataProvider.Instance().countpic() == num)
                {
                    DataProvider.Instance().drop_pics(num);
                }
                
                DataProvider.Instance().setpic(cmd,num);

                int goodjobarash = DataProvider.Instance().countpic();

                imgPreview.ImageUrl = "AHandler.ashx?imgID=" + goodjobarash.ToString();

                imgPreview.Visible = true;

                bpictup.Enabled = false;
                

            }
           /* else
            {
                this.lpicup.Font.Underline = false;
                lpicup.Text = "هیچ فایلی انتخاب نشده و یا فرمت عکس مناسب نیست ، دقت کنید که فایل انتخاب شده عکسی ستونی و کمتر از 700 کیلوبایت باشد";
                
            }*/
            
            
        }

        protected void nv_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (nv.SelectedValue)
            {
                case "1": r.nv = "خانم";
                    break;

                case "2": r.nv = "معاف از خدمت کفالت";
                    break;

                case "3": r.nv = "معاف از خدمت دانشجویی";
                    break;

                case "4": r.nv = "معاف از خدمت - پزشکی";
                    break;

                case "5": r.nv = "مشغول خدمت و یا سایر موارد";
                    break;

            }

         }
    

        
    }

        #endregion

}