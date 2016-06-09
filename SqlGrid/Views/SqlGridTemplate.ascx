<%@ Control Language="C#" %>
<%@ Register TagPrefix="sf" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Sitefinity.Web.UI.PublicControls" Assembly="Telerik.Sitefinity" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %>
<%@ Register TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI.PublicControls.BrowseAndEdit" Assembly="Telerik.Sitefinity" %>

<telerik:RadGrid id="RadGrid1" runat="server"  EnableViewState="true" DataSourceID="SqlDataSource1" >
    <MasterTableView>
       <NoRecordsTemplate>
         <div>There are no records to display</div>
       </NoRecordsTemplate>
    </MasterTableView>
</telerik:RadGrid>
<asp:SqlDataSource id="SqlDataSource1" runat="server" />
<sitefinity:BrowseAndEditToolbar ID="browseAndEditToolbar" runat="server" Mode="Edit"></sitefinity:BrowseAndEditToolbar>
