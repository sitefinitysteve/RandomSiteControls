using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Logging;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Modules.Forms;
using Telerik.Sitefinity.Modules.Forms.Web.UI;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields;
using Telerik.Web.UI;

namespace RandomSiteControls.Forms {
    /// <summary>
    /// This is obsolete, should be replaced native in 6.2
    /// </summary>
    public class FormCaptcha : FormsControl
    {
        protected override void InitializeControls(GenericContainer container)
        {
            if (!SystemManager.IsDesignMode)
            {
                //Hide the form if JS is disabled, it'll let them bypass the required fields.
                base.InitializeControls(container);
                this.BeforeFormSave += new EventHandler<CancelEventArgs>(FormsControlCustom_BeforeFormSave);
            }
        }


        #region EVENTS
        protected void FormsControlCustom_BeforeFormSave(object sender, CancelEventArgs e)
        {
            if (this.MyCaptcha != null)
            {
                if (!this.MyCaptcha.IsValid)
                {
                    e.Cancel = true;
                    this.MyCaptcha.ErrorMessage = this.CaptchaErrorMessage;
                }
            }
        }

        #endregion

        #region METHODS

        #endregion

        #region Properties
        private RadCaptcha _captcha = null;
        protected RadCaptcha MyCaptcha
        {
            get
            {
                if (!SystemManager.IsDesignMode)
                {
                    foreach (var control in this.FormControls.Controls[1].Controls)
                    {
                        if (control.GetType() == typeof(RadCaptcha))
                        {
                            _captcha = control as RadCaptcha;
                            break;
                        }
                    }
                }

                return _captcha;
            }
        }

        private string _captchaErrorMessage = "Invalid Code, please try again";
        /// <summary>
        /// This gets edited in advanced mode
        /// </summary>
        public string CaptchaErrorMessage
        {

            get
            {
                return _captchaErrorMessage;
            }
            set
            {
                _captchaErrorMessage = value;
            }
        }
        #endregion
    }
}
