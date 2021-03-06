﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Cập nhật Sản phẩm
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/product/product-update.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Selected" ContentPlaceHolderID="SelectedContent" runat="server">0</asp:Content>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitleContent" runat="server">
    Sản phẩm
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/product/product-update.js"></script>
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/paper-input/paper-input.html">
    <link rel="import" href="/bower_components/paper-radio-button/paper-radio-button.html">
    <link rel="import" href="/bower_components/paper-radio-group/paper-radio-group.html">
    <link rel="import" href="/bower_components/paper-button/paper-button.html">
    <link rel="import" href="/bower_components/core-menu/core-menu.html">
    <link rel="import" href="/bower_components/paper-dropdown/paper-dropdown.html">
    <link rel="import" href="/bower_components/paper-item/paper-item.html">
    <link rel="import" href="/bower_components/paper-dropdown-menu/paper-dropdown-menu.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <article ng-controller="UpdateCtrl">
        <div class="content">
            <div class="product-image">
                <img src="/Content/img/products/<%= ViewData["product_Image"] %>" alt="<%= ViewData["product_ID"] %>" />
                <paper-button raised>
                    Chọn ảnh
                    <input type="file" class="md-upload-button" name="image" id="md-upload-button" />
                </paper-button>
            </div>
            <div class="product-info">
                <h3 class="product-id"><%= ViewData["product_ID"] %></h3>
                <div>
                    <paper-input label="Tên sản phẩm" floatingLabel id="product-name" value="<%= ViewData["product_Name"] %>"></paper-input>
                </div>
                <div>
                    <h4 class="product-manufacturer">Nhà sản xuất</h4>
                    <paper-dropdown-menu label="Chọn nhà sản xuất">
                        <paper-dropdown class="dropdown">
                            <core-menu class="menu" id="product-manufacturer" valueattr="value" selected="<%= ViewData["product_Manufacturer"] %>">
                                <paper-item ng-repeat="manufacturer in manufacturers" value="{{manufacturer.Id}}">{{manufacturer.Name}}</paper-item>
                            </core-menu>
                        </paper-dropdown>
                    </paper-dropdown-menu>
                </div>
                <div>
                    <paper-input label="Giá" id="product-price" floatingLabel value="<%= ViewData["product_Price"] %>"></paper-input>
                </div>
                <div>
                    <paper-input label="Xuất xứ" id="product-origin" floatingLabel value="<%= ViewData["product_Origin"] %>"></paper-input>
                </div>
                <div>
                    <h4 class="product-sex">Giới tính</h4>
                    <paper-radio-group class="blue" id="product-sex" selected="<%= ViewData["product_Sex"] %>">
                        <paper-radio-button name="1" label="Bé trai"></paper-radio-button>
                        <paper-radio-button name="0" label="Bé gái"></paper-radio-button>
                    </paper-radio-group>
                </div>
                <div class="buttons-panel">
                    <paper-button id="btn-delete" class="btn-delete" ng-click="remove()" raised>Xóa</paper-button>
                    <paper-button id="btn-cancel" ng-click="cancel()">Hủy</paper-button>
                    <paper-button id="btn-accept" class="btn-accept" raised ng-click="accept()">Đồng ý</paper-button>
                </div>
            </div>
        </div>
    </article>

</asp:Content>