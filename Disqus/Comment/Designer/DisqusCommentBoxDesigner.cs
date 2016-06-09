using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;
[assembly: WebResource(RandomSiteControls.Disqus.Comment.Designer.DisqusCommentBoxDesigner.scriptReference, "application/x-javascript")]
namespace RandomSiteControls.Disqus.Comment.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="RandomSiteControls.Disqus.Comment.DisqusCommentBox"/> widget
    /// </summary>
    public class DisqusCommentBoxDesigner : ControlDesignerBase
    {
        #region Properties
        /// <summary>
        /// Gets the layout template path
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Gets the layout template name
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return DisqusCommentBoxDesigner.layoutTemplatePath;
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
        /// <summary>
        /// Gets the control that is bound to the Message property
        /// </summary>
        /*protected virtual Control Message
        {
            get
            {
                return this.Container.GetControl<Control>("Message", true);
            }
        }
        */
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

            //descriptor.AddElementProperty("message", this.Message.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(DisqusCommentBoxDesigner.scriptReference, typeof(DisqusCommentBoxDesigner).Assembly.FullName));
            return scripts;
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = "RandomSiteControls.Disqus.Comment.Designer.DisqusCommentBoxDesigner.ascx";
        public const string scriptReference = "RandomSiteControls.Disqus.Comment.Designer.DisqusCommentBoxDesigner.js";
        #endregion
    }
}
 