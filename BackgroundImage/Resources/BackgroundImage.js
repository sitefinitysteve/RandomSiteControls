$(document).ready(function () {
    setBackgroundImages();

    if(sfs_IsInDesignMode()){
        setInterval("setBackgroundImages()", 3000);
    }
});

function setBackgroundImages() {
    $("[id$=backgroundImageHiddenField]").each(function () {
        var imageData = $(this).attr('value');  //Only run this if there's an image specified

        if (imageData != null || imageData != "") {
            var bkImageData = Sys.Serialization.JavaScriptSerializer.deserialize(imageData);

            if (!sfs_IsInDesignMode()) {
                $(this).parent().parent().css({ 'background-image': 'url(' + bkImageData.ImageURL + ')',
                    'background-position': bkImageData.PositionX + " " + bkImageData.PositionY,
                    'background-repeat': bkImageData.Repeat
                });

                $(this).parent().parent().addClass('bkDecoratedItem');
            }
            else {
                removeDecorations();

                //Is in design mode, so we want to go higher
                $(this).closest('.sf_colsIn').css({ 'background-image': 'url(' + bkImageData.ImageURL + ')',
                    'background-position': bkImageData.PositionX + " " + bkImageData.PositionY,
                    'background-repeat': bkImageData.Repeat
                });

                $(this).closest('.sf_colsIn').addClass('bkDecoratedItem');

                $(this).closest('.rdMiddle').hide();
                $(this).closest('.zeControlDock').css('margin-bottom', '0px');

            }

            bkImageData = null;
        }

        imageData = null;
    });
}

function removeDecorations(){
    $('.bkDecoratedItem').each(function () {
        $(this).css({ 'background-image': '',
                      'background-position': '',
                      'background-repeat': ''
                    });
    });
}