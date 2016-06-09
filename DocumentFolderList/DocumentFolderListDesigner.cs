using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Web.UI;

[assembly: WebResource(RandomSiteControls.DocumentFolderList.DocumentFolderListDesigner.scriptReference, "application/x-javascript")]
namespace RandomSiteControls.DocumentFolderList
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="RandomSiteControls.DocumentFolderList.DocumentFolderList"/> widget
    /// </summary>
    public class DocumentFolderListDesigner : ControlDesignerBase
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
                    return DocumentFolderListDesigner.layoutTemplatePath;
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
        /// The LinkButton for selecting LibraryId
        /// </summary>
        protected internal virtual LinkButton SelectButtonLibraryId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("selectButtonLibraryId", false);
            }
        }

        /// <summary>
        /// The LinkButton for deselecting LibraryId
        /// </summary>
        protected internal virtual LinkButton DeselectButtonLibraryId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("deselectButtonLibraryId", false);
            }
        }

        /// <summary>
        /// The Flat Selector for LibraryId
        /// </summary>
        protected internal virtual FolderSelector LibraryIdItemSelector
        {
            get
            {
                return this.Container.GetControl<FolderSelector>("LibraryIdItemSelector", false);
            }
        }

        /// <summary>
        /// The LinkButton for "Done"
        /// </summary>
        protected virtual LinkButton DoneButtonLibraryId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("lnkDoneLibraryId", true);
            }
        }

        /// <summary>
        /// The LinkButton for "Cancel"
        /// </summary>
        protected virtual LinkButton CancelButtonLibraryId
        {
            get
            {
                return this.Container.GetControl<LinkButton>("lnkCancelLibraryId", true);
            }
        }

        /// <summary>
        /// The button area control
        /// </summary>
        protected virtual Control ButtonAreaLibraryId
        {
            get
            {
                return this.Container.GetControl<Control>("buttonAreaPanelLibraryId", false);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the FolderImageUrl property
        /// </summary>
        protected virtual Control FolderImageUrl
        {
            get
            {
                return this.Container.GetControl<Control>("FolderImageUrl", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the FolderExpandedImageUrl property
        /// </summary>
        protected virtual Control FolderExpandedImageUrl
        {
            get
            {
                return this.Container.GetControl<Control>("FolderExpandedImageUrl", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the ShowLineImages property
        /// </summary>
        protected virtual Control ShowLineImages
        {
            get
            {
                return this.Container.GetControl<Control>("ShowLineImages", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the IconSize property
        /// </summary>
        protected virtual Control IconSize
        {
            get
            {
                return this.Container.GetControl<Control>("IconSize", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the FilterExpressionForDocuments property
        /// </summary>
        protected virtual Control FilterExpressionForDocuments
        {
            get
            {
                return this.Container.GetControl<Control>("FilterExpressionForDocuments", true);
            }
        }

        /// <summary>
        /// Gets the control that is bound to the Expanded property
        /// </summary>
        protected virtual Control Expanded
        {
            get
            {
                return this.Container.GetControl<Control>("Expanded", true);
            }
        }

        #endregion

        #region Methods
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            // Place your initialization logic here

            if (this.PropertyEditor != null)
            {
                var uiCulture = this.PropertyEditor.PropertyValuesCulture;
                //this.LibraryIdItemSelector.UICulture = uiCulture;
                //this.LibraryIdItemSelector.ConstantFilter = "Visible=true";
            }

            #region Skin
            foreach (string skin in Enum.GetNames(typeof(SkinEnum)))
            {
                skinComboBox.Items.Add(new RadComboBoxItem(skin, skin));
            }
            #endregion
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

            descriptor.AddElementProperty("selectButtonLibraryId", this.SelectButtonLibraryId.ClientID);
            descriptor.AddElementProperty("deselectButtonLibraryId", this.DeselectButtonLibraryId.ClientID);
            descriptor.AddComponentProperty("LibraryIdItemSelector", this.LibraryIdItemSelector.ClientID);
            descriptor.AddElementProperty("lnkDoneLibraryId", this.DoneButtonLibraryId.ClientID);
            descriptor.AddElementProperty("lnkCancelLibraryId", this.CancelButtonLibraryId.ClientID);
            descriptor.AddElementProperty("folderImageUrl", this.FolderImageUrl.ClientID);
            descriptor.AddElementProperty("folderExpandedImageUrl", this.FolderExpandedImageUrl.ClientID);
            descriptor.AddElementProperty("showLineImages", this.ShowLineImages.ClientID);
            descriptor.AddElementProperty("iconSize", this.IconSize.ClientID);
            descriptor.AddElementProperty("filterExpressionForDocuments", this.FilterExpressionForDocuments.ClientID);
            descriptor.AddElementProperty("expanded", this.Expanded.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(DocumentFolderListDesigner.scriptReference, typeof(DocumentFolderListDesigner).Assembly.FullName));
            return scripts;
        }

        /// <summary>
        /// Gets the required by the control, core library scripts predefined in the <see cref="ScriptRef"/> enum.
        /// </summary>
        protected override ScriptRef GetRequiredCoreScripts()
        {
            return ScriptRef.JQuery | ScriptRef.JQueryUI;
        }
        #endregion

        protected virtual RadComboBox skinComboBox
        {
            get
            {
                return this.Container.GetControl<RadComboBox>("skinComboBox", true);
            }
        }

        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/SitefinitySteve/RandomSiteControls.DocumentFolderList.Views.DocumentFolderListDesigner.ascx";
        public const string scriptReference = "RandomSiteControls.DocumentFolderList.Resources.DocumentFolderListDesigner.js";
        #endregion
    }
}

