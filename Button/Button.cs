using System;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Modules.Pages.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using RandomSiteControls.Common;
using System.Linq;
using Telerik.Sitefinity;

namespace RandomSiteControls.Button {
    /// <summary>
    /// A control which displays recent news articles in a rotating manner.
    /// </summary>
    [RequireScriptManager]
    [ControlDesigner(typeof(ButtonDesigner)), PropertyEditorTitle("Button Properties")]
    public class Button : SteveControlBase
    {
        protected override void InitializeControls(GenericContainer container) {
            string buttonStyleElements = String.Empty;
            string containerStyleElements = "position:relative;";

            button.Text = String.Format("<span>{0}</span>", this.ButtonText);

            if (!String.IsNullOrEmpty(this.ButtonToolTip)) {
                button.ToolTip = this.ButtonToolTip;
            }

            button.CssClass = "sfsButton-inner";
            if (!String.IsNullOrEmpty(this.CssClass))
            {
                button.CssClass += " " + this.CssClass;
            }

            #region NAVIGATION
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
            
            button.Attributes.Add("style", buttonStyleElements);
            buttoncontainer.Attributes.Add("style", containerStyleElements);
        }

        protected override string LayoutTemplateName {
            get {
                //return "RandomSiteControls.Button.Views.ButtonTemplate.ascx";
                return null;
            }
        }

        public override string LayoutTemplatePath {
            get {
                var path = "~/SitefinitySteve/RandomSiteControls.Button.Views.ButtonTemplate.ascx";
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

        private string _location = String.Empty; 
        public string Location{
            get{
                return _location;
            }set{
                _location = value;
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
        #endregion

        #region CONTROL DEFINITIONS
        protected virtual System.Web.UI.WebControls.HyperLink button {
            get {
                return this.Container.GetControl<System.Web.UI.WebControls.HyperLink>("button", true);
            }
        }

        protected virtual Panel buttoncontainer {
            get {
                return this.Container.GetControl<Panel>("buttoncontainer", true);
            }
        }
        #endregion
    }
}