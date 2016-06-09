using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Modules.Pages.Configuration;

namespace RandomSiteControls
{

    public static class Installer
    {
        /// <summary>
        /// This is the actual method that is called by ASP.NET even before application start. Sweet!
        /// </summary>
        public static void PreApplicationStart()
        {
            // With this method we subscribe for the Sitefinity Bootstrapper_Initialized event, which is fired after initialization of the Sitefinity application
            Bootstrapper.Initialized += (new EventHandler<ExecutedEventArgs>(Installer.Bootstrapper_Initialized));
        }

        public static void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {
            Telerik.Sitefinity.Configuration.Config.RegisterSection<RandomSiteControls.Configuration.SitefinitySteveConfig>();

            //Add Tools
            InstallVirtualPaths(); // See that method for VIRTUAL PATHS installation code
            InstallWidgets(); // See that method for WIDGET installation code
            InstallLayouts(); // See that method for WIDGET installation code
        }

        private static void InstallVirtualPaths()
        {
            SiteInitializer initializer = SiteInitializer.GetInitializer();
            var virtualPathConfig = initializer.Context.GetConfig<VirtualPathSettingsConfig>();

            string key = "~/SitefinitySteve/*";
            if (!virtualPathConfig.VirtualPaths.ContainsKey(key))
            {
                var newVirtualPathNode = new VirtualPathElement(virtualPathConfig.VirtualPaths)
                {
                    VirtualPath = key,
                    ResolverName = "EmbeddedResourceResolver",
                    ResourceLocation = "RandomSiteControls"
                };

                virtualPathConfig.VirtualPaths.Add(newVirtualPathNode);
                Config.GetManager().SaveSection(virtualPathConfig);
            }
        }

        private static void InstallWidgets()
        {
            ConfigManager manager = Config.GetManager();
            var config = manager.GetSection<ToolboxesConfig>();
            var pageControls = config.Toolboxes["PageControls"];
            var pageTitleSection = pageControls
                .Sections
                .Where<ToolboxSection>(tb => tb.Name == ToolboxesConfig.ContentToolboxSectionName)
                .FirstOrDefault();

            RegisterTool("TabStripConfigurator",
                         "TabStripConfigurator",
                         "Tabstrip Tabs widget, only use inside of the tabstrip layout control",
                         "sfsControlTabStripConfiguratorIcon",
                         "RandomSiteControls.TabStrip.TabStripConfigurator, RandomSiteControls",
                         pageTitleSection, config, manager);

            RegisterTool("ContentLiteral",
                         "Content Literal",
                         "Content Literal",
                         "sfContentBlockIcn",
                         "RandomSiteControls.ContentLiteral.ContentLiteral, RandomSiteControls",
                         pageTitleSection, config, manager);

            RegisterTool("DocumentFolderList",
                         "Document Folder List",
                         "Document Folder List",
                         "sfListitemsIcn",
                         "RandomSiteControls.DocumentFolderList.DocumentFolderList, RandomSiteControls",
                         pageTitleSection, config, manager);

            RegisterTool("Placeholder",
                         "Placeholder",
                         "Placeholder",
                         "sfImageViewIcn",
                         "RandomSiteControls.Placeholder.Placeholder, RandomSiteControls",
                         pageTitleSection, config, manager);

            var scriptSection = pageControls
                 .Sections
                 .Where<ToolboxSection>(tb => tb.Name == "ScriptsAndStylesControlsSection")
                 .FirstOrDefault();

            RegisterTool("ScriptStyle",
                         "JavaScript And Css",
                         "ScriptStyle",
                         "sfLinkedFileViewIcn",
                         "RandomSiteControls.ScriptStyle",
                         scriptSection, config, manager);


            var mySection = pageControls.Sections.Where<ToolboxSection>(e => e.Name == "Random").FirstOrDefault();
            if (mySection == null)
            {
                mySection = new ToolboxSection(pageControls.Sections)
                {
                    Name = "Random",
                    Title = "Random Widgets",
                    Description = "https://www.sitefinitysteve.com widgets"
                };
                pageControls.Sections.Add(mySection);
            }

            RegisterTool("HttpErrorStatusCode",
                         "Http Error Status Code",
                         "Http Error Status Code",
                         "sfLinkedFileViewIcn",
                         "RandomSiteControls.ErrorControl.HttpErrorStatusCode",
                         mySection, config, manager);

            RegisterTool("sfContentBlockIcn",
                         "Page Title",
                         "Page Title",
                         "sfImageViewIcn",
                         "RandomSiteControls.PageTitle.PageTitle",
                         mySection, config, manager);

            var disqusSection = pageControls.Sections.Where<ToolboxSection>(e => e.Name == "Disqus").FirstOrDefault();
            if (disqusSection == null)
            {
                disqusSection = new ToolboxSection(pageControls.Sections)
                {
                    Name = "Disqus",
                    Title = "Disqus Widgets",
                    Enabled = false
                };
                pageControls.Sections.Add(disqusSection);
            }

            RegisterTool("DisqusCommentBox",
                         "Comment Box",
                         "Comment Box",
                         "sfForumsViewIcn",
                         "RandomSiteControls.Disqus.Comment.DisqusCommentBox",
                         disqusSection, config, manager);

            RegisterTool("DisqusCombination",
                         "Combination",
                         "Combination",
                         "sfListitemsIcn",
                         "RandomSiteControls.Disqus.Combination.DisqusCombination",
                         disqusSection, config, manager);

             RegisterTool("RecentComments",
                         "Recent Comments",
                         "Recent Comments",
                         "sfListitemsIcn",
                         "RandomSiteControls.Disqus.RecentComments.RecentComments",
                         disqusSection, config, manager);

             RegisterTool("PopularThreads",
                         "Popular Threads",
                         "Popular Threads",
                         "sfListitemsIcn",
                         "RandomSiteControls.Disqus.PopularThreads.PopularThreads",
                         disqusSection, config, manager);

             RegisterTool("TopCommenters",
                         "Top Commenters",
                         "Top Commenters",
                         "sfListitemsIcn",
                         "RandomSiteControls.Disqus.TopCommenters.TopCommenters",
                         disqusSection, config, manager);
        }

        private static void RegisterTool(string name, string title, string description, string cssClass, string type, ToolboxSection section, ToolboxesConfig config, ConfigManager manager)
        {
            if (!section.Tools.Any<ToolboxItem>(av => av.Name == name))
            {
                var tool = new ToolboxItem(section.Tools)
                {
                    Name = name,
                    Title = title,
                    Description = description,
                    CssClass = cssClass,
                    ResourceClassId = "",
                    ControlType = type
                };
                section.Tools.Add(tool);
                manager.SaveSection(config);
            }
        }

        private static void InstallLayouts()
        {
            ConfigManager manager = Config.GetManager();
            manager.Provider.SuppressSecurityChecks = true;
            var config = manager.GetSection<ToolboxesConfig>();
            var layouts = config.Toolboxes["PageLayouts"];
            foreach (var s in layouts.Sections) {
                Debug.WriteLine(s); ;
            }

            var section = layouts
                            .Sections
                            .Where<ToolboxSection>(tb => tb.Name == "Controls")
                            .FirstOrDefault();

            if (section == null)
            {
                section = new ToolboxSection(layouts.Sections)
                {
                    Name = "Controls",
                    Title = "Controls",
                    Description = "Controls"
                };
                layouts.Sections.Add(section);

                manager.SaveSection(config);
            }

            if (!section.Tools.Any<ToolboxItem>(e => e.Name == "TabStrip"))
            {
                var tool = new ToolboxItem(section.Tools)
                {
                    Name = "TabStrip",
                    Title = "TabStrip",
                    Description = "Renders the parent child layouts as a RadTabStrip",
                    ControlType = "RandomSiteControls.TabStrip.TabStripLayout",
                    CssClass = "sfsLayoutTabBoxIcon"
                };
                section.Tools.Add(tool);
            }

            if (!section.Tools.Any<ToolboxItem>(e => e.Name == "TabStripVertical"))
            {
                var tool = new ToolboxItem(section.Tools)
                {
                    Name = "TabStripVertical",
                    Title = "TabStrip Vertical",
                    Description = "Renders the parent child layouts as a RadTabStrip",
                    ControlType = "RandomSiteControls.TabStrip.TabStripVerticalLayout",
                    CssClass = "sfsLayoutTabBoxIcon"
                };
                section.Tools.Add(tool);
            }

            if (!section.Tools.Any<ToolboxItem>(e => e.Name == "FancyBox"))
            {
                var tool = new ToolboxItem(section.Tools)
                {
                    Name = "FancyBox",
                    Title = "FancyBox Popup",
                    Description = "Build a popup from the Sitefinity UI",
                    ControlType = "RandomSiteControls.FancyBox.FancyBoxLayout",
                    CssClass = "sfsLayoutFancyBoxIcon"
                };
                section.Tools.Add(tool);
            }

            manager.SaveSection(config);
            manager.Provider.SuppressSecurityChecks = false;
        }


    }

}
