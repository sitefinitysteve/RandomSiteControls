Type.registerNamespace("RandomSiteControls.Button");

RandomSiteControls.Button.ButtonDesigner = function (element) {
    RandomSiteControls.Button.ButtonDesigner.initializeBase(this, [element]);

    this._PageSelector = null;
    this._resizeControlDesignerDelegate = null;
}
RandomSiteControls.Button.ButtonDesigner.prototype = {
    initialize: function () {
        RandomSiteControls.Button.ButtonDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        RandomSiteControls.Button.ButtonDesigner.callBaseMethod(this, 'dispose');
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

        jQuery("#NavigateUrl").val(nullFilter(data.NavigateUrl));
        jQuery('#OpenInNewWindow').attr('checked', data.OpenInNewWindow);
        jQuery("#ButtonText").val(nullFilter(data.ButtonText));
        jQuery("#ButtonTooltip").val(nullFilter(data.ButtonToolTip));
        jQuery("#CssClass").val(nullFilter(data.CssClass));

        $find('paddingTop').set_value(data.PaddingTop.toString());
        $find('paddingBottom').set_value(data.PaddingBottom.toString());
        $find('paddingLeft').set_value(data.PaddingLeft.toString());
        $find('paddingRight').set_value(data.PaddingRight.toString());
        jQuery('#clearCheck').attr('checked', data.Clear);
        selectRadioButton("Alignment", data.Alignment);

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

        controlData.PaddingTop = $find('paddingTop').get_value();
        controlData.PaddingBottom = $find('paddingBottom').get_value();
        controlData.PaddingLeft = $find('paddingLeft').get_value();
        controlData.PaddingRight = $find('paddingRight').get_value();
        controlData.Clear = $('#clearCheck').is(':checked');
        controlData.Alignment = getSelectedChoice("Alignment");

        //controlData.EnableBrowserButtonStyle = $('#enableBrowserButtonStyle').is(':checked');

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

RandomSiteControls.Button.ButtonDesigner.registerClass('RandomSiteControls.Button.ButtonDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
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