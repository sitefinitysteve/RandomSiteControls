Type.registerNamespace("RandomSiteControls.SFRadButton");

RandomSiteControls.SFRadButton.SFRadButtonDesigner = function (element) {
    RandomSiteControls.SFRadButton.SFRadButtonDesigner.initializeBase(this, [element]);

    this._PageSelector = null;
    this._resizeControlDesignerDelegate = null;
}
RandomSiteControls.SFRadButton.SFRadButtonDesigner.prototype = {
    initialize: function () {
        RandomSiteControls.SFRadButton.SFRadButtonDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        RandomSiteControls.SFRadButton.SFRadButtonDesigner.callBaseMethod(this, 'dispose');
    },
    // Page Selector
    get_PageSelector: function () {
        return this._PageSelector;
    },
    set_PageSelector: function (value) {
        this._PageSelector = value;
    },
    refreshUI: function () {
        /* CONTROL REFERENCES */

        this.resizeEvents();

        //SET VALUES GOING TO CLIENT
        var data = this.get_controlData();

        selectRadioButton("pagemode", data.UseInternal);

        //Hide/Show the skin picker
        if (data.ShowSkinPicker == false) {
            $("#hidepicker").show();
            $("#showpicker").hide();
        }
        else {
            $("#hidepicker").hide();
            $("#showpicker").show();
        }

        jQuery("#NavigateUrl").val(nullFilter(data.NavigateUrl));
        jQuery('#OpenInNewWindow').attr('checked', data.OpenInNewWindow);
        jQuery("#ButtonText").val(nullFilter(data.ButtonText));
        jQuery("#ButtonTooltip").val(nullFilter(data.ButtonToolTip));
        jQuery("#CssClass").val(nullFilter(data.CssClass));
        $find('buttonSizeComboBox').set_text(data.ButtonSize);
        $find('skinComboBox').set_text(data.Skin);

        $find('paddingTop').set_value(data.PaddingTop.toString());
        $find('paddingBottom').set_value(data.PaddingBottom.toString());
        $find('paddingLeft').set_value(data.PaddingLeft.toString());
        $find('paddingRight').set_value(data.PaddingRight.toString());
        jQuery('#clearCheck').attr('checked', data.Clear);
        selectRadioButton("Alignment", data.Alignment);

        if (data.ButtonWidth > -1) {
            $find('widthTextBox').set_value(data.ButtonWidth.toString());
        }

        //Icons
        selectRadioButton("CustomIcon", data.EmbeddedIcon);
        selectRadioButton("IconPlacement", data.EmbeddedIconPlacement);

        jQuery("#PrimaryIconUrl").val(nullFilter(data.PrimaryIconUrl));
        jQuery("#PrimaryIconCssClass").val(nullFilter(data.PrimaryIconCssClass));
        jQuery("#SecondaryIconUrl").val(nullFilter(data.SecondaryIconUrl));
        jQuery("#SecondaryIconCssClass").val(nullFilter(data.SecondaryIconCssClass));

        //jQuery('#enableBrowserButtonStyle').attr('checked', data.EnableBrowserButtonStyle);

        jQuery("#OnClientClicked").val(nullFilter(data.OnClientClicked));
        jQuery("#OnClientClicking").val(nullFilter(data.OnClientClicking));
        jQuery("#OnClientMouseOut").val(nullFilter(data.OnClientMouseOut));
        jQuery("#OnClientMouseOver").val(nullFilter(data.OnClientMouseOver));

        //Page Selector
        var p = this.get_PageSelector();
        var pageid = data.SelectedPageID;
        if (pageid && p != null)
            p.set_value(pageid);
    },
    applyChanges: function () {
        /* CONTROL REFERENCES */



        //SET VALUES GOING TO SERVER
        var controlData = this.get_controlData();

        controlData.UseInternal = getSelectedChoice("pagemode");

        controlData.NavigateUrl = jQuery("#NavigateUrl").val();
        controlData.OpenInNewWindow = $('#OpenInNewWindow').is(':checked');
        controlData.ButtonText = jQuery("#ButtonText").val();
        controlData.ButtonToolTip = jQuery("#ButtonTooltip").val();
        controlData.CssClass = jQuery("#CssClass").val();
        controlData.ButtonSize = $find('buttonSizeComboBox').get_text();
        controlData.Skin = $find('skinComboBox').get_text();

        controlData.PaddingTop = $find('paddingTop').get_value();
        controlData.PaddingBottom = $find('paddingBottom').get_value();
        controlData.PaddingLeft = $find('paddingLeft').get_value();
        controlData.PaddingRight = $find('paddingRight').get_value();
        controlData.Clear = $('#clearCheck').is(':checked');
        controlData.Alignment = getSelectedChoice("Alignment");
        
        var width = $find('widthTextBox').get_value()
        if(width <= 0 || width == "undefined" || width === null)
            controlData.ButtonWidth = -1;
        else
            controlData.ButtonWidth = width; 

        //Icons
        controlData.EmbeddedIcon = getSelectedChoice("CustomIcon");
        controlData.EmbeddedIconPlacement = getSelectedChoice("IconPlacement");

        controlData.PrimaryIconUrl = jQuery("#PrimaryIconUrl").val();
        controlData.PrimaryIconCssClass = jQuery("#PrimaryIconCssClass").val();
        controlData.SecondaryIconUrl = jQuery("#SecondaryIconUrl").val();
        controlData.SecondaryIconCssClass = jQuery("#SecondaryIconCssClass").val();

        //controlData.EnableBrowserButtonStyle = $('#enableBrowserButtonStyle').is(':checked');

        controlData.OnClientClicked = jQuery("#OnClientClicked").val();
        controlData.OnClientClicking = jQuery("#OnClientClicking").val();
        controlData.OnClientMouseOut = jQuery("#OnClientMouseOut").val();
        controlData.OnClientMouseOver = jQuery("#OnClientMouseOver").val();

        if (this.get_PageSelector() != null)
            controlData.SelectedPageID = this.get_PageSelector().get_value();
    },

    // add resize events
    resizeEvents: function () {
        // resize on Page Select
        var s = this.get_PageSelector();
        s.add_selectorOpened(this._resizeControlDesigner);
        s.add_selectorClosed(this._resizeControlDesigner);
    },
    _resizeControlDesigner: function () {
        setTimeout("dialogBase.resizeToContent()", 50);
    }
}

RandomSiteControls.SFRadButton.SFRadButtonDesigner.registerClass('RandomSiteControls.SFRadButton.SFRadButtonDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();

function getSelectedChoice(groupName){
    var status = jQuery('.buttonDesigner').find("input[name='" + groupName + "']:checked").val();
    
    if (status == null || status == "undefined")
        return "None";
    else
        return status;
}

function selectRadioButton(groupName, value) {
    jQuery('.buttonDesigner').find("input[name='" + groupName + "'][value='" + value + "']").click();
}

function nullFilter(data){
    if (data == null || data == "null")
        return "";
    else
        return data;
}