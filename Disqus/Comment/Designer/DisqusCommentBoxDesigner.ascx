<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
</sitefinity:ResourceLinks>

<div class="sfContentViews sfSingleContentView" style="overflow: auto; width:500px; position:relative">
    <ol> 
        <li class="sfFormCtrl">
            <asp:Label ID="Label3" runat="server" AssociatedControlID="Title" CssClass="sfTxtLbl">Title</asp:Label>
            <asp:TextBox ID="Title" runat="server" CssClass="sfTxt" ClientIDMode="Static" />
            <div class="sfExample">Tells Disqus the title of the current page. This is used when creating the thread on Disqus for the first time. If undefined, Disqus will use the title attribute of the page. If that attribute could not be used, Disqus will use the URL of the page.</div>
        </li>       
        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="Identifier" CssClass="sfTxtLbl">Identifier</asp:Label>
            <asp:TextBox ID="Identifier" runat="server" CssClass="sfTxt" ClientIDMode="Static" />
            <div class="sfExample">Tells Disqus how to identify the current page. When the Disqus embed is loaded, the identifier is used to look up the correct thread. If disqus_identifier is undefined, the page's URL will be used. We recommend using your own unique way of identifying a thread.</div>
        </li>
        <li class="sfFormCtrl">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="Url" CssClass="sfTxtLbl">Url</asp:Label>
            <asp:TextBox ID="Url" runat="server" CssClass="sfTxt" ClientIDMode="Static" />
            <div class="sfExample">Tells Disqus the URL of the current page. We highly recommend defining this variable. If a user visits your page at the URL http://example.com/helloworld.html?123, Disqus may in fact load a different thread than if the user came from http://example.com/helloworld.html.</div>
        </li>
        <li class="sfFormCtrl">
            <asp:Label ID="Label2" runat="server" AssociatedControlID="CategoryID" CssClass="sfTxtLbl">CategoryID</asp:Label>
            <asp:TextBox ID="CategoryID" runat="server" CssClass="sfTxt" ClientIDMode="Static" />
            <div class="sfExample">Tells Disqus the category to be used for the current page. This is used when creating the thread on Disqus for the first time.</div>
        </li>
    </ol>
    <div id="footer" style="margin-top: 20px">
        <a href="http://help.disqus.com/customer/portal/articles/472098-javascript-configuration-variables" target="_blank" style="position:absolute; bottom: 0; left:0;">Disqus variable documentation</a>
        <a href="http://www.disqus.com" style="position:absolute; bottom: 0; right:0;"><img src='http://mediacdn.disqus.com/1341348056/img/powered-by.png' /></a>
    </div>
</div>
