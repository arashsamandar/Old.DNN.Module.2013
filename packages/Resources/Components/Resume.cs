using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Modules.FaavanResume1.Data;
using DotNetNuke.Modules.FaavanResume1.Components;

namespace DotNetNuke.Modules.FaavanResume1.Components
{


    public class tozihat
    {
        public int pid { get; set; }
        public string tozih { get; set; }
        public string natije { get; set; }
    }




    public class Resumepr
    {
        
        public int pid { get; set; }
        public string nms { get; set; }
        public string fml { get; set; }
        public string fname { get; set; }
        public string bday { get; set; }
        public string iid { get; set; }
        public string ms { get; set; }
        public string nv { get; set; }
        public string shotele { get; set; }
        public string emails { get; set; }
        public string address { get; set; }
        
    }
    
    public class Resumema
    {

        
        public int pid { get; set; }
        public string mth { get; set; }
        public string rth { get; set; }
        public string grs { get; set; }
        public string mtl { get; set; }
        public string sala { get; set; }
        public string mth2 { get; set; }
        public string rth2 { get; set; }
        public string grs2 { get; set; }
        public string mtl2 { get; set; }
        public string sala2 { get; set; }
        public string mth3 { get; set; }
        public string rth3 { get; set; }
        public string grs3 { get; set; }
        public string mtl3 { get; set; }
        public string sala3 { get; set; }
}

    public class Resumemk
    {

        public int pid { get; set; }
        public string shoghl2 { get; set; }
        public string shoro2 { get; set; }
        public string payan2 { get; set; }
        public string mahal2 { get; set; }
        public string elat2 { get; set; }

        public string shoghl3 { get; set; }
        public string shoro3 { get; set; }
        public string payan3 { get; set; }
        public string mahal3 { get; set; }
        public string elat3 { get; set; }

        public string shoghl4 { get; set; }
        public string shoro4 { get; set; }
        public string payan4 { get; set; }
        public string mahal4 { get; set; }
        public string elat4 { get; set; }

        public string shoghl5 { get; set; }
        public string shoro5 { get; set; }
        public string payan5 { get; set; }
        public string mahal5 { get; set; }
        public string elat5 { get; set; }

        public string shoghl1 { get; set; }
        public string shoro1 { get; set; }
        public string payan1 { get; set; }
        public string mahal1 { get; set; }
        public string elat1 { get; set; }

    }



}