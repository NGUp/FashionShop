<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Quản lý Nhà sản xuất
</asp:Content>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitleContent" runat="server">
	Nhà sản xuất
</asp:Content>

<asp:Content ID="Selected" ContentPlaceHolderID="SelectedContent" runat="server">2</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/manufacturer/manufacturer-index.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/manufacturer/manufacturer-index.js"></script>
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/core-field/core-field.html">
    <link rel="import" href="/bower_components/core-icon-button/core-icon-button.html">
    <link rel="import" href="/bower_components/paper-button/paper-button.html">
    <link rel="import" href="/bower_components/paper-input/paper-input.html">
    <link rel="import" href="/bower_components/paper-dialog/paper-dialog.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <article class="container" ng-controller="IndexCtrl">
        <div>
            <core-field class="search-box">
                <input placeholder="Từ khóa" autocomplete="off" spellcheck="false" name="keyword" ng-model="keyword" ng-enter="search()" flex>
                <core-icon-button icon="search" ng-click="search()"></core-icon-button>
            </core-field>
        </div>
        <ul class="manufacturers">
            <li ng-repeat="manufacturer in manufacturers">
                <div class="manufacturer">
                    <div>
                        <h5 class="manufacturer-id">{{manufacturer.Id}}</h5>
                        <h4 class="manufacturer-name">{{manufacturer.Name}}</h4>
                    </div>
                    <div class="div-buttons">
                        <core-icon-button icon="delete" class="button-delete" ng-click="deleteManufacturer(manufacturer)"></core-icon-button>
                        <core-icon-button icon="create" class="button-update" ng-click="updateManufacturer(manufacturer)"></core-icon-button>
                    </div>
                </div>
            </li>
        </ul>

        <div class="space"></div>
        
        <div class="manufacturer-paging">
            <core-icon-button icon="arrow-back" ng-click="previous()" active="false"></core-icon-button>
            <span>{{currentPage}} - {{totalPages}}</span>
            <core-icon-button icon="arrow-forward" ng-click="next()"></core-icon-button>
            <core-icon-button icon="refresh" ng-click="refresh()" ng-show="isSearching"></core-icon-button>
        </div>

        <paper-fab icon="add" ng-click="add()"></paper-fab>
    </article>

</asp:Content>