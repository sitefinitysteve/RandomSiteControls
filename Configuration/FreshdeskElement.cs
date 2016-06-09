using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;

namespace RandomSiteControls.Configuration {
    public class FreshdeskElement : ConfigElement
    {
        public FreshdeskElement(ConfigElement parent)
            : base(parent)
        {
        }

        [ObjectInfo(Title = "Url", Description = "Url of the freskdesk sso login")]
        [ConfigurationProperty("url", IsRequired = true, DefaultValue = "http://yoursite.freshdesk.com/login/sso?name={0}&email={1}&timestamp={2}&hash={3}")]
        public string Url
        {
            get
            {
                return (string)this["url"];
            }
            set
            {
                this["url"] = value;
            }
        }

        [ObjectInfo(Title = "Key")]
        [ConfigurationProperty("key", IsRequired = true, DefaultValue = "")]
        public string Key
        {
            get
            {
                return (string)this["key"];
            }
            set
            {
                this["key"] = value;
            }
        }

    }
}