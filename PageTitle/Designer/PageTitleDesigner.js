Type.registerNamespace("RandomSiteControls.PageTitle.Designer");

RandomSiteControls.PageTitle.Designer.PageTitleDesigner = function (element) {
    /* Initialize PageTitleText fields */
    this._pageTitleText = null;
    
    /* Calls the base constructor */
    RandomSiteControls.PageTitle.Designer.PageTitleDesigner.initializeBase(this, [element]);
}

RandomSiteControls.PageTitle.Designer.PageTitleDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        RandomSiteControls.PageTitle.Designer.PageTitleDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        RandomSiteControls.PageTitle.Designer.PageTitleDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        /* RefreshUI PageTitleText */
        jQuery(this.get_pageTitleText()).val(controlData.PageTitleText);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges PageTitleText */
        controlData.PageTitleText = jQuery(this.get_pageTitleText()).val();
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* --------------------------------- properties -------------------------------------- */

    /* PageTitleText properties */
    get_pageTitleText: function () { return this._pageTitleText; }, 
    set_pageTitleText: function (value) { this._pageTitleText = value; }
}

RandomSiteControls.PageTitle.Designer.PageTitleDesigner.registerClass('RandomSiteControls.PageTitle.Designer.PageTitleDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
