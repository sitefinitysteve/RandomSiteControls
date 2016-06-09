<%@ Control Language="C#" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %>

<sitefinity:ResourceLinks runat="server" UseEmbeddedThemes="true" Theme="Basic">
    <sitefinity:resourcefile javascriptlibrary="JQuery" />
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.kendo.all.min.js" Static="True" />
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_common_min.css" Static="True" />
    <sitefinity:ResourceFile Name="RandomSiteControls.Common.common.min.js" AssemblyInfo="RandomSiteControls.TabStrip.TabStripLayout, RandomSiteControls" Static="True" />
    <sitefinity:ResourceFile Name="RandomSiteControls.Common.Designer.min.css" AssemblyInfo="RandomSiteControls.TabStrip.TabStripLayout, RandomSiteControls" Static="True" />
    <sitefinity:ResourceFile Name="RandomSiteControls.KendoTabStrip.Resources.KendoTabStrip.js" AssemblyInfo="RandomSiteControls.TabStrip.TabStripLayout, RandomSiteControls" Static="True" />
</sitefinity:ResourceLinks>


<telerik:RadListView id="tabStripListView" runat="server" EnableEmbeddedBaseStylesheet="false" EnableEmbeddedSkins="false" ItemPlaceholderID="itemTemplate" EnableViewState="false">
    <LayoutTemplate>
        <ul class="kendo-tabstrip" runat="server" style="visibility:hidden">
            <asp:PlaceHolder ID="itemTemplate" runat="server" />
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li data-css='<%# Eval("CssClass") %>'><%# Eval("Text") %></li>    
    </ItemTemplate>
</telerik:RadListView>
