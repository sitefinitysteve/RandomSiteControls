<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
</sitefinity:ResourceLinks>
<sitefinity:ResourceLinks ID="resourcesLinks2" runat="server" UseEmbeddedThemes="true" Theme="Default">
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.CodeMirror.codemirror.css" Static="True" />
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.CodeMirror.Theme.default.css" Static="True" />
</sitefinity:ResourceLinks>        


<style type="text/css">
    #markupArea{
        width: 98%;
        height: 300px;
    }

    
    .CodeMirror-scroll{
        background-color: #FFFFFF;
    }

    .left-options{
        float:left;
    }

    .right-options{
        float:right;
    }
</style>

<div class="sfContentViews sfSingleContentView" style="max-height: 500px; overflow: auto; width: 600px ">
    <ul>        
        <li class="sfFormCtrl">
            <textarea id="markupArea"></textarea>
            <div class="sfExample" style="padding-top: 10px">
                Content will be rendered out literally onto the page.  You can write javascript\css\html, whatever.
            </div>
        </li>
        <li class="sfFormCtrl sfClearfix">
            <div class="left-options">
                <div class="sfTxtLbl">
                    Where to include in the HTML?
                </div>
                <span class="sfRadioList sfFieldWrp" >
                    <input type="radio" value="Head" name="radiobuttons" id="radiobuttons_head"><label for="radiobuttons_0" title="No wrapper will be rednered">In the head tag</label><br>
                    <input type="radio" value="InPlace" name="radiobuttons" id="radiobuttons_inplace" checked="checked"><label for="radiobuttons_1">Where the widget is dropped</label><br>
                    <input type="radio" value="BeforeBodyEndTag" name="radiobuttons" id="radiobuttons_end"><label for="radiobuttons_2" title="No wrapper will be rednered">Before the closing body tag</label>
                </span>
            </div>
            <div class="right-options">
                <span class="sfCheckListBox sfFieldWrp">
                    <input id="encodeForPreview" type="checkbox" />
                    <label for="encodeForPreview">Encode for Preview</label>
                    <div class="sfExample">Allows you to see the markup in the designer, <br />scripts or css for example</div>
                    <input id="encodeOnLive" type="checkbox" />
                    <label for="encodeOnLive">Encode Rendered Content</label>
                </span>
                
            </div>
        </li>
    </ul>
</div>
