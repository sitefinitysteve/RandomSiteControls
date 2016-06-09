using System;
using System.Web.UI.WebControls;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using RandomSiteControls.Configuration;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Modules.Pages.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Web.UI;
using System.Web.UI;
using System.ComponentModel;
using RandomSiteControls.Common;
using System.Configuration;
using Telerik.Sitefinity;

namespace RandomSiteControls.SFRadButton {
    /// <summary>
    /// A control which displays recent news articles in a rotating manner.
    /// </summary>
    [RequireScriptManager]
    [ControlDesigner(typeof(SFRadButtonDesigner)), PropertyEditorTitle("Button Properties")]
    public class SFRadButton : SteveControlBase
    {
        protected override void InitializeControls(GenericContainer container) {
            bool autoPostbackOverride = false;
            string buttonStyleElements = String.Empty;
            string containerStyleElements = "position:relative;";

            button.Text = this.ButtonText;

            if (this.ButtonSize != "Normal") {
                button.Height = new Unit("65px");
            }

            if (this.ButtonWidth > 0) {
                button.Width = new Unit(this.ButtonWidth, UnitType.Pixel);
            }

            if (!String.IsNullOrEmpty(this.ButtonToolTip)) {
                button.ToolTip = this.ButtonToolTip;
            }

            #region NAVIGATION
            button.ButtonType = RadButtonType.LinkButton;
            button.AutoPostBack = false;

            if (this.UseInternal) {
                using (var api = App.WorkWith())
                {
                    var page = api.Pages().Where(p => p.Id == SelectedPageID).Get().FirstOrDefault();
                    if (page != null)
                    {
                        button.NavigateUrl = ResolveUrl(page.GetFullUrl());
                    }
                }
            }
            else {
                button.NavigateUrl = this.NavigateUrl;
            }

            if (this.OpenInNewWindow) {
                button.Target = "_blank";
            }

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
            button.Skin = skin;

            //Findout if the skin is a telerik skin
            bool foundSkin = false;

            foreach (var s in Enum.GetValues(typeof(SkinEnum)))
            {
                if (s.ToString().ToLower() == button.Skin.ToLower())
                {
                    foundSkin = true;
                    break;
                }
            }

            if (foundSkin == false)
            {
                button.EnableEmbeddedSkins = false;
            }
            #endregion

            #region LOCATION
            switch (this.Alignment) {
            	case "Left":
                    string leftCount = "0";
                    if (this.PaddingLeft != "0")
                        leftCount = this.PaddingLeft.ToString() + "px";

                    buttonStyleElements += "left:" + leftCount + ";position:absolute;";                    
                    break;
                case "Right":
                    string rightCount = "0";
                    if (this.PaddingRight != "0")
                        rightCount = this.PaddingRight.ToString() + "px";

                    buttonStyleElements += "right:" + rightCount + ";position:absolute;";
                    break;
            }
            #endregion

            #region ICONS
            //User wants to use a RadButton Icon
            if (this.EmbeddedIcon != "None"){
                if (this.EmbeddedIconPlacement == "IconLeft"){
                    button.Icon.PrimaryIconCssClass = this.EmbeddedIcon;
                }
                else{
                    button.Icon.SecondaryIconCssClass = this.EmbeddedIcon;
                }
            }

            if(!String.IsNullOrEmpty(this.PrimaryIconCssClass))

            #endregion

            #region PADDING
            if (this.Clear)
                containerStyleElements += "clear:both;";

            if(this.PaddingTop != "0")
                containerStyleElements += "padding-top:" + this.PaddingTop.ToString().Replace("px", "") + "px;";

            if (this.PaddingBottom != "0")
                containerStyleElements += "padding-bottom:" + this.PaddingBottom.ToString().Replace("px", "") + "px;";

            /*
            if (this.PaddingLeft != "0")
                containerStyleElements += "padding-left:" + this.PaddingLeft.ToString().Replace("px", "") + "px;";

            if (this.PaddingRight != "0")
                containerStyleElements += "padding-right:" + this.PaddingRight.ToString().Replace("px", "") + "px;";
            
            if (this.PaddingLeft != "0")
                containerStyleElements += "padding-left:" + this.PaddingLeft.ToString().Replace("px", "") + "px;";

            if (this.PaddingRight != "0")
                containerStyleElements += "padding-right:" + this.PaddingRight.ToString().Replace("px", "") + "px;";
             * */
            #endregion


            if ((this.IsDesignMode() == true) && (this.IsPreviewMode() == false)) {
                //Add the clicking event to cancel tab clicking in design mode
                button.AutoPostBack = false;
            }
            else{
                if (autoPostbackOverride == false)
                    button.AutoPostBack = this.AutoPostBack;

                button.OnClientClicked = (!String.IsNullOrEmpty(this.OnClientClicked)) ? this.OnClientClicked.Replace("()", "") : "";
                button.OnClientClicking = (!String.IsNullOrEmpty(this.OnClientClicking)) ? this.OnClientClicking.Replace("()", "") : "";
                button.OnClientMouseOut = (!String.IsNullOrEmpty(this.OnClientMouseOut)) ? this.OnClientMouseOut.Replace("()", "") : "";
                button.OnClientMouseOver = (!String.IsNullOrEmpty(this.OnClientMouseOver)) ? this.OnClientMouseOver.Replace("()", "") : "";
                //button.OnClientLoad = "OnSfsButtonLoaded";
            }
            
            button.Attributes.Add("style", buttonStyleElements);
            buttoncontainer.Attributes.Add("style", containerStyleElements);

            this.CheckToolboxIcon();
        }

        protected override string LayoutTemplateName {
            get {
                //return "RandomSiteControls.Button.Views.ButtonTemplate.ascx";
                return null;
            }
        }

        public override string LayoutTemplatePath {
            get {
                var path = "~/SitefinitySteve/RandomSiteControls.SFRadButton.Views.SFRadButtonTemplate.ascx";
                return path;
            }
            set {
                base.LayoutTemplatePath = value;
            }
        }

        #region PROPERTIES
        private Guid _selectedPageID = Guid.Empty;
        public Guid SelectedPageID {
            get {
                return _selectedPageID;
            }set {
                _selectedPageID = value;
        	}
        }

        private string _skin = "Metro";
        public string Skin {
            get { return _skin; }
            set { _skin = value; }
        }

        private string _buttonSize = "Normal";
        public string ButtonSize {
            get { return _buttonSize; }
            set { _buttonSize = value; }
        }

        private int _buttonWidth = -1;
        public int ButtonWidth {
            get { return _buttonWidth; }
            set { _buttonWidth = value; }
        }

        private string _location = String.Empty; 
        public string Location{
            get{
                return _location;
            }set{
                _location = value;
            }
        }

        private bool _clear = false;
        public bool Clear {
            get {
                return _clear;
            }
            set {
                _clear = value;
            }
        }

        private string _paddingTop = "0";
        public string PaddingTop {
            get {
                return _paddingTop;
            }
            set {
                _paddingTop = value;
            }
        }

        private string _paddingBottom = "0";
        public string PaddingBottom {
            get {
                return _paddingBottom;
            }
            set {
                _paddingBottom = value;
            }
        }

        private string _paddingLeft = "0";
        public string PaddingLeft {
            get {
                return _paddingLeft;
            }
            set {
                _paddingLeft = value;
            }
        }

        private string _paddingRight = "0";
        public string PaddingRight {
            get {
                return _paddingRight;
            }
            set {
                _paddingRight = value;
            }
        }

        private string _buttonText = "Button";
        public string ButtonText {
            get {
                return _buttonText;
            }
            set {
                _buttonText = value;
            }
        }


        private string _cssClass = String.Empty;
        public string CssClass
        {
            get
            {
                return _cssClass;
            }
            set
            {
                _cssClass = value;
            }
        }

        private string _tooltip = String.Empty;
        public string ButtonToolTip
        {
            get
            {
                return _tooltip;
            }
            set
            {
                _tooltip = value;
            }
        }

        private bool _useInternal = true;
        public bool UseInternal
        {
            get
            {
                return _useInternal;
            }
            set
            {
                _useInternal = value;
            }
        }

        private string _navigateUrl = String.Empty;
        public string NavigateUrl {
            get {
                return _navigateUrl;
            }
            set {
                _navigateUrl = value;
            }
        }

        private bool _openInNewWindow = false;
        public bool OpenInNewWindow {
            get {
                return _openInNewWindow;
            }
            set {
                _openInNewWindow = value;
            }
        }

        private string _alignment = "Default";
        public string Alignment {
            get {
                return _alignment;
            }
            set {
                _alignment = value;
            }
        }

        #region Icons
        private string _embeddedIcon = "None";
        public string EmbeddedIcon {
            get {
                return _embeddedIcon;
            }
            set {
                _embeddedIcon = value;
            }
        }

        private string _embeddedIconPlacement = "Left";
        public string EmbeddedIconPlacement {
            get {
                return _embeddedIconPlacement;
            }
            set {
                _embeddedIconPlacement = value;
            }
        }

        private string _primaryIconUrl = String.Empty;
        public string PrimaryIconUrl {
            get {
                return _primaryIconUrl;
            }
            set {
                _primaryIconUrl = value;
            }
        }

        private string _primaryIconCssClass = String.Empty;
        public string PrimaryIconCssClass {
            get {
                return _primaryIconCssClass;
            }
            set {
                _primaryIconCssClass = value;
            }
        }

        private string _secondaryIconUrl = String.Empty;
        public string SecondaryIconUrl {
            get {
                return _secondaryIconUrl;
            }
            set {
                _secondaryIconUrl = value;
            }
        }

        private string _secondaryIconCssClass = String.Empty;
        public string SecondaryIconCssClass {
            get {
                return _secondaryIconCssClass;
            }
            set {
                _secondaryIconCssClass = value;
            }
        }
        
        #endregion

        #region ClientSideEvents
        private string _onClientClicked = "";
        [Category("Client Events")]
        public string OnClientClicked {
            get {
                return _onClientClicked;
            }
            set {
                _onClientClicked = value;
            }
        }

        private string _onClientClicking = "";
        [Category("Client Events")]
        public string OnClientClicking {
            get {
                return _onClientClicking;
            }
            set {
                _onClientClicking = value;
            }
        }

        private string _onClientMouseOut = "";
        [Category("Client Events")]
        public string OnClientMouseOut {
            get {
                return _onClientMouseOut;
            }
            set {
                _onClientMouseOut = value;
            }
        }

        private string _onClientMouseOver = "";
        [Category("Client Events")]
        public string OnClientMouseOver {
            get {
                return _onClientMouseOver;
            }
            set {
                _onClientMouseOver = value;
            }
        }

        private string _onClientLoad = "";
        [Category("Client Events")]
        public string OnClientLoad {
            get {
                return _onClientLoad;
            }
            set {
                _onClientLoad = value;
            }
        }
        #endregion

        private bool _autoPostBack = true;
        public bool AutoPostBack {
            get {
                return _autoPostBack;
            }
            set {
                _autoPostBack = value;
            }
        }
        #endregion

        #region CONTROL DEFINITIONS
        protected virtual RadButton button {
            get {
                return this.Container.GetControl<RadButton>("button", true);
            }
        }

        protected virtual Panel buttoncontainer {
            get {
                return this.Container.GetControl<Panel>("buttoncontainer", true);
            }
        }

        protected virtual HiddenField sfsButtonClientState {
            get {
                return this.Container.GetControl<HiddenField>("sfsButtonClientState", true);
            }
        }
        
        #endregion
    }
}