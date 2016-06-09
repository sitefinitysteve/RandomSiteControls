<%@ Register TagPrefix="designers" Assembly="Telerik.Sitefinity"  Namespace="Telerik.Sitefinity.Web.UI.ControlDesign" %>
<%@ Register TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register TagPrefix="Telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %> 
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI.Fields" TagPrefix="sf" %>

<style type="text/css">
    .clear{clear:both;}

    ul.position{
        float: left;
        margin-bottom: 10px;
        padding-right: 15px;
    }
    
    .generaltab{
        width: 567px;
    }
    
    #opennewwindow{
        margin-top: 10px;
    }
    
    .content{
        padding: 6px 0 6px 17px;
    }
    
    .sfLeftCol{
        width: 245px !important
    }
    
    .sfRightCol{
        width: 266px !important;
    }
    
    #NavigateUrl{
        width: 207px;
    }
</style>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server"> 
    <sitefinity:ResourceFile Name="RandomSiteControls.Common.common.js" AssemblyInfo="RandomSiteControls.TabStrip.TabStripLayout, RandomSiteControls" Static="True" />
    <sitefinity:ResourceFile Name="RandomSiteControls.SFRadButton.Resources.SFRadButtonDesigner.css"  AssemblyInfo="RandomSiteControls.TabStrip.TabStripLayout, RandomSiteControls" Static="True" /> 
    <sitefinity:ResourceFile Name="Styles/Tabstrip.css"/> 
</sitefinity:ResourceLinks>         

<!-- Required for page selector -->
<sitefinity:FormManager ID="formManager" runat="server" />

<div class="sfContentViews buttonDesigner">
    <telerik:RadTabStrip ID="tabStrip" runat="server" MultiPageID="multiPage" Skin="Default"  OnClientTabSelected="onClientButtonTabSelected" OnClientLoad="OnTabLoad" CssClass="sfSwitchControlViews">
        <Tabs>
            <telerik:RadTab Text="General" Value="General"  Selected="true" />
            <telerik:RadTab Text="Positioning" Value="Positioning" />
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="multiPage" runat="server" CssClass="multiPage">
        <telerik:RadPageView runat="server"  Selected="true">
            <!-- GENERAL -->
            <div class="sfColWrapper sfEqualCols sfModeSelector sfClearfix generaltab">
                <div class="sfLeftCol">
                    <h2 class="sfStep1">Content</h2>
                    <div class="sfStep1Options">
                        <ul class="sfTargetList">
                            <li>
                                <label for="ButtonText" class="sfTxtLbl">Text</label>
                                <input type="text" id="ButtonText" class="sfTxt" />
                                <p class="sfExample">
                                    Button content text
                                </p>
                            </li>
                            <li>
                                <label for="ButtonTooltip" class="sfTxtLbl">Tooltip</label>
                                <input type="text" id="ButtonTooltip" class="sfTxt" />
                                <p class="sfExample">
                                    Tooltip hover text
                                </p>
                            </li>
                            <li>
                                <label for="ButtonTooltip" class="sfTxtLbl">CssClass</label>
                                <input type="text" id="CssClass" class="sfTxt" />
                            </li>
                        </ul>
                    </div>
                </div>
                <!-- NAVIGATION -->
                <div class="sfRightCol">
                    <h2 class="sfStep2">Navigation</h2>
                    <div class="sfStep2Options">
                        <ul class="sfRadioList">
	                        <li id="liSfPage">
		                        <input type="radio" value="true" name="pagemode" id="rbTopLevelPages" checked="checked" class="radio">
		                        <label for="rbTopLevelPages">Sitefinity Page</label>
                                <div class="content">
		                            <sf:PageField ID="PageSelector" runat="server" WebServiceUrl="~/Sitefinity/Services/Pages/PagesService.svc/" DisplayMode="Write" />
                                </div>
	                        </li>
	                        <li id="liExternalUrl">
		                        <input type="radio" value="false" name="pagemode" id="rbSelectedPageChildren" class="radio">
		                        <label for="rbSelectedPageChildren">Static Url</label>
                                <div class="content" style="display:none">
		                            <input type="text" id="NavigateUrl" class="sfTxt" />
                                    <p class="sfExample">
                                        ex: http://www.google.com
                                    </p>
                                </div>
	                        </li>
                        </ul>
                        
                        <div id="opennewwindow">
                            <asp:CheckBox ID="OpenInNewWindow" runat="server" Checked="false" Text="Open in new window" TextAlign="Right" ClientIDMode="Static" CssClass="sfCheckBox sfFormCtrl" />
                        </div>
                    </div>
                </div>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" >
            <!-- POSITIONING -->
            <div id="paddingList">
                <h2>Padding</h2>
                <ul id="positionList1" class="position">
                    <li>
                        <telerik:RadNumericTextBox ID="paddingTop" runat="server" ShowSpinButtons="true" Skin="Default" ButtonsPosition="Right" Label="Top: " NumberFormat-DecimalDigits="0"  ClientIDMode="Static" MinValue="0" Value="0" Width="100px" EnableSingleInputRendering="True" />
                    </li>
                    <li>
                        <telerik:RadNumericTextBox ID="paddingBottom" runat="server" ShowSpinButtons="true" Skin="Default" ButtonsPosition="Right" Label="Bottom: " NumberFormat-DecimalDigits="0"  ClientIDMode="Static" MinValue="0" Value="0"  Width="100px" EnableSingleInputRendering="True" />
                    </li>
                </ul>
                <ul id="positionList2" class="position">
                    <li>
                        <telerik:RadNumericTextBox ID="paddingLeft" runat="server" ShowSpinButtons="true" Skin="Default" ButtonsPosition="Right" Label="Left: "  NumberFormat-DecimalDigits="0"  ClientIDMode="Static" MinValue="0" Value="0"  Width="100px" EnableSingleInputRendering="True" />
                    </li>
                    <li>
                        <telerik:RadNumericTextBox ID="paddingRight" runat="server" ShowSpinButtons="true" Skin="Default" ButtonsPosition="Right" Label="Right: "   NumberFormat-DecimalDigits="0"  ClientIDMode="Static" Value="0"  Width="100px" EnableSingleInputRendering="True" />
                    </li>
                </ul>
                <div class="clear"></div>
                <asp:CheckBox ID="clearCheck" runat="server" Checked="false" Text="Clear" TextAlign="Right" ClientIDMode="Static" CssClass="checkBox" />
                <h2 class="horizAlign">Horizontal Alignment</h2>
                <ul class="alignments">
                    <li>
                        <input type="radio" id="None" name="Alignment" value="Default" />
                        <label for="None">None</label>
                    </li>
                    <li>
                        <input type="radio" id="Left" name="Alignment" value="Left"  />
                        <label for="Left">Left</label>
                    </li>
                    <li>
                        <input type="radio" id="Right" name="Alignment" value="Right" />
                        <label for="Right">Right</label>
                    </li>
                </ul>
            </div>
        </telerik:RadPageView>
        
    </telerik:RadMultiPage>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $("body").addClass("sfSelectorDialog");

        $("#expanderDesignSettings").click(function () {
            var group = $("#groupDesignSettings").toggleClass("sfExpandedSection");

            if (group.hasClass("sfExpandedSection")) {
                group.find(".sfTargetList").show();
            } else {
                group.find(".sfTargetList").hide();
            }

            dialogBase.resizeToContent(); //Refresh
        });

        $(".radio").click(function () {
            $(".content").hide();
            $(this).parent().find(".content").show();
        });
    });

    function OnTabLoad(sender, args){
        if (dialogBase != null) {
            dialogBase.resizeToContent(); //Refresh
        }
    };

    function onClientButtonTabSelected(sender, args) {
        if (dialogBase != null) {
            dialogBase.resizeToContent(); //Refresh
        }
    }

</script>
