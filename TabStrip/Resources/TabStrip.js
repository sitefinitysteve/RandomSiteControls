function onSSTabStripLoad(sender, args) {
    var configurator = $(sender.get_element());
    var tabContainer = configurator.closest('.tabStripContainer');
    var selectedIndexControl = tabContainer.find("[id$='tabIndexState']");

    var currentSelectedTab = sender.get_selectedTab().get_index();

	//Cache the selectedIndex selector
    configurator.data("tabIndexState", selectedIndexControl);
    configurator.data("tabContainer", tabContainer);

    if (selectedIndexControl.val() != 0) {
    	currentSelectedTab = selectedIndexControl.val();
	}     

    if (configurator.data("animations") === false) {
        tabContainer.addClass("no-animations");
    }


    if($telerik.isIE6 || $telerik.isIE7 || $telerik.isIE8){
        tabContainer.addClass("old-ie-fix");
    }

    loadSSTabScript(tabContainer);

    //Only select default when we're not in design mode
    if (!sfs_IsInDesignMode()) { 
        if (currentSelectedTab !== 0) {
            var tabToSelect = sender.get_tabs().getTab(currentSelectedTab);
            if (tabToSelect !== null) {
                tabToSelect.select();

                selectSSMultipageItem(sender, currentSelectedTab);
            }
        }else{
            selectSSMultipageItem(sender, 0);
        }
    }
}

function onSSTabSelected(sender, args) {
    var newTabIndex = args.get_tab().get_index();
    
    var selectedValue = $(sender.get_element()).data("tabIndexState");
    selectedValue.val(newTabIndex);

    selectSSMultipageItem(sender, newTabIndex);
    newTabIndex = null;
}

function selectSSMultipageItem(tabstrip, index){
	var container = $(tabstrip.get_element()).data('tabContainer');
	var multiPageInner = container.find('.multiPageInner');
    var oldTab = multiPageInner.children();
    oldTab.removeClass("active");

    //TODO: Make sure we only try and swap if an element exists
    var newTab = multiPageInner.children(':eq(' + index + ')');
    newTab.addClass("active");

    container = null; 
}


function onSSTabSelecting(sender, args) {
    if (sfs_IsInDesignMode()) {
        args.set_cancel(true);
    }
}


function loadSSTabScript(tabContainer) {
    var tabDesignContainer = tabContainer.find('.tabDesignContainer');
    var hasScriptRun = tabDesignContainer.data("loaded");

    //Only run the script if it hasn't run already
    if (hasScriptRun === false) {
        //Get control references
        //var multiPage = tabContainer.find('.multiPageInner'); //This is where the tabs are
        var tabRoot = tabContainer.find('.tabRoot');
        var tabConfigurator = tabContainer.find('.tabConfigurator'); //Where the tabstrip lives

        var tabCount = 1; //index for the page view
        tabRoot.find('.multiPageInner').children().each(function () {
            $(this).addClass("tab-page");
            tabCount++;
        });
        
        if (tabCount > 0) {
            //multiPage.find('.sf_cols:first').show();
        }

        //Configure the tabstrip now
        var tabStripjQuery = tabConfigurator.find('[id$="tabStripControl"]');
        if (tabStripjQuery) {
            //Auto-resize Vertical **THIS IS A TEMP FIX**
            if (tabStripjQuery.hasClass("RadTabStripVertical")){
                //Get the width
                var stripWidth = tabStripjQuery.width();
                var parentWidth = tabStripjQuery.offsetParent().width();
                var percent = (parentWidth / stripWidth).toFixed(0);

                //Find the outer wrapper
                var tabStripOuter = tabStripjQuery.closest(".tabStripOuter");
                var tabsContentArea = tabStripOuter.parent().find(".tabDesignContainer");

                //Set the wrapper width
                tabStripOuter.css("width", percent + "%");
                tabsContentArea.css("width", (100 - percent) + "%");
                /*var width = $('#someElt').width();
                
                
                */
            }

        }

        var tabStripMsAjax = $find(tabStripjQuery.attr('id'));        
        if (tabStripMsAjax === null) {
            tabConfigurator.find('.tabStripInner').html('Unable to find the tabstrip, please add the TabStripConfigurator control to the Configurator layout area');
        }

        tabDesignContainer.data("loaded", true);  //Tell the control the init script ran

    }

    hasScriptRun = null; tabDesignContainer = null;
}

