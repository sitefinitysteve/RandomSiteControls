using System;
using Telerik.Sitefinity.Modules.Pages.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using RandomSiteControls.Common;

namespace RandomSiteControls.PageData {
    /// <summary>
    /// A control which displays recent news articles in a rotating manner.
    /// </summary>
    [RequireScriptManager]
    [ControlDesigner(typeof(PageDataDesigner)), PropertyEditorTitle("PageData Properties")]
    public class PageData : SteveControlBase
    {
        protected override void InitializeControls(GenericContainer container) {

            this.CheckToolboxIcon();
        }

        protected override string LayoutTemplateName {
            get {
                //return "RandomSiteControls.PageData.Views.PageDataTemplate.ascx";
                return null;
            }
        }

        public override string LayoutTemplatePath {
            get {
                var path = "~/RandomSiteControls/RandomSiteControls.PageData.Views.PageDataTemplate.ascx";
                return path;
            }
            set {
                base.LayoutTemplatePath = value;
            }
        }

        #region PROPERTIES
        

        #endregion

        #region CONTROL DEFINITIONS
        //protected virtual RadPageData PageData {
        //    get {
        //        return this.Container.GetControl<RadPageData>("PageData", true);
        //    }
        //}


        #endregion
    }
}