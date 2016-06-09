Type.registerNamespace("RandomSiteControls.ContentLiteral.Designer");

RandomSiteControls.ContentLiteral.Designer.ContentLiteralDesigner = function (element) {
    this._message = null;

    RandomSiteControls.ContentLiteral.Designer.ContentLiteralDesigner.initializeBase(this, [element]);
}

RandomSiteControls.ContentLiteral.Designer.ContentLiteralDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        RandomSiteControls.ContentLiteral.Designer.ContentLiteralDesigner.callBaseMethod(this, 'initialize');

        //Initalize codemirror
        var textarea = $("#markupArea").get(0);
        this._codeMirror = CodeMirror.fromTextArea(textarea, {
            //value: this._templateDataField.get_textElement().innerHTML,
            mode: "htmlmixed",
            lineNumbers: true,
            matchBrackets: true,
            tabMode: "classic",
            /*onChange: function (n) {
                
            } */
        });
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        RandomSiteControls.ContentLiteral.Designer.ContentLiteralDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {        
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        var position = controlData.LiteralEmbedPosition;
        switch(position){
            case "Head":
                $("#radiobuttons_head").click();
                break;
            case "InPlace":
                $("#radiobuttons_inplace").click();
                break;
            case "BeforeBodyEndTag":
                $("#radiobuttons_end").click();
                break;
        }

        if (controlData.DesignModePreviewEncoding) {
            $('#encodeForPreview').attr("checked", "checked");
        }

        if (controlData.HtmlEncodeContent) {
            $('#encodeOnLive').attr("checked", "checked");
        }

        this._codeMirror.setValue(controlData.Markup);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        controlData.LiteralEmbedPosition = $("input:radio[name='radiobuttons']:checked").val();
        controlData.DesignModePreviewEncoding = $('#encodeForPreview').is(':checked');
        controlData.HtmlEncodeContent = $('#encodeOnLive').is(':checked');

        controlData.Markup = this._codeMirror.getValue();
    },

}

RandomSiteControls.ContentLiteral.Designer.ContentLiteralDesigner.registerClass('RandomSiteControls.ContentLiteral.Designer.ContentLiteralDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);

