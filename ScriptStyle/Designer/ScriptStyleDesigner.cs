using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;

[assembly: WebResource(RandomSiteControls.ScriptStyleWidget.Designer.ScriptStyleDesigner.scriptReference, "application/x-javascript")]
namespace RandomSiteControls.ScriptStyleWidget.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="RandomSiteControls.ScriptStyle.ScriptStyle"/> widget
    /// </summary>
    public class ScriptStyleDesigner : ControlDesignerBase
    {
        #region Properties
        /// <summary>
        /// Gets the layout template path
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                return ScriptStyleDesigner.layoutTemplatePath;
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
            scripts.Add(new ScriptReference(ScriptStyleDesigner.scriptReference, typeof(ScriptStyleDesigner).Assembly.FullName));

            scripts.Add(new ScriptReference("Telerik.Sitefinity.Resources.Scripts.CodeMirror.codemirror.js", Config.Get<ControlsConfig>().ResourcesAssemblyInfo.Assembly.GetName().Name));
            scripts.Add(new ScriptReference("Telerik.Sitefinity.Resources.Scripts.CodeMirror.Mode.css.js", Config.Get<ControlsConfig>().ResourcesAssemblyInfo.Assembly.GetName().Name));
            scripts.Add(new ScriptReference("Telerik.Sitefinity.Resources.Scripts.CodeMirror.Mode.javascript.js", Config.Get<ControlsConfig>().ResourcesAssemblyInfo.Assembly.GetName().Name));
            //scripts.Add(new ScriptReference("RandomSiteControls.Common.CodeMirror.closebrackets.js", "RandomSiteControls"));
            //scripts.Add(new ScriptReference("RandomSiteControls.Common.CodeMirror.jshint.js", "RandomSiteControls"));
            //scripts.Add(new ScriptReference("RandomSiteControls.Common.CodeMirror.lint.js", "RandomSiteControls"));
            //scripts.Add(new ScriptReference("RandomSiteControls.Common.CodeMirror.javascript-lint.js", "RandomSiteControls"));

            return scripts;
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/SitefinitySteve/RandomSiteControls.ScriptStyle.Designer.ScriptStyleDesigner.ascx";
        public const string scriptReference = "RandomSiteControls.ScriptStyle.Designer.ScriptStyleDesigner.js";
        #endregion
    }
}
 
