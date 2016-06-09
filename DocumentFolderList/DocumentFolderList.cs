using System;
using System.Web.UI.WebControls;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using RandomSiteControls.Configuration;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Modules.Pages.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Data.Linq.Dynamic;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Web.UI;
using System.Web.UI;
using System.ComponentModel;
using RandomSiteControls.Common;
using System.Configuration;
using Telerik.Sitefinity;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Libraries.Model;
using System.Web.UI.HtmlControls;
using Telerik.Sitefinity.Security.Claims;

namespace RandomSiteControls.DocumentFolderList {
    /// <summary>
    /// A control which displays recent news articles in a rotating manner.
    /// </summary>
    [RequireScriptManager]
    [ControlDesigner(typeof(DocumentFolderListDesigner)), PropertyEditorTitle("Document Folder List Properties")]
    public class DocumentFolderList : SteveControlBase, ICustomWidgetVisualization
    {
        private string _cacheKey = "DocumentFolderList-LibId:{0}-FolderId:{1}-IsAnon:{2}-UserId:{3}";

        protected override void InitializeControls(GenericContainer container)
        {
            this.SetSkin();
            var iconSize = this.IconSize.ToLower().Trim() == "small" ? "sfSmallIcns" : "sfLargeIcns";
            documentFolderList.CssClass = "sfs_docFolderList {0}".Arrange(iconSize);

            treeview.ShowLineImages = this.ShowLineImages;

            this.CreateCacheKey();

            if (this.IsDesignMode())
            {
                RandomSiteControlsUtil.Cache.Remove(_cacheKey);
            }

            //BIND THE DATA
            if (this.LibraryId != Guid.Empty)
            {
                this.SetTreeNodeDocumentLibrariesAndFolders();
            }

        }

        private void SetSkin()
        {
            #region SKIN
            var skin = String.Empty;
            if (this.UserConfig.AllowCustomSkins)
            {
                //Use whatever is set in the control
                skin = this.Skin;
            }
            else
            {
                //Use the one from the config
                skin = this.UserConfig.Skin;
            }

            treeview.Skin = skin;

            //Findout if the skin is a telerik skin
            bool foundSkin = false;

            foreach (var s in Enum.GetValues(typeof(SkinEnum)))
            {
                if (s.ToString().ToLower() == treeview.Skin.ToLower())
                {
                    foundSkin = true;
                    break;
                }
            }

            if (foundSkin == false)
            {
                treeview.EnableEmbeddedSkins = false;
            }
            #endregion
        }

        private void CreateCacheKey()
        {
            _cacheKey = _cacheKey.Arrange(this.LibraryId, this.FolderId, this.IsAnonymous, this.UserId);
        }

        public void SetTreeNodeDocumentLibrariesAndFolders()
        {
            List<RadTreeNode> nodes = new List<RadTreeNode>();
            if (RandomSiteControlsUtil.Cache.Contains(_cacheKey)){
                //Load Cache
                nodes = RandomSiteControlsUtil.Cache[_cacheKey] as List<RadTreeNode>;
            } else {
                //Create Cache
                LibrariesManager manager = new LibrariesManager();

                //Folder Focused
                if (this.FolderId != Guid.Empty)
                {
                    var album = manager.GetDocumentLibrary(this.LibraryId);
                    if (album != null)
                    {
                        var folders = manager.GetAllFolders(album);
                        var selectedFolder = folders.FirstOrDefault(x => x.Id == this.FolderId);
                        if (selectedFolder != null)
                        {
                            this.ParseSingleFolder(nodes, manager, album, selectedFolder);
                        }
                        else
                        {
                            throw new Exception("Invalid FolderId Specified or Unable to find folder");
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid LibraryId Specified or Unable to find library");
                    }
                }
                else
                {
                    //Libary Focused
                    var album = manager.GetDocumentLibrary(this.LibraryId);
                    if (album != null)
                    {
                        this.ParseSingleAlbum(nodes, manager, album);
                    }
                    else
                    {
                        throw new Exception("Invalid LibraryId Specified");
                    }
                }

                if (!this.IsDesignMode() && this.UserConfig.CacheTimeoutMinutes > 0)
                {
                    //Add to cache
                    RandomSiteControlsUtil.AddToCache(nodes, _cacheKey, TimeSpan.FromMinutes(this.UserConfig.CacheTimeoutMinutes));
                }

            }

            //Bind to the tree
            treeview.Nodes.AddRange(nodes);
        }

        private void ParseSingleFolder(List<RadTreeNode> nodes, LibrariesManager manager, DocumentLibrary album, IFolder folder)
        {
            var folders = manager.GetAllFolders(album);

            RadTreeNode folderNode = new RadTreeNode(folder.Title.ToString());
            folderNode.Expanded = this.Expanded;
            this.SetImage(folderNode);
            folderNode.Attributes.Add("Id", folder.Id.ToString());
            folderNode.Attributes.Add("IsFolder", "true");
            folderNode.CssClass += " album";
            nodes.Add(folderNode);

            //Get Documents for this Library
            var docsInLibrary = manager.GetDocuments().Where(x => x.Parent.Id == album.Id && x.FolderId == folder.Id).Where(this.FilterExpressionForDocuments);
            foreach (var doc in docsInLibrary)
            {
                RadTreeNode docNode = this.CreateDocNode(album, doc);
                folderNode.Nodes.Add(docNode);
            }

            //Load Children
            foreach (var child in folders.Where(x => x.ParentId == folder.Id))
            {
                folderNode.Nodes.Add(this.GetChildNodes(child, folders, album, manager, docsInLibrary));
            }
        }


        private void ParseSingleAlbum(List<RadTreeNode> nodes, LibrariesManager manager, DocumentLibrary album)
        {
            RadTreeNode rootNode = new RadTreeNode(album.Title.ToString());
            rootNode.Expanded = this.Expanded;
            this.SetImage(rootNode);
            rootNode.Attributes.Add("Id", album.Id.ToString());
            rootNode.Attributes.Add("IsFolder", "true");
            rootNode.CssClass += " album";
            nodes.Add(rootNode);

            //Get Documents for this Library
            var docsInLibrary = manager.GetDocuments().Where(x => x.Parent.Id == album.Id && x.FolderId == null).Where(this.FilterExpressionForDocuments);
            foreach (var doc in docsInLibrary)
            {
                RadTreeNode docNode = this.CreateDocNode(album, doc);
                rootNode.Nodes.Add(docNode);
            }

            //Create nodes for all the folders
            var folders = manager.GetAllFolders(album);

            //Loop through all root folders
            foreach (var folder in folders.Where(x => x.ParentId == null))
            {
                var folderNode = new RadTreeNode();
                folderNode.Text = folder.Title.ToString();
                folderNode.Expanded = this.Expanded;
                this.SetImage(folderNode);
                folderNode.Attributes.Add("Id", folder.Id.ToString());
                folderNode.Attributes.Add("IsFolder", "true");
                folderNode.CssClass += " folder";

                //Load Documents
                var docsInFolder = manager.GetDocuments().Where(x => x.Parent.Id == album.Id && x.FolderId == folder.Id).Where(this.FilterExpressionForDocuments);
                foreach (var doc in docsInFolder)
                {
                    RadTreeNode docNode = this.CreateDocNode(album, doc);
                    folderNode.Nodes.Add(docNode);
                }

                //Load Children
                foreach (var child in folders.Where(x => x.ParentId == folder.Id))
                {
                    folderNode.Nodes.Add(this.GetChildNodes(child, folders, album, manager, docsInLibrary));
                }

                rootNode.Nodes.Add(folderNode);
            }
        }

        private RadTreeNode GetChildNodes(IFolder folder, IQueryable<IFolder> folders, DocumentLibrary album, LibrariesManager manager, IQueryable<Document> docsInLibrary)
        {
            var folderNode = new RadTreeNode();
            folderNode.Expanded = this.Expanded;
            folderNode.Text = folder.Title.ToString();
            this.SetImage(folderNode);
            folderNode.Attributes.Add("Id", folder.Id.ToString());
            folderNode.Attributes.Add("IsFolder", "true");
            folderNode.CssClass += " folder";

            //Load Documents
            var docsInFolder = manager.GetDocuments().Where(x => x.Parent.Id == album.Id && x.FolderId == folder.Id).Where(this.FilterExpressionForDocuments);
            foreach (var doc in docsInFolder)
            {
                RadTreeNode docNode = this.CreateDocNode(album, doc);
                folderNode.Nodes.Add(docNode);
            }

            //Load Children
            foreach (var child in folders.Where(x => x.ParentId == folder.Id))
            {
                folderNode.Nodes.Add(this.GetChildNodes(child, folders, album, manager, docsInLibrary));
            }

            return folderNode;
        }

        private RadTreeNode CreateDocNode(Telerik.Sitefinity.Libraries.Model.DocumentLibrary item, Telerik.Sitefinity.Libraries.Model.Document doc)
        {
            var docNode = new RadTreeNode();
            docNode.Text = doc.Title.ToString();
            docNode.NavigateUrl = doc.MediaUrl;
            docNode.Target = this.Target;
            docNode.Attributes.Add("Id", item.Id.ToString());
            docNode.Attributes.Add("ParentId", item.ParentId.ToString());
            docNode.Attributes.Add("IsFolder", "false");
            docNode.ContentCssClass = "sfdownloadTitle";
            docNode.CssClass += " sfdownloadFile sf{0}".Arrange(doc.Extension.Replace(".", "").ToLower());
            return docNode;
        }

        private void SetImage(RadTreeNode node)
        {
            #region IMAGES
            if (!String.IsNullOrEmpty(this.FolderImageUrl))
            {
                node.ImageUrl = this.FolderImageUrl;
            }

            if (!String.IsNullOrEmpty(this.FolderExpandedImageUrl))
            {
                node.ExpandedImageUrl = this.FolderExpandedImageUrl;
            }
            #endregion
        }

        protected override string LayoutTemplateName {
            get {
                //return "RandomSiteControls.Button.Views.ButtonTemplate.ascx";
                return null;
            }
        }

        public override string LayoutTemplatePath {
            get {
                var path = "~/SitefinitySteve/RandomSiteControls.DocumentFolderList.Views.DocumentFolderListTemplate.ascx";
                return path;
            }
            set {
                base.LayoutTemplatePath = value;
            }
        }

        #region PROPERTIES
        private Guid _libraryId = Guid.Empty;
        public Guid LibraryId {
            get {
                return _libraryId;
            }set {
                _libraryId = value;
        	}
        }

        string _selectedLibraryName;
        public string SelectedLibraryName
        {
            get { return _selectedLibraryName; }
            set
            {
                _selectedLibraryName = value;
            }
        }


        private Guid _folderId = Guid.Empty;
        public Guid FolderId
        {
            get
            {
                return _folderId;
            }
            set
            {
                _folderId = value;
            }
        }

        string _documentFilterExpression = "Visible == True && Status == Live";
        public string FilterExpressionForDocuments
        {
            get { return _documentFilterExpression; }
            set
            {
                _documentFilterExpression = value;
            }
        }

        bool _expanded = true;
        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                _expanded = value;
            }
        }

        string _folderImageUrl;
        public string FolderImageUrl
        {
            get { return _folderImageUrl; }
            set
            {
                _folderImageUrl = value;
            }
        }

        string _folderExpandedImageUrl;
        public string FolderExpandedImageUrl
        {
            get { return _folderExpandedImageUrl; }
            set
            {
                _folderExpandedImageUrl = value;
            }
        }

        string _iconSize = "Small";
        public string IconSize
        {
            get { return _iconSize; }
            set
            {
                _iconSize = value;
            }
        }


        private string _skin = "Bootstrap";
        public string Skin {
            get { return _skin; }
            set { _skin = value; }
        }

        public bool AllowCustomSkin
        {
            get { return this.UserConfig.AllowCustomSkins; }
        }

        string _target = "_blank";
        public string Target
        {
            get { return _target; }
            set
            {
                _target = value;
            }
        }

        bool _showLineImages = false;
        public bool ShowLineImages
        {
            get { return _showLineImages; }
            set
            {
                _showLineImages = value;
            }
        }


        public bool IsAnonymous
        {
            get {
                var identity = ClaimsManager.GetCurrentIdentity();
                return identity.IsAuthenticated ? false : true;
            }
        }

        public Guid UserId
        {
            get
            {
                var identity = ClaimsManager.GetCurrentIdentity();
                return identity.UserId;
            }
        }
        #endregion

        #region CONTROL DEFINITIONS
        protected virtual RadTreeView treeview
        {
            get {
                return this.Container.GetControl<RadTreeView>("treeview", true);
            }
        }

        protected virtual Panel treeviewContainer
        {
            get {
                return this.Container.GetControl<Panel>("treeviewContainer", true);
            }
        }

        protected virtual HiddenField sfsTreeViewClientState
        {
            get {
                return this.Container.GetControl<HiddenField>("sfsTreeViewClientState", true);
            }
        }

        protected virtual Panel documentFolderList
        {
            get
            {
                return this.Container.GetControl<Panel>("documentFolderList", true);
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.LibraryId == Guid.Empty;
            }
        }

        public string EmptyLinkText
        {
            get
            {
                return "Select a library";
            }
        }

        #endregion
    }
}