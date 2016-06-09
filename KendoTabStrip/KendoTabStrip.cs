using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Web.UI;
using Telerik.Web.UI;
using System.Collections;

namespace RandomSiteControls.KendoTabStrip {
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(RandomSiteControls.KendoTabStrip.KendoTabStripDesigner))]
    public class KendoTabStrip : SimpleView
    {
        #region Methods

        protected override void InitializeControls(GenericContainer container)
        {
            tabStripListView.NeedDataSource += new EventHandler<RadListViewNeedDataSourceEventArgs>(OnKendoListView_NeedsDataSource);
        }
        #endregion

        #region Properties
        
        #endregion

        #region Events
        public void OnKendoListView_NeedsDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            List<KendoTabStripTab> tabs = new List<KendoTabStripTab>();
            tabs.Add(new KendoTabStripTab("Tab 1", "tab-css1"));
            tabs.Add(new KendoTabStripTab("Tab 2", "tab-css2"));
            tabs.Add(new KendoTabStripTab("Tab 3", "tab-css3"));

            ((RadListView)sender).DataSource = tabs;
        }
        #endregion

        #region Layout
        /// <summary>
        /// Gets the layout template path
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                return KendoTabStrip.layoutTemplatePath;
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

        #region Control References
        /// <summary>
        /// Reference to the Label control that shows the Message.
        /// </summary>
        protected virtual RadListView tabStripListView
        {
            get
            {
                return this.Container.GetControl<RadListView>("tabStripListView", true);
            }
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/SitefinitySteve/RandomSiteControls.KendoTabStrip.Views.KendoTabStrip.ascx";
        #endregion
    }

    public class KendoTabStripTab {
        public KendoTabStripTab(string text, string css) {
            this.Text = text;
            this.CssClass = css;
        }
  
        public string Text { get; set; }
        public string CssClass { get; set; }
    }
}
