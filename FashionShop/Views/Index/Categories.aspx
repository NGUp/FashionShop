<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat=server>
    Loại mặt hàng
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/index/index-categories.js"></script>
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/index/index-categories.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat=server>
    <div ng-controller="CategoriesCtrl">
        <article class="row">
            <aside class="col-md-3">
                <div class="div-manufacturer">
                    <h2 class="line "><span>Nhà sản xuất</span></h2>
                    <ul class="manufacturers">
                        <li ng-repeat="manufacturer in manufacturers">
                            <a href="/index/manufacturer/{{manufacturer.Id.trim()}}/1">{{manufacturer.Name}}</a>
                        </li>
                        <li>
                            <a href="/index/manufacturers">Xem thêm...</a>
                        </li>
                    </ul>
                </div>
            </aside>
            <div class="col-md-9 content">
                <h2 class="line"><span>Loại mặt hàng</span></h2>
                <div>
                    <ul>
                        <% foreach (FashionShop.Models.Objects.Category category in (ViewData["categories"] as IEnumerable<FashionShop.Models.Objects.Category>)) { %>
                            <li class="category-element col-md-3" ng-click="showDetails('<% Response.Write(category.ID); %>')"><% Response.Write(category.Name); %></li>
                        <% } %>
                    </ul>
                </div>
            </div>
        </article>
    </div>
    <% if (Session["USER_ID"] != null) { %>
        <paper-fab icon="shopping-cart" class="btn-shopping-cart"></paper-fab>
    <% } %>
</asp:Content>