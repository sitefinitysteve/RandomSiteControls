using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Modules.Pages.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using RandomSiteControls.Common;
using System.Web.Script.Serialization;

namespace RandomSiteControls.BackgroundImage {
    /// <summary>
    /// A control which displays recent news articles in a rotating manner.
    /// </summary>
    [RequireScriptManager]
    [ControlDesigner(typeof(BackgroundImageDesigner)), PropertyEditorTitle("BackgroundImage Properties")]
    public class BackgroundImage : SteveControlBase {
        protected override void InitializeControls(GenericContainer container) {
            JavaScriptSerializer serializer = new JavaScriptSerializer(); //Initalize the Serializer

            Dictionary<string, object> outputs = new Dictionary<string, object>();
            outputs.Add("ImageURL", this.ImageURL);
            outputs.Add("PositionX", this.PositionX);
            outputs.Add("PositionY", this.PositionY);
            outputs.Add("Repeat", this.Repeat);

            backgroundImageHiddenField.Value = serializer.Serialize(outputs);
        }

        protected override string LayoutTemplateName {
            get {
                //return "RandomSiteControls.BackgroundImage.Views.BackgroundImageTemplate.ascx";
                return null;
            }
        }

        public override string LayoutTemplatePath {
            get {
                var path = "~/RandomSiteControls/RandomSiteControls.BackgroundImage.Views.BackgroundImageTemplate.ascx";
                return path;
            }
            set {
                base.LayoutTemplatePath = value;
            }
        }

        #region PROPERTIES
        private string _imageURL = String.Empty;
        public string ImageURL {
            get { return _imageURL; }
            set { _imageURL = value; }
        }

        private string _positionX = "center";
        public string PositionX {
            get { return _positionX; }
            set { _positionX = value; }
        }

        private string _positionY = "center";
        public string PositionY {
            get { return _positionY; }
            set { _positionY = value; }
        }

        private string _repeat = "no-repeat";
        public string Repeat {
            get { return _repeat; }
            set { _repeat = value; }
        }
        #endregion

        #region CONTROL DEFINITIONS
        protected virtual HiddenField backgroundImageHiddenField {
            get {
                return this.Container.GetControl<HiddenField>("backgroundImageHiddenField", true);
            }
        }
        #endregion
    }
}