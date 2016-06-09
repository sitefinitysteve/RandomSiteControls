Type.registerNamespace("RandomSiteControls.TabStrip");

RandomSiteControls.TabStrip.TabStripDesigner = function (element) {
    RandomSiteControls.TabStrip.TabStripDesigner.initializeBase(this, [element]);
}
RandomSiteControls.TabStrip.TabStripDesigner.prototype = {
    initialize: function () {
        RandomSiteControls.TabStrip.TabStripDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        RandomSiteControls.TabStrip.TabStripDesigner.callBaseMethod(this, 'dispose');
    },
    refreshUI: function () {
        /* CONTROL REFERENCES */
        var dynamicTabStrip = $find('dynamicTabStrip');
        var skinComboBox = $find('skinComboBox');
        var tabStripRenderStyleComboBox = $find('tabStripRenderStyleComboBox');
        var defaultTabBox = $find('defaultTabTextBox');
        var tabStripAlignStyleComboBox = $find("tabStripAlignStyleComboBox");
        var coreQuerystringKey = $("#coreQuerystringKey");
        

        //SET VALUES GOING TO CLIENT
        var data = this.get_controlData();
        skinComboBox.set_text(data.Skin);
        tabStripRenderStyleComboBox.set_text(data.Rendering);
        defaultTabBox.set_value(data.DefaultTab);
        defaultTabBox.set_maxValue(data.TabCount);
        coreQuerystringKey.val(data.QueryStringKey);

        //Hide/Show the skin picker
        if (data.ShowSkinPicker === false) {
            $("#hidepicker").show();
            $("#showpicker").hide();
        }
        else {
            $("#hidepicker").hide();
            $("#showpicker").show();
        }

        var item = tabStripAlignStyleComboBox.findItemByText(data.Alignment);
        item.select();

        //Loop through the tabs
        var tabs = Sys.Serialization.JavaScriptSerializer.deserialize(data.TabNames);
        if (tabs.length > 0) {
            dynamicTabStrip.get_tabs().clear(); //clear the default tab

            //populate it with the items in the DB
            for (var i = 0; i < tabs.length; i++) {
                dynamicTabStrip.trackChanges();

                tabs[i] = validateStructure(tabs[i]);

                var tab = new Telerik.Web.UI.RadTab();
                tab.set_text(tabs[i].Text);

                if (tabs[i].CssClass != "")
                    tab.set_outerCssClass(tabs[i].CssClass);

                if (tabs[i].Image != "")
                    tab.set_imageUrl(tabs[i].Image);

                if (tabs[i].NavigateUrl != "" && tabs[i].NavigateUrl != "#")
                    tab.set_value(tabs[i].NavigateUrl);

                if (tabs[i].Key != "")
                    tab.set_key(tabs[i].Key);

                dynamicTabStrip.get_tabs().add(tab);
                dynamicTabStrip.commitChanges();

                if (tab.get_index() == 0)
                    wireUpTab(tab);
            }

            checkRemoveButtonVisibility();
        }

        resizeDesigner();
    },
    applyChanges: function () {
        /* CONTROL REFERENCES */
        var dynamicTabStrip = $find('dynamicTabStrip');
        var skinComboBox = $find('skinComboBox');
        var tabStripRenderStyleComboBox = $find('tabStripRenderStyleComboBox');
        var defaultTabBox = $find('defaultTabTextBox');
        var tabStripAlignStyleComboBox = $find("tabStripAlignStyleComboBox");

        //Compile the tabitems
        var tabs = dynamicTabStrip.get_tabs();
        var flatTabs = new Array();
        for (var i = 0; i < getTabCount(); i++) {
            var tab = new Object();
            tab.Text = tabs.getTab(i).get_text();
            tab.Image = tabs.getTab(i).get_imageUrl();
            tab.NavigateUrl = tabs.getTab(i).get_value();
            tab.CssClass = tabs.getTab(i).get_outerCssClass();
            tab.Key = tabs.getTab(i).get_key();

            flatTabs[i] = tab;
        }

        //SET VALUES GOING TO SERVER
        var controlData = this.get_controlData();
        controlData.Skin = skinComboBox.get_text();
        controlData.Rendering = tabStripRenderStyleComboBox.get_text();
        controlData.TabNames = Sys.Serialization.JavaScriptSerializer.serialize(flatTabs);
        controlData.DefaultTab = defaultTabBox.get_value();
        controlData.Alignment = tabStripAlignStyleComboBox.get_text();
        controlData.QueryStringKey = $("#coreQuerystringKey").val();
    }
}

//Check for new properties here
function validateStructure(tab) {
	//Create the object
	var tempTab = new Object();
	
	tempTab.Text = tab.Text;
	tempTab.Image = tab.Image;
	tempTab.NavigateUrl = tab.NavigateUrl;
	tempTab.CssClass = tab.CssClass;

	//New properties
	tempTab.Key = "";
	tempTab.Key = tab.Key;

	return tempTab;
}

RandomSiteControls.TabStrip.TabStripDesigner.registerClass('RandomSiteControls.TabStrip.TabStripDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
