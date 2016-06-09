using System;
using System.Linq;
using System.Web.UI.WebControls;
using RandomSiteControls.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI;

namespace RandomSiteControls.Placeholder
{
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(RandomSiteControls.Placeholder.Designer.PlaceholderDesigner))]
    public class Placeholder : SimpleView
    {
        protected override void InitializeControls(GenericContainer container)
        {
            string urlFormat = "http://placehold.it/{0}x{1}/{2}/{3}";
            if(String.IsNullOrEmpty(this.ImageText.Trim())){
                placeholderImage.ImageUrl = String.Format(urlFormat, this.ImageWidth, this.ImageHeight, this.ImageBackgroundColor, this.ImageTextColor); 
            }
            else{
                urlFormat = urlFormat + "&text={4}";
                placeholderImage.ImageUrl = String.Format(urlFormat, this.ImageWidth, this.ImageHeight, this.ImageBackgroundColor, this.ImageTextColor, this.ImageText);
            }
        }

        #region Properties
        /// <summary>
        /// Gets or sets the message that will be displayed in the label.
        /// </summary>
        private int _imageWidth = 300;
        public int ImageWidth {
            get { return _imageWidth; }
            set { _imageWidth = value; }
        }

        private int _imageHeight = 200;
        public int ImageHeight {
            get { return _imageHeight; }
            set { _imageHeight = value; }
        }

        private string _backgroundColor = "00ADDC";
        public string ImageBackgroundColor {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        private string _imageTextColor = "FFFFFF";
        public string ImageTextColor {
            get { return _imageTextColor; }
            set { _imageTextColor = value; }
        }

        private string _imageText = String.Empty;

        public string ImageText {
            get { return _imageText; }
            set { _imageText = value; }
        }

        #endregion

        #region LAYOUTS
        /// <summary>
        /// Gets the layout template path
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                return Placeholder.layoutTemplatePath;
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
        protected virtual Image placeholderImage
        {
            get
            {
                return this.Container.GetControl<Image>("placeholderImage", true);
            }
        }
        #endregion

        #region Methods
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            this.RenderContents(writer);
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/SitefinitySteve/RandomSiteControls.Placeholder.Placeholder.ascx";
        #endregion
    }
}
