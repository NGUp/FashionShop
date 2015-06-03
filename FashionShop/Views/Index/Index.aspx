<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Main.Master" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat=server>
    Trang chủ
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/index/index-index.js"></script>
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/index/index-index.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/paper-progress/paper-progress.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat=server>
    <div ng-controller="IndexCtrl">
        <article class="row">
            <aside class="col-md-3">
                <h2>Loại mặt hàng</h2>
                <ul class="category">
                    <li ng-repeat="category in categories">
                        <a href="/index/category/{{category.ID.trim()}}/1">{{category.Name}}</a>
                    </li>
                </ul>
            </aside>
            <div class="col-md-9 content">
                <img class="cover" src="/Content/img/theme/index.png" alt="Kids Fashion" />
                <div>
                    <h2 class="title">Sản phẩm mới nhất</h2>
                    <paper-progress indeterminate></paper-progress>
                    <ul class="list-products">
                        <li ng-repeat="product in productsNew">
                            <div class="product-details col-md-3" ng-click="showDetails(product)">
                                <img class="new" src="/Content/img/theme/new.png" alt="New" />
                                <div class="product-image">
                                    <img ng-src="/Content/img/products/{{product.Image}}" alt="{{product.Id}}" />
                                </div>
                                <div class="product-info">
                                    <h4 class="product-name">{{product.Name}}</h4>
                                    <h4 class="product-price">{{product.Price}} VND <span class="btn-details">Chi tiết</span></h4>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
                <div>
                    <h2 class="title">Sản phẩm bán chạy nhất</h2>
                    <paper-progress indeterminate></paper-progress>
                    <ul class="list-products">
                        <li ng-repeat="product in productsSale">
                            <div class="product-details col-md-3" ng-click="showDetails(product)">
                                <img class="new" src="/Content/img/theme/best_seller.jpg" alt="New" />
                                <div class="product-image">
                                    <img ng-src="/Content/img/products/{{product.Image}}" alt="{{product.Id}}" />
                                </div>
                                <div class="product-info">
                                    <h4 class="product-name">{{product.Name}}</h4>
                                    <h4 class="product-price">{{product.Price}} VND <span class="btn-details">Chi tiết</span></h4>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </article>
    </div>    
</asp:Content>