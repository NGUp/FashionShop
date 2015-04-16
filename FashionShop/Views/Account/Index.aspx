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
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <article class="container" ng-controller="IndexCtrl">
            
        <div class="account-container">
            <div>
                <strong>ABC</strong> - <span>namvh</span>
                <div class="core-icon-button">
                    <div>
                        <core-icon-button icon="delete" class="button-delete" ng-click="deleteAccount()"></core-icon-button>
                    </div>
                    <div>
                        <core-icon-button icon="create" class="button-update" ng-click="updateAccount()"></core-icon-button>
                    </div>
                </div>
            </div>
            <h4 class="account-name">Võ Hoài Nam</h4>
            <div>
                <span class="account-sub-info">25/04/1994</span> - <span class="account-sub-info">Saigon</span>
            </div>
        </div>
        
    </article>

</asp:Content>
