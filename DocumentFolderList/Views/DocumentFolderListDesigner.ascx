<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
    <sitefinity:ResourceFile Name="Styles/jQuery/jquery.ui.core.css" />
    <sitefinity:ResourceFile Name="Styles/jQuery/jquery.ui.dialog.css" />
    <sitefinity:ResourceFile Name="Styles/jQuery/jquery.ui.theme.sitefinity.css" />
</sitefinity:ResourceLinks>
<sitefinity:ResourceLinks ID="ResourceLinks1" runat="server">
    <sitefinity:ResourceFile Name="RandomSiteControls.Common.common.js" AssemblyInfo="RandomSiteControls.TabStrip.TabStripLayout, RandomSiteControls" Static="True" />
</sitefinity:ResourceLinks>

<div id="designerLayoutRoot" class="sfContentViews sfSingleContentView" style="max-height: 600px; overflow: auto; width: 500px">
    <ol>
        <li class="sfFormCtrl">
            <div id="LibraryIdSelector">
                <sitefinity:FolderSelector ID="LibraryIdItemSelector" runat="server"
                    AllowMultipleSelection="false"
                    BindOnLoad="false"
                    AllowSearch="true"
                    ShowButtonsArea="false"
                    WebServiceUrl="~/Sitefinity/Services/Content/DocumentLibraryService.svc/folders/" />

                <asp:Panel runat="server" ID="buttonAreaPanelLibraryId" class="sfButtonArea sfSelectorBtns">
                    <asp:LinkButton ID="lnkDoneLibraryId" runat="server" OnClientClick="return false;" CssClass="sfLinkBtn sfSave">
                <strong class="sfLinkBtnIn">
                    <asp:Literal runat="server" Text="<%$Resources:Labels, Done %>" />
                </strong>
                    </asp:LinkButton>
                    <asp:Literal runat="server" Text="<%$Resources:Labels, or%>" />
                    <asp:LinkButton ID="lnkCancelLibraryId" runat="server" CssClass="sfCancel" OnClientClick="return false;">
                <asp:Literal runat="server" Text="<%$Resources:Labels, Cancel %>" />
                    </asp:LinkButton>
                </asp:Panel>
            </div>
            <label class="sfTxtLbl" for="selectedLibraryIdLabel">Library</label>
            <span class="sfSelectedItem" id="selectedLibraryIdLabel">
                <asp:Literal runat="server" Text="" />
            </span>
            <asp:LinkButton ID="selectButtonLibraryId" OnClientClick="return false;" runat="server" CssClass="sfLinkBtn sfChange">
        <span class="sfLinkBtnIn">
            <asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
        </span>
            </asp:LinkButton>
            <asp:LinkButton ID="deselectButtonLibraryId" OnClientClick="return false;" runat="server" CssClass="sfLinkBtn sfChange">
      <span class="sfLinkBtnIn">
        <asp:Literal runat="server" Text="<%$Resources:Labels, Remove %>" />
      </span>
            </asp:LinkButton>
            <div class="sfExample">Library</div>
        </li>

        <li class="sfFormCtrl">
            <asp:CheckBox runat="server" ID="ShowLineImages" Text="Show Line Images" CssClass="sfCheckBox" />
            <div class="sfExample">Should there be lines connecting the nodes</div>
        </li>

        <li class="sfFormCtrl">
            <asp:CheckBox runat="server" ID="Expanded" Text="Expanded" CssClass="sfCheckBox" />
            <div class="sfExample">Show all nodes expanded by default</div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="FolderImageUrl" CssClass="sfTxtLbl">Folder Image Url  (Optional)</asp:Label>
            <asp:TextBox ID="FolderImageUrl" runat="server" CssClass="sfTxt" />
            <div class="sfExample">Example: ~/images/folder.png</div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="FolderExpandedImageUrl" CssClass="sfTxtLbl">Folder Expanded Image Url (Optional)</asp:Label>
            <asp:TextBox ID="FolderExpandedImageUrl" runat="server" CssClass="sfTxt" />
            <div class="sfExample">Example: ~/images/folderOpen.png</div>
        </li>


        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="IconSize" CssClass="sfTxtLbl">Icon Size</asp:Label>
            <asp:TextBox ID="IconSize" runat="server" CssClass="sfTxt" />
            <div class="sfExample">Small or Large</div>
        </li>

        <li class="sfFormCtrl">
            <div id="skinpicker">
                <h2>Skin</h2>
                <telerik:RadComboBox id="skinComboBox" runat="server" Skin="Bootstrap" ExpandAnimation-Type="None"
                        CollapseAnimation-Type="None" AllowCustomText="true" ClientIDMode="Static" MaxHeight="300"
                        OnClientDropDownClosed="OnSkinDropDownClosedHandler" OnClientTextChange="OnClientTextChange" />
            </div>
        </li>

        <li class="sfFormCtrl" style="display:none">
            <asp:Label runat="server" AssociatedControlID="FilterExpressionForDocuments" CssClass="sfTxtLbl">Filter Expression For Documents (Optional)</asp:Label>
            <asp:TextBox ID="FilterExpressionForDocuments" runat="server" CssClass="sfTxt" />
            <div class="sfExample">Example: Status == Live && Title.Contains("Test")</div>
        </li>
    </ol>
</div>
