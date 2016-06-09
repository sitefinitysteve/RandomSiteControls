<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>



<link href="//netdna.bootstrapcdn.com/font-awesome/3.1.1/css/font-awesome.min.css" rel="stylesheet">

<!--[if IE 7]>
<link href="//netdna.bootstrapcdn.com/font-awesome/3.1.1/css/font-awesome-ie7.min.css" rel="stylesheet">
<![endif]-->

<sitefinity:ResourceLinks ID="resourcesLinks1" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
    <sitefinity:ResourceFile Name="Styles/Tabstrip.css"/> 
</sitefinity:ResourceLinks>
<sitefinity:ResourceLinks ID="resourcesLinks2" runat="server" UseEmbeddedThemes="true" Theme="Default">
    <sitefinity:ResourceFile JavaScriptLibrary="JQuery" />
    <sitefinity:ResourceFile JavaScriptLibrary="KendoWeb" />
</sitefinity:ResourceLinks> 
<sitefinity:ResourceLinks id="resourcesLinks3" runat="server" UseEmbeddedThemes="true" Theme="Default">
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_common_min.css" Static="True" />
</sitefinity:ResourceLinks>
<sitefinity:ResourceLinks ID="ResourceLinks1" runat="server" UseEmbeddedThemes="true" Theme="Default">
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.CodeMirror.codemirror.css" Static="True" />
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.CodeMirror.Theme.default.css" Static="True" />
</sitefinity:ResourceLinks>      

<link href="http://cdn.kendostatic.com/2013.1.319/styles/kendo.default.min.css" rel="stylesheet" />

<div class="sfContentViews" style="max-height: 600px; overflow: auto; width: 600px ">
    <telerik:RadTabStrip ID="tabStrip" runat="server" MultiPageID="multiPage" Skin="Default"  CssClass="sfSwitchControlViews" OnClientTabSelected="OnClientTabSelected" OnClientLoad="OnClientLoad">
        <Tabs>
            <telerik:RadTab Text="General" Value="general"  Selected="true" />
            <telerik:RadTab Text="JavaScript" Value="js"  />
            <telerik:RadTab Text="Css\Styles" Value="css" />
            <telerik:RadTab Text="External" Value="external" />
            <telerik:RadTab Text="Templates" Value="templates" />
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="multiPage" runat="server" CssClass="multiPage">
        <telerik:RadPageView runat="server"  Selected="true">
            <h2>Description</h2>
            <input id="description" type="text" class="k-textbox" style="width: 60%" placeholder="What does this widget do" />
            <div class="sfExample">Text that appears only in the page designer, so you can write out what these scripts\styles do.</div>

            <h2>Inline JavaScript</h2>
            <div class="left-options">
                <span class="sfRadioList sfFieldWrp" >
                    <input type="radio" value="Head" name="radiobuttons" id="radiobuttons_head"><label for="radiobuttons_0" title="No wrapper will be rednered">In the head tag</label><br>
                    <input type="radio" value="InPlace" name="radiobuttons" id="radiobuttons_inplace" checked="checked"><label for="radiobuttons_1">Where the widget is dropped</label><br>
                    <input type="radio" value="BeforeBodyEndTag" name="radiobuttons" id="radiobuttons_end"><label for="radiobuttons_2" title="No wrapper will be rednered">Before the closing body tag</label>
                </span>
                <div style="margin-top: 9px">
                    <label>
                        <input type="checkbox" id="designModeScripts" />
                        Script can run in design mode
                    </label>
                </div>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" Height="400px">
             <ul id="scriptPage">        
                <li class="sfFormCtrl markup-container">
                    <div class="markup-wrappers">
                        <span class="blue">&lt;</span><span class="brown">script </span><span class="red">type</span><span class="blue">='text/javascript'&gt;</span>
                    </div>
                    <textarea id="jsArea"></textarea>
                    <div class="markup-wrappers">
                        <span class="blue">&lt;/</span><span class="brown">script</span><span class="blue">&gt;</span>
                    </div>
                    <div class="sfExample" style="padding-top: 10px">
                        Content will be automatically wrapped in script tags
                    </div>
                </li>
            </ul>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" Height="400px">
            <ul>        
                <li class="sfFormCtrl markup-container">
                    <div class="markup-wrappers">
                        <span class="blue">&lt;</span><span class="brown">script </span><span class="red">type</span><span class="blue">='text/css'&gt;</span>
                    </div>
                    <textarea id="cssArea"></textarea>
                    <div class="markup-wrappers">
                        <span class="blue">&lt;/</span><span class="brown">style</span><span class="blue">&gt;</span>
                    </div>
                    <div class="sfExample" style="padding-top: 10px">
                        Content will be automatically wrapped in style tags
                    </div>
                </li>
            </ul>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" Height="400px">
            <div id="externalView">
                <div data-bind="attr: { class: linkType }">
                    <h2>Linker</h2>
                    <select id="typeDropDown" data-role="dropdownlist"
                            data-text-field="name" 
                            data-value-field="value" 
                            data-bind="source: linkTypes, value: linkType">
                    </select>
                    <input id="scriptInput" type="text" placeholder="Url of the file" class="k-textbox" data-bind="value: url" />
                    <select id="deferInput" data-role="dropdownlist"
                            data-text-field="name"  class="deferInput"
                            data-value-field="value" 
                            data-bind="source: asyncTypes, value: loadType">
                    </select>
                    <span id="found" data-bind="html: status"></span>
                    <div id="buttons" >
                        <span>Add To:</span>
                        <input id="head" data-bind="click: addItemHead" value="Head" type="button" class="k-button" />
                        <input id="inPlace" data-bind="click: addItemInPlace" value="In Place" type="button" class="k-button" />
                        <input id="bottom" data-bind="click: addItemBottom" value="Bottom" type="button" class="k-button" />
                    </div>
                </div>

                <div class="markup-wrappers">
                    <span class="blue tab1">&lt;</span><span class="brown">head</span><span class="blue">&gt;</span><br />
                    <ul class="tab2" data-template="script-row-template" data-bind="source: headerItems"></ul>
                    <span class="blue tab1">&lt;</span><span class="brown">/head</span><span class="blue">&gt;</span><br />
                    <span class="blue tab1">&lt;</span><span class="brown">body</span><span class="blue">&gt;</span><br />
                    <span class="green tab2">&lt;!-- Markup --&gt;</span><br />
                    <ul class="tab2" data-template="script-row-template" data-bind="source: inPlaceItems"></ul>
                    <span class="green tab2">&lt;!-- Markup --&gt;</span><br />
                    <ul class="tab2" data-template="script-row-template" data-bind="source: footerItems"></ul>
                    <span class="blue tab1">&lt;</span><span class="brown">/body</span><span class="blue">&gt;</span><br />
                </div>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" Height="400px">
            <div>
                <h2>Register Directive at the top of the markup</h2>
                <div style="border: 1px solid #7f9db9; overflow-y: auto;" class="reCodeBlock">
                    <div style="background-color: #ffffff;"><span style="margin-left: 0px ! important;"><code style="color: #000000;">&lt;%@ Register Assembly="RandomSiteControls" TagPrefix="sf" Namespace="RandomSiteControls" %&gt;</code></span></div>
                </div>

                <h2>Optionally you can put this in the webconfig to never have to use the register</h2>
                <div style="border: 1px solid #7f9db9; overflow-y: auto;" class="reCodeBlock">
                    <div style="background-color: #ffffff;"><span style="margin-left: 0px ! important;"><code style="color: #000000;">&lt;</code><code style="color: #006699; font-weight: bold;">pages</code><code style="color: #000000;">&gt;</code></span></div>
                    <div style="background-color: #f8f8f8;"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left: 12px ! important;"><code style="color: #000000;">&lt;</code><code style="color: #006699; font-weight: bold;">controls</code><code style="color: #000000;">&gt;</code></span></span></div>
                    <div style="background-color: #ffffff;"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left: 24px ! important;"><code style="color: #000000;">&lt;</code><code style="color: #006699; font-weight: bold;">add</code> <code style="color: #808080;">tagPrefix</code><code style="color: #000000;">=</code><code style="color: blue;">"sf"</code> <code style="color: #808080;">namespace</code><code style="color: #000000;">=</code><code style="color: blue;">"RandomSiteControls"</code> <code style="color: #808080;">assembly</code><code style="color: #000000;">=</code><code style="color: blue;">"RandomSiteControls"</code> <code style="color: #000000;">/&gt;</code></span></span></div>
                    <div style="background-color: #f8f8f8;"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left: 12px ! important;"><code style="color: #000000;">&lt;/</code><code style="color: #006699; font-weight: bold;">controls</code><code style="color: #000000;">&gt;</code></span></span></div>
                    <div style="background-color: #ffffff;"><span style="margin-left: 0px ! important;"><code style="color: #000000;">&lt;/</code><code style="color: #006699; font-weight: bold;">pages</code><code style="color: #000000;">&gt;</code></span></div>
                </div>
            </div>
            <div>
                <h2>Sample Code:</h2>
                    <div style="border: 1px solid #7f9db9; overflow-y: auto;" class="reCodeBlock">
                    <div style="background-color: #ffffff;"><span style="margin-left: 0px ! important;"><code style="color: #000000;">&lt;</code><code style="color: #006699; font-weight: bold;">sf:ScriptStyle</code> <code style="color: #808080;">runat</code><code style="color: #000000;">=</code><code style="color: blue;">"server"</code> <code style="color: #808080;">ScriptEmbedPosition</code><code style="color: #000000;">=</code><code style="color: blue;">"Head|InPlace|BeforeBodyEndTag"</code><code style="color: #000000;">&gt;</code></span></div>
                    <div style="background-color: #f8f8f8;"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left: 12px ! important;"><code style="color: #000000;">&lt;</code><code style="color: #006699; font-weight: bold;">script</code><code style="color: #000000;">&gt;</code></span></span></div>
                    <div style="background-color: #ffffff;"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left: 24px ! important;"><code style="color: #000000;">//Your Javascript goes here, no script tag needed</code></span></span></div>
                    <div style="background-color: #f8f8f8;"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left: 12px ! important;"><code style="color: #000000;">&lt;/</code><code style="color: #006699; font-weight: bold;">script</code><code style="color: #000000;">&gt;</code></span></span></div>
                    <div style="background-color: #ffffff;"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left: 12px ! important;"><code style="color: #000000;">&lt;</code><code style="color: #006699; font-weight: bold;">style</code><code style="color: #000000;">&gt;</code></span></span></div>
                    <div style="background-color: #f8f8f8;"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left: 24px ! important;"><code style="color: #000000;">//Your Css Goes here, no style tag needed</code></span></span></div>
                    <div style="background-color: #ffffff;"><span><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span style="margin-left: 12px ! important;"><code style="color: #000000;">&lt;/</code><code style="color: #006699; font-weight: bold;">style</code><code style="color: #000000;">&gt;</code></span></span></div>
                    <div style="background-color: #f8f8f8;"><span style="margin-left: 0px ! important;"><code style="color: #000000;">&lt;/</code><code style="color: #006699; font-weight: bold;">sf:ScriptStyle</code><code style="color: #000000;">&gt;</code></span></div>
                </div>
                <div class="sfExample">
                    All ScriptEmbedPosition Options are shown, choose only one
                </div>
            </div>

        </telerik:RadPageView>
    </telerik:RadMultiPage>
</div>



<style type="text/css">
    .style #inPlace,
    .style #bottom,
    .style .deferInput{
        display:none;
    }

    .CodeMirror-scroll{
        background-color: #FFFFFF;
    }

    #scriptInput {
        width: 300px;
    }

    #buttons {
        padding-top: 10px;
        padding-bottom: 10px;
    }

    .markup-wrappers {
        line-height: 23px;
        font-size: 13px;
        opacity: 0.6;
        -moz-user-select: none;
        -ms-user-select: none;
        -webkit-user-select: none;
        user-select: none;
        cursor: default;
    }

        .markup-wrappers .selectable {
            -moz-user-select: text;
            -ms-user-select: text;
            -webkit-user-select: text;
            user-select: text;
        }

    .markup-wrappers .red{
        color: #FF0000;
    }

    .markup-wrappers .blue{
        color: #0000FF;
    }

    .markup-wrappers .brown{
        color: #800000;
    }

    .markup-wrappers .green{
        color: #008034;
    }

    .markup-container{
        margin-top: 7px !important;
    }

    .remove {
        font-size:11px !important;
        margin-left: 10px;
        padding:0 3px !important;
        width: 58px;
    }

    .tab1 {
        margin-left: 10px;
    }

    .tab2 {
        margin-left: 30px;
    }

    .tab3 {
        margin-left: 40px;
    }

    .tab4 {
        margin-left: 50px;
    }

    .tab5 {
        margin-left: 60px;
    }

    #found{
        font-size: 22px;
        line-height: 15px;
        vertical-align: middle;
        display: inline-block;
    }

    #found .icon-remove-sign{
        color:#F74F4F;
    }

    #found .icon-ok-sign{
        color:#54D434;
    }


</style>


<!-- TEMPLATES -->
<script id="script-row-template" type="text/x-kendo-template">
    <li>
        #if(linkType === "script"){#
            <span class='blue'>&lt;</span><span class='brown'>script</span> <span class='red'>src</span><span class='blue'>="</span><span class='blue selectable' data-bind="text: url"></span><span class='blue'>"</span> <span class='red' data-bind="text: loadType"></span>
        #}else{#
            <span class='blue'>&lt;</span><span class='brown'>link</span> <span class='red'>href</span><span class='blue'>="</span><span class='blue selectable' data-bind="text: url"></span><span class='blue'>"</span>
        #}#
        <input class="k-button remove" data-bind="click: removeItem" value="Remove" type="button" />
    </li>
</script>