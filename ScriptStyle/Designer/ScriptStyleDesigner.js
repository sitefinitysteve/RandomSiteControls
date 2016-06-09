$externalModel = null;


$codeMirror = {
    css: null,
    js:null
}

Type.registerNamespace("RandomSiteControls.ScriptStyleWidget.Designer");

RandomSiteControls.ScriptStyleWidget.Designer.ScriptStyleDesigner = function (element) {
    RandomSiteControls.ScriptStyleWidget.Designer.ScriptStyleDesigner.initializeBase(this, [element]);
}

RandomSiteControls.ScriptStyleWidget.Designer.ScriptStyleDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        RandomSiteControls.ScriptStyleWidget.Designer.ScriptStyleDesigner.callBaseMethod(this, 'initialize');

        var jsTextarea = $("#jsArea").get(0);
        $codeMirror.js = CodeMirror.fromTextArea(jsTextarea, {
            mode: "javascript",
            lineNumbers: true,
            matchBrackets: true
        });

        //Initalize codemirror
        var cssTextarea = $("#cssArea").get(0);
        $codeMirror.css = CodeMirror.fromTextArea(cssTextarea, {
            mode: "css",
            lineNumbers: true,
            matchBrackets: true
        });

        //Add in blur event for the input
        $('#scriptInput').keyup(function () {
            var $this = $(this);
            delay(function () {
                $externalModel.onInputBlur($this);
            }, 300);
        });

        //Init the external scripts MVVM
        $externalModel = kendo.observable({
            url: "",
            loadType: "defer",
            location: "Bottom",
            linkType: "script",
            status:"",

            linkTypes: [
                { name: "Script", value: "script" },
                { name: "Style", value: "style" }
            ],

            asyncTypes: [
                { name: "Defer", value: "defer" },
                { name: "Async", value: "async" },
                { name: "None", value: "" }
            ],
            
            headerItems:[],
            inPlaceItems:[],
            footerItems:[],

            addItemHead: function () {
                var url = this.get("url");
                if (url !== "" && url !== " ") {
                    this.get("headerItems").push({
                        url: this.get("url"),
                        linkType: this.get("linkType"),
                        loadType: this.get("loadType")
                    });
                }

                this.set("url", "");
                this.set("status", "");
                dialogBase.resizeToContent();
            },
            addItemInPlace: function () {
                var url = this.get("url");
                if (url !== "" && url !== " ") {
                    this.get("inPlaceItems").push({
                        url: this.get("url"),
                        linkType: this.get("linkType"),
                        loadType: this.get("loadType")
                    });
                }

                this.set("url", "");
                this.set("status", "");
                dialogBase.resizeToContent();
            },
            addItemBottom: function () {
                var url = this.get("url");
                if (url !== "" && url !== " ") {
                    this.get("footerItems").push({
                        url: this.get("url"),
                        linkType: this.get("linkType"),
                        loadType: this.get("loadType")
                    });
                }

                this.set("url", "");
                this.set("status", "");
                dialogBase.resizeToContent();
            },
            removeItem: function(e){
                // the current data item (product) is passed as the "data" field of the event argument
                var item = e.data;
                var headerItems = this.get("headerItems");
                var inPlaceItems = this.get("inPlaceItems");
                var footerItems = this.get("footerItems");
                var index = headerItems.indexOf(item);

                if(index == -1){
                    //Try InPlace
                    index = this.get("inPlaceItems").indexOf(item);

                    if (index == -1) {
                        //Try Footer, gotta be here
                        index = this.get("footerItems").indexOf(item);
                        footerItems.splice(index, 1);
                    }else{
                        inPlaceItems.splice(index, 1);
                    }
                }else{
                    headerItems.splice(index, 1);
                }

                dialogBase.resizeToContent();
            },
            onInputBlur: function (e) {
                var $this = this;
                var test_url = e.val().replace("~/", "/");

                //Fix the UI depending on type
                if (test_url.contains(".css") && this.get("linkType") === "script"){
                    this.set("linkType", "style");
                } else if (test_url.contains(".js") && this.get("linkType") === "style") {
                    this.set("linkType", "script");
                }


                
                $this.set("status", "");

                if (test_url.startsWith("/") || test_url.startsWith("http://" + window.location.hostname || test_url.startsWith("https://" + window.location.hostname))) {
                    if (test_url === "" && test_url === " ") {
                        $this.set("status", "");
                    } else {
                        if (test_url.contains(".css") || test_url.contains(".js") || test_url.contains(".less")) {
                            $.ajax({
                                url: test_url,
                                type: 'HEAD',
                                dataType: 'json',
                                timeout: 5000,
                                error: function (error) {
                                    if(error.status !== 200)
                                        file_exists = 0;
                                    else
                                        file_exists = 1;
                                },
                                success: function () {
                                    file_exists = 1;
                                },
                                complete: function () {
                                    if (file_exists === 1) {
                                        $this.set("status", "<i class='icon-ok-sign' title='Found'></i>");
                                    } else {
                                        $this.set("status", "<i class='icon-remove-sign' title='Not Found'></i>");
                                    }
                                }
                            });
                        }
                    }
                }
            }
        });

        kendo.bind($("#externalView"), $externalModel);

        $(".k-widget.k-dropdown").css("width", "75px");
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        RandomSiteControls.ScriptStyleWidget.Designer.ScriptStyleDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        if (controlData.JavaScriptText != null)
            $codeMirror.js.setValue(controlData.JavaScriptText);

        if (controlData.CssText != null)
            $codeMirror.css.setValue(controlData.CssText);

        var position = controlData.ScriptEmbedPosition;
        switch (position) {
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
        $("#description").val(controlData.Description);

        if (controlData.AllowScriptsInDesignMode) {
            $('#designModeScripts').attr("checked", "checked");
        }

        //Load the external Links
        var headerItems = JSON.parse(controlData.ExternalHeaderLinks);
        var inPlaceItems = JSON.parse(controlData.ExternalInPlaceLinks);
        var footerItems = JSON.parse(controlData.ExternalFooterLinks);

        $externalModel.set("headerItems", headerItems);
        $externalModel.set("inPlaceItems", inPlaceItems);
        $externalModel.set("footerItems", footerItems);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        controlData.ScriptEmbedPosition = $("input:radio[name='radiobuttons']:checked").val();
        controlData.JavaScriptText = $codeMirror.js.getValue();
        controlData.CssText = $codeMirror.css.getValue();
        controlData.Description = $("#description").val();
        controlData.AllowScriptsInDesignMode = $('#designModeScripts').is(':checked');

        //Save the external Links
        var headerItems = $externalModel.get("headerItems");
        var inPlaceItems = $externalModel.get("inPlaceItems");
        var footerItems = $externalModel.get("footerItems");
        controlData.ExternalHeaderLinks = JSON.stringify(headerItems);
        controlData.ExternalInPlaceLinks = JSON.stringify(inPlaceItems);
        controlData.ExternalFooterLinks = JSON.stringify(footerItems);

    },


    /* --------------------------------- properties -------------------------------------- */
}

RandomSiteControls.ScriptStyleWidget.Designer.ScriptStyleDesigner.registerClass('RandomSiteControls.ScriptStyleWidget.Designer.ScriptStyleDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);

function OnClientLoad(sender, args) {
    setTimeout(function () {
        $codeMirror.js.refresh();
        $codeMirror.css.refresh();
    }, 1000);

}

function OnClientTabSelected(sender, args) {
    var tab = args.get_tab().get_value();

    if (tab === "js") {
        //Js
        $codeMirror.js.refresh();
        $codeMirror.js.focus();
        dialogBase.resizeToContent();
    } else {
        //Css
        $codeMirror.css.refresh();
        $codeMirror.css.focus();
        dialogBase.resizeToContent();
    }

}

String.prototype.contains = function (it) { return this.indexOf(it) != -1; };

if (typeof String.prototype.startsWith != 'function') {
    // see below for better implementation!
    String.prototype.startsWith = function (str) {
        return this.indexOf(str) == 0;
    };
}

var delay = (function () {
    var timer = 0;
    return function (callback, ms) {
        clearTimeout(timer);
        timer = setTimeout(callback, ms);
    };
})();