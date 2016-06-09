Type.registerNamespace("RandomSiteControls.Disqus.Combination.Designer");

RandomSiteControls.Disqus.Combination.Designer.DisqusCombinationDesigner = function (element) {
    this._message = null;

    RandomSiteControls.Disqus.Combination.Designer.DisqusCombinationDesigner.initializeBase(this, [element]);
}

RandomSiteControls.Disqus.Combination.Designer.DisqusCombinationDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        RandomSiteControls.Disqus.Combination.Designer.DisqusCombinationDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        RandomSiteControls.Disqus.Combination.Designer.DisqusCombinationDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

	findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {        
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        $("#Title").val(controlData.Title);

        /* RefreshUI Message */
        var numItemsBox = $find("NumToDisplay");
        numItemsBox.set_value(controlData.NumberOfItems);

        
        var excerptLength = $find("ExcerptLength");
        excerptLength.set_value(controlData.ExcerptLength);

        var colourComboBox = $find("Colour");
        colourComboBox.findItemByValue(controlData.Colour).select();

        var defaultTabComboBox = $find("DefaultTab");
        defaultTabComboBox.findItemByValue(controlData.DefaultTab).select();

        $("#hide-mods").prop("checked", controlData.HideModerators);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        controlData.Title = $("#Title").val();

        var numItemsBox = $find("NumToDisplay");
        controlData.NumberOfItems = numItemsBox.get_value();

        var excerptLength = $find("ExcerptLength");
        controlData.ExcerptLength = excerptLength.get_value();

        var colourComboBox = $find("Colour");
        controlData.Colour = colourComboBox.get_value();

        var defaultTabComboBox = $find("DefaultTab");
        controlData.DefaultTab = defaultTabComboBox.get_value();

        controlData.HideModerators = $("#hide-mods").prop("checked");
    },


   

    /* --------------------------------- properties -------------------------------------- */
}

RandomSiteControls.Disqus.Combination.Designer.DisqusCombinationDesigner.registerClass('RandomSiteControls.Disqus.Combination.Designer.DisqusCombinationDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);

