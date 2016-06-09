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
            <div class="sfExample"></div>
        </li>       
        <li class="sfFormCtrl">
            <asp:Label ID="Label2" runat="server" AssociatedControlID="NumToDisplay" CssClass="sfTxtLbl">Number of items to display</asp:Label>
            <telerik:RadNumericTextBox ID="NumToDisplay" runat="server" Skin="Default" MinValue="0" EnableSingleInputRendering="true" ClientIDMode="Static" NumberFormat-DecimalDigits="0" ShowSpinButtons="true" />
            <div class="sfExample">Max 20 is what disqus recommends</div>
        </li>  
        <li class="sfFormCtrl">
            <label class="sfTxtLbl">Hide moderators in ranking
                <input id="hide-mods" type="checkbox" checked="checked" />
            </label>
            <div class="sfExample"></div>
        </li>  
        <li class="sfFormCtrl">
            <asp:Label ID="Label5" runat="server" AssociatedControlID="Colour" CssClass="sfTxtLbl">Color Theme</asp:Label>
            <telerik:RadComboBox ID="Colour" runat="server" Skin="Default" ExpandAnimation-Type="None" CollapseAnimation-Type="None" ClientIDMode="Static">
                <Items>
                    <telerik:RadComboBoxItem Value="blue" Text="Blue" />
                    <telerik:RadComboBoxItem Value="grey" Text="Grey" />
                    <telerik:RadComboBoxItem Value="green" Text="Green" />
                    <telerik:RadComboBoxItem Value="red" Text="Red" />
                    <telerik:RadComboBoxItem Value="orange" Text="Orange" />
                </Items>
            </telerik:RadComboBox>
            <div class="sfExample"></div>
        </li> 
        <li class="sfFormCtrl">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="DefaultTab" CssClass="sfTxtLbl">Color Theme</asp:Label>
            <telerik:RadComboBox ID="DefaultTab" runat="server" Skin="Default" ExpandAnimation-Type="None" CollapseAnimation-Type="None" ClientIDMode="Static">
                <Items>
                    <telerik:RadComboBoxItem Value="people" Text="People" />
                    <telerik:RadComboBoxItem Value="recent" Text="Recent" />
                    <telerik:RadComboBoxItem Value="popular" Text="Popular" />
                </Items>
            </telerik:RadComboBox>
            <div class="sfExample"></div>
        </li> 
        <li class="sfFormCtrl">
            <asp:Label ID="Label4" runat="server" AssociatedControlID="ExcerptLength" CssClass="sfTxtLbl">Excerpt Length</asp:Label>
            <telerik:RadNumericTextBox ID="ExcerptLength" runat="server" Skin="Default" MinValue="0" EnableSingleInputRendering="true" ClientIDMode="Static" NumberFormat-DecimalDigits="0" ShowSpinButtons="true" />
            <div class="sfExample">How many characters should it show</div>
        </li>  
    </ol>
    <div id="footer" >
        <a style="background: url('http://mediacdn.disqus.com/1341348056/img/powered-by.png') right 8px no-repeat !important;display: block!important;height: 23px!important;text-indent: -9999em!important;" class="powered-by-disqus" target="_blank" href="http://disqus.com" tabindex="0">
            Powered by Disqus
        </a>
    </div>
</div>
