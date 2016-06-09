using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RandomSiteControls.Configuration;
using RandomSiteControls.Methods;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Configuration;
using System.Text;
using System.Security.Cryptography;
using Telerik.Sitefinity.Security.Claims;

namespace RandomSiteControls.SSO.Freshdesk {
    public static class Freshdesk
    {
        public static void GotoHelpLogin()
        {
            var config = Config.Get<SitefinitySteveConfig>();
            if (ClaimsManager.GetCurrentIdentity().IsAuthenticated)
            {
                var user = RandomSiteControlsUtil.GetCurrentUser();
                var username = user.UserName;
                var email = user.Email;
                string timems = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                var hash = GetHash(config.FreshdeskElement.Key, username, email, timems);
                var path = String.Format(config.FreshdeskElement.Url, HttpContext.Current.Server.UrlEncode(username), HttpContext.Current.Server.UrlEncode(email), timems, hash);

                HttpContext.Current.Response.Redirect(path);
            }else{
                HttpContext.Current.Response.Redirect("~/login?ReturnUrl=http://{0}/login/freshdesk".Arrange(HttpContext.Current.Request.Url.Host), true);
            }
        }


        private static string GetHash(string secret, string name, string email, string timems)
        {
            string input = name + email + timems;
            var keybytes = Encoding.Default.GetBytes(secret);
            var inputBytes = Encoding.Default.GetBytes(input);

            var crypto = new HMACMD5(keybytes);
            byte[] hash = crypto.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                string hexValue = b.ToString("X").ToLower(); // Lowercase for compatibility on case-sensitive systems
                sb.Append((hexValue.Length == 1 ? "0" : "") + hexValue);
            }
            return sb.ToString();
        }
    }
}