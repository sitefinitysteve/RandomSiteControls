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

namespace RandomSiteControls.Disqus.PopularThreads
{
    [ControlDesigner(typeof(RandomSiteControls.Disqus.PopularThreads.Designer.PopularThreadsDesigner)), PropertyEditorTitle("Disqus Popular Threads Options")]
    public class PopularThreads : SimpleView
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
                    scriptTagLiteral.Text = String.Format("<script type='text/javascript' src='{2}://{0}.disqus.com/popular_threads_widget.js?num_items={1}'></script>", shortname, this.NumberOfItems, HttpContext.Current.Request.Url.Scheme);        
                }
            }
            else
            {
                noShortNameLiteral.Text = "Disqus not yet globally configured.  Please set the shortname in the <strong>SitefinitySteve->Disqus</strong> Config settings <a href='/Sitefinity/Administration/Settings/Advanced' target='_blank'>here</a><br />";
            }

        }

        #region Properties
        private string _title =  "Popular Threads";
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
        public bool RenderTitle
        {
            get
            {
                return _renderTitle;
            }
            set
            {
                _renderTitle = value;
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

        private string _titleTag = "h3";
        public string TitleTag
        {
            get
            {
                return _titleTag;
            }
            set
            {
                _titleTag = value;
            }
        }

        private int _numberOfItems = 5;
        public int NumberOfItems
        {
            get
            {
                return _numberOfItems;
            }
            set
            {
                _numberOfItems = value;
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
                return PopularThreads.layoutTemplatePath;
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
        public static readonly string layoutTemplatePath = "RandomSiteControls.Disqus.PopularThreads.PopularThreads.ascx";
        #endregion
    }
}
