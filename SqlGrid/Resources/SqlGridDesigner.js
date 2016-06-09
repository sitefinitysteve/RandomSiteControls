Type.registerNamespace("RandomSiteControls.SqlGrid");

RandomSiteControls.SqlGrid.SqlGridDesigner = function (element) {
    RandomSiteControls.SqlGrid.SqlGridDesigner.initializeBase(this, [element]);
}
RandomSiteControls.SqlGrid.SqlGridDesigner.prototype = {
    initialize: function () {
        RandomSiteControls.SqlGrid.SqlGridDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        RandomSiteControls.SqlGrid.SqlGridDesigner.callBaseMethod(this, 'dispose');
    },
    refreshUI: function () {
        /* CONTROL REFERENCES */
        var connectionStringComboBox = $find('connectionStringComboBox');
        var selectStatementTextBox = $find('selectStatementTextBox');
        var skinComboBox = $find('skinComboBox');
        var pagerSizeTextBox = $find('pagerSizeTextBox');

        //SET VALUES GOING TO CLIENT
        var data = this.get_controlData();

        pagerSizeTextBox.set_value(data.PagerSize.toString());
        connectionStringComboBox.set_text(data.ConnectionString);
        skinComboBox.set_text(data.Skin);
        selectStatementTextBox.set_value(data.SelectStatement);

        $('#allowSortingCheckBox').attr('checked', data.AllowSorting);
        $('#allowPagingCheckBox').attr('checked', data.AllowPaging);
        $('#allowFilteringCheckBox').attr('checked', data.AllowFilteringByColumn);
        $('#allowGroupingCheckBox').attr('checked', data.AllowGrouping);
    },
    applyChanges: function () {
        /* CONTROL REFERENCES */
        var connectionStringComboBox = $find('connectionStringComboBox');
        var selectStatementTextBox = $find('selectStatementTextBox');
        var skinComboBox = $find('skinComboBox');
        var pagerSizeTextBox = $find('pagerSizeTextBox');

        //SET VALUES GOING TO SERVER
        var controlData = this.get_controlData();
        controlData.ConnectionString = connectionStringComboBox.get_text();
        controlData.SelectStatement = selectStatementTextBox.get_value();
        controlData.Skin = skinComboBox.get_text();
        controlData.PagerSize = pagerSizeTextBox.get_value();

        controlData.AllowSorting = $('#allowSortingCheckBox').is(':checked');
        controlData.AllowPaging = $('#allowPagingCheckBox').is(':checked');
        controlData.AllowFilteringByColumn = $('#allowFilteringCheckBox').is(':checked');
        controlData.AllowGrouping = $('#allowGroupingCheckBox').is(':checked');
    }
}

RandomSiteControls.SqlGrid.SqlGridDesigner.registerClass('RandomSiteControls.SqlGrid.SqlGridDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();