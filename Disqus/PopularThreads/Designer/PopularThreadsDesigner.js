Type.registerNamespace("RandomSiteControls.Disqus.PopularThreads.Designer");

RandomSiteControls.Disqus.PopularThreads.Designer.PopularThreadsDesigner = function (element) {
    this._message = null;

    RandomSiteControls.Disqus.PopularThreads.Designer.PopularThreadsDesigner.initializeBase(this, [element]);
}

RandomSiteControls.Disqus.PopularThreads.Designer.PopularThreadsDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        RandomSiteControls.Disqus.PopularThreads.Designer.PopularThreadsDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        RandomSiteControls.Disqus.PopularThreads.Designer.PopularThreadsDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

	findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {        
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        /* RefreshUI Message */
        $("#Title").val(controlData.Title);
        
        var numItemsBox = $find("NumToDisplay");
        numItemsBox.set_value(controlData.NumberOfItems);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        controlData.Title = $("#Title").val();
        
        var numItemsBox = $find("NumToDisplay");
        controlData.NumberOfItems = numItemsBox.get_value();
    },


   

    /* --------------------------------- properties -------------------------------------- */
}

RandomSiteControls.Disqus.PopularThreads.Designer.PopularThreadsDesigner.registerClass('RandomSiteControls.Disqus.PopularThreads.Designer.PopularThreadsDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);

