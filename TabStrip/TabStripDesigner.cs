using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using RandomSiteControls.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Web.UI;
using RandomSiteControls.Common;

namespace RandomSiteControls.TabStrip {
    /// <summary>
    /// The control designer class for the Rotator widget
    /// </summary>
    public class TabStripDesigner : SteveControlDesignerBase {
        /// <summary>
        /// Gets the name of the embedded layout template.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// Override this property to change the embedded template to be used with the dialog
        /// </remarks>
        protected override string LayoutTemplateName {
            get {
                //return "RandomSiteControls.TabStrip.Views.TabStripDesigner.ascx";
                return null;
            }
        }

        public override string LayoutTemplatePath {
            get {
                var path = "~/SitefinitySteve/RandomSiteControls.TabStrip.Views.TabStripDesigner.ascx";
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

            #region Skin
            foreach (SkinElement skin in UserConfig.Skins) {
                skinComboBox.Items.Add(new RadComboBoxItem(skin.Name, skin.Name));
            }
            #endregion

        }

        protected override HtmlTextWriterTag TagKey {
            get { //Use div wrapper tag to make easier common styling. This will surround the layout template with a div tag. 
                return HtmlTextWriterTag.Div;
            }
        }

        public override IEnumerable<ScriptReference> GetScriptReferences() {
            var res = new List<ScriptReference>(base.GetScriptReferences());
            var assemblyName = this.GetType().Assembly.GetName().ToString();
            res.Add(new ScriptReference("RandomSiteControls.TabStrip.Resources.TabStripDesigner.js", assemblyName));
            return res.ToArray();
        }

        #region ControlReferences
        protected virtual RadNumericTextBox tabCountTextBox {
            get {
                return this.Container.GetControl<RadNumericTextBox>("tabCountTextBox", true);
            }
        }


        protected virtual RadComboBox skinComboBox {
            get {
                return this.Container.GetControl<RadComboBox>("skinComboBox", true);
            }
        }

        protected virtual RadComboBox tabStripRenderStyleComboBox
        {
            get
            {
                return this.Container.GetControl<RadComboBox>("tabStripRenderStyleComboBox", true);
            }
        }
        #endregion
    }
}
