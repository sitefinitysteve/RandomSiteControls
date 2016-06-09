<%@ Control Language="C#" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Sitefinity.Web.UI.PublicControls" Assembly="Telerik.Sitefinity" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %>
<%@ Register TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI.PublicControls.BrowseAndEdit" Assembly="Telerik.Sitefinity" %>

<sitefinity:ResourceLinks id="resourcesLinksStyles" runat="server" UseEmbeddedThemes="true" Theme="Basic">
  <sitefinity:ResourceFile Name="RandomSiteControls.DocumentFolderList.Resources.DocumentFolderList.min.css" AssemblyInfo="RandomSiteControls.DocumentFolderList.DocumentFolderList, RandomSiteControls" Static="True" />
  <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Themes.Basic.Styles.icons.css" Static="true" />
</sitefinity:ResourceLinks>

<sitefinity:ResourceLinks id="resourcesLinksScripts" runat="server" UseEmbeddedThemes="true" Theme="Basic">
    <sitefinity:ResourceFile JavaScriptLibrary="JQuery"/>
    <sitefinity:ResourceFile Name="RandomSiteControls.DocumentFolderList.Resources.DocumentFolderList.min.js" AssemblyInfo="RandomSiteControls.DocumentFolderList.DocumentFolderList, RandomSiteControls" Static="True" />
</sitefinity:ResourceLinks>

<asp:Panel id="documentFolderList" runat="server" EnableViewState="false">
    <telerik:RadTreeView ID="treeview" runat="server" ExpandAnimation-Type="None" CollapseAnimation-Type="None" CssClass="sfdownloadList sfListMode" EnableViewState="false">
    </telerik:RadTreeView>
</asp:Panel>

