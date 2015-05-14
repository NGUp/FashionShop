<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Quản lý Sản phẩm
</asp:Content>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitleContent" runat="server">
	Quản lý Sản phẩm
</asp:Content>

<asp:Content ID="Selected" ContentPlaceHolderID="SelectedContent" runat="server">0</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/product/product-index.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Scripts/base64.js"></script>
    <script src="/Content/js/product/product-index.js"></script>
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/core-icon-button/core-icon-button.html">
    <link rel="import" href="/bower_components/paper-input/paper-input.html">
    <link rel="import" href="/bower_components/paper-dialog/paper-dialog.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <article class="container" ng-controller="IndexCtrl">
        <ul class="list-products">
            <li ng-repeat="product in products">
                <div class="product-details" ng-click="showDetails(product)">
                    <h4 class="product-manufacturer">{{product.Manufacturer}}</h4>
                    <div class="product-image">
                        <img ng-src="/Content/img/products/{{product.Image}}" alt="{{product.Id}}" />
                    </div>
                    <div class="product-info">
                        <h4>{{product.Id}}</h4>
                        <h4 class="product-name">{{product.Name}}</h4>
                        <h4>{{product.Price}} VND</h4>
                    </div>
                </div>
            </li>
        </ul>

        <div class="space"></div>
        
        <div class="product-paging">
            <core-icon-button icon="arrow-back" ng-click="previous()" active="false"></core-icon-button>
            <span>{{currentPage}} - {{totalPages}}</span>
            <core-icon-button icon="arrow-forward" ng-click="next()"></core-icon-button>
            <core-icon-button icon="search" ng-click="search()" ng-hide="isSearching"></core-icon-button>
            <core-icon-button icon="refresh" ng-click="refresh()" ng-show="isSearching"></core-icon-button>
        </div>

        <paper-dialog heading="Tìm kiếm" id="paper-dialog" transition="paper-dialog-transition-center">
            <paper-input label="Mã sản phẩm" id="txtProductID" spellcheck="false" floatingLabel></paper-input>
            <paper-input label="Tên sản phẩm" id="txtProductName" spellcheck="false" floatingLabel></paper-input>
            <core-icon-button icon="search" affirmative autofocus class="search-button" ng-click="searchProducts()"></core-icon-button>
        </paper-dialog>
    </article>

</asp:Content>


