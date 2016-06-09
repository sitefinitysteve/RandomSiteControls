using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace RandomSiteControls.Breadcrumb
{
    public class CleanBreadcrumb : Telerik.Sitefinity.Web.UI.NavigationControls.Breadcrumb.Breadcrumb
    {
        protected override void CreateChildControls()
        {
            base.CreateChildControls();


        }

        /// <summary>
        /// Public Collection of Nodes
        /// </summary>
        public RadSiteMapNodeCollection Nodes
        {
            get
            {
                return this.SiteMapBreadcrumb.Nodes;
            }
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            writer.Write("<ol class='clean-breadcrumb breadcrumb'>");
            foreach (RadSiteMapNode node in this.SiteMapBreadcrumb.Nodes)
            {
                var url = node.NavigateUrl;
                if (node.NavigateUrl.StartsWith("~"))
                    url = System.Web.VirtualPathUtility.ToAbsolute(node.NavigateUrl);


                writer.Write(@"<li class='{2}'>
                                <a href='{0}'>{1}</a>
                               </li>".Arrange(url, node.Text, (node.Selected) ? "selected active" : ""));
            }
            writer.Write("</ol>");
        }
    }
}
