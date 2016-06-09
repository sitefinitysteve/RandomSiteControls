<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
</sitefinity:ResourceLinks>
<div id="designerLayoutRoot" class="sfContentViews sfSingleContentView" style="max-height: 400px; overflow: auto; ">
<ol>        
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="PageTitleText" CssClass="sfTxtLbl">Page Title</asp:Label>
    <asp:TextBox ID="PageTitleText" runat="server" CssClass="sfTxt" />
    <div class="sfExample">Leave blank and the title will inherit from the Title in the Sitefinity Backend.  Only add text here if you want to override.</div>
    </li>
    
</ol>
</div>
