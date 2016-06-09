Type.registerNamespace("RandomSiteControls.PageData");

RandomSiteControls.PageData.PageDataDesigner = function (element) {
    RandomSiteControls.PageData.PageDataDesigner.initializeBase(this, [element]);
}
RandomSiteControls.PageData.PageDataDesigner.prototype = {
    initialize: function () {
        RandomSiteControls.PageData.PageDataDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        RandomSiteControls.PageData.PageDataDesigner.callBaseMethod(this, 'dispose');
    },
    refreshUI: function () {
        /* CONTROL REFERENCES */

        //SET VALUES GOING TO CLIENT
        var data = this.get_controlData();

    },
    applyChanges: function () {
        /* CONTROL REFERENCES */


        //SET VALUES GOING TO SERVER
        var controlData = this.get_controlData();


    }
}

RandomSiteControls.PageData.PageDataDesigner.registerClass('RandomSiteControls.PageData.PageDataDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
