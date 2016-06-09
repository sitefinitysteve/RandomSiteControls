<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>
<%@ Register Assembly="Telerik.Web.UI" TagPrefix="telerik" Namespace="Telerik.Web.UI" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
    <sitefinity:ResourceFile JavaScriptLibrary="JQuery" />
    <sitefinity:ResourceFile JavaScriptLibrary="KendoWeb" />
</sitefinity:ResourceLinks>

<sitefinity:ResourceLinks id="ResourceLinks1" runat="server" UseEmbeddedThemes="true" Theme="Default">
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_common_min.css" Static="True" />
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_default_min.css" Static="True" />
</sitefinity:ResourceLinks>

<link href="http://cdn.kendostatic.com/2013.1.319/styles/kendo.default.min.css" rel="stylesheet" />

<div id="controlsContainer" class="sfContentViews sfSingleContentView clearfix" style="height: 460px; width: 700px; overflow: auto; ">
    <div class="clearfix sfClearFix placeholder-wrapper">
        <ol id="controls">        
            <li class="sfFormCtrl">
                <h2>Width</h2>
                <input type="text" data-role="numerictextbox" type="number" data-min="1" data-bind="value: width" data-decimals="0"  data-format="d"  />
            </li>
            <li class="sfFormCtrl">
                <h2>Height</h2>
                <input type="text" data-role="numerictextbox" type="number" data-min="1" data-bind="value: height" data-decimals="0" data-format="d" />
            </li>    
            <li class="sfFormCtrl">
                <h2>Image Text</h2>
                <input type="text" data-bind="value: text" class="k-textbox" placeholder="(Optional)"  />
            </li>    
            <li class="sfFormCtrl">
                <h2>Background Color</h2>
                <telerik:RadColorPicker id="backgroundPicker" runat="server" KeepInScreenBounds="true" Preset="Metro" Skin="Metro" OnClientColorChange="onBackgroundColorChange" ClientIDMode="Static" />
            </li>    
            <li class="sfFormCtrl">
                <h2>Text Color</h2>
                <telerik:RadColorPicker id="textPicker" runat="server" KeepInScreenBounds="true" Preset="Metro" Skin="Metro" OnClientColorChange="onTextColorChange" ClientIDMode="Static" />
            </li>    
        
        </ol>
        <div class="preview">
            <img data-bind="attr: { src: getUrl }" style="max-width: 450px" />
        </div>
    </div>
    <div class="donate">
        Thanks to <a href="http://placehold.it" target="_blank">http://placehold.it</a> for providing an awesome service, please donate!
    </div>
</div>



<style type="text/css">
    .placeholder-wrapper{
        position:relative;
    }

    .preview {
        position: absolute;
        top:0;
        left:200px;
        width: 499px;
        background: #FFF;
        padding: 10px;
        overflow-y: scroll;
        height: 436px;
        -moz-box-sizing: border-box;
        -webkit-box-sizing: border-box;
        box-sizing: border-box;
    }

    .sfFormCtrl{
        margin-top:0 !important;
    }

    .preview img{
        max-width: 300px;
    }

    #controls{
        position: absolute;
        top:0;
        left:0;
        width: 176px;
    }

    .donate{
        bottom: 51px;
        left:0;
        position:absolute;
    }
</style>