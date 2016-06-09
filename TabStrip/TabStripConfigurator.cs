using System;
using System.Collections.Generic;
using System.Web;
using RandomSiteControls.Configuration;
using Telerik.Sitefinity.Modules.Pages.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Web.UI;
using System.Web.Script.Serialization;
using Telerik.Sitefinity.Web.UI;
using System.Web.UI;
using RandomSiteControls.Common;
using System.Configuration;

namespace RandomSiteControls.TabStrip {
    /// <summary>
    /// A control which displays recent news articles in a rotating manner.
    /// </summary>
    [RequireScriptManager]
    [ControlDesigner(typeof(TabStripDesigner)), PropertyEditorTitle("TabStrip Options")]
    public class TabStripConfigurator : SteveControlBase 
    {
        private List<RadTab> _tabs = null;

        protected override void InitializeControls(GenericContainer container) {
            //TabStrip options
            #region GenerateTabs
            tabStripControl.Tabs.Clear();

            tabStripControl.Tabs.AddRange(this.GetTabs().ToArray());
            #endregion

           // if ((this.IsDesignMode() == true) && (this.IsPreviewMode() == false)) {
                //Add the clicking event to cancel tab clicking in design mode
                tabStripControl.OnClientTabSelecting = "onSSTabSelecting";
                tabStripControl.OnClientTabSelected = "onSSTabSelected";
           // }

            #region Rendering
            if (this.Rendering == "Horizontal")
                tabStripControl.Orientation = TabStripOrientation.HorizontalTop;
            else if(this.Rendering == "Vertical")
                tabStripControl.Orientation = TabStripOrientation.VerticalLeft;
            #endregion

            #region SKIN
            var skin = String.Empty;
            if (this.UserConfig.AllowCustomSkins)
            {
                //Use whatever is set in the control
                skin = this.Skin;
            }
            else
            {
                //Use the one from the config
                skin = this.UserConfig.Skin;
            }

            tabStripControl.Skin = skin;

            //Findout if the skin is a telerik skin
            bool foundSkin = false;

            foreach (var s in Enum.GetValues(typeof(SkinEnum)))
            {
                if (s.ToString().ToLower() == tabStripControl.Skin.ToLower())
                {
                    foundSkin = true;
                    break;
                }
            }

            if (foundSkin == false)
            {
                tabStripControl.EnableEmbeddedSkins = false;
            }
            #endregion

            this.CheckToolboxIcon();


            tabStripControl.CausesValidation = this.CausesValidation;

            //Set the alignment 
            switch(this.Alignment) {
                case "Left":
                    tabStripControl.Align = TabStripAlign.Left;
                    break;
                case "Right":
                    tabStripControl.Align = TabStripAlign.Right;
                    break;
                case "Center":
                    tabStripControl.Align = TabStripAlign.Center;
                    break;
                case "Justify":
                    tabStripControl.Align = TabStripAlign.Justify;
                    break;
            }

            tabStripControl.SelectedIndex = this.DefaultTab - 1;

            if(!String.IsNullOrEmpty(QueryStringKey)){
                //Find the key
                if(HttpContext.Current.Request.QueryString[this.QueryStringKey] != null){
                    //Exists, get the value 
                    var value = HttpContext.Current.Request.QueryString[this.QueryStringKey];

                    //Find the matching tab
                    foreach(RadTab tab in tabStripControl.Tabs){
                        if(tab.Attributes["Key"] != null){
                            if(value == tab.Attributes["Key"]){
                                tab.Selected = true;
                            }
                        }
                    }
                }
            }

            tabStripControl.Attributes.Add("data-animations", this.EnableAnimations.ToString().ToLower());
        }

        protected override string LayoutTemplateName {
            get {
                //return "RandomSiteControls.TabStrip.Views.TabStripConfigurator.ascx";
                return null;
            }
        }

        public override string LayoutTemplatePath {
            get {
                var path = "~/SitefinitySteve/RandomSiteControls.TabStrip.Views.TabStripConfigurator.ascx";
                return path;
            }
            set {
                base.LayoutTemplatePath = value;
            }
        }

        #region Methods
        public List<RadTab> GetTabs() {
            if (_tabs == null) {
                _tabs = new List<RadTab>();

                JavaScriptSerializer serializer = new JavaScriptSerializer(); //Initalize the Serializer
                Object[] names = serializer.Deserialize(this.TabNames, typeof(Object)) as Object[];

                foreach (var t in names) {
                    RadTab newTab = new RadTab();

                    object tabName = null;
                    ((System.Collections.Generic.Dictionary<string, object>)t).TryGetValue("Text", out tabName);

                    object tabClass = null;
                    ((System.Collections.Generic.Dictionary<string, object>)t).TryGetValue("CssClass", out tabClass);

                    object tabImage = null;
                    ((System.Collections.Generic.Dictionary<string, object>)t).TryGetValue("Image", out tabImage);

                    object tabNavigateUrl = null;
                    ((System.Collections.Generic.Dictionary<string, object>)t).TryGetValue("NavigateUrl", out tabNavigateUrl);

                    object isDefault = null;
                    ((System.Collections.Generic.Dictionary<string, object>)t).TryGetValue("Default", out isDefault);

                    object tabKey = null;
                    ((System.Collections.Generic.Dictionary<string, object>)t).TryGetValue("Key", out tabKey);

                    newTab.Text = (String.IsNullOrEmpty(tabName.ToString())) ? "Tab " + (_tabs.Count + 1) : tabName.ToString();

                    //Use image only if not blank
                    if (tabImage != null) {
                        if (!String.IsNullOrEmpty(tabImage.ToString().Trim()))
                            newTab.ImageUrl = tabImage.ToString().Trim();
                    }

                    //Use image only if not blank
                    if (tabClass != null) {
                        if (!String.IsNullOrEmpty(tabClass.ToString().Trim()))
                            newTab.OuterCssClass = tabClass.ToString();
                    }

                    //Use image only if not blank
                    if (tabKey != null)
                    {
                        if (!String.IsNullOrEmpty(tabKey.ToString().Trim()))
                            newTab.Attributes.Add("Key", tabKey.ToString());
                    }

                    //Use image only if not blank
                    if (tabNavigateUrl != null) {
                        if (!String.IsNullOrEmpty(tabNavigateUrl.ToString().Trim()) && tabNavigateUrl.ToString().Trim() != "#") {
                            newTab.NavigateUrl = tabNavigateUrl.ToString().Trim();
                            newTab.Target = "_blank";
                        }
                    }

                    if (isDefault != null) {
                        bool state = Convert.ToBoolean(isDefault);
                        newTab.Selected = state;
                    }

                    _tabs.Add(newTab);
                }
            }

            return _tabs;
        }
        #endregion

        #region PROPERTIES
        public string QueryStringKey { get; set; }

        private bool _enableAnimations = true;
        public bool EnableAnimations {
            get { return _enableAnimations; }
            set { _enableAnimations = value; }
        }

        private string _skin = "Metro";
        public string Skin{
            get{
                return _skin;
            }        	
            set{
                _skin = value;
            }
        }

        private string _rendering = "Horizontal";
        public string Rendering
        {
            get
            {
                return _rendering;
            }
            set
            {
                _rendering = value;
            }
        }

        private string _tabNames = "[{'Text':'Tab 1','Image':'','NavigateUrl':'', 'CssClass':'', 'Key':''},{'Text':'Tab 2','Image':'','NavigateUrl':'', 'CssClass':'', 'Key':''},{'Text':'Tab 3','Image':'','NavigateUrl':'', 'CssClass':'', 'Key':''}]";
        public string TabNames {
            get {
                return _tabNames;
            }
            set {
                _tabNames = value;
            }
        }

        private string _imageURLS = String.Empty;
        public string ImageURLS {
            get {
                return _imageURLS;
            }
            set {
                _imageURLS = value;
            }
        }

        private string _alignment = "Left";
        public string Alignment
        {
            get
            {
                return _alignment;
            }
            set
            {
                _alignment = value;
            }
        }

        private int _defaultTab = 1;
        public int DefaultTab {
            get {
                return _defaultTab;
            }
            set {
                _defaultTab = value;
            }
        }

        public int TabCount {
            get {
                return this.GetTabs().Count;
        	}
            set{}
        }

        private bool _causesValidation = true;
        public bool CausesValidation {
            get { return _causesValidation; }
            set { _causesValidation = value; }
        }

        #endregion

        #region CONTROL DEFINITIONS
        protected virtual RadTabStrip tabStripControl {
            get {
                return this.Container.GetControl<RadTabStrip>("tabStripControl", true);
            }
        }


        #endregion
    }
}