<%@ Register TagPrefix="designers" Assembly="Telerik.Sitefinity"  Namespace="Telerik.Sitefinity.Web.UI.ControlDesign" %>
<%@ Register TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register TagPrefix="Telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>

<style type="text/css">
    .settings1{
        float:left;
        width: 250px;
    }
    
    .settings2{
        float:left;
        width: 250px;
    }
    
    .checkbox input{
         margin-right: 5px;
        margin-top: 5px;
    }
    
    .RadInput_Sitefinity, .RadInputMgr_Sitefinity{
        font:inherit !important;
    }
    .RadInput_Sitefinity .riLabel {
        color: #666666;
    }
    .inputItem{
        margin-bottom: 8px;
    }
    
    #comboSkinLabel{
        color: Red;
    }
</style>

<sitefinity:ResourceLinks runat="server">
    <sitefinity:ResourceFile Name="RandomSiteControls.Common.common.js" AssemblyInfo="RandomSiteControls.TabStrip.TabStripLayout, RandomSiteControls" Static="True" />
</sitefinity:ResourceLinks>

<div class="sfContentViews">
     <h2>Data Setup</h2>
        <div class="inputItem">
            <telerik:RadComboBox id="connectionStringComboBox" runat="server" Width="422px" Skin="Sitefinity" Label="Connection String: "  ClientIDMode="Static" 
                                EmptyMessage="Connection String: Select from dropdown or type in your own" ExpandAnimation-Type="None" 
                                CollapseAnimation-Type="None" AllowCustomText="false" />
        </div>
        <div class="inputItem">
            <telerik:RadTextBox id="selectStatementTextBox" runat="server" EmptyMessage="Sql Query Goes here, select * from table"
                                Width="532px" Height="103px" TextMode="MultiLine" Skin="Sitefinity"  ClientIDMode="Static" />
        </div>
        <asp:Label ID="debugLabel" runat="server" />

        <h2>Settings</h2>
        <div style="overflow:auto">
            <ul class="settings1">
                <li>
                    <asp:CheckBox ID="allowSortingCheckBox" runat="server" Text="Sorting" ClientIDMode="Static" EnableViewState="false" TextAlign="Right" CssClass="checkbox" />
                </li>
                <li>
                    <asp:CheckBox ID="allowPagingCheckBox" runat="server" Text="Paging" ClientIDMode="Static" EnableViewState="false" TextAlign="Right" CssClass="checkbox" />
                    <span style='display:inline-block; margin-left: 8px'>(<telerik:RadNumericTextBox ID="pagerSizeTextBox" runat="server" ShowSpinButtons="true" Skin="Sitefinity" ButtonsPosition="Right" Label="Page Size" NumberFormat-DecimalDigits="0"  ClientIDMode="Static" MinValue="0" Text="0" />)</span>
                </li>
            
                <li>
                    <asp:CheckBox ID="allowFilteringCheckBox" runat="server" Text="Filtering" ClientIDMode="Static" EnableViewState="false" TextAlign="Right" CssClass="checkbox" />
                </li>
                <li>
                    <asp:CheckBox ID="allowGroupingCheckBox" runat="server" Text="Grouping" ClientIDMode="Static" EnableViewState="false" TextAlign="Right" CssClass="checkbox" />
                </li>
            </ul>
            <ul class="settings2">
                <li>
                    <telerik:RadComboBox id="skinComboBox" runat="server" Skin="Sitefinity" ExpandAnimation-Type="None" Label="Skin" 
                                         CollapseAnimation-Type="None" AllowCustomText="true"  ClientIDMode="Static" OnClientDropDownClosed="OnSkinDropDownClosedHandler" OnClientTextChange="OnClientTextChange" />
                </li>
                <li>
                    <div id="comboSkinLabel">
                    
                    </div>
                </li>
            </ul>
        </div>
</div>
<script type="text/javascript">

</script>
