Type.registerNamespace("RandomSiteControls.DocumentFolderList");

RandomSiteControls.DocumentFolderList.DocumentFolderListDesigner = function (element) {
    /* Initialize LibraryId fields */
    this._selectButtonLibraryId = null;
    this._selectButtonLibraryIdClickDelegate = null;
    this._deselectButtonLibraryId = null;
    this._deselectButtonLibraryIdClickDelegate = null;
    this._lnkDoneLibraryId = null;
    this._lnkCancelLibraryId = null;
    this._selectLibraryIdDialog = null;
    this._LibraryIdItemSelector = null;
    this._LibraryIdSelectedKeys = null;
    this._LibraryIdSelectedItems = null;
    this._LibraryIdBinderBound = false;
    this._doneSelectingLibraryIdDelegate = null;
    this._cancelLibraryIdDelegate = null;
    this._LibraryIdItemSelectorCloseDelegate = null;

    /* Initialize FolderImageUrl fields */
    this._folderImageUrl = null;

    /* Initialize FolderExpandedImageUrl fields */
    this._folderExpandedImageUrl = null;

    /* Initialize ShowLineImages fields */
    this._showLineImages = null;

    /* Initialize IconSize fields */
    this._iconSize = null;

    /* Initialize FilterExpressionForDocuments fields */
    this._filterExpressionForDocuments = null;

    /* Initialize Expanded fields */
    this._expanded = null;

    /* Calls the base constructor */
    RandomSiteControls.DocumentFolderList.DocumentFolderListDesigner.initializeBase(this, [element]);
}

RandomSiteControls.DocumentFolderList.DocumentFolderListDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        RandomSiteControls.DocumentFolderList.DocumentFolderListDesigner.callBaseMethod(this, 'initialize');

        /* Initialize LibraryId */
        if (this._selectButtonLibraryId) {
            this._selectButtonLibraryIdClickDelegate = Function.createDelegate(this, this._selectButtonLibraryIdClicked);
            $addHandler(this._selectButtonLibraryId, "click", this._selectButtonLibraryIdClickDelegate);
        }

        if (this._deselectButtonLibraryId) {
            this._deselectButtonLibraryIdClickDelegate = Function.createDelegate(this, this._deselectButtonLibraryIdClicked);
            $addHandler(this._deselectButtonLibraryId, "click", this._deselectButtonLibraryIdClickDelegate);
        }

        if (this._lnkDoneLibraryId) {
            this._LibraryIdDoneSelectingDelegate = Function.createDelegate(this, this._LibraryIdDoneSelecting);
            $addHandler(this._lnkDoneLibraryId, "click", this._LibraryIdDoneSelectingDelegate);
        }

        if (this._lnkCancelLibraryId) {
            this._LibraryIdCancelDelegate = Function.createDelegate(this, this._LibraryIdItemSelectorCloseHandler);
            $addHandler(this._lnkCancelLibraryId, "click", this._LibraryIdCancelDelegate);
        }

        this._selectLibraryIdDialog = jQuery("#LibraryIdSelector").dialog({
            autoOpen: false,
            modal: false,
            width: 540,
            height: "auto",
            closeOnEscape: true,
            resizable: false,
            draggable: false,
            zIndex: 5000,
        });
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        RandomSiteControls.DocumentFolderList.DocumentFolderListDesigner.callBaseMethod(this, 'dispose');

        /* Dispose LibraryId */

    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */


        var skinComboBox = $find('skinComboBox');

        skinComboBox.set_text(controlData.Skin);

        if (controlData.AllowCustomSkin == false) {
            $("#skinpicker").hide();
        }


        /* RefreshUI LibraryId */
        this.get_selectedLibraryId().innerHTML = controlData.SelectedLibraryName;
        $(this.get_selectedLibraryId()).data("libraryid", controlData.LibraryId);
        $(this.get_selectedLibraryId()).data("folderid", controlData.FolderId);
        if (controlData.LibraryId && controlData.LibraryId != "00000000-0000-0000-0000-000000000000") {
            this.get_selectButtonLibraryId().innerHTML = '<span class=\"sfLinkBtnIn\">Change</span>';
            $(this.get_deselectButtonLibraryId()).show()
        }
        else {
            $(this.get_deselectButtonLibraryId()).hide()
        }



        /* RefreshUI FolderImageUrl */
        jQuery(this.get_folderImageUrl()).val(controlData.FolderImageUrl);

        /* RefreshUI FolderExpandedImageUrl */
        jQuery(this.get_folderExpandedImageUrl()).val(controlData.FolderExpandedImageUrl);

        /* RefreshUI ShowLineImages */
        jQuery(this.get_showLineImages()).attr("checked", controlData.ShowLineImages);

        /* RefreshUI IconSize */
        jQuery(this.get_iconSize()).val(controlData.IconSize);

        /* RefreshUI FilterExpressionForDocuments */
        jQuery(this.get_filterExpressionForDocuments()).val(controlData.FilterExpressionForDocuments);

        /* RefreshUI Expanded */
        jQuery(this.get_expanded()).attr("checked", controlData.Expanded);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        if (controlData.AllowCustomSkin == true) {
            var skinComboBox = $find('skinComboBox');
            controlData.Skin = skinComboBox.get_text();
        }


        /* ApplyChanges LibraryId */
        controlData.FolderId = $(this.get_selectedLibraryId()).data("folderid");
        controlData.LibraryId = $(this.get_selectedLibraryId()).data("libraryid");
        controlData.SelectedLibraryName = this.get_selectedLibraryId().innerHTML;

        /* ApplyChanges FolderImageUrl */
        controlData.FolderImageUrl = jQuery(this.get_folderImageUrl()).val();

        /* ApplyChanges FolderExpandedImageUrl */
        controlData.FolderExpandedImageUrl = jQuery(this.get_folderExpandedImageUrl()).val();

        /* ApplyChanges ShowLineImages */
        controlData.ShowLineImages = jQuery(this.get_showLineImages()).is(":checked");

        /* ApplyChanges IconSize */
        controlData.IconSize = jQuery(this.get_iconSize()).val();

        /* ApplyChanges FilterExpressionForDocuments */
        controlData.FilterExpressionForDocuments = jQuery(this.get_filterExpressionForDocuments()).val();

        /* ApplyChanges Expanded */
        controlData.Expanded = jQuery(this.get_expanded()).is(":checked");
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* LibraryId event handlers */


    /* --------------------------------- private methods --------------------------------- */

    /* LibraryId private methods */
    _selectButtonLibraryIdClicked: function (sender, args) {
        var itemSelector = this.get_LibraryIdItemSelector();
        if (itemSelector) {
            // dynamic items don't support fallback, the binder search should work as in monolingual
            //itemSelector._selectorSearchBox.get_binderSearch()._multilingual = false;
            itemSelector.dataBind();
        }

        this._selectLibraryIdDialog.dialog("open");
        jQuery("#designerLayoutRoot").hide();
        this._selectLibraryIdDialog.dialog().parent().css("min-width", "525px");
        dialogBase.resizeToContent();
        return false;
    },

    _deselectButtonLibraryIdClicked: function (sender, args) {
        //this.get_selectedLibraryId().innerHTML = "00000000-0000-0000-0000-000000000000";
        this.get_selectedLibraryId().innerHTML = "No Library Selected";
        $(this.get_selectedLibraryId()).data("libraryid", "");
        $(this.get_selectedLibraryId()).data("folderid", "");
        this.get_selectButtonLibraryId().innerHTML = '<span class=\"sfLinkBtnIn\">Select...</span>';
        $(this.get_deselectButtonLibraryId()).hide()
        return false;
    },

    _LibraryIdItemSelectorCloseHandler: function (sender, args) {
        this._selectLibraryIdDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
    },

    _LibraryIdDoneSelecting: function (sender, args) {
        var selectedItem = this.get_LibraryIdSelectedItems()[0];
        if (selectedItem != null) {
            var title = "";
            var libraryId = "";
            var folderId = "";

            if (selectedItem.ParentId == null) {
                //Root Library
                title = selectedItem.Title;
                libraryId = selectedItem.Id;
                folderId = "";
            } else {
                title = selectedItem.Path;
                libraryId = selectedItem.RootId;
                folderId = selectedItem.Id;
            }

            this.get_selectedLibraryId().innerHTML = title;

            $(this.get_selectedLibraryId()).data("libraryid", libraryId);
            $(this.get_selectedLibraryId()).data("folderid", folderId);

            this.get_selectButtonLibraryId().innerHTML = '<span class=\"sfLinkBtnIn\">Change</span>';
            $(this.get_deselectButtonLibraryId()).show()
        }
        this._selectLibraryIdDialog.dialog("close");
        jQuery("#designerLayoutRoot").show();
        dialogBase.resizeToContent();
    },

    /* --------------------------------- properties -------------------------------------- */

    /* LibraryId properties */
    get_selectButtonLibraryId: function () {
        return this._selectButtonLibraryId;
    },
    set_selectButtonLibraryId: function (value) {
        this._selectButtonLibraryId = value;
    },

    get_deselectButtonLibraryId: function () {
        return this._deselectButtonLibraryId;
    },
    set_deselectButtonLibraryId: function (value) {
        this._deselectButtonLibraryId = value;
    },

    get_LibraryIdItemSelector: function () {
        return this._LibraryIdItemSelector;
    },
    set_LibraryIdItemSelector: function (value) {
        this._LibraryIdItemSelector = value;
    },

    get_LibraryIdBinder: function () {
        return this._LibraryIdItemSelector.get_binder();
    },

    get_LibraryIdSelectedKeys: function () {
        return this._LibraryIdItemSelector.get_selectedKeys();
    },
    set_LibraryIdSelectedKeys: function (keys) {
        this._selectedKeys = keys;
    },

    get_LibraryIdSelectedItems: function () {
        return this._LibraryIdItemSelector.getSelectedItems();
    },
    set_LibraryIdSelectedItems: function (items) {
        this._LibraryIdSelectedItems = items;
        if (this._LibraryIdBinderBound) {
            this._LibraryIdItemSelector.bindSelector();
        }
    },

    get_lnkDoneLibraryId: function () {
        return this._lnkDoneLibraryId;
    },
    set_lnkDoneLibraryId: function (value) {
        this._lnkDoneLibraryId = value;
    },
    get_lnkCancelLibraryId: function () {
        return this._lnkCancelLibraryId;
    },
    set_lnkCancelLibraryId: function (value) {
        this._lnkCancelLibraryId = value;
    },
    get_selectedLibraryId: function () {
        if (this._selectedLibraryIdLabel == null) {
            this._selectedLibraryIdLabel = jQuery(this.get_element()).find('#selectedLibraryIdLabel').get(0);
        }
        return this._selectedLibraryIdLabel;
    },

    /* FolderImageUrl properties */
    get_folderImageUrl: function () { return this._folderImageUrl; },
    set_folderImageUrl: function (value) { this._folderImageUrl = value; },

    /* FolderExpandedImageUrl properties */
    get_folderExpandedImageUrl: function () { return this._folderExpandedImageUrl; },
    set_folderExpandedImageUrl: function (value) { this._folderExpandedImageUrl = value; },

    /* ShowLineImages properties */
    get_showLineImages: function () { return this._showLineImages; },
    set_showLineImages: function (value) { this._showLineImages = value; },

    /* IconSize properties */
    get_iconSize: function () { return this._iconSize; },
    set_iconSize: function (value) { this._iconSize = value; },

    /* FilterExpressionForDocuments properties */
    get_filterExpressionForDocuments: function () { return this._filterExpressionForDocuments; },
    set_filterExpressionForDocuments: function (value) { this._filterExpressionForDocuments = value; },

    /* Expanded properties */
    get_expanded: function () { return this._expanded; },
    set_expanded: function (value) { this._expanded = value; }
}

RandomSiteControls.DocumentFolderList.DocumentFolderListDesigner.registerClass('RandomSiteControls.DocumentFolderList.DocumentFolderListDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
