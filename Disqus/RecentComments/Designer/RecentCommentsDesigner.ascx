<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
</sitefinity:ResourceLinks>

<div class="sfContentViews sfSingleContentView" style="overflow: auto;">
    <ol> 
        <li class="sfFormCtrl">
            <asp:Label ID="Label3" runat="server" AssociatedControlID="Title" CssClass="sfTxtLbl">Title</asp:Label>
            <asp:TextBox ID="Title" runat="server" CssClass="sfTxt" ClientIDMode="Static" />
            <div class="sfExample">Tells Disqus the title of the current page. This is used when creating the thread on Disqus for the first time. If undefined, Disqus will use the title attribute of the page. If that attribute could not be used, Disqus will use the URL of the page.</div>
        </li>   
        <li class="sfFormCtrl">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="NumToDisplay" CssClass="sfTxtLbl">Number of items to display</asp:Label>
            <telerik:RadNumericTextBox ID="NumToDisplay" runat="server" Skin="Default" MinValue="0" EnableSingleInputRendering="true" ClientIDMode="Static" NumberFormat-DecimalDigits="0" ShowSpinButtons="true" />
            <div class="sfExample">Max 20 is what disqus recommends</div>
        </li>  
        <li class="sfFormCtrl">
            <asp:Label ID="Label2" runat="server" AssociatedControlID="ExcerptLength" CssClass="sfTxtLbl">Excerpt Length</asp:Label>
            <telerik:RadNumericTextBox ID="ExcerptLength" runat="server" Skin="Default" MinValue="0" EnableSingleInputRendering="true" ClientIDMode="Static" NumberFormat-DecimalDigits="0" ShowSpinButtons="true" />
            <div class="sfExample">How many characters should it show</div>
        </li>  
        <li class="sfFormCtrl">
            <label class="sfTxtLbl">Hide avatars
                <input id="hide-avatars" type="checkbox" checked="checked" />
            </label>
            <div class="sfExample"></div>
        </li>      
        <li class="sfFormCtrl">
            <asp:Label ID="Label5" runat="server" AssociatedControlID="AvatarSize" CssClass="sfTxtLbl">Avatar size</asp:Label>
            <telerik:RadComboBox ID="AvatarSize" runat="server" Skin="Default" ExpandAnimation-Type="None" CollapseAnimation-Type="None" ClientIDMode="Static">
                <Items>
                    <telerik:RadComboBoxItem Value="24" Text="Small (24px)" />
                    <telerik:RadComboBoxItem Value="32" Text="Medium (32px)" />
                    <telerik:RadComboBoxItem Value="48" Text="Large (48px)" />
                    <telerik:RadComboBoxItem Value="92" Text="X-Large (92px)" />
                    <telerik:RadComboBoxItem Value="128" Text="Ginormous (128px)" />
                </Items>
            </telerik:RadComboBox>
            <div class="sfExample"></div>
        </li> 
    </ol>
    <div id="footer"> 
        <a style="background: url('http://mediacdn.disqus.com/1341348056/img/powered-by.png') right 8px no-repeat !important;display: block!important;height: 23px!important;text-indent: -9999em!important;" class="powered-by-disqus" target="_blank" href="http://disqus.com" tabindex="0">
            Powered by Disqus
        </a>
    </div>
</div>
