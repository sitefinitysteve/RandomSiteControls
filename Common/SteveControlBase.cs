using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Web.UI;
using System.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data.Configuration;
using System.Diagnostics;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using RandomSiteControls.Configuration;


namespace RandomSiteControls.Common {
    public class SteveControlBase : SimpleView {
        /// <summary>
        /// Loops through the toolbox node
        /// </summary>
        /// <param name="cssClass"></param>
        public void CheckToolboxIcon() {
            /*if (this.IsDesignMode() == true) {
                //Here's all my control namespaces to look for
                Dictionary<string, string> controls = new Dictionary<string, string>();
                controls.Add("RandomSiteControls.TabStrip.TabStripConfigurator", "sfsControlTabStripConfiguratorIcon");
                controls.Add("RandomSiteControls.SqlGrid.SqlGrid", "sfsControlSqlGridIcon");
                controls.Add("RandomSiteControls.Button.Button", "sfsControlButtonIcon");
                controls.Add("RandomSiteControls.BackgroundImage.BackgroundImage", "sfsControlBackgroundImageIcon");
                controls.Add("RandomSiteControls.FancyBox.FancyBoxScripts", "sfsControlFancyBoxScripts");

                try {
                    var toolboxes = Telerik.Sitefinity.Configuration.Config.Get<ToolboxesConfig>().Toolboxes;
                    var layouts = toolboxes.Values.FirstOrDefault(x => x.Name == "PageControls"); //Get to the layout area

                    //Loop through all the Tools in layout
                    foreach (var config in layouts.Tools) {
                        ToolboxItem tool = config.Value;
                        //Check to see if any tools match the ones in the dictionary
                        foreach (var c in controls) {
                            if (c.Key.ToLower() == tool.ControlType.ToLower()) {
                                tool.CssClass = c.Value;
                            }
                        }
                    }
                } catch (Exception ex) {
                }
            }
             * 

            //Add in the ResourceLinkControl
            ResourceLinks resLink = new ResourceLinks();
            ResourceFile file = new ResourceFile();
            file.AssemblyInfo = "RandomSiteControls.FancyBox.FancyBoxLayout, RandomSiteControls";
            file.Name = "RandomSiteControls.Common.Designer.css";
            file.Static = true;

            resLink.Links.Add(file);
            this.Controls.Add(resLink);*/
        }

        protected override void InitializeControls(GenericContainer container) {
            //this.CheckToolboxIcon();

        }

        
        public bool ShowSkinPicker
        {
            get
            {
                //return (ConfigurationManager.AppSettings["SitefinitySteveSkin"] == null) ? true : false;
                return this.UserConfig.AllowCustomSkins;
            }
        }

        private SitefinitySteveConfig _userConfig = null;
        public SitefinitySteveConfig UserConfig{
            get{
                if (_userConfig == null)
                {
                    _userConfig = Config.Get<SitefinitySteveConfig>();
                }

                return _userConfig;
            }
        }

        protected override string LayoutTemplateName {
            get {
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
        }
    }
}
