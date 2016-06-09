using System;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;

namespace RandomSiteControls.Configuration
{
    public class ContentLiteralConfigElement : ConfigElement
    {
        public ContentLiteralConfigElement(ConfigElement parent)
            : base(parent)
        {
        }
        /*
        [ObjectInfo(Description = "Globally encodes script tags in the controls", Title = "Encode Script tags on render")]
        [ConfigurationProperty("preventScriptTags", IsRequired = true, IsKey = true, DefaultValue = false)]
        public bool PreventScriptTags
        {
            get
            {
                return (bool)this["preventScriptTags"];
            }
            set
            {
                this["preventScriptTags"] = value;
            }
        }
        */
        [ObjectInfo(Description = "Appends the sfContentBlock class in a wrapped div", Title = "Wrap all literals")]
        [ConfigurationProperty("wrapLiterals", IsRequired = true, IsKey = true, DefaultValue = false)]
        public bool WrapLiteralAsContentBlock
        {
            get
            {
                return (bool)this["wrapLiterals"];
            }
            set
            {
                this["wrapLiterals"] = value;
            }
        }

    }
}
