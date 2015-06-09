<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Quản lý Đơn hàng
</asp:Content>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitleContent" runat="server">
	Quản lý Đơn hàng
</asp:Content>

<asp:Content ID="Selected" ContentPlaceHolderID="SelectedContent" runat="server">4</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/bower_components/bootstrap/dist/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="/Content/css/order/order-update.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/order/order-update.js"></script>
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/paper-button/paper-button.html">
    <link rel="import" href="/bower_components/paper-input/paper-input.html">
    <link rel="import" href="/bower_components/core-icon-button/core-icon-button.html">
    <link rel="import" href="/bower_components/core-icon/core-icon.html">
    <link rel="import" href="/bower_components/core-field/core-field.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <article class="custom-container" ng-controller="UpdateCtrl">
        <div class="cart-info">
            <h5>Khách hàng:</h5>
            <h4 class="cart-customer-name"><%= ViewData["CUSTOMER_NAME"] %></h4>
            <input type="hidden" id="purchase-id" value="<%= ViewData["PURCHASE_ID"] %>">
        </div>
        <div class="cart">
            <ul>
                <li class="product" ng-repeat="item in cart">
                    <div class="row">
                        <div class="col-md-1 image">
                            <img src="/Content/img/products/{{item.Product.Image}}" alt="{{item.Product.Id}}" />
                        </div>
                        <div class="col-md-8">
                            <h5 class="product-name">{{item.Product.Manufacturer}} {{item.Product.Name}}</h5>
                            <h5>{{item.Product.Id}} - {{item.Product.Price}} VND</h5>
                        </div>
                        <div class="col-md-3 div-function">
                            <core-field class="search-box">
                                <input placeholder="Số lượng" value="{{item.Quantity}}" ng-model="item.Quantity" autocomplete="off" spellcheck="false" name="keyword" flex>
                            </core-field>
                            <div class="div-remove">
                                <core-icon-button icon="delete" class="btn-remove" ng-click="remove($index)"></core-icon-button>
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
        <div class="div-payment">
            <h3 class="bill">Tổng tiền: {{total()}} VND</h3>
            <div class="clear">
                <paper-button raised ng-click="cancel()">Hủy</paper-button>
                <paper-button raised class="btn-update" ng-click="update()">Cập nhật</paper-button>
            </div>
        </div>
    </article>

</asp:Content>