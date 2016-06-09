using System;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;

namespace RandomSiteControls.Configuration
{
    public class ScriptStyleConfigElement : ConfigElement
    {
        public ScriptStyleConfigElement(ConfigElement parent)
            : base(parent)
        {
        }

        [ObjectInfo(Description = "Markup to apply before the description text", Title = "Description Markup")]
        [ConfigurationProperty("descriptionMarkup", IsRequired = true, IsKey = true, DefaultValue = "<i class='icon-beaker pull-left icon-large'></i>")]
        public string DescriptionMarkup
        {
            get
            {
                return (string)this["descriptionMarkup"];
            }
            set
            {
                this["descriptionMarkup"] = value;
            }
        }

    }
}
