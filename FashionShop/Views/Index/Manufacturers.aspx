<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Nhà sản xuất
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/index/index-manufacturers.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/index/index-manufacturers.js"></script>
</asp:Content>

<asp:Content ID="WebComponent" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/paper-button/paper-button.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <article class="row" ng-controller="ManufacturersCtrl">
        <aside class="col-md-3">
            <div class="div-category">
                <h2 class="line"><span>Loại mặt hàng</span></h2>
                <ul class="category">
                    <li ng-repeat="category in categories">
                        <a href="/index/category/{{category.ID.trim()}}/1">{{category.Name}}</a>
                    </li>
                </ul>
            </div>
        </aside>
        <div class="col-md-9 content">
            <h2 class="line"><span>Nhà sản xuất</span></h2>
            <div>
                <ul>
                    <% foreach (FashionShop.Models.Objects.Manufacturer manufacturer in (ViewData["manufacturers"] as IEnumerable<FashionShop.Models.Objects.Manufacturer>)) { %>
                        <li class="manufacturer col-md-3" ng-click="showDetails('<% Response.Write(manufacturer.Id); %>')"><% Response.Write(manufacturer.Name); %></li>
                    <% } %>
                </ul>
            </div>
        </div>
    </article>
    <% if (Session["USER_ID"] != null) { %>
        <paper-fab icon="shopping-cart" class="btn-shopping-cart"></paper-fab>
    <% } %>
</asp:Content>