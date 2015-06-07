<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat=server>
    Tìm kiếm nâng cao
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/index/index-advance.js"></script>
</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/index/index-advance.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/core-field/core-field.html">
    <link rel="import" href="/bower_components/core-icon-button/core-icon-button.html">
    <link rel="import" href="/bower_components/paper-dropdown/paper-dropdown.html">
    <link rel="import" href="/bower_components/paper-dropdown-menu/paper-dropdown-menu.html">
    <link rel="import" href="/bower_components/core-menu/core-menu.html">
    <link rel="import" href="/bower_components/paper-item/paper-item.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat=server>
    <div ng-controller="AdvanceCtrl">
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
                <h2 class="line"><span>Tìm kiếm nâng cao</span></h2>
                <div class="div-condition">
                    <div class="space">
                        <paper-dropdown-menu label="Loại mặt hàng">
                            <paper-dropdown class="dropdown">
                                <core-menu class="menu" id="category" valueattr="value">
                                    <paper-item ng-repeat="category in categories" value="{{category.ID.trim()}}">
                                        {{category.Name}}
                                    </paper-item>
                                    <paper-item value="-1">Tất cả</paper-item>
                                </core-menu>
                            </paper-dropdown>
                        </paper-dropdown-menu>
                    </div>
                    <div class="space">
                        <paper-dropdown-menu label="Giới tính">
                            <paper-dropdown class="dropdown">
                                <core-menu class="menu" id="sex" valueattr="value">
                                    <paper-item value="0">Bé gái</paper-item>
                                    <paper-item value="1">Bé trai</paper-item>
                                    <paper-item value="2">Tất cả</paper-item>
                                </core-menu>
                            </paper-dropdown>
                        </paper-dropdown-menu>
                    </div>
                    <div class="space">
                        <paper-dropdown-menu label="Giá">
                            <paper-dropdown class="dropdown">
                                <core-menu class="menu" id="price" valueattr="value">
                                    <paper-item value="0">100.000 - 300.000</paper-item>
                                    <paper-item value="1">300.000 - 500.000</paper-item>
                                    <paper-item value="2">500.000 - 1.000.000</paper-item>
                                    <paper-item value="3">Tất cả</paper-item>
                                </core-menu>
                            </paper-dropdown>
                        </paper-dropdown-menu>
                    </div>
                    <div class="space">
                        <paper-button raised class="btn-search" ng-click="searchAdvance()">Tìm kiếm</paper-button>
                    </div>
                </div>
            </div>
        </article>
        <% if (Session["USER_ID"] != null) { %>
            <paper-fab icon="shopping-cart" ng-click="goCart()" class="btn-shopping-cart"></paper-fab>
        <% } %>
    </div>
</asp:Content>