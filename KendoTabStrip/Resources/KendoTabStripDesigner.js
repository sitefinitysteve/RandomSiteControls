Type.registerNamespace("RandomSiteControls.KendoTabStrip.Designer");

RandomSiteControls.KendoTabStrip.Designer.KendoTabStripDesigner = function (element) {
        this._message = null;

    RandomSiteControls.KendoTabStrip.Designer.KendoTabStripDesigner.initializeBase(this, [element]);
}

RandomSiteControls.KendoTabStrip.Designer.KendoTabStripDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        // Here you can attach to events or do other initialization 
        RandomSiteControls.KendoTabStrip.Designer.KendoTabStripDesigner.callBaseMethod(this, 'initialize');
        
    },
    dispose: function () {
        // this is the place to unbind/dispose the event handlers created in the initialize method
        RandomSiteControls.KendoTabStrip.Designer.KendoTabStripDesigner.callBaseMethod(this, 'dispose');
        
    },

    /* --------------------------------- public methods ---------------------------------- */
    // Called when the designer window gets opened and here is place to "bind" your designer to the control properties
    refreshUI: function () {        
        var controlData = this._propertyEditor.get_control(); // JavaScript clone of your control - all the control properties will be properties of the controlData too

                jQuery(this.get_message()).val(controlData.Message);
    },

    // Called when the "save" button is clicked. Here you can transfer the settings from the designer to the control
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

                controlData.Message = jQuery(this.get_message()).val();

    },
    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* --------------------------------- properties -------------------------------------- */

          
    // DOM Element with id: Message
    get_message: function () { return this._message; }, 
    set_message: function (value) { this._message = value; }

}

RandomSiteControls.KendoTabStrip.Designer.KendoTabStripDesigner.registerClass('RandomSiteControls.KendoTabStrip.Designer.KendoTabStripDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);

