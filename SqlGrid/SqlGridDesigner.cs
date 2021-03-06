﻿    using System;
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

namespace RandomSiteControls.SqlGrid {
    /// <summary>
    /// The control designer class for the Rotator widget
    /// </summary>
    public class SqlGridDesigner : SteveControlDesignerBase {
        /// <summary>
        /// Gets the name of the embedded layout template.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// Override this property to change the embedded template to be used with the dialog
        /// </remarks>
        protected override string LayoutTemplateName {
            get {
                //return "RandomSiteControls.SqlGrid.Views.SqlGridDesigner.ascx";
                return null;
            }
        }

        public override string LayoutTemplatePath {
            get {
                var path = "~/RandomSiteControls/RandomSiteControls.SqlGrid.Views.SqlGridDesigner.ascx";
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
            this.DesignerMode = ControlDesignerModes.Simple;
            base.InitializeControls(container);

            #region Connection String
            //Load in the connection Strings
            var dataConfig = Config.Get<DataConfig>();
            var connectionStrings = dataConfig.ConnectionStrings;

            foreach (var c in connectionStrings.Keys) {
                connectionStringComboBox.Items.Add(new RadComboBoxItem(c.ToString(), c.ToString()));
            }

            if (connectionStringComboBox.Items.Count == 0){
                connectionStringComboBox.EmptyMessage = "No Connection strings detected";
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
            res.Add(new ScriptReference("RandomSiteControls.SqlGrid.Resources.SqlGridDesigner.js", assemblyName));
            return res.ToArray();
        }

        #region ControlReferences
        protected virtual Label debugLabel {
            get {
                return this.Container.GetControl<Label>("debugLabel", true);
            }
        }

        protected virtual RadComboBox connectionStringComboBox {
            get {
                return this.Container.GetControl<RadComboBox>("connectionStringComboBox", true);
            }
        }

        protected virtual RadComboBox skinComboBox {
            get {
                return this.Container.GetControl<RadComboBox>("skinComboBox", true);
            }
        }

        protected virtual RadTextBox selectStatementTextBox {
            get {
                return this.Container.GetControl<RadTextBox>("selectStatementTextBox", true);
            }
        }

        protected virtual CheckBox allowSortingCheck {
            get {
                return this.Container.GetControl<CheckBox>("allowSortingCheck", true);
            }
        }

        protected virtual CheckBox allowPagingCheck {
            get {
                return this.Container.GetControl<CheckBox>("allowPagingCheck", true);
            }
        }

        protected virtual CheckBox allowFiltering {
            get {
                return this.Container.GetControl<CheckBox>("allowFiltering", true);
            }
        }

        protected virtual CheckBox allowGrouping {
            get {
                return this.Container.GetControl<CheckBox>("allowGrouping", true);
            }
        }

        protected virtual RadNumericTextBox pageSizetTextBox {
            get {
                return this.Container.GetControl<RadNumericTextBox>("pageSizetTextBox", true);
            }
        }
        #endregion
    }
}
