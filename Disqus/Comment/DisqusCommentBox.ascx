<%@ Control Language="C#" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI.PublicControls.BrowseAndEdit" Assembly="Telerik.Sitefinity" %>
<%@ Register TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" Assembly="Telerik.Sitefinity" %>
<%@ Register TagPrefix="sfs" Namespace="RandomSiteControls" Assembly="RandomSiteControls" %>


<asp:Panel id="disqusWrapper" CssClass="disqus-commentbox-wrapper" runat="server">
    <sitefinity:ResourceLinks runat="server" UseEmbeddedThemes="true" Theme="Basic">
        <sitefinity:ResourceFile JavaScriptLibrary="JQuery"/>
        <sitefinity:ResourceFile Name="RandomSiteControls.Disqus.Comment.DisqusCommentBox.js" AssemblyInfo="RandomSiteControls.Disqus.Comment.DisqusCommentBox, RandomSiteControls" Static="True" />
    </sitefinity:ResourceLinks>

    <div id="disqus_thread"></div>

    <sfs:ScriptStyle id="scriptStyleWidgetDisqusProperties" runat="server" EmbedPosition="Head">
        <script>
            // Disqus properties
        </script>
    </sfs:ScriptStyle>
 
    
    <noscript>Please enable JavaScript to view the <a href="http://disqus.com/?ref_noscript">comments powered by Disqus.</a></noscript>
    <asp:Literal ID="noShortNameLiteral" runat="server" />
    <a href="http://disqus.com" class="dsq-brlink powered-by-disqus">comments powered by <span class="logo-disqus">Disqus</span></a>
    <!-- Widget by https://www.sitefinitysteve.com -->
</asp:Panel>
<asp:Panel id="disqusDesignMode" runat="server" Visible="false">
    <div>
        Disabled in design mode
    </div>
    <div id="footer">
        <a href="http://disqus.com" target="_blank"  class="powered-by-disqus" style="background: url('http://mediacdn.disqus.com/1341348056/img/powered-by.png') right 8px no-repeat !important;display: block!important;height: 23px!important;text-indent: -9999em!important;">
            Powered by Disqus
        </a>
    </div>
</asp:Panel>

