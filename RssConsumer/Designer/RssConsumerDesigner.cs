using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;

[assembly: WebResource(RandomSiteControls.RssConsumer.Designer.RssConsumerDesigner.scriptReference, "application/x-javascript")]
namespace RandomSiteControls.RssConsumer.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="RandomSiteControls.RssConsumer.RssConsumer"/> widget
    /// </summary>
    public class RssConsumerDesigner : ControlDesignerBase
    {
        #region Properties
        /// <summary>
        /// Obsolete. Use LayoutTemplatePath instead.
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the layout template's relative or virtual path.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    return RssConsumerDesigner.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
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
        /// Gets the control that is bound to the RssFeed property
        /// </summary>
        protected virtual Control RssFeed
        {
            get
            {
                return this.Container.GetControl<Control>("RssFeed", true);
            }
        }



        /// <summary>
        /// Gets the control that is bound to the XPath property
        /// </summary>
        protected virtual Control XPath
        {
            get
            {
                return this.Container.GetControl<Control>("XPath", true);
            }
        }

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

            descriptor.AddElementProperty("rssFeed", this.RssFeed.ClientID);
            descriptor.AddElementProperty("xPath", this.XPath.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(RssConsumerDesigner.scriptReference, typeof(RssConsumerDesigner).Assembly.FullName));
            return scripts;
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/SitefinitySteve/RandomSiteControls.RssConsumer.Designer.RssConsumerDesigner.ascx";
        public const string scriptReference = "RandomSiteControls.RssConsumer.Designer.RssConsumerDesigner.js";
        #endregion
    }
}
 
