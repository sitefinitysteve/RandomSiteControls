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
            <telerik:RadTab Text="Style" Value="Style" />
            <telerik:RadTab Text="Positioning" Value="Positioning" />
            <telerik:RadTab Text="Icons" Value="Icons" />
            <telerik:RadTab Text="Events" Value="Events" />
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
                        
                        <div id="opennewwindow" style="display:none">
                            <asp:CheckBox ID="OpenInNewWindow" runat="server" Checked="false" Text="Open in new window" TextAlign="Right" ClientIDMode="Static" CssClass="sfCheckBox sfFormCtrl" />
                        </div>
                    </div>
                </div>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" >
            <!-- Style -->
            <ul class="generalList">
                <li>
                    <telerik:RadComboBox id="buttonSizeComboBox" runat="server" Skin="Default" ExpandAnimation-Type="None" Label="Button Size" CollapseAnimation-Type="None" AllowCustomText="false"  ClientIDMode="Static"  LabelCssClass="sfTxtLbl">
                            <Items>
                                <telerik:RadComboBoxItem Text="Normal" Value="Normal" />
                                <telerik:RadComboBoxItem Text="Large" Value="Large" />
                            </Items>
                    </telerik:RadComboBox>
                </li>
               <li>
                    <label for="ButtonTooltip" class="sfTxtLbl">CssClass</label>
                    <input type="text" id="CssClass" class="sfTxt" />
                </li>
                <li>
                    <h2>Skin</h2>
                    <div id="showpicker">
                            <telerik:RadComboBox id="skinComboBox" runat="server" Skin="Default" ExpandAnimation-Type="None" CollapseAnimation-Type="None" AllowCustomText="true"  ClientIDMode="Static" OnClientDropDownClosed="OnSkinDropDownClosedHandler" OnClientTextChange="OnClientTextChange" LabelCssClass="sfTxtLbl" />
                    </div>
                    <div id="hidepicker" class=".instructions" style="display:none">
                        Your skin has been pre-defined by your site admin, you may not change it
                    </div>
                 </li>
            </ul>
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
                <asp:CheckBox ID="clearCheck" runat="server" Checked="false" Text="Clear" TextAlign="Left" ClientIDMode="Static" CssClass="checkBox" />
                <h2 class="horizAlign">Horizontal Alignment</h2>
                <ul class="sfRadioList RotatorDesignList sfNavModes ">
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
                <h2 class="horizAlign">Width</h2>
                <telerik:RadNumericTextBox id="widthTextBox" runat="server" ClientIDMode="Static" ShowSpinButtons="true" Skin="Default" NumberFormat-DecimalDigits="0" MinValue="0" EmptyMessage="Size in Pixels"  Width="160px"  EnableSingleInputRendering="True" />
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" >
            <!-- Icons -->
            <h2>Built-in Icons</h2>
            <div id="customIconContainer">
                <ul class="customIconList">
                    <li>
                        <input type="radio" id="rbAdd" name="CustomIcon" value="rbAdd"  />
                        <label for="rbAdd" class="rbAdd">&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbRemove" name="CustomIcon" value="rbRemove"  />
                        <label for="rbRemove" class="rbRemove">&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbOk" name="CustomIcon" value="rbOk"  />
                        <label for="rbOk" class="rbOk">&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbCancel" name="CustomIcon" value="rbCancel" />
                        <label for="rbCancel" class="rbCancel" >&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbUpload" name="CustomIcon" value="rbUpload"  />
                        <label for="rbUpload" class="rbUpload">&nbsp;</label>
                    </li>
                </ul>
                <ul class="customIconList">
                    <li>
                        <input type="radio" id="rbDownload" name="CustomIcon" value="rbDownload"  />
                        <label for="rbDownload" class="rbDownload">&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbPrevious" name="CustomIcon" value="rbPrevious" />
                        <label for="rbPrevious" class="rbPrevious" >&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbNext" name="CustomIcon" value="rbNext"  />
                        <label for="rbNext" class="rbNext">&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbOpen" name="CustomIcon" value="rbOpen"  />
                        <label for="rbOpen" class="rbOpen">&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="Radio1" name="CustomIcon" value="rbPrevious" />
                        <label for="rbPrevious" class="rbPrevious" >&nbsp;</label>
                    </li>
                </ul>
                <ul class="customIconList">
                    <li>
                        <input type="radio" id="Radio2" name="CustomIcon" value="rbNext"  />
                        <label for="rbNext" class="rbNext">&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbAttach" name="CustomIcon" value="rbAttach"  />
                        <label for="rbAttach" class="rbAttach">&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbSave" name="CustomIcon" value="rbSave" />
                        <label for="rbSave" class="rbSave" >&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbConfig" name="CustomIcon" value="rbConfig"  />
                        <label for="rbConfig" class="rbConfig">&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbPrint" name="CustomIcon" value="rbPrint"  />
                        <label for="rbPrint" class="rbPrint">&nbsp;</label>
                    </li>
                </ul>
                <ul class="customIconList">
                    <li>
                        <input type="radio" id="rbRefresh" name="CustomIcon" value="rbRefresh" />
                        <label for="rbRefresh" class="rbRefresh" >&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbSearch" name="CustomIcon" value="rbSearch"  />
                        <label for="rbSearch" class="rbSearch">&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbHelp" name="CustomIcon" value="rbHelp"  />
                        <label for="rbHelp" class="rbHelp">&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbCart" name="CustomIcon" value="rbCart" />
                        <label for="rbCart" class="rbCart" >&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbEdit" name="CustomIcon" value="rbEdit"  />
                        <label for="rbEdit" class="rbEdit">&nbsp;</label>
                    </li>
                </ul>
                <ul class="customIconList">
                    <li>
                        <input type="radio" id="rbRSS" name="CustomIcon" value="rbRSS"  />
                        <label for="rbRSS" class="rbRSS">&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="rbMail" name="CustomIcon" value="rbMail" />
                        <label for="rbMail" class="rbMail" >&nbsp;</label>
                    </li>
                    <li>
                        <input type="radio" id="None" name="CustomIcon" value="None" />
                        <label for="None" class="none" >None</label>
                    </li>
                </ul>
                <div style="clear:both">​</div>
            </div>
            <div style="clear:both">​</div>
            <div id="position">
                <h2>Position Icon to the...</h2>
                <ul class="placementList">
                    <li>
                        <input type="radio" id="IconLeft" name="IconPlacement" value="IconLeft" checked="checked" />
                        <label for="IconLeft">Left</label>
                    </li>
                    <li>
                        <input type="radio" id="IconRight" name="IconPlacement" value="IconRight" />
                        <label for="IconRight">Right</label>
                    </li>
                </ul>
            </div>
            <div style="clear:both">​</div>
            <div id="groupDesignSettings" class="sfExpandableSection">
                <h3><a class="sfMoreDetails" id="expanderDesignSettings">Custom Icons</a></h3>
                <ul class="sfTargetList" style="display:none">
                    <li>
                        <label for="PrimaryIconUrl" class="sfTxtLbl">Left IconUrl</label>
                        <input type="text" id="PrimaryIconUrl" class="sfTxt" />
                    </li>
                    <li>
                        <label for="PrimaryIconCssClass" class="sfTxtLbl">Left IconCssClass</label>
                        <input type="text" id="PrimaryIconCssClass" class="sfTxt" />
                    </li>
                    <li>
                        <label for="SecondaryIconUrl" class="sfTxtLbl">Right IconUrl</label>
                        <input type="text" id="SecondaryIconUrl" class="sfTxt" />
                    </li>
                    <li>
                        <label for="SecondaryIconCssClass" class="sfTxtLbl">Right IconCssClass</label>
                        <input type="text" id="SecondaryIconCssClass" class="sfTxt" />
                    </li>
                </ul>
            </div>
     

            <!-- USED AS A DUMMY TO LOAD THE ICONS -->
            <telerik:RadButton runat="server" style='display:none' />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" >
            <!-- EVENTS -->
            <div id="" class="">
                <ul class="sfTargetList">
                    <li>
                        <label for="OnClientClicked" class="sfTxtLbl">OnClientClicked</label>
                        <input type="text" id="OnClientClicked" class="sfTxt" />
                    </li>
                    <li>
                        <label for="OnClientClicking" class="sfTxtLbl">OnClientClicking</label>
                        <input type="text" id="OnClientClicking" class="sfTxt" />
                    </li>
                    <li>
                        <label for="OnClientMouseOut" class="sfTxtLbl">OnClientMouseOut</label>
                        <input type="text" id="OnClientMouseOut" class="sfTxt" />
                    </li>
                    <li>
                        <label for="OnClientMouseOver" class="sfTxtLbl">OnClientMouseOver</label>
                        <input type="text" id="OnClientMouseOver" class="sfTxt" />
                    </li>
                </ul>
                <div id="samplecode" class="sfExample">
                    <strong>Example:</strong>
                    <code>download_OnClientClicking</code>
                    <p style="margin-top: 4px;margin-bottom: 4px;">Dont put braces at the end of the events.  More detail <a href='http://www.telerik.com/help/aspnet-ajax/button-client-side-events-overview.html' target="_blank">here</a></p>
                    <p>If the function names don't exist on the live page, you'll get script errors</p>
                </div>
                
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
