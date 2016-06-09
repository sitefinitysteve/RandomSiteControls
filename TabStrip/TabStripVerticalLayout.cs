using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Web.UI;
using Telerik.Web.UI;
using System.Web.UI;
using System.Diagnostics;
using System.Web.UI.WebControls;
using RandomSiteControls.Common;

namespace RandomSiteControls.TabStrip {
    public class TabStripVerticalLayout : SteveLayoutControlBase
    {        
        protected override void CreateChildControls() {
            base.CreateChildControls();

            base.CheckToolboxIcon(); 
        }

        public override string AssemblyInfo {
            get {
                return GetType().ToString();
            }
            set { 
                base.AssemblyInfo = value;
            }
        }

        #region TEMPLATE
        public override string Layout {
            get {
                /*return this.CustomTempalate;*/
                var layout = this.ViewState["Layout"] as string;
                if (string.IsNullOrEmpty(layout)) {
                    layout = this.CustomTempalate;
                }
                return layout;
            }
        }

        public string CustomTempalate = "~/SitefinitySteve/RandomSiteControls.TabStrip.Views.TabStripVerticalLayout.ascx";
        #endregion
    }
}
