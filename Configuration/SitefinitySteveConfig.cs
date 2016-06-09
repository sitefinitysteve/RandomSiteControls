using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Sitefinity.Configuration;
using System.Configuration;
using Telerik.Sitefinity.Localization;

namespace RandomSiteControls.Configuration
{
    public class SitefinitySteveConfig : ConfigSection
    {
        protected override void OnPropertiesInitialized()
        {
            base.OnPropertiesInitialized();
            this.PreLoadSkins();
            //this.AddThis.PreLoad();
        }

        [ConfigurationProperty("showSkinPicker", DefaultValue = false, IsRequired = true)]
        [ObjectInfo(Description = "Shows the combobox for the RadControls which support skinning", Title = "Allow Custom Skins")]
        public bool AllowCustomSkins
        {
            get
            {
                return (bool)this["showSkinPicker"];
            }
            set
            {
                this["showSkinPicker"] = value;
            }
        }

        [ConfigurationProperty("skin", DefaultValue = "Bootstrap", IsRequired = true)]
        [ObjectInfo(Description = "Default Skin", Title = "Skin")]
        public string Skin
        {
            get
            {
                return (string)this["skin"];
            }
            set
            {
                this["skin"] = value;
            }
        }

        [ConfigurationProperty("cacheTimeoutMinutes", DefaultValue = 20, IsRequired = true)]
        [ObjectInfo(Description = "Query Cache Timeout", Title = "Cache Timeout")]
        public int CacheTimeoutMinutes
        {
            get
            {
                return (int) this["cacheTimeoutMinutes"];
            }
            set
            {
                this["cacheTimeoutMinutes"] = value;
            }
        }

        [ConfigurationProperty("Skins")]
        public ConfigElementDictionary<string, SkinElement> Skins
        {
            get
            {
                return (ConfigElementDictionary<string, SkinElement>)this["Skins"];
            }
        }

        [ConfigurationProperty("HttpHeaderModule")]
        public HttpHeaderElement HttpHeaderModule
        {
            get
            {
                return (HttpHeaderElement)this["HttpHeaderModule"];
            }
        }

        [ConfigurationProperty("disqus")]
        public DisqusConfigElement Disqus
        {
            get
            {
                return (DisqusConfigElement)this["disqus"];
            }
            set
            {
                this["disqus"] = value;
            }
        }
        /*
        [ConfigurationProperty("placeholder")]
        public PlaceholderConfigElement PlaceHolder
        {
            get
            {
                return (PlaceholderConfigElement)this["placeholder"];
            }
            set
            {
                this["placeholder"] = value;
            }
        }
        */


        [ConfigurationProperty("scriptstyle")]
        public ScriptStyleConfigElement ScriptStyle
        {
            get
            {
                return (ScriptStyleConfigElement)this["scriptstyle"];
            }
            set
            {
                this["scriptstyle"] = value;
            }
        }

        [ConfigurationProperty("ContentLiteral")]
        public ContentLiteralConfigElement ContentLiteral
        {
            get
            {
                return (ContentLiteralConfigElement)this["ContentLiteral"];
            }
            set
            {
                this["ContentLiteral"] = value;
            }
        }

        [ConfigurationProperty("freshdeskElement")]
        public FreshdeskElement FreshdeskElement
        {
            get
            {
                return (FreshdeskElement)this["freshdeskElement"];
            }
            set
            {
                this["freshdeskElement"] = value;
            }
        }

        /*
        [ConfigurationProperty("AddThis")]
        public AddThisConfigElement AddThis
        {
            get
            {
                return (AddThisConfigElement)this["AddThis"];
            }
            set
            {
                this["AddThis"] = value;
            }
        }*/
        /// <summary>
        /// Test Method to preload the skins
        /// </summary>
        public void PreLoadSkins()
        {
            //ConfigManager manager = ConfigManager.GetManager();
            //var config = manager.GetSection<SitefinitySteveConfig>();

            foreach (string skin in Enum.GetNames(typeof(SkinEnum)))
            {
                bool canAdd = true;

                //Check for duplicate
                foreach (var c in this.Skins)
                {
                    if (skin.ToLower() == ((SkinElement)c).Name.ToLower())
                    {
                        canAdd = false;
                    }
                }

                if (canAdd)
                {
                    this.Skins.Add(new SkinElement(this.Skins)
                    {
                        Name = skin
                    });
                }
            }

            //manager.SaveSection(this);
        }

        /// <summary>
        /// Makes control templates editable in the Sitefinity UI
        /// </summary>
        public static void RegisterTemplates()
        {
            RandomSiteControls.RssConsumer.RssConsumer.RegisterWidgetTemplateForUI();
        }
    }
}
