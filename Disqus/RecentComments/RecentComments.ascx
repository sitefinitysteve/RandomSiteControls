<%@ Control Language="C#" %>

<asp:Panel id="disqusWrapper" CssClass="disqus-recentcomments-wrapper" runat="server">
        <div id='recentcomments' class='dsq-widget'>
            <asp:Literal id="titleLiteral" runat="server" />
            <asp:Literal id="scriptTagLiteral" runat="server" />
            <asp:Panel id="disqusDesignMode" runat="server" Visible="false">
                <div>
                    Disabled in design mode
                </div>
            </asp:Panel>
        </div>
    <!-- Widget by https://www.sitefinitysteve.com -->
</asp:Panel>


