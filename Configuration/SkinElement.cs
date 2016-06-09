using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Configuration;
using System.Configuration;
using Telerik.Sitefinity.Localization;

namespace RandomSiteControls.Configuration
{
    public class SkinElement : ConfigElement
    {
        public SkinElement(ConfigElement parent) : base(parent)
        {
        }

        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public String Name
        {
            get
            {
                return (String)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
    }
}
