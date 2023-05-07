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

using System.Collections.Generic;
//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace DotNetNuke.Modules.FaavanResume1.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for FaavanResume1
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IPortable, ISearchable, IUpgradeable
    {


        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        public string ExportModule(int ModuleID)
        {
            //string strXML = "";

            //List<FaavanResume1Info> colFaavanResume1s = GetFaavanResume1s(ModuleID);
            //if (colFaavanResume1s.Count != 0)
            //{
            //    strXML += "<FaavanResume1s>";

            //    foreach (FaavanResume1Info objFaavanResume1 in colFaavanResume1s)
            //    {
            //        strXML += "<FaavanResume1>";
            //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objFaavanResume1.Content) + "</content>";
            //        strXML += "</FaavanResume1>";
            //    }
            //    strXML += "</FaavanResume1s>";
            //}

            //return strXML;

            throw new System.NotImplementedException("The method or operation is not implemented.");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
            //XmlNode xmlFaavanResume1s = DotNetNuke.Common.Globals.GetContent(Content, "FaavanResume1s");
            //foreach (XmlNode xmlFaavanResume1 in xmlFaavanResume1s.SelectNodes("FaavanResume1"))
            //{
            //    FaavanResume1Info objFaavanResume1 = new FaavanResume1Info();
            //    objFaavanResume1.ModuleId = ModuleID;
            //    objFaavanResume1.Content = xmlFaavanResume1.SelectSingleNode("content").InnerText;
            //    objFaavanResume1.CreatedByUser = UserID;
            //    AddFaavanResume1(objFaavanResume1);
            //}

            throw new System.NotImplementedException("The method or operation is not implemented.");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        {
            //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

            //List<FaavanResume1Info> colFaavanResume1s = GetFaavanResume1s(ModInfo.ModuleID);

            //foreach (FaavanResume1Info objFaavanResume1 in colFaavanResume1s)
            //{
            //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objFaavanResume1.Content, objFaavanResume1.CreatedByUser, objFaavanResume1.CreatedDate, ModInfo.ModuleID, objFaavanResume1.ItemId.ToString(), objFaavanResume1.Content, "ItemId=" + objFaavanResume1.ItemId.ToString());
            //    SearchItemCollection.Add(SearchItem);
            //}

            //return SearchItemCollection;

            throw new System.NotImplementedException("The method or operation is not implemented.");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        public string UpgradeModule(string Version)
        {
            throw new System.NotImplementedException("The method or operation is not implemented.");
        }

        #endregion

    }

}
