using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI;
using RandomSiteControls.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Web.UI;
using System.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data.Configuration;
using System.Diagnostics;
using Telerik.Sitefinity.Modules.Pages.Configuration;


namespace RandomSiteControls.Common {
    public class SteveControlDesignerBase : ControlDesignerBase {
        /// <summary>
        /// Loops through the toolbox node
        /// </summary>
        /// <param name="cssClass"></param>
        public void CheckToolboxIcon() {
            /*
            if (this.IsDesignMode() == true) {
                //Here's all my control namespaces to look for
                Dictionary<string, string> controls = new Dictionary<string, string>();
                controls.Add("RandomSiteControls.TabStrip.TabStripConfigurator", "sfsControlTabStripConfiguratorIcon");
                controls.Add("RandomSiteControls.SqlGrid.SqlGrid", "sfsControlSqlGridIcon");
                controls.Add("RandomSiteControls.Button.Button", "sfsControlButtonIcon");
                controls.Add("RandomSiteControls.BackgroundImage.BackgroundImage", "sfsControlBackgroundImageIcon");


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
             * */
        }
        
        
        protected override void InitializeControls(GenericContainer container) {

            //Load in the Designer styles
            //this.CheckToolboxIcon();
        }

        protected override string LayoutTemplateName {
            get { throw new NotImplementedException(); }
        }

        protected override HtmlTextWriterTag TagKey {
            get { //Use div wrapper tag to make easier common styling. This will surround the layout template with a div tag. 
                return HtmlTextWriterTag.Div;
            }
        }

        private SitefinitySteveConfig _userConfig = null;
        public SitefinitySteveConfig UserConfig
        {
            get
            {
                if (_userConfig == null)
                {
                    _userConfig = Config.Get<SitefinitySteveConfig>();
                }

                return _userConfig;
            }
        }

    }
}
