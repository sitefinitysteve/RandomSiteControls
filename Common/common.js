function resizeDesigner() {
    if (dialogBase != null){
        dialogBase.resizeToContent(); //Refresh
    }
}

function sfs_IsInDesignMode() {
    var sfPageEditor = $('.sfPageEditor');
    if (sfPageEditor.index() > -1) {
        return true;
    } else {
        return false;
    }
}

function sfs_AddCommandToToolbar(container, linktextclass, text, clickfuntion) {
  /* if(!$telerik.isIE) 
        $('.fancyOuterlayout', container).closest('.rdTable').find('.rdTop').find('.rdCommands').delay(1000).append('<li><a title="' + text + '" onclick="' + clickfuntion + '"><span class="' + linktextclass + '">' + text + '</span></a></li>');
  */
}

/* ####################### */
/* ## SKIN HELPERS      ## */
/* ####################### */
function OnSkinDropDownClosedHandler(sender, args) {
    checkSkinState(sender);
}

function OnClientTextChange(sender, args) {
    checkSkinState(sender);
}

function checkSkinState(combo) {
    var value = combo.get_value();

    if (value == "") {
        $('#comboSkinLabel').html("FYI, this skin isn't in the telerik suite, make sure you attach a css file to your page which contains the <a href='http://www.telerik.com/help/aspnet-ajax/createcustomskin.html' target='_blank'>skin definition</a>");
    } else {
        $('#comboSkinLabel').html("");
    }

    if (dialogBase != null) {
        dialogBase.resizeToContent(); //Refresh
    }
    combo = null; value = null;
}
/* ####################### */
/* ## END SKIN HELPERS      ## */
/* ####################### */