$(document).ready(function () {
    $(".kendo-tabstrip").each(function () {

        //Get the root
        var container = $(this).closest(".tabStripContainer");
        var tabs = $(this).children();
        var subtabcontainer = container.find(".tabChildInner").children();
        var tabdata = new Array();

        //Create the tab data

        subtabcontainer.each(function (i) {
            var tabelement = tabs.eq(i);

            tabdata[i] = {
                text: tabelement.html(),
                content: $(this).html(),
                cssclass: tabelement.attr("data-css")
            };
        });


        $(this).kendoTabStrip({
            dataTextField: "text",
            dataContentField: "content",
            dataSpriteCssClass: "cssclass",
            dataSource: tabdata
        }).data("kendoTabStrip").select(1);

        //Remove the old elements
        container.find(".tabDesignContainer").remove();
        $(this).css("visibility", "visible");

        /*
        var container = $(this).closest(".tabStripContainer");
        var subtabcontainer = container.find(".tabChildInner");

        container.find(".tabConfigurator").remove();

        $(this).prependTo(subtabcontainer);
        $(this).kendoTabStrip().data("kendoTabStrip")

        $(this).css("visibility", "visible");
        container.find(".tabDesignContainer").show();
        */
    });
});