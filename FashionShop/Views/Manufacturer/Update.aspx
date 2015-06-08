<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
	Quản lý Nhà sản xuất
</asp:Content>

<asp:Content ID="HeaderTitle" ContentPlaceHolderID="HeaderTitleContent" runat="server">
	Quản lý Nhà sản xuất
</asp:Content>

<asp:Content ID="Selected" ContentPlaceHolderID="SelectedContent" runat="server">2</asp:Content>

<asp:Content ID="StyleSheet" ContentPlaceHolderID="StyleSheetContent" runat="server">
    <link href="/Content/css/manufacturer/manufacturer-update.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="/Content/js/manufacturer/manufacturer-update.js"></script>
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
            <h2 class="manufacturer-title">Cập nhật nhà sản xuất</h2>
            <h5 class="manufacturer-id">Mã nhà sản xuất: <span id="manufacturer-id"><%= ViewData["ID"] %></span></h5>
            <template is="auto-binding">
                <paper-input-decorator label="Tên loại" floatingLabel isInvalid="{{!$.txtName.validity.valid}}" error="Tên nhà sản xuất không hợp lệ.">
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