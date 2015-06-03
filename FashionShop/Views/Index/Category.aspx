﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat=server>
    Loại mặt hàng
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/index/index-category.js"></script>
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/index/index-category.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/core-icon-button/core-icon-button.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat=server>
    <div ng-controller="CategoryCtrl">
        <article class="row">
            <aside class="col-md-3">
                <h2 class="line"><span>Loại mặt hàng</span></h2>
                <ul class="category">
                    <li ng-repeat="category in categories">
                        <a href="/index/category/{{category.ID.trim()}}/1">{{category.Name}}</a>
                    </li>
                </ul>
            </aside>
            <div class="col-md-9 content">
                <h2 class="line"><span>Mặt hàng: <%= ViewData["category"] %></span></h2>
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
                <div class="clear"></div>
                <div>
                    <div class="div-paging">
                        <core-icon-button icon="arrow-back" ng-click="previous()" active="false"></core-icon-button>
                        <span id="page"><%= ViewData["page"]%></span> - <span id="page-total"><%= ViewData["total"]%></span>
                        <core-icon-button icon="arrow-forward" ng-click="next()"></core-icon-button>
                    </div>
                </div>
            </div>
        </article>
    </div>    
</asp:Content>