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
    <script src="/Scripts/base64.js"></script>
    <script src="/Content/js/account/account-index.js"></script>
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
            
        <div class="account-container" ng-repeat="account in accounts">
            <div>
                <span>{{account.Username}}</span>
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

        <div class="space"></div>
        
        <div class="account-paging">
            <core-icon-button icon="arrow-back" ng-click="previous()" active="false"></core-icon-button>
            <span>{{currentPage}} - {{totalPages}}</span>
            <core-icon-button icon="arrow-forward" ng-click="next()"></core-icon-button>
            <core-icon-button icon="search" ng-click="search()" ng-hide="isSearching"></core-icon-button>
            <core-icon-button icon="refresh" ng-click="refresh()" ng-show="isSearching"></core-icon-button>
        </div>

        <paper-dialog heading="Tìm kiếm" id="paper-dialog" transition="paper-dialog-transition-center">
            <template is="auto-binding">
                <paper-input-decorator label="Mã tài khoản" floatingLabel isInvalid="{{!$.txtID.validity.valid}}" error="Mã tài khoản không hợp lệ.">
                    <input is="core-input" id="txtID" spellcheck="false" type="text" pattern="^[a-z0-9]{5,50}$">
                </paper-input-decorator>
            </template>
            <template is="auto-binding">
                <paper-input-decorator label="Tên tài khoản" floatingLabel isInvalid="{{!$.txtUsername.validity.valid}}" error="Tên tài khoản không hợp lệ.">
                    <input is="core-input" id="txtUsername" spellcheck="false" type="text" pattern="^[a-zA-Z0-9_]{5,50}$">
                </paper-input-decorator>
            </template>
            <core-icon-button icon="search" affirmative autofocus class="search-button" ng-click="searchAccounts()"></core-icon-button>
        </paper-dialog>
    </article>

</asp:Content>
