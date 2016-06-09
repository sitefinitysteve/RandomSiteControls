using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Web.UI;
using System.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data.Configuration;
using System.Diagnostics;
using RandomSiteControls.Common;

namespace RandomSiteControls.PageData {
    /// <summary>
    /// The control designer class for the Rotator widget
    /// </summary>
    public class PageDataDesigner : SteveControlDesignerBase {
        /// <summary>
        /// Gets the name of the embedded layout template.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// Override this property to change the embedded template to be used with the dialog
        /// </remarks>
        protected override string LayoutTemplateName {
            get {
                //return "RandomSiteControls.PageData.Views.PageDataDesigner.ascx";
                return null;
            }
        }

        public override string LayoutTemplatePath {
            get {
                var path = "~/RandomSiteControls/RandomSiteControls.PageData.Views.PageDataDesigner.ascx";
                return path;
            }
            set {
                base.LayoutTemplatePath = value;
            }
        }

        /// <summary>
        /// Gets a type from the resource assembly.
        /// Resource assembly is an assembly that contains embedded resources such as templates, images, CSS files and etc.
        /// By default this is Telerik.Sitefinity.Resources.dll.
        /// </summary>
        /// <value>The resources assembly info.</value>
        protected override Type ResourcesAssemblyInfo {
            get {
                return this.GetType();
            }
        }


        /// <summary>
        /// Initializes the controls.
        /// </summary>
        /// <param name="container">The control container.</param>
        /// <remarks>
        /// Initialize your controls in this method. Do not override CreateChildControls method.
        /// </remarks>
        protected override void InitializeControls(GenericContainer container) {
            base.InitializeControls(container);
            this.DesignerMode = ControlDesignerModes.Simple;

        }
        
        public override IEnumerable<ScriptReference> GetScriptReferences() {
            var res = new List<ScriptReference>(base.GetScriptReferences());
            var assemblyName = this.GetType().Assembly.GetName().ToString();
            res.Add(new ScriptReference("RandomSiteControls.PageData.Resources.PageDataDesigner.js", assemblyName));
            return res.ToArray();
        }

        #region ControlReferences
        //protected virtual Label debugLabel {
        //    get {
        //        return this.Container.GetControl<Label>("debugLabel", true);
        //    }
        //}


        #endregion
    }
}
