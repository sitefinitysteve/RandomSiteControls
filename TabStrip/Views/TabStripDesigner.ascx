<%@ Register TagPrefix="designers" Assembly="Telerik.Sitefinity"  Namespace="Telerik.Sitefinity.Web.UI.ControlDesign" %>
<%@ Register TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>


<style type="text/css">
    .tab-wrapper{
        width: 600px;
    }

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

    .RadInput_Bootstrap, .RadInputMgr_Metro{
        font:inherit !important;
    }
    .RadInput_Bootstrap .riLabel {
        color: #666666;
    }
    .inputItem{
        margin-bottom: 8px;
    }
    #comboSkinLabel{
        color: Red;
    }

    .rtsTxt{
        text-decoration:none !important;
        text-transform: none !important;
    }

    .instructions{
        background: none repeat scroll 0 0 #FCFDC5;
        border: 1px dotted #666666;
        color: #666666;
        margin-top: 20px;
        padding: 5px;
        text-align: center;
    }
    .tabNameItem .txtinput{
        width: 311px;
    }
    .tabNameItem .imginput{
        width: 282px;
    }
    fieldset {
        background: none repeat scroll 0 0 #E6E6E6;
        border: 1px solid #919191;
        padding: 5px;
    }
    .multiPageContentArea{
        padding-top: 15px;
        padding-bottom: 15px;
    }

    #tabTextBox{
    }

    #tabImageBox{
    }

    #tabNames{
        margin-top: 20px;
    }

    .optionalitems{
        margin-top: 10px;
    }

    .RadInput_Bootstrap label.riLabel {
        color: #000000;
        font-weight: bold;
        display: block;
    }

    .options-page h2{
        margin-top: 11px;
    }
</style>

<sitefinity:ResourceLinks runat="server">
    <sitefinity:ResourceFile JavaScriptLibrary="JQuery"/>
    <sitefinity:ResourceFile Name="RandomSiteControls.Common.common.js" AssemblyInfo="RandomSiteControls.TabStrip.TabStripLayout, RandomSiteControls" Static="True" />
    <sitefinity:ResourceFile Name="Styles/Tabstrip.css"/>
</sitefinity:ResourceLinks>


<div class="sfContentViews tab-wrapper">
    <telerik:RadTabStrip id="radTabStripRoot" runat="server" Skin="Default" MultiPageID="multiPage" CssClass="sfSwitchControlViews" OnClientTabSelected="onMainTab_Selected">
        <tabs>
                <telerik:RadTab Text="Layout" Selected="true" PageViewID="LayoutPageView" />
                <telerik:RadTab Text="Options" PageViewID="StylePageView" />
            </tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="multiPage" runat="server" CssClass="multiPageContentArea" >
        <telerik:RadPageView ID="LayoutPageView" runat="server" Selected="True">
            <div class="inputItem">
                <telerik:RadButton ID="addButton" runat="server" Primary="true" Text="Add Tab" OnClientClicking="onAddTab_Click" ClientIDMode="Static" Skin="Bootstrap" AutoPostBack="false">
                </telerik:RadButton>
                <telerik:RadButton ID="removeButton" runat="server" Primary="true" Text="Remove Selected Tab" OnClientClicking="onRemoveTab_Click"  ClientIDMode="Static" Skin="Bootstrap" AutoPostBack="false" style="display:none">
                </telerik:RadButton>
            </div>
            <telerik:RadTabStrip id="dynamicTabStrip" runat="server" Skin="Default" OnClientLoad="OnTabStrip_ClientLoad"  OnClientTabSelecting="onTab_Selected" ClientIDMode="Static">
                <tabs>
                <telerik:RadTab Text="Tab 1" Selected="true">

                </telerik:RadTab>
            </tabs>
            </telerik:RadTabStrip>
            <ul id="tabNames" class="inputItem">
                <li>
                    <label class="sfTxtLbl" for="tabTextBox">Text:</label>
                    <input type="text" class="sfTxt" id="tabTextBox" />
                    <p class="sfExample"><strong>Example:</strong> Reports</p>
                </li>
                <li>
                    <label class="sfTxtLbl" for="cssClassTextBox">Css Class: <span class="optional">(optional)</span></label>
                    <input type="text" class="sfTxt" id="cssClassTextBox" />
                    <p class="sfExample">Wraps the tab in this class name for you to apply custom styling</p>
                </li>
                <li class="optionalitems">
                    <label class="sfTxtLbl" for="tabImage">Image Url: <span class="optional">(optional)</span></label>
                    <input type="text" class="sfTxt" id="tabImageBox" />
                    <p class="sfExample"><strong>Example:</strong> http://www.mysite.com/images/icons/rss_small.gif</p>
                </li>
                <li>
                    <label class="sfTxtLbl" for="tabNavigateUrl">Navigate Url: <span class="optional">(optional)</span></label>
                    <input type="text" class="sfTxt" id="tabNavigateUrl" />
                    <p class="sfExample"><strong>Example:</strong> http://www.google.com/ will send you to google on click of the tab</p>
                </li>
                <li>
                    <label class="sfTxtLbl" for="tabNavigateUrl">Querystring Value: <span class="optional">(optional)</span></label>
                    <input type="text" class="sfTxt" id="tabKeyTextBox" />
                    <p class="sfExample">Unique key for this tab, used for selection by querystring</p>
                </li>
            </ul>
            <asp:Label ID="debugLabel" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="StylePageView" runat="server">
            <ul class="options-page">
                <li>
                    <telerik:RadNumericTextBox ID="defaultTabTextBox" runat="server" Label="Default Tab:" Skin="Bootstrap" ShowSpinButtons="true" MinValue="1" NumberFormat-DecimalDigits="0" ClientEvents-OnLoad="onDefaultBox_Load" ClientIDMode="Static" />
                </li>
                <li>
                    <h2>Render</h2>
                    <telerik:RadComboBox id="tabStripRenderStyleComboBox" runat="server" Skin="Bootstrap" ExpandAnimation-Type="None"
                            CollapseAnimation-Type="None" AllowCustomText="false" ClientIDMode="Static">
                            <Items>
                                <telerik:RadComboBoxItem Text="Horizontal" Value="Horizontal" />
                                <telerik:RadComboBoxItem Text="Vertical" Value="Vertical" />
                            </Items>
                     </telerik:RadComboBox>
                </li>
                <li>
                    <h2>Alignment</h2>
                    <telerik:RadComboBox id="tabStripAlignStyleComboBox" runat="server" Skin="Bootstrap" ExpandAnimation-Type="None"
                            CollapseAnimation-Type="None" AllowCustomText="false" ClientIDMode="Static">
                            <Items>
                                <telerik:RadComboBoxItem Text="Left" Value="Left" />
                                <telerik:RadComboBoxItem Text="Right" Value="Right" />
                                <telerik:RadComboBoxItem Text="Center" Value="Center" />
                                <telerik:RadComboBoxItem Text="Justify" Value="Justify" />
                            </Items>
                     </telerik:RadComboBox>
                </li>
                <li style="margin-top: 11px;">
                    <label class="sfTxtLbl" for="tabNavigateUrl">Querystring Key: <span class="optional">(optional)</span></label>
                    <input type="text" class="sfTxt" id="coreQuerystringKey" />
                    <p class="sfExample">
                        Querystring to watch for on the url.  If the control sees it, and the value matches the Querystring value set in one of the tabs, that tab will be selected
                        <br />
                        Ex: http://site.com/mypage?select=tab3 (Where "selected" is this value and "tab3" is the value set on the tab)
                    </p>
                </li>
            </ul>
            <h2>Skin</h2>
            <div id="showpicker" style="overflow: auto">
                <ul class="settingsLeft">
                    <li></li>
                </ul>
                <ul class="settingsRight">
                    <li>
                        <telerik:RadComboBox id="skinComboBox" runat="server" Skin="Bootstrap" ExpandAnimation-Type="None"
                            CollapseAnimation-Type="None" AllowCustomText="true" ClientIDMode="Static"
                            OnClientDropDownClosed="OnSkinDropDownClosedHandler" OnClientTextChange="OnClientTextChange" />
                        <div id="comboSkinLabel">
                        </div>
                    </li>
                </ul>
            </div>
            <div id="hidepicker" class=".instructions" style="display:none">
                Your skin has been pre-defined by your site admin, you may not change it
            </div>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <div class="instructions">
        You need to place this widget inside of the <strong>TabStrip Layout control</strong>
        configurator panel area. Click the layout button at the top right and look for the
        pink TabStrip layout icon to drag onto your page.
    </div>
    <asp:HiddenField ID="tabNamesHiddenField" runat="server" ClientIDMode="Static" />
</div>
<script type="text/javascript">
    var tabNames = new Array();
    var tabStrip;
    var defaultBox;

    $(document).ready(function () {
        $("body").addClass("sfSelectorDialog");
    });

    function OnTabStrip_ClientLoad(sender) {
        tabStrip = sender;
        wireUpTab(tabStrip.get_tabs().getTab(0));
    }

    function onDefaultBox_Load(sender) {
        defaultBox = sender;
    }

    function onAddTab_Click(sender, args) {
        tabStrip.trackChanges();
        var tab = new Telerik.Web.UI.RadTab();
        var newNumber = getTabCount() + 1;
        tab.set_text("Tab " + newNumber);
        tabStrip.get_tabs().add(tab);
        tabStrip.commitChanges();

        setDefaultTab(newNumber);

        checkRemoveButtonVisibility();

        resizeDialog();
    }

    function onRemoveTab_Click(sender, args) {
        var tabCount = getTabCount();
        setDefaultTab(getTabCount() - 1);

        if (tabCount > 1) {
            tabStrip.trackChanges();
            //remove the selected tab
            var tab = tabStrip.get_selectedTab();
            tabStrip.get_tabs().remove(tab);
            tabStrip.commitChanges();

            //select the first tab
            tabStrip.get_tabs().getTab(0).select();

            resizeDialog();
        }

        checkRemoveButtonVisibility();
    }

    function checkRemoveButtonVisibility() {
        if (getTabCount() > 1) {
            $("#removeButton").show();
        } else {
            $("#removeButton").hide();
        }
    }

    function onTab_Selected(sender, args) {
        var tab = args.get_tab();
        wireUpTab(tab);
    }

    function onMainTab_Selected(sender, args) {
        resizeDialog();
    }

    function wireUpTab(tab) {
        var textBox = $("#tabTextBox");
        var imageBox = $("#tabImageBox");
        var navigateUrl = $("#tabNavigateUrl");
        var cssClassBox = $("#cssClassTextBox");
        var tabKeyTextBox = $("#tabKeyTextBox");

        textBox.val(tab.get_text());
        cssClassBox.val(tab.get_outerCssClass());
        imageBox.val(tab.get_imageUrl());
        tabKeyTextBox.val(tab.get_key());

        //Set the navigate URL..darn thing defaults to #
        var navValue = tab.get_value();
        if(navValue != "#")
            navigateUrl.val(tab.get_value());
        else
            navigateUrl.val("");

        //Wire up the key events
        textBox.unbind('keyup').keyup(function () {
            var text = textBox.val();
            if (text == "")
                text = "Tab " + (tab.get_index() + 1);

            tab.set_text(text);
        });

        imageBox.unbind('keyup').keyup(function () {
            tab.set_imageUrl(imageBox.val());
        });


        cssClassBox.unbind('keyup').keyup(function () {
            tab.set_outerCssClass(cssClassBox.val());
        });

        navigateUrl.unbind('keyup').keyup(function () {
            tab.set_value(navigateUrl.val()); //Were storing in value b/c setting nav will cause issues with clicking the tab
        });

        tabKeyTextBox.unbind('keyup').keyup(function () {
            tab.set_key(tabKeyTextBox.val());
        });
    }

    function setDefaultTab(value) {
        defaultBox.set_maxValue(value);

        if (defaultBox.get_value() > value) {
            defaultBox.set_value(value);
        }

        //$("#dynamicTabStrip .rtsTxt").css("text-decoration", "none");
        //$("#dynamicTabStrip .rtsTxt:eq(" + value - 1 + ")").css("text-decoration", "underline");
    }

    function getTabCount() {
        return tabStrip.get_tabs().get_count();
    }

    function getTabNames() {
        var values = $('#tabNamesHiddenField').attr('value');

        if (values != null || values != "") {
            return Sys.Serialization.JavaScriptSerializer.deserialize(values);
        }
    }

    function setTabNames() {
        $('#tabNamesHiddenField').attr('value', Sys.Serialization.JavaScriptSerializer.serialize(tabNames));
    }


    function resizeDialog() {
        if (dialogBase != null) {
            dialogBase.resizeToContent(); //Refresh
        }
    }

</script>
