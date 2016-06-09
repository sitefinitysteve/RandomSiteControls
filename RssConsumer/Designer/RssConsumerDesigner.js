Type.registerNamespace("RandomSiteControls.RssConsumer.Designer");

RandomSiteControls.RssConsumer.Designer.RssConsumerDesigner = function (element) {
    /* Initialize RssFeed fields */
    this._rssFeed = null;
    
    /* Initialize RssFeedTimeoutSeconds fields */
    this._rssFeedTimeoutSeconds = null;
    
    /* Initialize Take fields */
    this._take = null;
    
    /* Initialize XPath fields */
    this._xPath = null;
    
    /* Calls the base constructor */
    RandomSiteControls.RssConsumer.Designer.RssConsumerDesigner.initializeBase(this, [element]);
}

RandomSiteControls.RssConsumer.Designer.RssConsumerDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        RandomSiteControls.RssConsumer.Designer.RssConsumerDesigner.callBaseMethod(this, 'initialize');

        $("#Take").kendoNumericTextBox({
            min: 1,
            decimals: 0,
            format: "#"
        });

    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        RandomSiteControls.RssConsumer.Designer.RssConsumerDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        /* RefreshUI RssFeed */
        jQuery(this.get_rssFeed()).val(controlData.RssFeed);

        /* RefreshUI Take */
        $("#Take").data("kendoNumericTextBox").value(controlData.Take);

        /* RefreshUI XPath */
        jQuery(this.get_xPath()).val(controlData.XPath);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges RssFeed */
        controlData.RssFeed = jQuery(this.get_rssFeed()).val();

        /* ApplyChanges Take */
        controlData.Take = $("#Take").data("kendoNumericTextBox").value();

        /* ApplyChanges XPath */
        controlData.XPath = jQuery(this.get_xPath()).val();
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* --------------------------------- properties -------------------------------------- */

    /* RssFeed properties */
    get_rssFeed: function () { return this._rssFeed; }, 
    set_rssFeed: function (value) { this._rssFeed = value; },

    /* RssFeedTimeoutSeconds properties */
    get_rssFeedTimeoutSeconds: function () { return this._rssFeedTimeoutSeconds; }, 
    set_rssFeedTimeoutSeconds: function (value) { this._rssFeedTimeoutSeconds = value; },

    /* Take properties */
    get_take: function () { return this._take; }, 
    set_take: function (value) { this._take = value; },

    /* XPath properties */
    get_xPath: function () { return this._xPath; }, 
    set_xPath: function (value) { this._xPath = value; }
}

RandomSiteControls.RssConsumer.Designer.RssConsumerDesigner.registerClass('RandomSiteControls.RssConsumer.Designer.RssConsumerDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
