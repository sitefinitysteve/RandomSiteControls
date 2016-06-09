using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web;
using System.Web.UI;

namespace RandomSiteControls.ErrorControl {
    public class HttpErrorStatusCode : CompositeControl
    {
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            if (this.IsDesignMode())
            {
                LiteralControl message = new LiteralControl();

                message.Text = "Page loads with status code: {0}".Arrange(this.StatusCode);

                this.Controls.Add(message);
            }
        }

        /// <summary>
        /// Status code with default value of 404. 
        /// </summary>
        private int _statusCode = 404;

        /// <summary>
        /// Gets or sets a value of the status code.
        /// </summary>
        public int StatusCode
        {
            set { this._statusCode = value; }
            get { return this._statusCode;  }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.IsBackend())
            {
                base.OnPreRender(e);
                HttpContext.Current.Response.StatusCode = this.StatusCode;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.RenderContents(writer);
        }
    }
}