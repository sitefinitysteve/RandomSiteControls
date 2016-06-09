<%@ Control Language="C#" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %>
<%@ Register TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI.PublicControls.BrowseAndEdit" Assembly="Telerik.Sitefinity" %>

<sitefinity:ResourceLinks runat="server" UseEmbeddedThemes="true" Theme="Basic">
    <sitefinity:ResourceFile Name="RandomSiteControls.Common.common.min.js" AssemblyInfo="RandomSiteControls.TabStrip.TabStripLayout, RandomSiteControls" Static="True" />
    <sitefinity:ResourceFile Name="RandomSiteControls.Common.Designer.min.css" AssemblyInfo="RandomSiteControls.TabStrip.TabStripLayout, RandomSiteControls" Static="True" />
    <sitefinity:ResourceFile Name="RandomSiteControls.TabStrip.Resources.TabStrip.min.css" AssemblyInfo="RandomSiteControls.TabStrip.TabStripLayout, RandomSiteControls" Static="True" />
    <sitefinity:ResourceFile Name="RandomSiteControls.TabStrip.Resources.TabStrip.js" AssemblyInfo="RandomSiteControls.TabStrip.TabStripLayout, RandomSiteControls" Static="True" />
</sitefinity:ResourceLinks>

<telerik:RadTabStrip id="tabStripControl" runat="server" Skin="Metro" EnableViewState="True" OnClientLoad="onSSTabStripLoad" OnClientTabSelected="onSSTabSelected" >
    <Tabs>
        <telerik:RadTab text="Tab1" Selected="True" />
    </Tabs>
</telerik:RadTabStrip>
<asp:HiddenField ID="tabIndexState" runat="server" />