<%@ Control Language="C#" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Sitefinity.Web.UI.PublicControls" Assembly="Telerik.Sitefinity" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %>
<%@ Register TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI.PublicControls.BrowseAndEdit" Assembly="Telerik.Sitefinity" %>

<asp:Panel ID="buttoncontainer" runat="server" EnableViewState="false" CssClass="sfs_button">
    <telerik:RadButton id="button" runat="server" Text="Button"  />
</asp:Panel>

