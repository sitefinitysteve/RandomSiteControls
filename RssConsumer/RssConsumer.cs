using System;
using System.Linq;
using System.Net;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Caching;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Web.UI;
using System.Xml.XPath;

namespace RandomSiteControls.RssConsumer
{
    [ControlTemplateInfo(AreaName = "RssConsumer", ControlDisplayName = "RssConsumer"), Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(RandomSiteControls.RssConsumer.Designer.RssConsumerDesigner))]
    public class RssConsumer : SimpleView, ICustomWidgetVisualization
    {

        protected override void InitializeControls(GenericContainer container)
        {
            if (!String.IsNullOrEmpty(this.RssFeed))
            {
                rssListView.NeedDataSource += rssListView_NeedDataSource;
            }
        }

        #region Events
        protected void rssListView_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            string cacheKey = "SitefinitySteveRssConsumerFeed" + this.RssFeed.GetHashCode();
            XDocument doc = null;

            if (this.Cache.Contains(cacheKey)) {
                XDocument cachedFeed = (Cache.GetData(cacheKey)) as XDocument;

                doc = cachedFeed;
            }else {
                //Reload the cache
                HttpWebRequest rq = WebRequest.Create(this.RssFeed) as HttpWebRequest;
                rq.Timeout = this.RssFeedTimeoutSeconds * 1000;

                HttpWebResponse response = rq.GetResponse() as HttpWebResponse;
                XmlTextReader reader = new XmlTextReader(response.GetResponseStream());

                doc = XDocument.Load(reader);
                reader.Close();

                //Add to the cache
                this.Cache.Add(cacheKey,
                              doc,
                               Telerik.Microsoft.Practices.EnterpriseLibrary.Caching.CacheItemPriority.Normal,
                                null,
                                new Telerik.Microsoft.Practices.EnterpriseLibrary.Caching.Expirations.AbsoluteTime(TimeSpan.FromMinutes(this.CacheTimeoutMinutes)));
            }

            
            

            var elements = doc.XPathSelectElements(this.XPath);
            ((RadListView)sender).DataSource = elements.Take(this.Take);
        }
        #endregion

        #region Properties
        public virtual ICacheManager Cache
        {
            get
            {
                return SystemManager.GetCacheManager(CacheManagerInstance.Global);
            }
        }

        private string _xPath = "rss/channel/item";
        public string XPath
        {
            get { return _xPath; }
            set { _xPath = value; }
        }

        public string RssFeed { get; set; }

        private int _rssTimeout = 60;
        public int RssFeedTimeoutSeconds
        {
            get { return _rssTimeout; }
            set { _rssTimeout = value; }
        }

        private int _take = 6;
        public int Take
        {
            get { return _take; }
            set { _take = value; }
        }

        private int _cacheTimeoutMinutes = 30;
        public int CacheTimeoutMinutes {
            get { return _cacheTimeoutMinutes; }
            set { _cacheTimeoutMinutes = value; }
        }

        /// <summary>
        /// Gets the is empty.
        /// </summary>
        /// <value>The is empty.</value>
        public bool IsEmpty
        {
            get
            {
                return String.IsNullOrEmpty(this.RssFeed);
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
                return "Edit Rss Consumer";
            }
        }

        #endregion

        #region Layouts
        /// <summary>
        /// Obsolete. Use LayoutTemplatePath instead.
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the layout template's relative or virtual path.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    return RssConsumer.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }
        #endregion

        #region Control References
        protected virtual RadListView rssListView
        {
            get { return this.Container.GetControl<RadListView>("rssListView", true); }
        }

        #endregion

        #region Methods
        public static void RegisterWidgetTemplateForUI(){
            RandomSiteControls.Methods.Helpers.AddTemplate(RssConsumer.embeddedTemplatePath, typeof(RssConsumer), "RssConsumer", "Rss Consumer", "RssConsumer");
        }
        #endregion


        #region Private members & constants
        public static readonly string layoutTemplatePath = "~/SitefinitySteve/RandomSiteControls.RssConsumer.RssConsumer.ascx";
        public static readonly string embeddedTemplatePath = "RandomSiteControls.RssConsumer.RssConsumer.ascx";
        #endregion
    }
}
