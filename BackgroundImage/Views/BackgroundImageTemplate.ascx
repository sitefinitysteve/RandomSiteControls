<%@ Control Language="C#" %>
<%@ Register TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register TagPrefix="Telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %> 

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server"> 
    <sitefinity:ResourceFile Name="RandomSiteControls.Common.common.js" AssemblyInfo="RandomSiteControls.BackgroundImage.BackgroundImage, RandomSiteControls" Static="True" />
    <sitefinity:ResourceFile Name="RandomSiteControls.Common.Designer.css" AssemblyInfo="RandomSiteControls.BackgroundImage.BackgroundImage, RandomSiteControls" Static="True" />
    <sitefinity:ResourceFile Name="RandomSiteControls.BackgroundImage.Resources.BackgroundImage.js" AssemblyInfo="RandomSiteControls.BackgroundImage.BackgroundImage, RandomSiteControls" Static="True" />
</sitefinity:ResourceLinks>     

<asp:HiddenField ID="backgroundImageHiddenField" ClientIDMode="AutoID" runat="server" EnableViewState="false" />