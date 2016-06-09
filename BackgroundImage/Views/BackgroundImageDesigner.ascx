<%@ Register TagPrefix="designers" Assembly="Telerik.Sitefinity"  Namespace="Telerik.Sitefinity.Web.UI.ControlDesign" %>
<%@ Register TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register TagPrefix="Telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %> 

<style type="text/css">
    .positioning{
        margin-top: 20px;
    }
    .itemLabel{
        display: inline-block;
        width: 55px !important;
        font-weight: bold;
    }
    .sfTargetList{
        margin-top: 20px;
    }
</style>

<div class="sfContentViews buttonDesigner">
    <ul class="sfTargetList">
        <li>
            <label for="ImageURL" class="sfTxtLbl">Image URL</label>
            <input type="text" id="ImageURL" class="sfTxt"  />
        </li>
        <li class="positioning">
            <telerik:RadComboBox id="xPositionCombo" runat="server" ClientIDMode="Static" Skin="Default" Label="X Position" LabelCssClass="itemLabel">
                <Items>
                    <telerik:RadComboBoxItem Text="Left" Value="left" />
                    <telerik:RadComboBoxItem Text="Right" Value="right" />
                    <telerik:RadComboBoxItem Text="Center" Value="center" />
                </Items>
                <ExpandAnimation Type="None" />
                <CollapseAnimation Type="None" />
            </telerik:RadComboBox>
        </li>
        <li>
            <telerik:RadComboBox id="yPositionCombo" runat="server" ClientIDMode="Static" Skin="Default" Label="Y Position" LabelCssClass="itemLabel">
                <Items>
                    <telerik:RadComboBoxItem Text="Top" Value="top" />
                    <telerik:RadComboBoxItem Text="Bottom" Value="bottom" />
                    <telerik:RadComboBoxItem Text="Center" Value="center" />
                </Items>
                <ExpandAnimation Type="None" />
                <CollapseAnimation Type="None" />
            </telerik:RadComboBox>
        </li>
        <li>
            <telerik:RadComboBox id="repeaterCombo" runat="server" ClientIDMode="Static" Skin="Default" Label="Repeat" LabelCssClass="itemLabel">
                <Items>
                    <telerik:RadComboBoxItem Text="No Repeat" Value="no-repeat" />
                    <telerik:RadComboBoxItem Text="Repeat" Value="repeat" />
                    <telerik:RadComboBoxItem Text="Repeat X" Value="repeat-x" />
                    <telerik:RadComboBoxItem Text="Repeat Y" Value="repeat-y" />
                </Items>
                <ExpandAnimation Type="None" />
                <CollapseAnimation Type="None" />
            </telerik:RadComboBox>
        </li>
    </ul>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $("body").addClass("sfSelectorDialog"); 
    });

</script>
