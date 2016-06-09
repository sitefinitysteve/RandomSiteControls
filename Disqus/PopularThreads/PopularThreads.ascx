<%@ Control Language="C#" %>

<asp:Panel id="disqusWrapper" CssClass="disqus-popularthreads-wrapper" runat="server">
        <div id="popularthreads" class="dsq-widget">
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


