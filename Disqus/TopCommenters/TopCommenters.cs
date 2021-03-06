using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using RandomSiteControls.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Model;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace RandomSiteControls.Disqus.TopCommenters
{
    [ControlDesigner(typeof(RandomSiteControls.Disqus.TopCommenters.Designer.TopCommentersDesigner)), PropertyEditorTitle("Disqus Top Commenters Options")]
    public class TopCommenters : SimpleView
    {
        protected override void InitializeControls(GenericContainer container)
        {
            var shortname = Config.Get<SitefinitySteveConfig>().Disqus.ShortName;
            bool renderInDesignMode = Config.Get<SitefinitySteveConfig>().Disqus.RenderScriptInDesignMode;
            bool canRender = true;

            if (!renderInDesignMode && this.IsDesignMode()) {
                //Dont render the control
                canRender = false;
                disqusDesignMode.Visible = true;
            }
            else {
                disqusDesignMode.Visible = false;
            }


            if (!String.IsNullOrEmpty(this.ShortName))
            {
                shortname = this.ShortName;
            }

            if (this.RenderTitle)
            {
                if (!String.IsNullOrEmpty(this.Title))
                    this.titleLiteral.Text = String.Format("<{1} class='dsq-widget-title'>{0}</{1}>", this.Title, this.TitleTag);
            }
            

            if (!String.IsNullOrEmpty(shortname))
            {
                if (canRender)
                {
					var scheme = HttpContext.Current.Request.Url.Scheme;
                    scriptTagLiteral.Text = String.Format("<script type='text/javascript' src='{5}://{0}.disqus.com/top_commenters_widget.js?num_items={1}&hide_mods={2}&hide_avatars={3}&avatar_size={4}'></script>", shortname, this.NumberOfItems, this.HideModerators, this.HideAvatars, this.AvatarSize, scheme);        
                }
            }
            else
            {
                noShortNameLiteral.Text = "Disqus not yet globally configured.  Please set the shortname in the <strong>SitefinitySteve->Disqus</strong> Config settings <a href='/Sitefinity/Administration/Settings/Advanced' target='_blank'>here</a><br />";
            }

        }

        #region Properties
        private string _title = "Top Commenters";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        private bool _renderTitle = true;
        public bool RenderTitle {
            get {
                return _renderTitle;
            }
            set {
                _renderTitle = value;
            }
        }

        private string _titleTag = "h3";
        public string TitleTag {
            get {
                return _titleTag;
            }
            set {
                _titleTag = value;
            }
        }

        private string _shortName = String.Empty;
        public string ShortName
        {
            get
            {
                return _shortName;
            }
            set
            {
                _shortName = value;
            }
        }

        private int _avatarSize = 32;
        public int AvatarSize {
            get {
                return _avatarSize;
            }
            set {
                _avatarSize = value;
            }
        } 

        private int _numberOfItems = 5;
        public int NumberOfItems {
            get {
                return _numberOfItems;
            }
            set {
                _numberOfItems = value;
            }
        }

        private bool _hideAvatars = false;
        public bool HideAvatars {
            get {
                return _hideAvatars;
            }
            set {
                _hideAvatars = value;
            }
        }

        private bool _hideModerators = false;
        public bool HideModerators {
            get {
                return _hideModerators;
            }
            set {
                _hideModerators = value;
            }
        }

        /// <summary>
        /// Gets the layout template path
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Gets the layout template name
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return TopCommenters.layoutTemplatePath;
            }
        }
        #endregion

        #region Control References
        protected virtual Literal titleLiteral
        {
            get
            {
                return this.Container.GetControl<Literal>("titleLiteral", true);
            }
        }
        
        protected virtual Literal noShortNameLiteral
        {
            get
            {
                return this.Container.GetControl<Literal>("noShortNameLiteral", true);
            }
        }

        protected virtual Literal scriptTagLiteral
        {
            get
            {
                return this.Container.GetControl<Literal>("scriptTagLiteral", true);
            }
        }

        protected virtual Panel disqusWrapper
        {
            get
            {
                return this.Container.GetControl<Panel>("disqusWrapper", true);
            }
        }

        protected virtual Panel disqusDesignMode
        {
            get
            {
                return this.Container.GetControl<Panel>("disqusDesignMode", true);
            }
        }

        
        #endregion


        #region Private members & constants
        public static readonly string layoutTemplatePath = "RandomSiteControls.Disqus.TopCommenters.TopCommenters.ascx";
        #endregion
    }
}
