using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Web.UI;
using System.Diagnostics;

namespace RandomSiteControls.Common {
    public class SteveLayoutControlBase : LayoutControl{
        /// <summary>
        /// Loops through the toolbox node
        /// </summary>
        /// <param name="cssClass"></param>
        public void CheckToolboxIcon() {
            if (this.IsDesignMode() == true) {
                //REMOVED IN 5.1

                /*
                //Here's all my control namespaces to look for
                Dictionary<string, string> controls = new Dictionary<string, string>();
                controls.Add("RandomSiteControls.TabStrip.TabStripLayout", "sfsLayoutTabBoxIcon");
                controls.Add("RandomSiteControls.FancyBox.FancyBoxLayout", "sfsLayoutFancyBoxIcon");


                try {
                    var toolboxes = Telerik.Sitefinity.Configuration.Config.Get<ToolboxesConfig>().Toolboxes;
                    Telerik.Sitefinity.Modules.Pages.Configuration.Toolbox layouts = toolboxes.Values.FirstOrDefault(x => x.Name == "PageLayouts"); //Get to the layout area
                    
                    
                    //Loop through all the Tools in layout
                    foreach (var config in layouts.Sections[0].Tools)
                    {
                        /*ToolboxItem tool = config.Value;
                        //Check to see if any tools match the ones in the dictionary
                        foreach (var c in controls){
                            if (c.Key.ToLower() == tool.ControlType.ToLower()){
                                tool.CssClass = c.Value;		
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    Debug.WriteLine(ex.ToString());
                }
    */
            }
        }
    }
}
