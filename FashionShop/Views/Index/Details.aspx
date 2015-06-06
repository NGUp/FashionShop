<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Chi tiết sản phẩm
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/index/index-details.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/index/index-details.js"></script>
</asp:Content>

<asp:Content ID="WebComponent" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/paper-button/paper-button.html">
    <link rel="import" href="/bower_components/core-field/core-field.html">
    <link rel="import" href="/bower_components/core-icon-button/core-icon-button.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <article class="row" ng-controller="DetailsCtrl">
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
            <h2 class="line"><span>Chi tiết sản phẩm</span></h2>
            <div class="row">
                <div class="col-md-4">
                    <div>
                        <img src="/Content/img/products/<%= ViewData["product_Image"] %>" id="product-id" alt="<%= ViewData["product_ID"] %>" />
                    </div>
                </div>
                <div class="col-md-8">
                    <h3 class="product-name">
                        <%= ViewData["product_Manufacturer"] %> <%= ViewData["product_Name"] %>
                    </h3>
                    <h4 class="product-price">
                        <%= ViewData["product_Price"] %> VND
                    </h4>
                    <div class="product-info">
                        <h5 class="product-category">Loại mặt hàng: <%= ViewData["product_Category"] %></h5>
                        <h5 class="product-origin">Xuất xứ: <%= ViewData["product_Origin"] %></h5>
                        <h5 class="product-sex">
                            Giới tính:
                            <%   if (Int32.Parse(ViewData["product_Sex"].ToString()) == 1) { %>
                                Nam
                            <% } else { %>
                                Nữ
                            <% } %>
                        </h5>
                        <h5 class="product-views">Số lượt xem: <%= ViewData["product_Views"] %></h5>
                        <h5 class="product-sales">Số lượng bán: <%= ViewData["product_Sales"] %></h5>
                        <% if (Session["USER_ID"] != null) { %>
                            <% 
                               Hashtable cart = (Session["PRODUCTS"] as Hashtable);
                               
                                if (cart[ViewData["product_ID"].ToString()] == null) { %>
                                <paper-button raised class="btn-order" ng-hide="ordered" ng-click="order()">Đặt hàng</paper-button>
                                <div class="ordered" ng-show="ordered"><span>Đã đặt hàng</span></div>
                            <% }
                               else
                               { %>
                                <div class="ordered"><span>Đã đặt hàng</span></div>
                            <% } %>
                        <% } %>
                    </div>
                </div>
            </div>
            <div class="products-relative">
                <h3 class="line"><span>Sản phẩm cùng loại</span></h3>
                <ul>
                    <li ng-repeat="product in products" class="product" ng-click="showDetails(product)">
                        <div>
                            <img src="/Content/img/products/{{product.Image}}" alt="{{product.Id}}" style="width: 150px;" />
                            <h5 class="relative-product-name">{{product.Name}}
                            <h5 class="relative-product-price">{{product.Price}} VND</h5>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    <% if (Session["USER_ID"] != null) { %>
        <paper-fab icon="shopping-cart" ng-click="goCart()" class="btn-shopping-cart"></paper-fab>
    <% } %>
    </article>
</asp:Content>