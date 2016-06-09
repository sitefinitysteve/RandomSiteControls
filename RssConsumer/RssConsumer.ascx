<%@ Control Language="C#" %>

<%--Sitefinity Steve RssConsumer Control Template--%>

<telerik:RadListView ID="rssListView" runat="server" ItemPlaceholderID="itemPlaceHolder" EnableEmbeddedBaseStylesheet="false" EnableEmbeddedSkins="false" EnableViewState="False">
    <LayoutTemplate>
        <ul class="rss-feed">
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li>
            <h3>
               <%# ((XElement)Container.DataItem).Element("title").Value %>
            </h3>
            <div><%# ((XElement)Container.DataItem).Element("pubDate").Value %></div>
            <br />
            <a href="<%# ((XElement)Container.DataItem).Element("link").Value %>">Read Full Story</a>
        </li>
    </ItemTemplate>
</telerik:RadListView>
