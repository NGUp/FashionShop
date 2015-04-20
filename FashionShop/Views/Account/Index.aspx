<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Quản lý Tài khoản
</asp:Content>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitleContent" runat="server">
	Quản lý Tài khoản
</asp:Content>

<asp:Content ID="Selected" ContentPlaceHolderID="SelectedContent" runat="server">3</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/account/account-index.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/account/account-index.js"></script>
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/core-icon-button/core-icon-button.html">
    <link rel="import" href="/bower_components/paper-button/paper-button.html">
    <link rel="import" href="/bower_components/paper-input/paper-input.html">
    <link rel="import" href="/bower_components/paper-dialog/paper-dialog.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <article class="container" ng-controller="IndexCtrl">
            
        <div class="account-container" ng-repeat="account in accounts">
            <div>
                <span ng-show="isAdmin(account.Permission)" class="account-admin" ng-class="{admin: isAdmin(account.Permission)}">Administrator</span>
                <strong>{{account.ID}}</strong> - <span>{{account.Username}}</span>
                <div class="core-icon-button">
                    <div class="account-state">
                        <img src="/Content/img/admin/state.png" alt="State" ng-class="{alive: isAlive(account.State)}" />
                    </div>
                    <div>
                        <core-icon-button icon="delete" class="button-delete" ng-click="deleteAccount(account)"></core-icon-button>
                    </div>
                    <div>
                        <core-icon-button icon="create" class="button-update" ng-click="updateAccount(account)"></core-icon-button>
                    </div>
                </div>
            </div>
            <h4 class="account-name" ng-class="{name: isAdmin(account.Permission)}">{{account.Name}}</h4>
            <div>
                <span class="account-sub-info">{{toDate(account.Birthday)}}</span> - <span class="account-sub-info">{{account.City}}</span>
            </div>
        </div>

        <div class="space">
        </div>
        
        <div class="account-paging">
            <core-icon-button icon="arrow-back" ng-click="previous()" active="false"></core-icon-button>
            <span>{{currentPage}} - {{totalPages}}</span>
            <core-icon-button icon="arrow-forward" ng-click="next()"></core-icon-button>
            <core-icon-button icon="search" ng-click="search()"></core-icon-button>
        </div>

        <paper-dialog heading="Tìm kiếm" transition="paper-dialog-transition-center">
            <div>
                <paper-input label="Mã tài khoản" floatingLabel></paper-input>
            </div>
            <div>
                <paper-input label="Tên tài khoản" floatingLabel></paper-input>
            </div>
            <core-icon-button icon="search" affirmative autofocus class="search-button"></core-icon-button>

      </paper-dialog>
    </article>

</asp:Content>
