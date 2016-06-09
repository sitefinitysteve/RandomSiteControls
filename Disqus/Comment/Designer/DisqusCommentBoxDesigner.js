Type.registerNamespace("RandomSiteControls.Disqus.Comment.Designer");

RandomSiteControls.Disqus.Comment.Designer.DisqusCommentBoxDesigner = function (element) {
    this._message = null;

    RandomSiteControls.Disqus.Comment.Designer.DisqusCommentBoxDesigner.initializeBase(this, [element]);
}

RandomSiteControls.Disqus.Comment.Designer.DisqusCommentBoxDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        RandomSiteControls.Disqus.Comment.Designer.DisqusCommentBoxDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        RandomSiteControls.Disqus.Comment.Designer.DisqusCommentBoxDesigner.callBaseMethod(this, 'dispose');
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
        $("#Identifier").val(controlData.Identifier);
        $("#Url").val(controlData.Url);
        $("#CategoryID").val(controlData.CategoryID);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        controlData.Title = $("#Title").val();
        controlData.Identifier = $("#Identifier").val();
        controlData.Url = $("#Url").val();
        controlData.CategoryID = $("#CategoryID").val();
    },


   

    /* --------------------------------- properties -------------------------------------- */
}

RandomSiteControls.Disqus.Comment.Designer.DisqusCommentBoxDesigner.registerClass('RandomSiteControls.Disqus.Comment.Designer.DisqusCommentBoxDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);

