Type.registerNamespace("RandomSiteControls.BackgroundImage");

RandomSiteControls.BackgroundImage.BackgroundImageDesigner = function (element) {
    RandomSiteControls.BackgroundImage.BackgroundImageDesigner.initializeBase(this, [element]);
}
RandomSiteControls.BackgroundImage.BackgroundImageDesigner.prototype = {
    initialize: function () {
        RandomSiteControls.BackgroundImage.BackgroundImageDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        RandomSiteControls.BackgroundImage.BackgroundImageDesigner.callBaseMethod(this, 'dispose');
    },
    refreshUI: function () {
        var repeaterCombo = $find('repeaterCombo');
        var xPositionCombo = $find('xPositionCombo');
        var yPositionCombo = $find('yPositionCombo');

        //SET VALUES GOING TO CLIENT
        var data = this.get_controlData();
        jQuery("#ImageURL").val(nullFilter(data.ImageURL));

        xPositionCombo.findItemByValue(data.PositionX).select();
        yPositionCombo.findItemByValue(data.PositionY).select();
        repeaterCombo.findItemByValue(data.Repeat).select();
    },
    applyChanges: function () {
        var repeaterCombo = $find('repeaterCombo');
        var xPositionCombo = $find('xPositionCombo');
        var yPositionCombo = $find('yPositionCombo');

        //SET VALUES GOING TO SERVER
        var controlData = this.get_controlData();

        controlData.ImageURL = jQuery("#ImageURL").val();
        controlData.PositionX = xPositionCombo.get_value();
        controlData.PositionY = yPositionCombo.get_value();
        controlData.Repeat = repeaterCombo.get_value();
    }
}

RandomSiteControls.BackgroundImage.BackgroundImageDesigner.registerClass('RandomSiteControls.BackgroundImage.BackgroundImageDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();

function nullFilter(data) {
    if (data == null || data == "null")
        return "";
    else
        return data;
}