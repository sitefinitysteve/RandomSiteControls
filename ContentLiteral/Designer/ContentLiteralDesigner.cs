using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;
using Telerik.Sitefinity.Web.Configuration;

[assembly: WebResource(RandomSiteControls.ContentLiteral.Designer.ContentLiteralDesigner.scriptReference, "application/x-javascript")]
namespace RandomSiteControls.ContentLiteral.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="RandomSiteControls.LiteralMarkup.ContentLiteral"/> widget
    /// </summary>
    public class ContentLiteralDesigner : ControlDesignerBase
    {
        #region Properties
        /// <summary>
        /// Gets the layout template path
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                return ContentLiteralDesigner.layoutTemplatePath;
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
            scripts.Add(new ScriptReference(ContentLiteralDesigner.scriptReference, typeof(ContentLiteralDesigner).Assembly.FullName));

            scripts.Add(new ScriptReference("Telerik.Sitefinity.Resources.Scripts.CodeMirror.codemirror.js", Config.Get<ControlsConfig>().ResourcesAssemblyInfo.Assembly.GetName().Name));
            scripts.Add(new ScriptReference("Telerik.Sitefinity.Resources.Scripts.CodeMirror.Mode.htmlmixed.js", Config.Get<ControlsConfig>().ResourcesAssemblyInfo.Assembly.GetName().Name));
            scripts.Add(new ScriptReference("Telerik.Sitefinity.Resources.Scripts.CodeMirror.Mode.xml.js", Config.Get<ControlsConfig>().ResourcesAssemblyInfo.Assembly.GetName().Name));
            scripts.Add(new ScriptReference("Telerik.Sitefinity.Resources.Scripts.CodeMirror.Mode.css.js", Config.Get<ControlsConfig>().ResourcesAssemblyInfo.Assembly.GetName().Name));
            scripts.Add(new ScriptReference("Telerik.Sitefinity.Resources.Scripts.CodeMirror.Mode.javascript.js", Config.Get<ControlsConfig>().ResourcesAssemblyInfo.Assembly.GetName().Name));


            return scripts;
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/SitefinitySteve/RandomSiteControls.ContentLiteral.Designer.ContentLiteralDesigner.ascx";
        public const string scriptReference = "RandomSiteControls.ContentLiteral.Designer.ContentLiteralDesigner.js";
        #endregion
    }
}
 
