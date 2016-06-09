using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Web.UI;

namespace RandomSiteControls.PageTitle {
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(RandomSiteControls.PageTitle.Designer.PageTitleDesigner))]
    public class PageTitle : SimpleView
    {
        /// <summary>
        /// Initializes the controls.
        /// </summary>
        /// <param name="container"></param>
        /// <remarks>
        /// Initialize your controls in this method. Do not override CreateChildControls method.
        /// </remarks>
        protected override void InitializeControls(GenericContainer container) {
            if (!this.AllowRender)
            {
                this.Visible = false;

                if (!String.IsNullOrEmpty(this.PageTitleText))
                {
                    HttpContext.Current.Items["PageTitle"] = this.PageTitleText;
                }
                else
                {
                    HttpContext.Current.Items["PageTitle"] = "Set the PageTitleText Property";
                }
            }
            else
            {
                PageSiteNode node = SiteMapBase.GetActualCurrentNode();
                var title = (!String.IsNullOrEmpty(this.PageTitleText) ? this.PageTitleText : (node == null) ? "Page Title" : node.Title);
                this.SetTitle(title);
            }
        }
  
        private void SetTitle(string title) {
            
            pageTitleLabel.Text = "<{0} class=\"{1}\"><span class=\"text\">{2}</span></{0}>".Arrange(this.WrapperTag, this.CssClass, title);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
            if(HttpContext.Current.Items["PageTitle"] != null){
                this.SetTitle(HttpContext.Current.Items["PageTitle"].ToString());
            }
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            if (HttpContext.Current.Items["PageTitle"] != null)
            {
                this.SetTitle(HttpContext.Current.Items["PageTitle"].ToString());
            }

            base.RenderControl(writer);
        }

        #region PROPERTIES
        private string _text = String.Empty;
        public string PageTitleText
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        private string _wrapperTag = "h1";
        public string WrapperTag {
            get { return _wrapperTag; }
            set { _wrapperTag = value; }
        }

        private bool _allowRender = true;
        public bool AllowRender {
            get { return _allowRender; }
            set { _allowRender = value; }
        }

        private string _cssClass = "page-title";
        public string CssClass {
            get { return _cssClass; }
            set { _cssClass = value; }
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
                return PageTitle.layoutTemplatePath;
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
        protected virtual Literal pageTitleLabel
        {
            get
            {
                return this.Container.GetControl<Literal>("pageTitleLabel", true);
            }
        }
        
       
        #endregion

        #region Methods
        /// <summary>
        /// Remove the outer span on the control
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            RenderContents(writer);
        } 
        #endregion

        #region Private members & constants

        public static readonly string layoutTemplatePath = "~/SitefinitySteve/RandomSiteControls.PageTitle.PageTitle.ascx";
        #endregion
    }
}
