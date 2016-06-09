using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.Pages.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Web.UI;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data.Configuration;
using Telerik.Sitefinity.Web.UI.PublicControls.BrowseAndEdit;
using System.Web.UI;
using System.Diagnostics;
using RandomSiteControls.Common;
using System.Collections;


namespace RandomSiteControls.SqlGrid {
    /// <summary>
    /// A control which displays recent news articles in a rotating manner.
    /// </summary>
    [RequireScriptManager]
    [ControlDesigner(typeof(SqlGridDesigner)), PropertyEditorTitle("Edit the SQL Grid")]
    public class SqlGrid : SteveControlBase, IBrowseAndEditable 
    {
        public BrowseAndEditableInfo BrowseAndEditableInfo {
            get {
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
            set {
                // TODO: Implement this property setter
                throw new NotImplementedException();
            }
        }

        protected override void InitializeControls(GenericContainer container) {
            #region BrowseAndEdit
            this.BrowseAndEditToolbar.Commands.AddRange(this.commands);
            var bem = BrowseAndEditManager.GetCurrent(this.Page);
            if (bem != null) {
                bem.Add(this.BrowseAndEditToolbar);
            }
            #endregion
            RadGrid1.AllowSorting = this.AllowSorting;
            RadGrid1.AllowPaging = this.AllowPaging;
            RadGrid1.AllowFilteringByColumn = this.AllowFilteringByColumn;
            RadGrid1.GroupingEnabled = this.AllowGrouping;

            if (EnableSEOPager) {
                RadGrid1.PagerStyle.EnableSEOPaging = true;
                RadGrid1.PagerStyle.UseRouting = true;
            }

            #region GROUPING
            RadGrid1.ShowGroupPanel = (RadGrid1.GroupingEnabled == true) ? true : false;
            RadGrid1.ClientSettings.AllowDragToGroup = (RadGrid1.GroupingEnabled == true) ? true : false;
            #endregion

            RadGrid1.PageSize = this.PagerSize;
            RadGrid1.AutoGenerateColumns = true;
            RadGrid1.PagerStyle.Mode = GridPagerMode.NextPrevAndNumeric;

            #region SKIN
            bool foundSkin = false;
            foreach (string skin in Enum.GetNames(typeof(SkinEnum))){
                if (skin.ToLower() == this.Skin.ToLower()){
                    RadGrid1.Skin = skin;
                    foundSkin = true;
                    break;
                }
            }
            if (foundSkin == false) {
                RadGrid1.EnableEmbeddedSkins = false;
            }
            #endregion

            #region DATA
            //Get the connection string
            if (!String.IsNullOrEmpty(this.ConnectionString)) {
                if (Config.Get<DataConfig>().ConnectionStrings.ContainsKey(this.ConnectionString)) {
                    var connectionString = Config.Get<DataConfig>().ConnectionStrings[this.ConnectionString];
                    SqlDataSource1.ConnectionString = connectionString.ConnectionString;
                    SqlDataSource1.SelectCommand = this.SelectStatement;
                    SqlDataSource1.SelectCommandType = SqlDataSourceCommandType.Text;


                    //Validate the appSettings to see if there's any exclusions
                    if (System.Web.Configuration.WebConfigurationManager.AppSettings["sfsRadGridExclude"] != null) {
                        if (!String.IsNullOrEmpty(this.SelectStatement)) {
                            var exclusions = System.Web.Configuration.WebConfigurationManager.AppSettings["sfsRadGridExclude"].ToString();

                            foreach (string table in exclusions.Split(';')) {
                                if (this.SelectStatement.ToLower().Contains(table.ToLower())) {
                                    SqlDataSource1.SelectCommand = String.Empty;
                                    this.Controls.Add(new LiteralControl("<strong>Query Exeption</strong><br/>You are using a restricted word in your query defined in the web.config (YOU SHALL NOT PASS)<br/>  Please fix your query or contact your web admin."));
                                    break;
                                }
                            }
                        }
                        else{
                            this.Controls.Add(new LiteralControl("No Select query detected, click Edit"));        	
                        }
                    }
                } else {
                    this.Controls.Add(new LiteralControl("<div class='noconnection'>Connection string " + this.ConnectionString + " not found in the Data.config file</div>"));
                }
            } else {
                this.Controls.Add(new LiteralControl("Click Edit to choose your connectionstring and set your query"));
            }
            #endregion

            this.CheckToolboxIcon();
        }

        protected override string LayoutTemplateName {
            get {
                //return "RandomSiteControls.SqlGrid.Views.SqlGridTemplate.ascx";
                return null;
            }
        }

        public override string LayoutTemplatePath {
            get {
                var path = "~/RandomSiteControls/RandomSiteControls.SqlGrid.Views.SqlGridTemplate.ascx";
                return path;
            }
            set {
                base.LayoutTemplatePath = value;
            }
        }

        #region EVENTS

        #endregion

        #region PROPERTIES
        private string _selectStatement = String.Empty;
        public string SelectStatement {
            get { return _selectStatement; }
            set { _selectStatement = value; }
        }

        private string _connectionString = "Sitefinity";
        public string ConnectionString{
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        private bool _allowSorting = false;
        public bool AllowSorting {
            get {
                return _allowSorting;
            }
            set {
                _allowSorting = value;
            }
        }

        private bool _allowPaging = false;
        public bool AllowPaging {
            get {
                return _allowPaging;
            }
            set {
                _allowPaging = value;
            }
        }

        private bool _allowGrouping = false;
        public bool AllowGrouping {
            get {
                return _allowGrouping;
            }
            set {
                _allowGrouping = value;
            }
        }

        private int _pagerSize = 20;
        public int PagerSize {
            get {
                return _pagerSize;
            }
            set {
                _pagerSize = value;
            }
        }

        private bool _allowFilteringByColumn = false;
        public bool AllowFilteringByColumn {
            get {
                return _allowFilteringByColumn;
            }
            set {
                _allowFilteringByColumn = value;
            }
        }

        private bool _enableSEOPager = false;
        public bool EnableSEOPager {
            get {
                return _enableSEOPager;
            }
            set {
                _enableSEOPager = value;
            }
        }

        private string _skin = "Sitefinity";
        public string Skin {
            get { return _skin; }
            set { _skin = value; }
        }
        #endregion

        #region CONTROL DEFINITIONS
        protected virtual RadGrid RadGrid1 {
            get {
                return this.Container.GetControl<RadGrid>("RadGrid1", true);
            }
        }

        protected virtual SqlDataSource SqlDataSource1 {
            get {
                return this.Container.GetControl<SqlDataSource>("SqlDataSource1", true);
            }
        }
        #endregion

        #region Browse and Edit
        private BrowseAndEditToolbar browseAndEditToolbar;
        private List<BrowseAndEditCommand> commands = new List<BrowseAndEditCommand>();
        BrowseAndEditToolbar IBrowseAndEditable.BrowseAndEditToolbar {
            get {
                return this.BrowseAndEditToolbar;
            }
        }

        public void AddCommands(IList<BrowseAndEditCommand> commands) {
            this.commands.AddRange(commands);
        }

        protected virtual BrowseAndEditToolbar BrowseAndEditToolbar {
            get {
                if (this.browseAndEditToolbar == null) {
                    this.browseAndEditToolbar = this.Container.GetControl<BrowseAndEditToolbar>("browseAndEditToolbar", true);
                }
                return this.browseAndEditToolbar;
            }
        }

        #endregion
    }
}