<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
    <sitefinity:ResourceFile JavaScriptLibrary="JQuery" />
    <sitefinity:ResourceFile JavaScriptLibrary="KendoWeb" />
</sitefinity:ResourceLinks>

<sitefinity:ResourceLinks id="ResourceLinks1" runat="server" UseEmbeddedThemes="true" Theme="Default">
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_common_min.css" Static="True" />
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_default_min.css" Static="True" />
</sitefinity:ResourceLinks>

<div id="designerLayoutRoot" class="sfContentViews sfSingleContentView" style="max-height: 400px; overflow: auto; ">
    <ul>        
        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="RssFeed" CssClass="sfTxtLbl">Feed Url</asp:Label>
            <asp:TextBox ID="RssFeed" runat="server" CssClass="k-textbox"  ClientIDMode="Static" Width="352px" />
            <div class="sfExample">Url of the XML feed</div>
        </li>
        <li class="sfFormCtrl">
            <label class="sfTxtLbl" for="Take">Count</label>
            <input ID="Take"  type="text" />
            
            <div class="sfExample">Max items to show</div>
        </li>    
        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="XPath" CssClass="sfTxtLbl">XPath</asp:Label>
            <asp:TextBox ID="XPath" runat="server" CssClass="k-textbox"  ClientIDMode="Static" />
            <div class="sfExample">Path the elements</div>
        </li>
    </ul>
</div>
