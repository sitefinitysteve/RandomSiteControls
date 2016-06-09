using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;

[assembly: WebResource(RandomSiteControls.Placeholder.Designer.PlaceholderDesigner.scriptReference, "application/x-javascript")]
namespace RandomSiteControls.Placeholder.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="RandomSiteControls.Placeholder.Placeholder"/> widget
    /// </summary>
    public class PlaceholderDesigner : ControlDesignerBase
    {
        #region Properties
        /// <summary>
        /// Gets the layout template path
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                return PlaceholderDesigner.layoutTemplatePath;
            }
        }

        /// <summary>
        /// Gets the layout template name
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return String.Empty;
            }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        #endregion

        #region Control references

        #endregion

        #region Methods
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            // Place your initialization logic here
        }
        #endregion

        #region IScriptControl implementation
        /// <summary>
        /// Gets a collection of script descriptors that represent ECMAScript (JavaScript) client components.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptDescriptor> GetScriptDescriptors()
        {
            var scriptDescriptors = new List<ScriptDescriptor>(base.GetScriptDescriptors());
            var descriptor = (ScriptControlDescriptor)scriptDescriptors.Last();



            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(PlaceholderDesigner.scriptReference, typeof(PlaceholderDesigner).Assembly.FullName));
            return scripts;
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/SitefinitySteve/RandomSiteControls.Placeholder.Designer.PlaceholderDesigner.ascx";
        public const string scriptReference = "RandomSiteControls.Placeholder.Designer.PlaceholderDesigner.js";
        #endregion
    }
}
 
