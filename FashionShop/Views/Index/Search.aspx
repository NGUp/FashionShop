<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat=server>
    Tìm kiếm đơn giản
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/index/index-search.js"></script>
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/index/index-search.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/core-field/core-field.html">
    <link rel="import" href="/bower_components/core-icon-button/core-icon-button.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat=server>
    <div ng-controller="SearchCtrl">
        <article class="row">
            <aside class="col-md-3">
                <div>
                    <core-field class="search-box">
                        <input placeholder="Từ khóa" autocomplete="off" spellcheck="false" name="keyword" ng-model="keyword" ng-enter="search()" flex>
                        <core-icon-button icon="search" ng-click="search()"></core-icon-button>
                    </core-field>
                </div>
                <div class="div-category">
                    <h2 class="line"><span>Loại mặt hàng</span></h2>
                    <ul class="category">
                        <li ng-repeat="category in categories">
                            <a href="/index/category/{{category.ID.trim()}}/1">{{category.Name}}</a>
                        </li>
                    </ul>
                </div>
                <div class="div-manufacturer">
                    <h2 class="line "><span>Nhà sản xuất</span></h2>
                    <ul class="category">
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
                <h2 class="line "><span>Tìm kiếm</span></h2>
                <div>
                    <h5 class="search-result">Từ khóa: <% Response.Write(ViewData["keyword"]); %></h5>
                    <h5 class="search-result">Kết quả: <% Response.Write((ViewData["products"] as IEnumerable<FashionShop.Models.Objects.Product>).Count()); %> sản phẩm.</h5>
                </div>
                <div>
                    <% foreach (FashionShop.Models.Objects.Product product in (ViewData["products"] as IEnumerable<FashionShop.Models.Objects.Product>)) { %>
                        <div class="product-details col-md-3" ng-click="showDetails('<% Response.Write(product.Id); %>')">
                            <div class="product-image">
                                <img src="/Content/img/products/<% Response.Write(product.Image); %>" alt="<% Response.Write(product.Id); %>" />
                            </div>
                            <div class="product-info">
                                <h4 class="product-name"><% Response.Write(product.Name); %></h4>
                                <h4 class="product-price"><% Response.Write(product.Price); %> VND <span class="btn-details">Chi tiết</span></h4>
                            </div>
                        </div>
                    <% } %>
                </div>
            </div>
        </article>
    </div>
    <% if (Session["USER_ID"] != null) { %>
        <paper-fab icon="shopping-cart" class="btn-shopping-cart"></paper-fab>
    <% } %>
</asp:Content>