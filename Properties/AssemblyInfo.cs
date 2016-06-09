using System.Web;
using RandomSiteControls;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web.UI;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("RandomSiteControls")]
[assembly: AssemblyDescription("steve@sitefinitysteve.com")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Sitefinity Steve")]
[assembly: AssemblyProduct("RandomSiteControls")]
[assembly: AssemblyCopyright("Copyright © Sitefinitysteve.com")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("55986538-1692-47cc-9006-96be47bf0657")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("9.0.6000.2")]
[assembly: AssemblyFileVersion("9.0.6000.2")]

//INSTALLER
[assembly: PreApplicationStartMethod(typeof(Installer), "PreApplicationStart")]

//COMMON
[assembly: WebResource("RandomSiteControls.Common.common.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.Common.common.min.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.Common.Designer.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("RandomSiteControls.Common.Designer.min.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("RandomSiteControls.Common.layouts.gif", "image/gif")]
[assembly: WebResource("RandomSiteControls.Common.controlicons.gif", "image/gif")]

//SQLGRID
[assembly: WebResource("RandomSiteControls.SqlGrid.Resources.SqlGridDesigner.js", "text/javascript")]

//PAGE TITLE
[assembly: WebResource("RandomSiteControls.PageTitle.Designer.PageTitleDesigner.js", "text/javascript")]

//TABSTRIP
[assembly: WebResource("RandomSiteControls.TabStrip.Resources.configurator.png", "image/png")]
[assembly: WebResource("RandomSiteControls.TabStrip.Resources.tabcontainer.png", "image/png")]
[assembly: WebResource("RandomSiteControls.TabStrip.Resources.tablayouts.png", "image/png")]
[assembly: WebResource("RandomSiteControls.TabStrip.Resources.TabStrip.min.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("RandomSiteControls.TabStrip.Resources.TabStrip.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("RandomSiteControls.TabStrip.Resources.TabStrip.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.TabStrip.Resources.TabStrip.min.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.TabStrip.Resources.tabstripcontainer.png", "image/png")]
[assembly: WebResource("RandomSiteControls.TabStrip.Resources.TabStripDesigner.js", "text/javascript")]
// TABSTRIP CONTAINER IMAGES
[assembly: WebResource("RandomSiteControls.TabStrip.Resources.horz-text.png", "image/png")]

//RadButton
[assembly: WebResource("RandomSiteControls.SFRadButton.Resources.SFRadButtonDesigner.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.SFRadButton.Resources.SFRadButton.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.SFRadButton.Resources.SFRadButton.min.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.SFRadButton.Resources.SFRadButtonDesigner.css", "text/css", PerformSubstitution = true)]

//Button
[assembly: WebResource("RandomSiteControls.Button.Resources.ButtonDesigner.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.Button.Resources.ButtonDesigner.css", "text/css", PerformSubstitution = true)]

//PageData
[assembly: WebResource("RandomSiteControls.PageData.Resources.PageDataDesigner.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.PageData.Resources.PageDataDesigner.css", "text/css", PerformSubstitution = true)]

//BackgroundImage
[assembly: WebResource("RandomSiteControls.BackgroundImage.Resources.BackgroundImage.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.BackgroundImage.Resources.BackgroundImageDesigner.js", "text/javascript")]

//Fancybox
[assembly: WebResource("RandomSiteControls.FancyBox.Resources.fancybox-steve-layout.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.FancyBox.Resources.fancybox-steve-layout.min.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.FancyBox.Resources.jquery.fancybox-1.3.8.min.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.FancyBox.Resources.fancybox-steve.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("RandomSiteControls.FancyBox.Resources.fancybox-steve.min.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("RandomSiteControls.FancyBox.Resources.fblayouts.gif", "image/gif")]
[assembly: WebResource("RandomSiteControls.FancyBox.Resources.close-icon.png", "image/png")]

//KendoTabStrip
[assembly: WebResource("RandomSiteControls.KendoTabStrip.Resources.KendoTabStrip.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.KendoTabStrip.Resources.KendoTabStrip.min.js", "text/javascript")]

//Codemirror
[assembly: WebResource("RandomSiteControls.Common.CodeMirror.closebrackets.js", "text/javascript")]

//Disqus
[assembly: WebResource("RandomSiteControls.Disqus.Comment.DisqusCommentBox.js", "text/javascript")]
[assembly: WebResource("RandomSiteControls.Disqus.Comment.DisqusCommentBox.min.js", "text/javascript")]

