using System;
using System.Linq;
using RandomSiteControls.Common;

namespace RandomSiteControls.FancyBox {
    public class FancyBoxLayout : SteveLayoutControlBase {
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

        public string CustomTempalate = "~/SitefinitySteve/RandomSiteControls.FancyBox.Views.FancyBoxLayout.ascx";
        #endregion
    }
}
