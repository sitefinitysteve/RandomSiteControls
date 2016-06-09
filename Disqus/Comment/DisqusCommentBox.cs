using System;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using RandomSiteControls.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Model;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace RandomSiteControls.Disqus.Comment
{
    [ControlDesigner(typeof(RandomSiteControls.Disqus.Comment.Designer.DisqusCommentBoxDesigner)), PropertyEditorTitle("Disqus Comment Options")]
    public class DisqusCommentBox : SimpleView
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
                disqusWrapper.Visible = false;
            }
            else {
                disqusDesignMode.Visible = false;
                disqusWrapper.Visible = true;
            }


            if (!String.IsNullOrEmpty(this.ShortName))
            {
                shortname = this.ShortName;
            }


            if (!String.IsNullOrEmpty(shortname))
            {
                if (canRender)
                {
                    string properties = String.Empty;

                    if (this.Title != String.Empty)
                    {
                        properties += String.Format("var disqus_title = '{0}';", this.Title);
                    }

                    if (this.CategoryID != String.Empty)
                    {
                        properties += String.Format("var disqus_category_id = '{0}';", this.CategoryID);
                    }

                    if (this.Identifier != String.Empty)
                    {
                        properties += String.Format("var disqus_identifier = '{0}';", this.Identifier);
                    }

                    if (this.Url != String.Empty)
                    {
                        properties += String.Format("var disqus_url = '{0}';", this.Url);
                    }

                    properties += String.Format("var disqus_developer = {0};", (Config.Get<SitefinitySteveConfig>().Disqus.DeveloperMode == true) ? 1 : 0);


                    properties += String.Format("var disqus_shortname = '{0}'; ", shortname);

                    scriptStyleWidgetDisqusProperties.JavaScriptText = properties;
                }
            }
            else
            {
                noShortNameLiteral.Text = "Disqus not yet globally configured.  Please set the shortname in the <strong>SitefinitySteve->Disqus</strong> Config settings <a href='/Sitefinity/Administration/Settings/Advanced' target='_blank'>here</a><br />";
            }

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

		protected override void Render(HtmlTextWriter writer)
		{
			this.RenderContents(writer);
		}

        #region Properties
        private string _title = String.Empty;
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


        private string _categoryID = String.Empty;
        public string CategoryID
        {
            get
            {
                return _categoryID;
            }
            set
            {
                _categoryID = value;
            }
        }

        private string _identifier = String.Empty;
        public string Identifier
        {
            get
            {
                return _identifier;
            }
            set
            {
                _identifier = value;
            }
        }


        private string _url = String.Empty;
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
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
                return DisqusCommentBox.layoutTemplatePath;
            }
        }
        #endregion

        #region Control References
        protected virtual Literal noShortNameLiteral
        {
            get
            {
                return this.Container.GetControl<Literal>("noShortNameLiteral", true);
            }
        }

        protected virtual ScriptStyle scriptStyleWidgetDisqusProperties
        {
            get
            {
                return this.Container.GetControl<ScriptStyle>("scriptStyleWidgetDisqusProperties", true);
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

        protected virtual Literal titleLiteral
        {
            get
            {
                return this.Container.GetControl<Literal>("titleLiteral", true);
            }
        }

        protected virtual Literal developerLiteral
        {
            get
            {
                return this.Container.GetControl<Literal>("developerLiteral", true);
            }
        }

        protected virtual Literal shortNameLiteral
        {
            get
            {
                return this.Container.GetControl<Literal>("shortNameLiteral", true);
            }
        }

        protected virtual Literal categoryLiteral {
            get
            {
                return this.Container.GetControl<Literal>("categoryLiteral", true);
            }
        }

        protected virtual Literal identifierLiteral
        {
            get
            {
                return this.Container.GetControl<Literal>("identifierLiteral", true);
            }
        }

        protected virtual Literal urlLiteral
        {
            get
            {
                return this.Container.GetControl<Literal>("urlLiteral", true);
            }
        }
        #endregion


        #region Private members & constants
        public static readonly string layoutTemplatePath = "RandomSiteControls.Disqus.Comment.DisqusCommentBox.ascx";
        #endregion
    }
}
