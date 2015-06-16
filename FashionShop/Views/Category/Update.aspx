<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Quản lý Loại mặt hàng
</asp:Content>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitleContent" runat="server">
	Loại mặt hàng
</asp:Content>

<asp:Content ID="Selected" ContentPlaceHolderID="SelectedContent" runat="server">1</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/category/category-update.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/category/category-update.js"></script>
</asp:Content>

<asp:Content ID="WebComponents" ContentPlaceHolderID="WebComponentsContent" runat="server">
    <link rel="import" href="/bower_components/core-field/core-field.html">
    <link rel="import" href="/bower_components/core-icon-button/core-icon-button.html">
    <link rel="import" href="/bower_components/paper-button/paper-button.html">
    <link rel="import" href="/bower_components/paper-input/paper-input.html">
    <link rel="import" href="/bower_components/paper-dialog/paper-dialog.html">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <article class="container" ng-controller="UpdateCtrl">
        <div class="content">
            <h2 class="category-title">Cập nhật loại mặt hàng</h2>
            <h5 class="category-id">Mã loại hàng: <span id="category-id"><%= ViewData["ID"] %></span></h5>
            <template is="auto-binding">
                <paper-input-decorator label="Tên loại" floatingLabel isInvalid="{{!$.txtName.validity.valid}}" error="Tên loại không hợp lệ.">
                    <input is="core-input" id="txtName" spellcheck="false" type="text" value="<%= ViewData["Name"] %>" pattern="^([a-zA-Z ]{0,}[^\u0000-\u007F]{0,})+$">
                </paper-input-decorator>
            </template>
            <div class="div-buttons">
                <paper-button raised ng-click="cancel()">Hủy</paper-button>
                <paper-button raised class="btn-update" ng-click="update()">Cập nhật</paper-button>
            </div>
        </div>
        

    </article>

</asp:Content>