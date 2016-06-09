Type.registerNamespace("RandomSiteControls.Placeholder.Designer");
var $phmodel = null;

RandomSiteControls.Placeholder.Designer.PlaceholderDesigner = function (element) {

    RandomSiteControls.Placeholder.Designer.PlaceholderDesigner.initializeBase(this, [element]);
}

RandomSiteControls.Placeholder.Designer.PlaceholderDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        RandomSiteControls.Placeholder.Designer.PlaceholderDesigner.callBaseMethod(this, 'initialize');

        $phmodel = kendo.observable({
            width: 300,
            height: 300,
            text: "",
            bgcolor: "00ADDC",
            textcolor: "FFFFFF",
            getUrl: function (e) {
                var height = this.get("height");
                var width = this.get("width");
                var bgcolor = this.get("bgcolor");
                var textcolor = this.get("textcolor");
                var text = this.get("text");

                if (text === "" || text === " " || text === null)
                    return "http://placehold.it/" + width + "x" + height + "/" + bgcolor + "/" + textcolor;
                else
                    return "http://placehold.it/" + width + "x" + height + "/" + bgcolor + "/" + textcolor + "&text=" + text.replace(" ", "+");
            }
        });

        kendo.bind($("#controlsContainer"), $phmodel);
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        RandomSiteControls.Placeholder.Designer.PlaceholderDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {        
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */
        
        $phmodel.set("width", controlData.ImageWidth);
        $phmodel.set("height", controlData.ImageHeight);
        $phmodel.set("text", controlData.ImageText);
        $phmodel.set("bgcolor", controlData.ImageBackgroundColor);
        $phmodel.set("textcolor", controlData.ImageTextColor);

        var backgroundPicker = $find("backgroundPicker");
        backgroundPicker.set_selectedColor("#" + controlData.ImageBackgroundColor);

        var textPicker = $find("textPicker");
        textPicker.set_selectedColor("#" + controlData.ImageTextColor);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        controlData.ImageText = $phmodel.get("text");
        controlData.ImageWidth = $phmodel.get("width");
        controlData.ImageHeight = $phmodel.get("height");
        controlData.ImageBackgroundColor = $phmodel.get("bgcolor");
        controlData.ImageTextColor = $phmodel.get("textcolor");
    },


    /* --------------------------------- properties -------------------------------------- */

}

RandomSiteControls.Placeholder.Designer.PlaceholderDesigner.registerClass('RandomSiteControls.Placeholder.Designer.PlaceholderDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);

function onBackgroundColorChange(sender, args) {
    $phmodel.set("bgcolor", sender.get_selectedColor().replace("#", ""));
}

function onTextColorChange(sender, args) {
    $phmodel.set("textcolor", sender.get_selectedColor().replace("#", ""));
}