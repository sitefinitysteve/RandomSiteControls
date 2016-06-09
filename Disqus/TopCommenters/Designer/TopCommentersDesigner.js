Type.registerNamespace("RandomSiteControls.Disqus.TopCommenters.Designer");

RandomSiteControls.Disqus.TopCommenters.Designer.TopCommentersDesigner = function (element) {
    this._message = null;

    RandomSiteControls.Disqus.TopCommenters.Designer.TopCommentersDesigner.initializeBase(this, [element]);
}

RandomSiteControls.Disqus.TopCommenters.Designer.TopCommentersDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        RandomSiteControls.Disqus.TopCommenters.Designer.TopCommentersDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        RandomSiteControls.Disqus.TopCommenters.Designer.TopCommentersDesigner.callBaseMethod(this, 'dispose');
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

        var avatarComboBox = $find("AvatarSize");
        avatarComboBox.findItemByValue(controlData.AvatarSize).select();

        $("#hide-avatars").prop("checked", controlData.HideAvatars);
        $("#hide-mods").prop("checked", controlData.HideModerators);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        controlData.Title = $("#Title").val();

        var numItemsBox = $find("NumToDisplay");
        controlData.NumberOfItems = numItemsBox.get_value();

        var avatarComboBox = $find("AvatarSize");
        controlData.AvatarSize = avatarComboBox.get_value();


        controlData.HideAvatars = $("#hide-avatars").prop("checked");
        controlData.HideModerators = $("#hide-mods").prop("checked");
    },


   

    /* --------------------------------- properties -------------------------------------- */
}

RandomSiteControls.Disqus.TopCommenters.Designer.TopCommentersDesigner.registerClass('RandomSiteControls.Disqus.TopCommenters.Designer.TopCommentersDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);

