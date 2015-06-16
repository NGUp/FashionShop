<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Quản lý Loại mặt hàng
</asp:Content>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitleContent" runat="server">
	Loại mặt hàng
</asp:Content>

<asp:Content ID="Selected" ContentPlaceHolderID="SelectedContent" runat="server">1</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/category/category-add.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/category/category-add.js"></script>
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/core-field/core-field.html">
    <link rel="import" href="/bower_components/core-icon-button/core-icon-button.html">
    <link rel="import" href="/bower_components/paper-button/paper-button.html">
    <link rel="import" href="/bower_components/paper-input/paper-input.html">
    <link rel="import" href="/bower_components/paper-dialog/paper-dialog.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <article class="container" ng-controller="AddCtrl">
        <div class="content">
            <h2 class="category-title">Thêm loại mặt hàng</h2>
            <template is="auto-binding">
                <paper-input-decorator label="Mã loại" floatingLabel isInvalid="{{!$.txtID.validity.valid}}" error="Mã loại không hợp lệ.">
                    <input is="core-input" id="txtID" spellcheck="false" type="text" pattern="^[A-Z]{4,10}$">
                </paper-input-decorator>
            </template>
            <template is="auto-binding">
                <paper-input-decorator label="Tên loại" floatingLabel isInvalid="{{!$.txtName.validity.valid}}" error="Tên loại không hợp lệ.">
                    <input is="core-input" id="txtName" spellcheck="false" type="text" pattern="^([a-zA-Z ]{0,}[^\u0000-\u007F]{0,})+$">
                </paper-input-decorator>
            </template>
            <div class="div-buttons">
                <paper-button raised ng-click="cancel()">Hủy</paper-button>
                <paper-button raised class="btn-add" ng-click="add()">Thêm</paper-button>
            </div>
        </div>
        

    </article>

</asp:Content>
