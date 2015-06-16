<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Giỏ hàng
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/index/index-cart.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/index/index-cart.js"></script>
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/core-icon-button/core-icon-button.html">
    <link rel="import" href="/bower_components/core-icon/core-icon.html">
    <link rel="import" href="/bower_components/core-field/core-field.html">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <article class="content" ng-controller="CartCtrl" style="min-height: 60.75%; padding: 16px; position: relative;">
        <h2 class="title">Giỏ hàng của bạn</h2>
        <div class="cart">
            <% if (Session["PRODUCTS"] == null || (Session["PRODUCTS"] as Hashtable).Count == 0)
               { %>
                    <h5 class="title-empty">Giỏ hàng trống</h5>
            <% }
               else
               {
                   if (Session["ALERT"] != null)
                   {
            %>
                <h3 class="error"><% Response.Write(Session["ALERT"]); %></h3>
            <%
                   }
            %>
                    <ul>
                        <li class="product" ng-repeat="item in cart">
                            <div class="row">
                                <div class="col-md-1 image">
                                    <img src="/Content/img/products/{{item.Product.Image}}" alt="{{item.Product.Id}}" />
                                </div>
                                <div class="col-md-8">
                                    <h5 class="product-name">{{item.Product.Manufacturer}} {{item.Product.Name}}</h5>
                                    <h5>{{item.Product.Id}} - {{standardizePrice(item.Product.Price)}} VND</h5>
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
            <% 
               }
            %>
        </div>
        <div class="clear"></div>
        <% if (Session["PRODUCTS"] != null && (Session["PRODUCTS"] as Hashtable).Count > 0) { %>
           <div class="div-payment">
                <h3 class="bill">Tổng tiền: {{standardizePrice(total())}} VND</h3>
                <div class="clear">
                    <paper-button raised ng-click="refresh()">
                        <core-icon icon="delete"></core-icon> Làm mới
                    </paper-button>
                    <paper-button raised class="btn-update" ng-click="update()">
                        <core-icon icon="system-update-tv"></core-icon> Cập nhật
                    </paper-button>
                    <div>
                        <paper-button raised class="btn-payment" ng-click="pay()">
                            <core-icon icon="payment"></core-icon> Thanh toán
                        </paper-button>
                    </div>
                </div>
            </div>
        <% } %>
        
    </article>

</asp:Content>