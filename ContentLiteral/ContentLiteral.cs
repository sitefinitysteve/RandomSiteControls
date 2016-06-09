using System.Web.UI;
using RandomSiteControls.Configuration;
using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace RandomSiteControls.ContentLiteral
{
    public enum LiteralEmbedPosition
    {
        Head,
        InPlace,
        BeforeBodyEndTag
    }

    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(RandomSiteControls.ContentLiteral.Designer.ContentLiteralDesigner)), PropertyEditorTitle("Edit Raw Markup")]
    public class ContentLiteral : SimpleView, ICustomWidgetVisualization
    {
        private string _literal = String.Empty;


        protected override void InitializeControls(GenericContainer container) {
            _literal = (String.IsNullOrEmpty(this.Markup)) ? String.Empty : this.Markup.Trim();
            /*
            //Remove script tags...this is a crappy implimentation :)
            if (Config.Get<SitefinitySteveConfig>().ContentLiteral.PreventScriptTags)
            {
                text = text.Replace("<script>", "&lt;script&gt;")
                           .Replace("</script>", "&lt;/script&gt;")
                           .Replace("<script", "&lt;script");
            }
            */
            //Wrapper code
            if (this.IsDesignMode() == true && this.IsPreviewMode() == false)
            {
                //Preview Mode
                if (this.DesignModePreviewEncoding)
                {
                    if (HttpContext.Current != null)
                    {
                        string previewContent = HttpContext.Current.Server.HtmlEncode(_literal);
                        previewLiteral.Text = this.CleanupMarkup(previewContent);
                        

                        if (this.RequiresWrapper())
                        {
                            previewLiteral.Text = "<div class='sfContentBlock sfContentLiteral'>{0}</div>".Arrange(previewLiteral.Text);
                        }
                    }
                }

                if(this.LiteralEmbedPosition != RandomSiteControls.ContentLiteral.LiteralEmbedPosition.InPlace){
                    if (this.ShowRenderedText)
                    {
                        previewLiteral.Text += "<span class='renderedin' style='font-size: 10px'>-- Rendered in " + this.LiteralEmbedPosition.ToString() + "--</span>";
                    }
                }

            }else{
                previewLiteral.Visible = false; //Just in case
            }
        }

        private bool? _requireWrapper = null;
        private bool RequiresWrapper() {
            if (_requireWrapper == null)
            {
                _requireWrapper = false;

                //Wrapper code
                if (Config.Get<SitefinitySteveConfig>().ContentLiteral.WrapLiteralAsContentBlock)
                {
                    if (this.RemoveWrapper)
                        _requireWrapper = false;
                    else
                        _requireWrapper = true;
                }
            }
            
            return _requireWrapper.Value;
        }

        protected override void OnPreRender(EventArgs e){
            LiteralEmbedPosition scriptEmbedPosition = this.LiteralEmbedPosition;
            Literal literal = new Literal();
            literal.Text = _literal;

            if (scriptEmbedPosition == LiteralEmbedPosition.Head)
            {
                this.Page.Header.Controls.Add(literal);
                return;
            }
            else if (scriptEmbedPosition == LiteralEmbedPosition.InPlace)
            {
                //Encoding
                if (this.HtmlEncodeContent)
                {
                    if (HttpContext.Current != null)
                    {
                        literal.Text = HttpContext.Current.Server.HtmlEncode(literal.Text);
                        literal.Text = this.CleanupMarkup(literal.Text);
                        previewLiteral.Visible = false; //Hide preview, we don't want 2
                    }
                }

                if (this.RequiresWrapper())
                {
                    literal.Text = "<div class='sfContentBlock sfContentLiteral'>{0}</div>".Arrange(literal.Text);
                }
                this.Controls.Add(literal);
                return;
            }
            else if (scriptEmbedPosition == LiteralEmbedPosition.BeforeBodyEndTag)
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(ContentLiteral), this.ClientID, literal.Text, false);
                return;
            }
        }

        #region METHODS
        private string CleanupMarkup(string content){
            return content.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;").Replace(" ", "&nbsp;").Replace("\n", "<br />");
        }

        /// <summary>
        /// Gets the is empty.
        /// </summary>
        /// <value>The is empty.</value>
        public bool IsEmpty
        {
            get
            {
                return String.IsNullOrEmpty(this.Markup);
            }
        }

        /// <summary>
        /// Gets the empty link text.
        /// </summary>
        /// <value>The empty link text.</value>
        public string EmptyLinkText
        {
            get
            {
                return "Enter Content";
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Remove the outer span on the control
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            RenderContents(writer);
        }

        #endregion

        #region Properties
        private LiteralEmbedPosition _literalEmbedPosition = LiteralEmbedPosition.InPlace;
        public LiteralEmbedPosition LiteralEmbedPosition {
            get { 
                if (_literalEmbedPosition == null)
                    _literalEmbedPosition = new LiteralEmbedPosition();
                return _literalEmbedPosition; 
            }
            set { _literalEmbedPosition = value; }
        }

        private string _markup = String.Empty;
        public string Markup {
            get { return _markup; }
            set { _markup = value; }
        }

        public bool RemoveWrapper { get; set; }

        private bool _htmlEncode = false;
        public bool HtmlEncodeContent
        {
            get { return _htmlEncode; }
            set { _htmlEncode = value; }
        }

        private bool _showRenderedText = true;
        public bool ShowRenderedText {
            get { return _showRenderedText; }
            set { _showRenderedText = value; }
        }

        private bool _designModePreviewEncoding = false;
        public bool DesignModePreviewEncoding
        {
            get { return _designModePreviewEncoding; }
            set { _designModePreviewEncoding = value; }
        }

        private bool _visibleInDesignMode = false;

        public bool VisibleInDesign {
            get { return _visibleInDesignMode; }
            set { _visibleInDesignMode = value; }
        }

        #endregion

        #region LayoutControls

        /// <summary>
        /// Gets the layout template path
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                return ContentLiteral.layoutTemplatePath;
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
        protected virtual Literal previewLiteral
        {
            get
            {
                return this.Container.GetControl<Literal>("previewLiteral", true);
            }
        }
        #endregion


        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/SitefinitySteve/RandomSiteControls.ContentLiteral.ContentLiteral.ascx";
        #endregion
    }
}
