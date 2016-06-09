using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Security;
using Telerik.Sitefinity.Security.Claims;
using Telerik.Sitefinity.Security.Model;
using Telerik.Sitefinity.Web;

namespace RandomSiteControls.Methods
{
    public static class Helpers
    {
        /// <summary>
        /// Gets the current page node and converts the pages to css classes, useful on the body element
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use RandomSiteControlsUtil", false)]
        public static string GetCurrentPageNodeAsClasses(){
            string css = String.Empty;
            var currentPage = SitefinitySiteMap.GetActualCurrentNode();
            if (currentPage != null)
            {
                css =  " " + currentPage.Url.TrimStart('~', '/').Replace("'", "").Replace("<", "").Replace(">", "").Replace("\"", "").Replace("/", " ");
            }

            return css;
        }

        /// <summary>
        /// Creates a Canonical Url
        /// </summary>
        [Obsolete("Use RandomSiteControlsUtil", false)]
        public static void CreateCanonical(Page page, string url)
        {
            HtmlLink seoTag = new HtmlLink();
            seoTag.Attributes.Add("rel", "canonical");
            seoTag.Href = url;

            page.Header.Controls.Add(seoTag);
        }

        /// <summary>
        /// Set the meta Description
        /// </summary>
        [Obsolete("Use RandomSiteControlsUtil", false)]
        public static void CreateMetaDescription(Page page, string text)
        {
            page.MetaDescription = text;
        }

        /// <summary>
        /// Set the meta Description
        /// </summary>
        [Obsolete("Use RandomSiteControlsUtil", false)]
        public static void CreateMetaKeywords(Page page, string text)
        {
            page.MetaKeywords = text;
        }

        /// <summary>
        /// This is the code which will add a template to the Sitefinity Backend Template UI
        /// </summary>
        /// <param name="embeddedTemplatePath">Path without the Virtual Node, ex: RandomSiteControls.RssConsumer.RssConsumer.ascx</param>
        /// <param name="type">Type of the widget</param>
        /// <param name="name">Name</param>
        /// <param name="friendlyName">Easier to read name</param>
        /// <param name="areaName">Section Group</param>
        [Obsolete("Use RandomSiteControlsUtil", false)]
        public static void AddTemplate(string embeddedTemplatePath, Type type, string name, string friendlyName, string areaName)
        {
            var initalizer = SiteInitializer.GetInitializer();
            var manager = initalizer.PageManager;

            var existingTemplate = manager.GetPresentationItems<ControlPresentation>().Where(p =>
                    p.EmbeddedTemplateName == embeddedTemplatePath &&
                    p.ControlType == type.FullName &&
                    p.Name == name)
                    .SingleOrDefault();

            if (existingTemplate == null)
            {

                initalizer.RegisterControlTemplate(
                        embeddedTemplatePath,
                        type.FullName,
                        name,
                        null,
                        areaName,
                        "ASP_NET_TEMPLATE",
                        type.Assembly.FullName,
                        friendlyName
                        );

                initalizer.SaveChanges();
            }
        }

        [Obsolete("Use RandomSiteControlsUtil", false)]
        public static User GetCurrentUser(string provider = "")
        {
            var identity = ClaimsManager.GetCurrentIdentity();
            //var currentUserID = SecurityManager.GetCurrentUserId();
            var user = UserManager.GetManager(provider).GetUser(identity.UserId);

            return user;
        }


    }
}
