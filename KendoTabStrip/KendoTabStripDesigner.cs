using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;

[assembly: WebResource(RandomSiteControls.KendoTabStrip.KendoTabStripDesigner.scriptReference, "application/x-javascript")]
namespace RandomSiteControls.KendoTabStrip
{
    /// <summary>
	/// Represents a designer for the <typeparamref name="RandomSiteControls.KendoTabStrip.KendoTabStrip"/> widget
    /// </summary>
    public class KendoTabStripDesigner : ControlDesignerBase
    {

        #region Properties
        /// <summary>
        /// Gets the layout template path
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                return KendoTabStripDesigner.layoutTemplatePath;
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
        #endregion

        #region Control references
			
		/// <summary>
		/// Gets the control that is bound to the Message property
		/// </summary>
		protected virtual Control Message
		{
			get
			{
				return this.Container.GetControl<Control>("Message", true);
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

            descriptor.AddElementProperty("message", this.Message.ClientID);
            
            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(KendoTabStripDesigner.scriptReference, typeof(KendoTabStripDesigner).Assembly.FullName));
            return scripts;
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/SitefinitySteve/RandomSiteControls.KendoTabStrip.Views.KendoTabStripDesigner.ascx";
        public const string scriptReference = "RandomSiteControls.KendoTabStrip.Resources.KendoTabStripDesigner.js";
        #endregion
    }
}
 
